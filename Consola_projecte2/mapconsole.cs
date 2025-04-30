using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MultiCAT6.Utils;

namespace Consola_projecte2
{
    public partial class mapconsole : Form
    {
        // Control del mapa i overlay per als marcadors
        private GMapControl gmap;
        private GMapOverlay markersOverlay;
        private GMapOverlay overlayRutas = new GMapOverlay("rutas");
        private DataTable airplanesTable;

        // Variables per la simulació temporal
        private int simulationStartTime;    // Moment inicial (ex. 0)
        private int simulationEndTime;      //Moment final 
        private int simulationStep = 1;      // +1 endavant, -1 enrere
        private int currentSimulationTime;  // Temps simulat actual, de tipus int
        private int speedFactor = 1;
        private int timerInterval = 1000;      // Interval del timer en mil·lisegons (500 ms per exemple)
        private Timer simulationTimer;

        private bool isPlaying = false;

        // Diccionari per mantenir els marcadors ja creats (clau: Aircraft_ID)
        private Dictionary<string, GMarkerGoogle> aircraftMarkers = new Dictionary<string, GMarkerGoogle>();

        // Punt de referència per la conversió (per exemple, la posició del radar o centre del mapa)
        private const double radarLat = 41.2972; // latitud (ex: Barcelona)
        private const double radarLon = 2.0833;   // longitud

        public mapconsole(DataTable dt)
        {
            InitializeComponent();
            this.airplanesTable = dt;
            InitializeGMap();
            this.splitContainer1.Dock = DockStyle.Fill;
            //InitializeSimulationTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Inicialitza el control GMap.NET i configura les opcions bàsiques.
        /// </summary>
        private void InitializeGMap()
        {
            gmap = new GMapControl
            {
                Dock = DockStyle.Fill,
                MapProvider = GMapProviders.GoogleMap,  // També pots utilitzar OpenStreetMap
                Position = new PointLatLng(radarLat, radarLon), // Posició inicial (ex: el punt de referència)
                MinZoom = 1,
                MaxZoom = 20,
                Zoom = 6
            };

            // Activar doble buffering per reduir el parpelleig
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(gmap, true, null);

            GMaps.Instance.Mode = AccessMode.ServerOnly;
            //this.Controls.Add(gmap);
            splitContainer1.Panel2.Controls.Add(gmap);

            markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
            gmap.OnMarkerClick += GmapControl1_OnMarkerClick;
        }

        /// <summary>
        /// Inicialitza el Timer que simula l'evolució temporal.
        /// Aquí es converteix el primer registre de "Time of day (seconds)" de string a enter (segons).
        /// </summary>
        private void InitializeSimulationTimer()
        {
            if (airplanesTable.Rows.Count > 0 && airplanesTable.Columns.Contains("Time of day (seconds)"))
            {
                // Start format "xx:yy:zz:ttt"
                string timeString = Convert.ToString(airplanesTable.Rows[0]["Time of day (seconds)"]);
                string[] parts = timeString.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);
                int milliseconds = int.Parse(parts[3]);

                double totalSeconds = hours * 3600 + minutes * 60 + seconds + milliseconds / 1000.0;
                simulationStartTime = Convert.ToInt32(totalSeconds);
                currentSimulationTime = simulationStartTime;

                //nou
                //if (simulationTimer == null)
                //{ 
                simulationTimer = new Timer();
                //}
                //simulationTimer = new Timer();
                simulationTimer.Interval = timerInterval;
                simulationTimer.Tick += SimulationTimer_Tick;
                simulationTimer.Start();

                //end
                string timeStringend = Convert.ToString(airplanesTable.Rows[airplanesTable.Rows.Count - 1]["Time of day (seconds)"]);
                string[] partsend = timeStringend.Split(':');
                int hoursend = int.Parse(partsend[0]);
                int minutesend = int.Parse(partsend[1]);
                int secondsend = int.Parse(partsend[2]);
                int millisecondsend = int.Parse(partsend[3]);

                double totalSecondsend = hoursend * 3600 + minutesend * 60 + secondsend + millisecondsend / 1000.0;
                simulationEndTime = Convert.ToInt32(totalSecondsend);
            }
            else
            {
                simulationStartTime = 0;
                currentSimulationTime = 0;
                simulationEndTime = 0;
            }

            this.trackBar1.Minimum = simulationStartTime;
            this.trackBar1.Maximum = simulationEndTime;

            //simulationTimer = new Timer();
            //simulationTimer.Interval = timerInterval;
            ////simulationTimer.Tick += SimulationTimer_Tick;
            //simulationTimer.Stop();
        }

        /// <summary>
        /// Funció auxiliar per extreure el temps en segons a partir del camp "Time of day (seconds)" d'una fila.
        /// </summary>
        private int ParseTime(DataRow row)
        {
            string timeString = Convert.ToString(row["Time of day (seconds)"]);
            string[] parts = timeString.Split(':');
            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            int seconds = int.Parse(parts[2]);
            int milliseconds = int.Parse(parts[3]);

            double totalSeconds = hours * 3600 + minutes * 60 + seconds + milliseconds / 1000.0;
            return Convert.ToInt32(totalSeconds);
        }

        /// <summary>
        /// Cada tick del Timer actualitza el temps simulat i actualitza la posició dels marcadors.
        /// Aquesta versió actualitza els marcadors existents o en afegeix de nous, sense esborrar-los completament.
        /// Aplica la conversió de coordenades polars a geogràfiques.
        /// </summary>
        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                return;
            }
            // Incrementem el temps simulat
            currentSimulationTime += simulationStep;
            TimeSpan t = TimeSpan.FromSeconds(currentSimulationTime);
            string hhmmss = t.ToString(@"hh\:mm\:ss");
            temps.Text = hhmmss;


            if (currentSimulationTime < simulationStartTime || currentSimulationTime > simulationEndTime)
            {
                simulationTimer.Stop();
                isPlaying = false;
                return;
            }

            //UpdateMarkersForTime(currentSimulationTime);
            //trackBar1.Value = currentSimulationTime;
            //gmap.Refresh();

            // Iterem cada fila del DataTable
            if (isPlaying == true)
            {
                foreach (DataRow row in airplanesTable.Rows)
                {
                    if (row["Time of day (seconds)"] != DBNull.Value)
                    {
                        int recordTime = ParseTime(row);

                        // Si aquest registre correspon al temps simulat actual...
                        if (recordTime == currentSimulationTime)
                        {
                            string id = Convert.ToString(row["Aircraft_ID"]);

                            if (id != "")
                            {

                                double lat = row["latitud"] != DBNull.Value ? Convert.ToDouble(row["latitud"]) : 0;
                                double lng = row["longitud"] != DBNull.Value ? Convert.ToDouble(row["longitud"]) : 0;

                                //// Altres dades (velocitat i altitud)
                                double speed = row["Mach"] != DBNull.Value ? Convert.ToDouble(row["Mach"]) : 0;
                                double altitude = row["Flight Level"] != DBNull.Value ? Convert.ToDouble(row["Flight Level"]) : 0;

                                // La nova posició calculada
                                PointLatLng newPosition = new PointLatLng(lat, lng);

                                // Si ja existeix un marcador per aquest avió, el mourem; si no, en creem un nou.
                                if (aircraftMarkers.ContainsKey(id))
                                {
                                    aircraftMarkers[id].Position = newPosition;
                                    aircraftMarkers[id].ToolTipText = $"Avió ID: {id}\nVelocitat: M{speed}\nAltitud: FL{altitude}";
                                    if (id == idselectermarker1)
                                    {
                                        selectedMarker1.Position = newPosition;
                                        heightselectermarker1 = row["hwgs84"] != DBNull.Value ? Convert.ToDouble(row["hwgs84"]) : 0; 

                                    }
                                    if (id == idselectermarker2)
                                    {
                                        selectedMarker2.Position = newPosition;
                                        heightselectermarker2 = row["hwgs84"] != DBNull.Value ? Convert.ToDouble(row["hwgs84"]) : 0;
                                    }


                                }
                                else
                                {
                                    GMarkerGoogle marker = new GMarkerGoogle(newPosition, GMarkerGoogleType.blue_dot);
                                    marker.ToolTipText = $"Avió ID: {id}\nVelocitat: M{speed}\nAltitud: FL{altitude}";
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                    aircraftMarkers.Add(id, marker);
                                    markersOverlay.Markers.Add(marker);
                                }
                            }
                        }
                    }
                }
                //Calcul de distancies
                if (selectedMarker1 != null & selectedMarker2 != null & heightselectermarker1 != -1000 & heightselectermarker2 != -1000)
                {
                    double lat1 = selectedMarker1.Position.Lat;
                    double lon1 = selectedMarker1.Position.Lng;
                    double lat2 = selectedMarker2.Position.Lat;
                    double lon2 = selectedMarker2.Position.Lng;
                    
                    (double U1, double V1) = change_geodesic2stereographic(lat1, lon1, heightselectermarker1);
                    (double U2, double V2) = change_geodesic2stereographic(lat2, lon2, heightselectermarker2);

                    double distancia = Math.Sqrt(Math.Pow(U2 - U1, 2) + Math.Pow(V2 - V1, 2))/ 1852;
                    label1.Text = $"The stereographic distance between the aircrafts is: {distancia:F2} NM";

                    //linea
                    overlayRutas.Routes.Clear();
                    List<PointLatLng> puntos = new List<PointLatLng> { selectedMarker1.Position, selectedMarker2.Position };
                    GMapRoute ruta = new GMapRoute(puntos, "LineaEntreMarcadores") { Stroke = new Pen(Color.Red, 2) };
                    overlayRutas.Routes.Add(ruta);
                    gmap.Overlays.Add(overlayRutas);
                }

                // Refresquem el mapa per veure els canvis.
                gmap.Refresh();
                trackBar1.Value = currentSimulationTime;



                // Opcional: Comprovem si el temps simulat ha superat l'últim registre per aturar o reiniciar la simulació.
                simulationEndTime = simulationStartTime;
                if (airplanesTable.Rows.Count > 0 && airplanesTable.Columns.Contains("Time of day (seconds)"))
                {
                    string timeStringEnd = Convert.ToString(airplanesTable.Rows[airplanesTable.Rows.Count - 1]["Time of day (seconds)"]);
                    string[] parts = timeStringEnd.Split(':');
                    int hours = int.Parse(parts[0]);
                    int minutes = int.Parse(parts[1]);
                    int seconds = int.Parse(parts[2]);
                    int milliseconds = int.Parse(parts[3]);
                    double totalSecondsEnd = hours * 3600 + minutes * 60 + seconds + milliseconds / 1000.0;
                    simulationEndTime = Convert.ToInt32(totalSecondsEnd);
                    if (currentSimulationTime > simulationEndTime)
                    {
                        simulationTimer.Stop();
                        // O reinicia la simulació:
                        // currentSimulationTime = simulationStartTime;
                    }
                }
            }
        }

        private void UpdateMarkersForTime(int time)
        {
            if (isPlaying == true)
            {
                foreach (DataRow row in airplanesTable.Rows)
                {
                    // Comprovem que la fila tingui un temps vàlid
                    if (row["Time of day (seconds)"] == DBNull.Value)
                        continue;

                    int recordTime = ParseTime(row);
                    if (recordTime != time)
                        continue;

                    // Extraiem l'ID de l'avió
                    string id = Convert.ToString(row["Aircraft_ID"]);
                    if (string.IsNullOrEmpty(id))
                        continue;

                    // Latiud i longitud (o 0 si no hi ha dada)
                    double lat = row.Table.Columns.Contains("latitud") && row["latitud"] != DBNull.Value
                        ? Convert.ToDouble(row["latitud"])
                        : 0;
                    double lng = row.Table.Columns.Contains("longitud") && row["longitud"] != DBNull.Value
                        ? Convert.ToDouble(row["longitud"])
                        : 0;

                    // Altres dades pel tooltip
                    double speed = row.Table.Columns.Contains("Mach") && row["Mach"] != DBNull.Value
                        ? Convert.ToDouble(row["Mach"])
                        : 0;
                    double altitude = row.Table.Columns.Contains("Flight Level") && row["Flight Level"] != DBNull.Value
                        ? Convert.ToDouble(row["Flight Level"])
                        : 0;

                    var newPosition = new PointLatLng(lat, lng);

                    if (aircraftMarkers.TryGetValue(id, out var existingMarker))
                    {
                        // Si ja existia, només actualitzem la posició i text
                        existingMarker.Position = newPosition;
                        existingMarker.ToolTipText =
                            $"Avió ID: {id}\nVelocitat: M{speed}\nAltitud: FL{altitude}";
                    }
                    else
                    {
                        // Si no existia, creem un nou marcador
                        var marker = new GMarkerGoogle(newPosition, GMarkerGoogleType.blue_dot)
                        {
                            ToolTipText = $"Avió ID: {id}\nVelocitat: M{speed}\nAltitud: FL{altitude}",
                            ToolTipMode = MarkerTooltipMode.OnMouseOver
                        };
                        aircraftMarkers[id] = marker;
                        markersOverlay.Markers.Add(marker);
                    }
                }
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            //isPlaying = true;
            //simulationStep = +1;
            //simulationTimer.Start();
            if (currentSimulationTime > simulationStartTime)
            {
                //gmap.Refresh();
                isPlaying = true;
                simulationStep = 1;
                simulationTimer.Start();
            }
            else
            {
                isPlaying = true;
                InitializeSimulationTimer();
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            isPlaying = false;
            simulationTimer.Stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) //no funciona al 100 per 1000
        {
            currentSimulationTime = trackBar1.Value;
            markersOverlay.Markers.Clear();
            aircraftMarkers.Clear();
            UpdateMarkersForTime(currentSimulationTime);
            gmap.Refresh();

            if (isPlaying)
            {
                simulationTimer.Start();
            }
            else
            {
                simulationTimer.Stop();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            currentSimulationTime = simulationStartTime;
            trackBar1.Value = currentSimulationTime;
            markersOverlay.Markers.Clear();
            aircraftMarkers.Clear();
            simulationStep = 1;
            simulationTimer.Dispose();
            simulationTimer = null;
            InitializeSimulationTimer();
            //UpdateMarkersForTime(currentSimulationTime);
            gmap.Refresh();
            //simulationTimer.Stop();

            idselectermarker1 = "";
            idselectermarker2 = "";
            markersOverlay.Markers.Remove(selectedMarker1);
            markersOverlay.Markers.Remove(selectedMarker2);
            selectedMarker1 = null;
            selectedMarker2 = null;
            overlayRutas.Routes.Clear();
            label1.Text = "Select two aircrafts";
            heightselectermarker1 = -1000;
            heightselectermarker2 = -1000;

        }

        private void reverse_Click(object sender, EventArgs e)
        {
            //gmap.Refresh();
            isPlaying = true;
            simulationStep = -1;
            simulationTimer.Start();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void temps_Click(object sender, EventArgs e)
        {

        }

        private void accelerar_Click(object sender, EventArgs e)
        {
            if (speedFactor < 512)
            {
                speedFactor = speedFactor * 2;
                simulationTimer.Interval = timerInterval / speedFactor;
                string f = velocitat.Text;
                string numPart = f.Substring(1);
                int vel = int.Parse(numPart);
                string speed = Convert.ToString(vel * 2);
                velocitat.Text = $"x{speedFactor}";
            }
        }

        private void reduir_Click(object sender, EventArgs e)
        {
            if (speedFactor > 1)
            {
                speedFactor = speedFactor / 2;
                simulationTimer.Interval = timerInterval / speedFactor;
                string s = velocitat.Text;
                string numPart = s.Substring(1);
                int vel = int.Parse(numPart);
                string speed = Convert.ToString(vel / 2);
                velocitat.Text = $"x{speedFactor}";
            }
        }

        private GMapMarker selectedMarker1 = null;
        private GMapMarker selectedMarker2 = null;
        private string idselectermarker1 = "";
        private string idselectermarker2 = "";
        private double heightselectermarker1 = -1000;
        private double heightselectermarker2 = -1000;

        private void GmapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (selectedMarker1 == null)
            {
                idselectermarker1 = aircraftMarkers.FirstOrDefault(kv => kv.Value == item).Key;
                PointLatLng position = item.Position;
                selectedMarker1 = new GMarkerGoogle(position, GMarkerGoogleType.red_dot);
                markersOverlay.Markers.Add(selectedMarker1);

                //MessageBox.Show("Primer marcador seleccionado: " + item.ToolTipText);
            }
            else if (selectedMarker2 == null)
            {
                idselectermarker2 = aircraftMarkers.FirstOrDefault(kv => kv.Value == item).Key;
                PointLatLng position = item.Position;
                selectedMarker2 = new GMarkerGoogle(position, GMarkerGoogleType.red_dot);
                markersOverlay.Markers.Add(selectedMarker2);

                //MessageBox.Show("Segundo marcador seleccionado: " + item.ToolTipText);
            }
            else
            {
                // Si ya hay dos seleccionados, puedes resetear o preguntar si quieres cambiar
                MessageBox.Show("There are already two selected aircraft. Reseting selection.");
                idselectermarker1 = "";
                idselectermarker2 = "";
                markersOverlay.Markers.Remove(selectedMarker1);
                markersOverlay.Markers.Remove(selectedMarker2);
                selectedMarker1 = null;
                selectedMarker2 = null;
                overlayRutas.Routes.Clear();
                label1.Text = "Select two aircrafts";
                heightselectermarker1 = -1000;
                heightselectermarker2 = -1000;
            }
        }
        public (double, double) change_geodesic2stereographic(double lat, double lon, double h)
        {
            lat = lat * Math.PI / 180;
            lon = lon * Math.PI / 180;
            GeoUtils utils = new GeoUtils();
            CoordinatesWGS84 geode = new CoordinatesWGS84(lat, lon, h);
            CoordinatesXYZ geocen = utils.change_geodesic2geocentric(geode);

            double LatTMA = (41 + (06.0 / 60.0) + (56.560 / 3600.0)) * Math.PI / 180;
            double LonTMA = (1 + (41.0 / 60.0) + (33.010 / 3600.0)) * Math.PI / 180;
            double hTMA = 0;
            CoordinatesWGS84 TMA = new CoordinatesWGS84(LatTMA, LonTMA, hTMA);
            utils.setCenterProjection(TMA);

            CoordinatesXYZ cartesian = utils.change_geocentric2system_cartesian(geocen);
            CoordinatesUVH stereographic = utils.change_system_cartesian2stereographic(cartesian);
            double U = stereographic.U;
            double V = stereographic.V;
            return (U, V);
        }
    }
}

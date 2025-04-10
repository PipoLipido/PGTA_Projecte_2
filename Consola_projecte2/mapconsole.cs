using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Consola_projecte2
{
    public partial class mapconsole : Form
    {
        // Control del mapa i overlay per als marcadors
        private GMapControl gmap;
        private GMapOverlay markersOverlay;
        private DataTable airplanesTable;

        // Variables per la simulació temporal
        private int simulationStartTime;    // Moment inicial (ex. 0)
        private int currentSimulationTime;  // Temps simulat actual, de tipus int
        private int timerInterval = 200;      // Interval del timer en mil·lisegons (500 ms per exemple)
        private Timer simulationTimer;

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
            InitializeSimulationTimer();
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
            this.Controls.Add(gmap);

            markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
        }

        /// <summary>
        /// Inicialitza el Timer que simula l'evolució temporal.
        /// Aquí es converteix el primer registre de "Time of day (seconds)" de string a enter (segons).
        /// </summary>
        private void InitializeSimulationTimer()
        {
            if (airplanesTable.Rows.Count > 0 && airplanesTable.Columns.Contains("Time of day (seconds)"))
            {
                // Exemple: el primer registre té el temps en format "xx:yy:zz:ttt"
                string timeString = Convert.ToString(airplanesTable.Rows[0]["Time of day (seconds)"]);
                string[] parts = timeString.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);
                int milliseconds = int.Parse(parts[3]);

                double totalSeconds = hours * 3600 + minutes * 60 + seconds + milliseconds / 1000.0;
                simulationStartTime = Convert.ToInt32(totalSeconds);
                currentSimulationTime = simulationStartTime;
            }
            else
            {
                simulationStartTime = 0;
                currentSimulationTime = 0;
            }

            simulationTimer = new Timer();
            simulationTimer.Interval = timerInterval;
            simulationTimer.Tick += SimulationTimer_Tick;
            simulationTimer.Start();
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
            // Incrementem el temps simulat
            currentSimulationTime++;

            // Iterem cada fila del DataTable
            foreach (DataRow row in airplanesTable.Rows)
            {
                if (row["Time of day (seconds)"] != DBNull.Value)
                {
                    int recordTime = ParseTime(row);

                    // Si aquest registre correspon al temps simulat actual...
                    if (recordTime == currentSimulationTime)
                    {
                        string id = Convert.ToString(row["Aircraft_ID"]);

                        // Aconseguim els valors polars
                        double rho = row["Rho (Nautical Miles)"] != DBNull.Value ? Convert.ToDouble(row["Rho (Nautical Miles)"]) : 0;
                        double theta = row["Theta (degrees)"] != DBNull.Value ? Convert.ToDouble(row["Theta (degrees)"]) : 0;

                        // Convertim l'angle de graus a radians.
                        double thetaRad = theta * Math.PI / 180.0;

                        // Calcular la variació en latitud i longitud.
                        // 1 grau de latitud ≈ 60 milles nàutiques.
                        double deltaLat = (rho * Math.Cos(thetaRad)) / 60.0;
                        double deltaLon = (rho * Math.Sin(thetaRad)) / (60.0 * Math.Cos(radarLat * Math.PI / 180.0));

                        // La nova latitud i longitud
                        double lat = radarLat + deltaLat;
                        double lng = radarLon + deltaLon;

                        // Altres dades (velocitat i altitud)
                        double speed = row["Mach"] != DBNull.Value ? Convert.ToDouble(row["Mach"]) : 0;
                        double altitude = row["Flight Level"] != DBNull.Value ? Convert.ToDouble(row["Flight Level"]) : 0;

                        // La nova posició calculada
                        PointLatLng newPosition = new PointLatLng(lat, lng);

                        // Si ja existeix un marcador per aquest avió, el mourem; si no, en creem un nou.
                        if (aircraftMarkers.ContainsKey(id))
                        {
                            aircraftMarkers[id].Position = newPosition;
                        }
                        else
                        {
                            GMarkerGoogle marker = new GMarkerGoogle(newPosition, GMarkerGoogleType.blue_dot);
                            marker.ToolTipText = $"Avió ID: {id}\nVelocitat: M{speed}\nAltitud: FL{altitude}\nTemps: {recordTime}";
                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            aircraftMarkers.Add(id, marker);
                            markersOverlay.Markers.Add(marker);
                        }
                    }
                }
            }

            // Refresquem el mapa per veure els canvis.
            gmap.Refresh();

            // Opcional: Comprovem si el temps simulat ha superat l'últim registre per aturar o reiniciar la simulació.
            int simulationEndTime = simulationStartTime;
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
}

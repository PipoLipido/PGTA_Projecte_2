using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTdecoder
{
    public class CAT
    {
        public DataTable dt { get; set; }
        //FSPEC
        public int fspeclength { get; set; }
        public int DSI { get; set; }
        public int lenght { get; set; }

        //1048/010  Data Source Identifier

        public string SAC { get; set; }
        public string SIC { get; set; }

        //1048/020  Target Report Descriptor
        public string TYP { get; set; }
        public string SIM { get; set; }
        public string RDP { get; set; }
        public string SPI { get; set; }
        public string RAB { get; set; }
        public string TST { get; set; }
        public string ERR { get; set; }
        public string XPP { get; set; }
        public string ME { get; set; }
        public string MI { get; set; }
        public string FOE_FRI { get; set; }
        public string ADSB { get; set; }
        public string ADSB_EP { get; set; }
        public string ADSB_VAL { get; set; }
        public string SCN { get; set; }
        public string SCN_EP { get; set; }
        public string SCN_VAL { get; set; }
        public string PAI { get; set; }
        public string PAI_EP { get; set; }
        public string PAI_VAL { get; set; }


        //1048/040  Measured Position in Slant Polar Co-ordinates
        public string R { get; set; }
        public string ANGL { get; set; }

        //1048/042  Calculated Position in Cartesian Co-ordinates

        public string X { get; set; }
        public string Y { get; set; }

        //1048/070  Mode-3/A Code in Octal Representation

        public string V { get; set; }
        public string G { get; set; }
        public string L { get; set; }

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        //1048/090  Flight Level in Binary Representation
        public string V_FL { get; set; }
        public string G_FL { get; set; }
        public string FL { get; set; }

        //1048/110  Height Measured by a 3D Radar
        public string H { get; set; }

        //1048/130  Radar Plot Characteristics
        public string SRL { get; set; }
        public string SRR { get; set; }
        public string SAM { get; set; }
        public string PRL { get; set; }
        public string PAM { get; set; }
        public string RPD { get; set; }
        public string APD { get; set; }

        //1048/140  Time of Day
        public string hour_of_day { get; set; } //UTC
        public string seconds { get; set; }

        //1048/161  Track/Plot Number
        public string TRCK_NMBR { get; set; }

        //1048/170  Track Status
        public string CNF { get; set; }
        public string RAD { get; set; }
        public string DOU { get; set; }
        public string MAH { get; set; }
        public string CDM { get; set; }
        public string TRE { get; set; }
        public string GHO { get; set; }
        public string SUP { get; set; }
        public string TCC { get; set; }

        //1048/200  Calculated Track Velocity in Polar Representation
        public string TRCK_VEL_R { get; set; }
        public string TRCK_VEL_ANGL { get; set; }

        //1048/220  Aircraft Address
        public string ADRESS { get; set; }

        //1048/230  Communications / ACAS Capability and Flight Status
        public string COM { get; set; }
        public string STAT { get; set; }
        public string SI { get; set; }
        public string MSSC { get; set; }
        public string ARC { get; set; }
        public string AIC { get; set; }
        public string B1A { get; set; }
        public string B1B { get; set; }

        //1048/240  Aircraft Identification
        public string ID { get; set; }

        //1048/250  Mode S MB Data
        public string BDSDATA { get; set; }
        public string BDS1 { get; set; }
        public string BDS2 { get; set; }

    }


    public class AsterixDecoder
    {
        public static List<CAT> ParseAsterixCat48(byte[] data)
        {
            // Creem el DataTable amb la mateixa estructura que l'original
            DataTable TaulaMain = CreateSchema();

            // 1. Preprocessar: identificar els segments (missatges) al vector
            List<(int Order, int StartIndex, int Length)> segments = new List<(int, int, int)>();

            int indexByte = 0;
            int orderCounter = 0;
            while (indexByte < data.Length)
            {
                // Si el byte no és 48 (categoria 48) saltem un byte
                if (data[indexByte] != 48)
                {
                    indexByte++;
                    continue;
                }
                // Calculem la longitud del missatge
                int messageLength = (data[indexByte + 1] << 8) | data[indexByte + 2];
                segments.Add((orderCounter, indexByte, messageLength));
                orderCounter++;
                indexByte += messageLength;
            }

            // 2. Processar els segments en paral·lel.
            // Utilitzem un ConcurrentDictionary per recollir el resultat, indexat per l'ordre del missatge
            var resultRows = new ConcurrentDictionary<int, Dictionary<string, object>>();

            Parallel.ForEach(segments, segment =>
            {
                Dictionary<string, object> rowData = ProcessMessage(data, segment.StartIndex, segment.Length, TaulaMain);
                resultRows[segment.Order] = rowData;
            });



            // 3. Ordenem els resultats i omplim el DataTable
            foreach (var key in resultRows.Keys.OrderBy(k => k))
            {
                DataRow row = TaulaMain.NewRow();
                foreach (var kvp in resultRows[key])
                {
                    if (TaulaMain.Columns.Contains(kvp.Key))
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                }
                TaulaMain.Rows.Add(row);
            }

            for (int i = 0; i < TaulaMain.Rows.Count; i++)
            {
                TaulaMain.Rows[i]["Index"] = i + 1; // o "i" si vols començar a 0
            }


            // Creem l'objecte CAT amb el DataTable resultat
            CAT record = new CAT();
          
            TaulaMain = I048_data_items.data_items.Corrected_Altitude(TaulaMain);
            TaulaMain = I048_data_items.data_items.LatLong(TaulaMain);

            record.dt = TaulaMain;

            return new List<CAT> { record };
        }

        // Mètode per processar individualment cada missatge (segment)
        private static Dictionary<string, object> ProcessMessage(byte[] data, int start, int length, DataTable schema)
        {
            Dictionary<string, object> rowData = new Dictionary<string, object>();
            int octetanalyzed = start;

            // Llegim el header bàsic
            int dsi = data[start];
            if (schema.Columns.Contains("DSI"))
                rowData["DSI"] = dsi;

            int recordLength = (data[start + 1] << 8) | data[start + 2];
            if (schema.Columns.Contains("lenght"))
                rowData["lenght"] = recordLength;

            // Processar el camp FSPEC: determinació de quants bytes ocupa
            int fspecStart = start + 3;
            int lastFspecByte = 0;
            bool indexFound = false;
            List<string> fspec = new List<string>();

            while (!indexFound)
            {
                int currentByte = data[fspecStart + lastFspecByte];
                int ultimBit = currentByte % 2;
                if (ultimBit == 0)
                    indexFound = true;
                fspec.Add(Convert.ToString(currentByte, 2).PadLeft(8, '0'));
                lastFspecByte++;
            }
            int fspecLength = lastFspecByte;

            // Ajustem el byte d'anàlisi després del header i el FSPEC
            octetanalyzed = start + 3 + fspecLength;

            // Processar el doble bucle FSPEC per extreure les dades de cada component
            // NOTA: La seqüència és important perquè es suma l'ocupació en octets de cada data item (variable 'octetanalyzed')
            var schemaColumnNames = new HashSet<string>(schema.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            for (int fspecAnalyzedByte = 0; fspecAnalyzedByte < fspecLength; fspecAnalyzedByte++)
            {
                for (int fspecAnalyzedBit = 0; fspecAnalyzedBit < 7; fspecAnalyzedBit++)
                {
                    if (fspec[fspecAnalyzedByte].Substring(fspecAnalyzedBit, 1) != "0")
                    {
                        // Aquest mètode s'encarrega d'extreure l'item pertinent;
                        // se li passa la posició del bit, el byte de l'fspec, el vector de dades, la longitud del fspec i la posició actual.
                        //var resultDataItem = I048_data_items.data_items.GetDataItem(fspecAnalyzedBit, fspecAnalyzedByte, data, fspecLength, octetanalyzed);
                        var resultDataItem = I048_data_items.data_items.GetDataItem(fspecAnalyzedBit, fspecAnalyzedByte, data, fspecLength, octetanalyzed);
                        // resultDataItem.Item3 conté la quantitat d'octets consumits per aquest item
                        octetanalyzed += resultDataItem.Item3;

                        // S'iterarà pel DataTable retornat per GetDataItem i s'incorporen els valors a rowData
                        foreach (DataRow fila in resultDataItem.Item4.Rows)
                        {
                            foreach (DataColumn col in resultDataItem.Item4.Columns)
                            {
                                //schema.Columns.Contains(col.ColumnName)
                                if (schemaColumnNames.Contains(col.ColumnName))
                                {
                                    rowData[col.ColumnName] = fila[col.ColumnName];
                                }
                            }
                        }
                    }
                }
            }
            return rowData;
        }

        // Mètode auxiliar per crear la definició del DataTable (la mateixa estructura que el codi original)
        private static DataTable CreateSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(int));
            dt.Columns.Add("SAC", typeof(int));
            dt.Columns.Add("SIC", typeof(int));
            dt.Columns.Add("Time of day (seconds)", typeof(string));
            dt.Columns.Add("latitud", typeof(string));
            dt.Columns.Add("longitud", typeof(string));
            dt.Columns.Add("hwgs84", typeof(string));
            dt.Columns.Add("Corrected Altitude", typeof(string));
            dt.Columns.Add("TYP", typeof(string));
            dt.Columns.Add("SIM", typeof(string));
            dt.Columns.Add("RDP", typeof(string));
            dt.Columns.Add("SPI", typeof(string));
            dt.Columns.Add("RAB", typeof(string));
            dt.Columns.Add("TST", typeof(string));
            dt.Columns.Add("ERR", typeof(string));
            dt.Columns.Add("XPP", typeof(string));
            dt.Columns.Add("ME", typeof(string));
            dt.Columns.Add("MI", typeof(string));
            dt.Columns.Add("FOE_FRI", typeof(string));

            //dt.Columns.Add("ADSB_EP", typeof(string));
            //dt.Columns.Add("ADSB_VAL", typeof(string));
            //dt.Columns.Add("SCN_EP", typeof(string));
            //dt.Columns.Add("SCN_VAL", typeof(string));
            //dt.Columns.Add("PAI_EP", typeof(string));
            //dt.Columns.Add("PAI_VAL", typeof(string));

            dt.Columns.Add("Rho", typeof(double));
            dt.Columns.Add("Theta", typeof(double));
            dt.Columns.Add("V", typeof(string));
            dt.Columns.Add("G", typeof(string));
            dt.Columns.Add("L", typeof(string));
            dt.Columns.Add("Mode3A", typeof(string));
            dt.Columns.Add("V_fl", typeof(string));
            dt.Columns.Add("G_fl", typeof(string));
            dt.Columns.Add("Flight Level", typeof(double));
            //Mode C corrected
            dt.Columns.Add("SRL", typeof(double));
            dt.Columns.Add("SRR", typeof(int));
            dt.Columns.Add("SAM", typeof(double));
            dt.Columns.Add("PRL", typeof(double));
            dt.Columns.Add("PAM", typeof(double));
            dt.Columns.Add("RPD", typeof(double));
            dt.Columns.Add("APD", typeof(double));
            dt.Columns.Add("Aircraft Address", typeof(string));
            dt.Columns.Add("Aircraft_ID", typeof(string));
            //MODE S
            dt.Columns.Add("SelectedAltitude_Status", typeof(string));
            dt.Columns.Add("SelectedAltitude", typeof(int));
            dt.Columns.Add("FMSAltitude_Status", typeof(string));
            dt.Columns.Add("FMSAltitude", typeof(int));
            dt.Columns.Add("BaroSetting_Status", typeof(string));
            dt.Columns.Add("BaroSetting", typeof(double));
            dt.Columns.Add("MCP_FCU_MODE_BITS_Status", typeof(string));
            dt.Columns.Add("VNAV", typeof(string));
            dt.Columns.Add("AltHoldMode", typeof(string));
            dt.Columns.Add("ApprMode", typeof(string));
            dt.Columns.Add("TargetAltitudeSource_Status", typeof(string));
            dt.Columns.Add("TargetAltitudeSource", typeof(string));
            dt.Columns.Add("LWingD", typeof(string)); //no apareix
            dt.Columns.Add("RollAngle_Status", typeof(string));
            dt.Columns.Add("RollAngle", typeof(double));
            dt.Columns.Add("TrueTrackAngle_Status", typeof(string));
            dt.Columns.Add("TrueTrackAngle", typeof(double));
            dt.Columns.Add("GS_Status", typeof(string));
            dt.Columns.Add("GS", typeof(double));
            dt.Columns.Add("TrackAngleRate_Status", typeof(string));
            dt.Columns.Add("TrackAngleRate", typeof(double));
            dt.Columns.Add("TAS_Status", typeof(string));
            dt.Columns.Add("TAS", typeof(double));
            dt.Columns.Add("MagneticHeading_Status", typeof(string));
            dt.Columns.Add("MagneticHeading", typeof(double));
            dt.Columns.Add("IndicatedAirspeed_Status", typeof(string));
            dt.Columns.Add("IndicatedAirspeed", typeof(double));
            dt.Columns.Add("Mach_Status", typeof(string));
            dt.Columns.Add("Mach", typeof(double));
            dt.Columns.Add("BaromAltRate_Status", typeof(string));
            dt.Columns.Add("BaromAltRate", typeof(double));
            dt.Columns.Add("Below", typeof(string)); // no apareix
            dt.Columns.Add("InertialVertVel_Status", typeof(string));
            dt.Columns.Add("InertialVertVel", typeof(double));

            dt.Columns.Add("TrackNumber", typeof(int));
            dt.Columns.Add("X coordinate", typeof(int));
            dt.Columns.Add("Y coordinate", typeof(int));
            dt.Columns.Add("Ground Speed", typeof(double));
            dt.Columns.Add("Heading", typeof(double));

            dt.Columns.Add("CNF", typeof(string));
            dt.Columns.Add("RAD", typeof(string));
            dt.Columns.Add("DOU", typeof(string));
            dt.Columns.Add("MAH", typeof(string));
            dt.Columns.Add("CDM", typeof(string));
            dt.Columns.Add("TRE", typeof(string));
            dt.Columns.Add("GHO", typeof(string));
            dt.Columns.Add("SUP", typeof(string));
            dt.Columns.Add("TCC", typeof(string));

            dt.Columns.Add("3D Radar Height", typeof(int));
            dt.Columns.Add("COM", typeof(string));
            dt.Columns.Add("STAT", typeof(string));
            dt.Columns.Add("SI", typeof(string));
            dt.Columns.Add("MSCC", typeof(string));
            dt.Columns.Add("ARC", typeof(string));
            dt.Columns.Add("AIC", typeof(string));
            dt.Columns.Add("B1A", typeof(string));
            dt.Columns.Add("B1B", typeof(string));

            return dt;
        }
    }

}


        

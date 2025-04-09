using System;
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
            int missatgeAnalitzat = 1;
            List<CAT> results = new List<CAT>();

            
            DataTable TaulaMain = new DataTable();
            TaulaMain.Columns.Add("SAC", typeof(int));
            TaulaMain.Columns.Add("SIC", typeof(int));
            TaulaMain.Columns.Add("Time of day (seconds)", typeof(string));
            TaulaMain.Columns.Add("TYP", typeof(string));
            TaulaMain.Columns.Add("SIM", typeof(string));
            TaulaMain.Columns.Add("RDP", typeof(string));
            TaulaMain.Columns.Add("SPI", typeof(string));
            TaulaMain.Columns.Add("RAB", typeof(string));
            TaulaMain.Columns.Add("TST", typeof(string));
            TaulaMain.Columns.Add("ERR", typeof(string));
            TaulaMain.Columns.Add("XPP", typeof(string));
            TaulaMain.Columns.Add("ME", typeof(string));
            TaulaMain.Columns.Add("MI", typeof(string));
            TaulaMain.Columns.Add("FOE_FRI", typeof(string));
            TaulaMain.Columns.Add("ADSB_EP", typeof(string));
            TaulaMain.Columns.Add("ADSB_VAL", typeof(string));
            TaulaMain.Columns.Add("SCN_EP", typeof(string));
            TaulaMain.Columns.Add("SCN_VAL", typeof(string));
            TaulaMain.Columns.Add("PAI_EP", typeof(string));
            TaulaMain.Columns.Add("PAI_VAL", typeof(string));
            TaulaMain.Columns.Add("Rho (Nautical Miles)", typeof(double));
            TaulaMain.Columns.Add("Theta (degrees)", typeof(double));
            TaulaMain.Columns.Add("X coordinate", typeof(int));
            TaulaMain.Columns.Add("Y coordinate", typeof(int));
            TaulaMain.Columns.Add("V", typeof(string));
            TaulaMain.Columns.Add("G", typeof(string));
            TaulaMain.Columns.Add("L", typeof(string));
            TaulaMain.Columns.Add("Mode3A", typeof(string));
            TaulaMain.Columns.Add("V_fl", typeof(string));
            TaulaMain.Columns.Add("G_fl", typeof(string));
            TaulaMain.Columns.Add("Flight Level", typeof(double));
            TaulaMain.Columns.Add("SRL", typeof(double));
            TaulaMain.Columns.Add("SRR", typeof(int));
            TaulaMain.Columns.Add("SAM", typeof(double));
            TaulaMain.Columns.Add("PRL", typeof(double));
            TaulaMain.Columns.Add("PAM", typeof(double));
            TaulaMain.Columns.Add("RPD", typeof(double));
            TaulaMain.Columns.Add("APD", typeof(double));
            TaulaMain.Columns.Add("Aircraft_ID", typeof(string));
            TaulaMain.Columns.Add("SelectedAltitude_Status", typeof(string));
            TaulaMain.Columns.Add("SelectedAltitude", typeof(int));
            TaulaMain.Columns.Add("FMSAltitude_Status", typeof(string));
            TaulaMain.Columns.Add("FMSAltitude", typeof(int));
            TaulaMain.Columns.Add("BaroSetting_Status", typeof(string));
            TaulaMain.Columns.Add("BaroSetting", typeof(double));
            TaulaMain.Columns.Add("MCP_FCU_MODE_BITS_Status", typeof(string));
            TaulaMain.Columns.Add("VNAV", typeof(string));
            TaulaMain.Columns.Add("AltHoldMode", typeof(string));
            TaulaMain.Columns.Add("ApprMode", typeof(string));
            TaulaMain.Columns.Add("TargetAltitudeSource_Status", typeof(string));
            TaulaMain.Columns.Add("TargetAltitudeSource", typeof(string));
            TaulaMain.Columns.Add("LWingD", typeof(string));
            TaulaMain.Columns.Add("RollAngle_Status", typeof(string));
            TaulaMain.Columns.Add("RollAngle", typeof(double));
            TaulaMain.Columns.Add("TrueTrackAngle_Status", typeof(string));
            TaulaMain.Columns.Add("TrueTrackAngle", typeof(double));
            TaulaMain.Columns.Add("GS_Status", typeof(string));
            TaulaMain.Columns.Add("GS", typeof(double));
            TaulaMain.Columns.Add("TrackAngleRate_Status", typeof(string));
            TaulaMain.Columns.Add("TrackAngleRate", typeof(double));
            TaulaMain.Columns.Add("TAS_Status", typeof(string));
            TaulaMain.Columns.Add("TAS", typeof(double));
            TaulaMain.Columns.Add("MagneticHeading_Status", typeof(string));
            TaulaMain.Columns.Add("MagneticHeading", typeof(double));
            TaulaMain.Columns.Add("IndicatedAirspeed_Status", typeof(string));
            TaulaMain.Columns.Add("IndicatedAirspeed", typeof(double));
            TaulaMain.Columns.Add("Mach_Status", typeof(string));
            TaulaMain.Columns.Add("Mach", typeof(double));
            TaulaMain.Columns.Add("BaromAltRate_Status", typeof(string));
            TaulaMain.Columns.Add("BaromAltRate", typeof(double));
            TaulaMain.Columns.Add("Below", typeof(string));
            TaulaMain.Columns.Add("InertialVertVel_Status", typeof(string));
            TaulaMain.Columns.Add("InertialVertVel", typeof(double));
            TaulaMain.Columns.Add("Velocity", typeof(double));
            TaulaMain.Columns.Add("Heading", typeof(double));
            TaulaMain.Columns.Add("3D Radar Height", typeof(int));
            TaulaMain.Columns.Add("COM", typeof(string));
            TaulaMain.Columns.Add("STAT", typeof(string));
            TaulaMain.Columns.Add("SI", typeof(string));
            TaulaMain.Columns.Add("MSSC", typeof(string));
            TaulaMain.Columns.Add("ARC", typeof(string));
            TaulaMain.Columns.Add("AIC", typeof(string));
            TaulaMain.Columns.Add("B1A", typeof(string));
            TaulaMain.Columns.Add("B1B", typeof(string));
            TaulaMain.Columns.Add("TrackNumber", typeof(int));
            TaulaMain.Columns.Add("CNF", typeof(string));
            TaulaMain.Columns.Add("RAD", typeof(string));
            TaulaMain.Columns.Add("DOU", typeof(string));
            TaulaMain.Columns.Add("MAH", typeof(string));
            TaulaMain.Columns.Add("CDM", typeof(string));
            TaulaMain.Columns.Add("TRE", typeof(string));
            TaulaMain.Columns.Add("GHO", typeof(string));
            TaulaMain.Columns.Add("SUP", typeof(string));
            TaulaMain.Columns.Add("TCC", typeof(string));

            int indexByte = 0;
            CAT record = new CAT();
            while (indexByte < data.Length) //en comptes de mirar totes les dades com un sol vector format per tots els missatges junts, separem missatge per missatge.
            {
                DataTable dtNonCompressed = new DataTable();
                int octetanalyzed = indexByte;

                if (data[indexByte] != 48) // Comprovar si és Categoria 48
                {
                    indexByte++;
                    continue;
                }

                //CAT record = new CAT();
                record.DSI = data[indexByte];

                int length = (data[indexByte + 1] << 8) | data[indexByte + 2];
                record.lenght = data[indexByte + 1] | data[indexByte + 2]; //Longitud total en octets de 1 avió

                // while per mirar quants octets ocupa fspec, per poder separar fspec de la resta i mirar quines categories estan incloses
                int lastFspecByte = 0;
                bool indexfound = false;
                List<string> fspec = new List<string>();

                while (indexfound == false)
                {
                    int bit = (data[indexByte + 3 + lastFspecByte] >> 7) & 1;
                    if (bit == 0)
                    {
                        indexfound = true;
                    }
                    fspec.Add(Convert.ToString(data[indexByte + 3 + lastFspecByte], 2).PadLeft(8, '0'));
                    lastFspecByte++;
                }

                record.fspeclength = lastFspecByte;


                //primer byte
                int fspecAnalyzedByte = 0;
                octetanalyzed = octetanalyzed + 3 + record.fspeclength;

                DataRow filaActual = TaulaMain.NewRow();

                while (fspecAnalyzedByte < record.fspeclength) //itera el fspec mirant quins son 1 i quins 0
                {
                    int fspecAnalyzedBit = 0;
                    while (fspecAnalyzedBit < 7)
                    {
                        if (fspec[fspecAnalyzedByte].Substring(fspecAnalyzedBit, 1) != "0") // if per comprovar si la component de l'fspec és un 1, desplaçem a la esquerra el numero 1 tantes vegades com fspecAnalyzedBit
                        {
                            var resultDataItem = I048_data_items.data_items.GetDataItem(fspecAnalyzedBit, fspecAnalyzedByte, data, record.fspeclength, octetanalyzed); // (index de l'octet, octet de l'fspec que toca,  
                            octetanalyzed = octetanalyzed + resultDataItem.Item3;
                            //dtNonCompressed.Merge(resultDataItem.Item4);
                            foreach (DataRow fila in resultDataItem.Item4.Rows)
                            {
                                foreach (DataColumn col in resultDataItem.Item4.Columns)
                                {
                                    if (TaulaMain.Columns.Contains(col.ColumnName))
                                    {
                                        filaActual[col.ColumnName] = fila[col.ColumnName];
                                    }
                                }
                            }

                        }
                        fspecAnalyzedBit++;
                    }
                    fspecAnalyzedByte++;
                }

                TaulaMain.Rows.Add(filaActual);

                missatgeAnalitzat = missatgeAnalitzat + 1;

                if (missatgeAnalitzat == 3476) //3476
                {
                    missatgeAnalitzat = 3476;
                }
                octetanalyzed = octetanalyzed - 3 - record.fspeclength;

                indexByte = indexByte + record.lenght;
            }


            if (!TaulaMain.Columns.Contains("Index"))
            {
                TaulaMain.Columns.Add("Index", typeof(int));
            }
            for (int i = 0; i < TaulaMain.Rows.Count; i++)
            {
                TaulaMain.Rows[i]["Index"] = i + 1; // o només 'i' si vols començar a 0
            }

            record.dt = TaulaMain;
            results.Add(record);
            return results;
        }
    }
}

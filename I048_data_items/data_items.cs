using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.IO.Ports;
using System.Collections;


namespace I048_data_items
{
    public class data_items
    {
        public static (string, string, int, DataTable) GetDataItem(int fspecAnalyzedBit, int fspecAnalayzedByte, byte[] data, int fspeclenght, int octetanalyzed)
        {
            DataTable dt = new DataTable();
            //Data Source Identifier
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 1)
            {
                string data_item = "I048/010";
                string data_item_description = "Data Source Identifier";
                int length_octets = 2;
                DataTable dataSourceIdentifier = DataSourceIdentifier(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, dataSourceIdentifier);
            }

            //Time of the Day
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 2)
            {
                string data_item = "I048/140";
                string data_item_description = "Time-of-Day";
                int length_octets = 3;
                DataTable Time_of_Day = TimeofDay(data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, Time_of_Day);
            }

            //Target Report Descriptor
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 3)
            {
                string data_item = "I048/020";
                string data_item_description = "Target Report Descriptor";

                // While used to know the length of the data item
                int length_octets = 1;
                int byteIndex = 0;
                int bit = 0;
                while (byteIndex < 3)
                {
                    bit = (data[octetanalyzed + 1] >> 7) & 1;
                    if (bit == 1)
                    {
                        length_octets = length_octets + 1;
                    }
                    else
                    {
                        break;
                    }
                        byteIndex++;
                }

                DataTable Time_of_Day = TargetReportDescriptor(data, octetanalyzed + 1, length_octets);

      
    
                return (data_item, data_item_description, length_octets, dt);
            }

            //Measured Position in Slant Polar Coordinates
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/040";
                string data_item_description = "Measured Position in Slant polar Coordinates";
                int length_octets = 4;
                DataTable slantPolarCoordinates = SlantPolarCoordinates(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, dt);
            }

            //Mode-3/A
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 5)
            {
                string data_item = "I048/070";
                string data_item_description = "Mode-3/A Code in Octal Representation";
                int length_octets = 2;
                DataTable mode3A = Mode3A(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, dt);
            }

            //Flight Level
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 6)
            {
                string data_item = "I048/090";
                string data_item_description = "Flight Level in Binary Representation";
                int length_octets = 2;
                DataTable flightLevel = FlightLevel(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, dt);
            }

            //Radar Plot Characteristics
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 7) 
            {
                string data_item = "I048/130";
                string data_item_description = "Radar Plot Characteristics";
                //int length_octets = 1+1+; //un altre dels raros
                //return (data_item, data_item_description, length_octets, dt);
            }

            //fi primer octet

            //Aircraft Adress
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 1)
            {
                string data_item = "I048/220";
                string data_item_description = "Aircraft Adress";
                int length_octets = 3;
                DataTable aircraftAddress = AircraftAddress(data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, dt);
            }

            //Aircraft Identification
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 2)
            {
                string data_item = "I048/240";
                string data_item_description = "Aircraft Identification";
                int length_octets = 6;
                return (data_item, data_item_description, length_octets, dt);
            }

            //Mode S **
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 3)
            {
                string data_item = "I048/250";
                string data_item_description = "Mode S MB Data";
                //int length_octets = 1 + 8*n;//wtf com poso aixo??
                //return (data_item, data_item_description, length_octets, dt);
            }

            //Track Number
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/161";
                string data_item_description = "Track Number";
                int length_octets = 2;
                DataTable trackNumber = TrackNumber(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, trackNumber);
            }

            //Calculed Position in Cartesian Coordinates
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 5)
            {
                string data_item = "I048/042";
                string data_item_description = "Calculated Position in Cartesian Coordinates";
                int length_octets = 4;
                return (data_item, data_item_description, length_octets, dt);
            }

            //Calculed Track Velocity in Polar Coordinates
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 6)
            {
                string data_item = "I048/200";
                string data_item_description = "Calculated Track Velocity in Polar Representation";
                int length_octets = 4;
                return (data_item, data_item_description, length_octets, dt);
            }

            //Track Status
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 7)
            {
                string data_item = "I048/170";
                string data_item_description = "Track Status";
                
                int length_octets = 1;
                int bit = (data[octetanalyzed + 1] >> 7) & 1;
                

                if (bit == 1)
                {
                    length_octets = 2;
                }

                //return (data_item, data_item_description, length_octets, dt);
            }

            //fi segon octet

            //if (fspecanalyzed == 3 && fspecIndex == 1)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 2)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 3)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 4)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //Height Measured by 3D Radar
            if (fspecAnalayzedByte == 3 && fspecAnalyzedBit == 5)
            {
                string data_item = "I048/110";
                string data_item_description = "Height Measured by 3D Radar";
                int length_octets = 2;
                return (data_item, data_item_description, length_octets, dt);
            }

            //if (fspecanalyzed == 3 && fspecIndex == 6)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //Communications / ACAS Capability and Flight Status
            if (fspecAnalayzedByte == 3 && fspecAnalyzedBit == 7)
            {
                string data_item = "I048/230";
                string data_item_description = "Communications / ACAS Capability and Flight Status";
                int length_octets = 2;
                return (data_item, data_item_description, length_octets, dt);
            }

            //fi tercer octet

            //if (fspecanalyzed == 3 && fspecIndex == 1)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 2)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 3)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 4)
            //{
            //    string data_item = "I048/250";
            //    string data_item_description = "Data Source Identifier";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //if (fspecanalyzed == 3 && fspecIndex == 5)
            //{
            //    string data_item = "I048/110";
            //    string data_item_description = "Height Measured by 3D Radar";
            //    int length_octets = 2;
            //    return (data_item, data_item_description, length_octets);
            //}
            //return ("", "", 0);

            //Special Purpose Field
            if (fspecAnalayzedByte == 3 && fspecAnalyzedBit == 6)
            {
                string data_item = "SP-Data Item";
                string data_item_description = "Special Purpose Field";
                //int length_octets = 1+1+;
                //return (data_item, data_item_description, length_octets, dt);
            }

            //Reserved Expansion Field
            if (fspecAnalayzedByte == 3 && fspecAnalyzedBit == 7)
            {
                string data_item = "RE-Data Item";
                string data_item_description = "Reserved Expansion Field";
                //int length_octets = 1+1+;
                //return (data_item, data_item_description, length_octets, dt);
            }
            return ("", "", 0, dt);
        }

        public static DataTable DataSourceIdentifier(byte byte1, byte byte2)
        {
            //SAC
            string pathCSV = "SACdata.csv"; // Ruta del fitxer CSV
            int numeroDecimal = Convert.ToInt32(byte1);//passem byte a string
            string numDecimalString = Convert.ToString(numeroDecimal);
            var linies = File.ReadAllLines(pathCSV);//llegim el fitxer csv

            string SAC = "";
            int rowNumber = 0;
            using (StreamReader reader = new StreamReader(pathCSV))
            {
                while (!reader.EndOfStream)
                {
                    rowNumber++;  // Comptador de files
                    string line = reader.ReadLine();
                    string[] columns = line.Split(';');  // Assumeix separació per comes

                    if (columns.Length >= 3)  // Assegurar que la columna 3 existeix
                    {
                        string binaryValue = columns[2].Trim();  // Eliminar espais innecessaris

                        if (binaryValue == numDecimalString)
                        {
                            SAC = columns[1];
                            break;  // Si només vols la primera coincidència, trenca el bucle
                        }
                    }
                }                
            }


            //SIC
            string SIC = Convert.ToString(byte2, 2).PadLeft(8, '0');

            DataTable dt = new DataTable();
            dt.Columns.Add("SAC", typeof(int));
            dt.Columns.Add("SIC", typeof(int));
            dt.Rows.Add(SAC, SIC);

            return dt;
        }
        public static DataTable TimeofDay(byte byte1, byte byte2, byte byte3)
        {
            // 1. Concatenem els bytes en un enter de 16 bits (MSB + LSB)
            int TimeOfDay = (byte1 << 8) | byte2;
            DataTable dt = new DataTable();
            dt.Columns.Add("Time of day (seconds)", typeof(int));
            dt.Rows.Add(TimeOfDay);

            // 2. Retornem el nombre de segons des de mitjanit en UTC
            return dt;
        }
        public static DataTable TargetReportDescriptor(byte[] data, int octetanalyzed, int length_octets)
        {
            octetanalyzed = Convert.ToInt32(data[octetanalyzed], 2);
            string TYP = "";
            string SIM = "";
            string RDP = "";
            string SPI = "";
            string RAB = "";
            string TST = "";
            string ERR = "";
            string XPP = "";
            string ME = "";
            string MI = "";
            string FOE_FRI = "";


            int byteIndex = 0;
            while (byteIndex < length_octets)
            {
                if (byteIndex == 0)
                {
                    TYP = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(0, 3);

                    if (TYP == "000")
                    {
                        TYP = "No detection";
                    }
                    else if (TYP == "001")
                    {
                        TYP = "Single PSR detection";
                    }
                    else if (TYP == "010")
                    {
                        TYP = "Single SSR detection";
                    }
                    else if (TYP == "011")
                    {
                        TYP = "SSR + PSR detection";
                    }
                    else if (TYP == "100")
                    {
                        TYP = "Single ModeS All-Call";
                    }
                    else if (TYP == "101")
                    {
                        TYP = "Single ModeS Roll-Call";
                    }
                    else if (TYP == "110")
                    {
                        TYP = "ModeS All-Call + PSR";
                    }
                    else if (TYP == "111")
                    {
                        TYP = "ModeS Roll-Call + PSR";
                    }
                    else
                    {
                        TYP = "Valor de TYP no reconocido";
                    }

                    SIM = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(3, 1);

                    if (SIM == "1")
                    {
                        SIM = "Simulated target report";
                    }
                    else
                    {
                        SIM = "Actual target report";
                    }


                    RDP = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(4, 1);

                    if (RDP == "1")
                    {
                        RDP = "Report from RDP Chain 2 ";
                    }
                    else
                    {
                        RDP = "Report from RDP Chain 1";
                    }


                    SPI = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(5, 1);

                    if (SPI == "1")
                    {
                        SPI = "Special Position Identification";
                    }
                    else
                    {
                        SPI = "Absence of SPI";
                    }


                    RAB = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(6, 1);

                    if (RAB == "1")
                    {
                        RAB = "Report from field monitor(fixed transponder)";
                    }
                    else
                    {
                        RAB = "Report from aircraft transponder";
                    }

                    byteIndex = byteIndex + 1;

                }

                else if (byteIndex == 1)
                {
                    octetanalyzed = octetanalyzed + 1;

                    TST = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(0, 1);

                    if (TST == "1")
                    {
                        TST = "Test target report";
                    }
                    else
                    {
                        TST = "Real target report";
                    }

                    ERR = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(1, 1);

                    if (ERR == "1")
                    {
                        ERR = "Extended Range present";
                    }
                    else
                    {
                        ERR = "No Extended Range";
                    }

                    XPP = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(2, 1);

                    if (XPP == "1")
                    {
                        XPP = "X-Pulse present";
                    }
                    else
                    {
                        XPP = "No X-Pulse present";
                    }


                    ME = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(3, 1);

                    if (ME == "1")
                    {
                        ME = "No Military emergency";
                    }
                    else
                    {
                        ME = "Military emergency";
                    }


                    MI = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(4, 1);

                    if (MI == "1")
                    {
                        MI = "Report from field monitor(fixed transponder)";
                    }
                    else
                    {
                        MI = "Report from aircraft transponder";
                    }


                    FOE_FRI = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(5, 2);

                    if (FOE_FRI == "00")
                    {
                        FOE_FRI = "No Mode 4 interrogation";
                    }
                    else if (FOE_FRI == "01")
                    {
                        FOE_FRI = "Friendly target";
                    }
                    else if (FOE_FRI == "10")
                    {
                        FOE_FRI = "Unknown target";
                    }
                    else if (FOE_FRI == "11")
                    {
                        FOE_FRI = "No reply";
                    }

                    byteIndex = byteIndex + 1;
                }

                else if (byteIndex == 2)
                {
                    octetanalyzed = octetanalyzed + 1;
                    //    string TST = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(0, 1);

                    //    if (TST == "1")
                    //    {
                    //        TST = "Test target report";
                    //    }
                    //    else
                    //    {
                    //        TST = "Real target report";
                    //    }

                    //    string ERR = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(1, 1);

                    //    if (ERR == "1")
                    //    {
                    //        ERR = "Extended Range present";
                    //    }
                    //    else
                    //    {
                    //        ERR = "No Extended Range";
                    //    }

                    //    string XPP = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(2, 1);

                    //    if (XPP == "1")
                    //    {
                    //        XPP = "X-Pulse present";
                    //    }
                    //    else
                    //    {
                    //        XPP = "No X-Pulse present";
                    //    }


                    //    string ME = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(3, 1);

                    //    if (ME == "1")
                    //    {
                    //        ME = "No Military emergency";
                    //    }
                    //    else
                    //    {
                    //        ME = "Military emergency";
                    //    }


                    //    string MI = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(4, 1);

                    //    if (MI == "1")
                    //    {
                    //        MI = "Report from field monitor(fixed transponder)";
                    //    }
                    //    else
                    //    {
                    //        MI = "Report from aircraft transponder";
                    //    }                    


                    //    string FOE_FRI = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0').Substring(5, 2);

                    //    if (FOE_FRI == "00")
                    //    {
                    //        FOE_FRI = "No Mode 4 interrogation";
                    //    }
                    //    else if (FOE_FRI == "01")
                    //    {  
                    //        FOE_FRI = "Friendly target";
                    //    }
                    //    else if (FOE_FRI == "10")
                    //    {
                    //        FOE_FRI = "Unknown target";
                    //    }
                    //    else if (FOE_FRI == "11")
                    //    {
                    //        FOE_FRI = "No reply";
                    //    }
                    //}
                }

            }
            DataTable dt = new DataTable();
            dt.Columns.Add("TYP", typeof(int));
            dt.Columns.Add("SIM", typeof(int));
            dt.Columns.Add("RDP", typeof(int));
            dt.Columns.Add("SPI", typeof(int));
            dt.Columns.Add("RAB", typeof(int));
            dt.Columns.Add("TST", typeof(int));
            dt.Columns.Add("ERR", typeof(int));
            dt.Columns.Add("XPP", typeof(int));
            dt.Columns.Add("ME", typeof(int));
            dt.Columns.Add("MI", typeof(int));
            dt.Columns.Add("FOE_FRI", typeof(int));

            dt.Rows.Add(TYP, SIM, RDP, SPI, RAB, TST, ERR, XPP, ME, MI, FOE_FRI);

            return dt;
        }
        public static DataTable SlantPolarCoordinates(byte byte1, byte byte2, byte byte3, byte byte4)
        {

            int RawRHO = Convert.ToInt32(((byte1 << 8) | byte2));
            float RHO = RawRHO / 256;

            int RawTHETA = Convert.ToInt32(((byte1 << 8) | byte2));
            float THETA = RawTHETA*360 / 2^(16);

            DataTable dt = new DataTable();

            dt.Columns.Add("Rho (Nautical Miles)", typeof(int));
            dt.Columns.Add("Theta (degrees)", typeof(int));
            dt.Rows.Add(RHO, THETA);

            return dt;
        }

        public static DataTable Mode3A(byte byte1, byte byte2)
        {

            string M3A_octets = Convert.ToString(((byte1 << 8) | byte2));

            string V = M3A_octets.Substring(0, 1);
            string G= M3A_octets.Substring(1, 1);
            string L= M3A_octets.Substring(2, 1);

            int A = Convert.ToInt32(M3A_octets.Substring(3, 3));
            int B = Convert.ToInt32(M3A_octets.Substring(6, 3));
            int C = Convert.ToInt32(M3A_octets.Substring(9, 3));
            int D = Convert.ToInt32(M3A_octets.Substring(12, 3));


            DataTable dt = new DataTable();

            dt.Columns.Add("V", typeof(int));
            dt.Columns.Add("G", typeof(int));
            dt.Columns.Add("L", typeof(int));

            dt.Columns.Add("Mode3A", typeof(int));
            dt.Rows.Add(V, G, L , $"A = {A:D2}, B = {B:D2}, C = {C:D2}, D = {D:D2}");

            return dt;
        }

        public static DataTable FlightLevel(byte byte1, byte byte2)
        {

            string FL_octets = Convert.ToString(((byte1 << 8) | byte2));

            string V = FL_octets.Substring(0, 1);
            string G = FL_octets.Substring(1, 1);
            double FL = Math.Round((Convert.ToDouble(FL_octets.Substring(2, 14))) / 1000) * 1000; //divide by 1000 then round to lets say 3 from 3.15 and then multiply again by 1000
            // fer el complement a 2 pels fl negatius
            if (V == "0")
            {
                V = "Code validated";
            }
            else
            {
                V = "Code not validated";
            }

            if (G == "0")
            {
                G = "Default";
            }
            else
            {
                G = "Garbled Code";
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("V", typeof(int));
            dt.Columns.Add("G", typeof(int));
            dt.Columns.Add("Flight Level", typeof(int));

            dt.Columns.Add("Mode3A", typeof(int));
            dt.Rows.Add(V, G, FL);

            return dt;
        }

        //public static DataTable RadarPlotCharacteristics(byte byte1, byte byte2)
        //{

        //    string FL_octets = Convert.ToString(((byte1 << 8) | byte2));

        //    string V = FL_octets.Substring(0, 1);
        //    string G = FL_octets.Substring(1, 1);
        //    int FL = Convert.ToInt32(FL_octets.Substring(2, 14));

        //    if (V == "0")
        //    {
        //        V = "Code validated";
        //    }
        //    else
        //    {
        //        V = "Code not validated";
        //    }

        //    if (G == "0")
        //    {
        //        G = "Default";
        //    }
        //    else
        //    {
        //        G = "Garbled Code";
        //    }

        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("V", typeof(int));
        //    dt.Columns.Add("G", typeof(int));
        //    dt.Columns.Add("Flight Level", typeof(int));

        //    dt.Columns.Add("Mode3A", typeof(int));
        //    dt.Rows.Add(V, G, FL);

        //    return dt;
        //}
        public static DataTable AircraftAddress(byte byte1, byte byte2, byte byte3)
        {

            int AA_octets = (byte1 << 16) | (byte2 << 8) | byte3;

            string AircraftAddress = AA_octets.ToString("X6");

            DataTable dt = new DataTable();

            dt.Columns.Add("V", typeof(int));
            dt.Columns.Add("G", typeof(int));
            dt.Columns.Add("Flight Level", typeof(int));

            dt.Columns.Add("Mode3A", typeof(int));
            dt.Rows.Add(AircraftAddress);

            return dt;
        }
        public static DataTable TrackNumber(byte byte1, byte byte2)
        {
            string TrackNumberString = Convert.ToString(((byte1 << 8) | byte2));

            int TrackNumber = Convert.ToInt32(TrackNumberString.Substring(4, 12));
            
            DataTable dt = new DataTable();

            dt.Columns.Add("TrackNumber", typeof(int));
            dt.Rows.Add(TrackNumber);

            return dt;
        }

    }
}

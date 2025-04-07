using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Policy;


namespace I048_data_items
{
    public class data_items
    {
        public static (string, string, int, DataTable) GetDataItem(int fspecAnalyzedBit, int fspecAnalayzedByte, byte[] data, int fspeclenght, int octetanalyzed)
        {
            DataTable dt = new DataTable();
            //Data Source Identifier
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 0)
            {
                string data_item = "I048/010";
                string data_item_description = "Data Source Identifier";
                int length_octets = 2;
                DataTable dataSourceIdentifier = DataSourceIdentifier(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, dataSourceIdentifier);
            }

            //Time of the Day
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 1)
            {
                string data_item = "I048/140";
                string data_item_description = "Time-of-Day";
                int length_octets = 3;
                DataTable Time_of_Day = TimeofDay(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2]); //crec que no estan be els bytes agafats
                return (data_item, data_item_description, length_octets, Time_of_Day);
            }

            //Target Report Descriptor
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 2)
            {
                string data_item = "I048/020";
                string data_item_description = "Target Report Descriptor";

                // While used to know the length of the data item
                int length_octets = 1;
                int byteIndex = 1;
                string bit = "0";
                while (byteIndex < 3)
                {
                    bit = ((Convert.ToString(data[octetanalyzed + byteIndex], 2).PadLeft(8, '0')).Substring(6, 1));
                    if (bit == "1")
                    {
                        length_octets = length_octets + 1;
                    }
                    else
                    {
                        break;
                    }
                    byteIndex++;
                }

                DataTable targetReportDescriptor = TargetReportDescriptor(data, octetanalyzed, length_octets);



                return (data_item, data_item_description, length_octets, targetReportDescriptor);
            }

            //Measured Position in Slant Polar Coordinates
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 3)
            {
                string data_item = "I048/040";
                string data_item_description = "Measured Position in Slant polar Coordinates";
                int length_octets = 4;
                DataTable slantPolarCoordinates = SlantPolarCoordinates(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, slantPolarCoordinates);
            }

            //Mode-3/A
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/070";
                string data_item_description = "Mode-3/A Code in Octal Representation";
                int length_octets = 2;
                DataTable mode3A = Mode3A(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, mode3A);
            }

            //Flight Level
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 5)
            {
                string data_item = "I048/090";
                string data_item_description = "Flight Level in Binary Representation";
                int length_octets = 2;
                DataTable flightLevel = FlightLevel(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, flightLevel);
            }

            //Radar Plot Characteristics
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 6)
            {
                //The first octet must be checked in order to know which subfields will appear
                string data_item = "I048/130";
                string data_item_description = "Radar Plot Characteristics";
                int length_octets = 1;
                string byte1 = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0');

                List<string> subfields = new List<string>();

                for (int i = 0; i <= 7; i++)
                {
                    if (byte1.Substring(i, 1) == "1")
                    {
                        if (i <= 7)
                        {
                            length_octets++;
                            subfields.Add(Convert.ToString(i));
                        }
                        else // NO ACABO D'ENTENDRE QUE S'HA DE FER
                        {
                            length_octets++;
                        }
                    }
                }
                DataTable radarPlotCharacteristics = RadarPlotCharacteristics(data, subfields, octetanalyzed);

                return (data_item, data_item_description, length_octets, radarPlotCharacteristics);
            }

            //fi primer octet

            //Aircraft Adress
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 0)
            {
                string data_item = "I048/220";
                string data_item_description = "Aircraft Adress";
                int length_octets = 3;
                DataTable aircraftAddress = AircraftAddress(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2]);
                return (data_item, data_item_description, length_octets, aircraftAddress);
            }

            //Aircraft Identification
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 1)
            {
                string data_item = "I048/240";
                string data_item_description = "Aircraft Identification";
                int length_octets = 6;
                DataTable aircraftID = AircraftID(data, octetanalyzed, length_octets);
                return (data_item, data_item_description, length_octets, aircraftID);
            }

            //Mode S
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 2)
            {
                string data_item = "I048/250";
                string data_item_description = "Mode S MB Data";
                byte DFRepetition = data[octetanalyzed];
                int length_octets = DFRepetition * 8 + 1;
                DataTable modeS = ModeS(data, octetanalyzed, length_octets);
                return (data_item, data_item_description, length_octets, modeS);
            }

            //Track Number
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 3)
            {
                string data_item = "I048/161";
                string data_item_description = "Track Number";
                int length_octets = 2;
                DataTable trackNumber = TrackNumber(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, trackNumber);
            }

            //Calculed Position in Cartesian Coordinates
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/042";
                string data_item_description = "Calculated Position in Cartesian Coordinates";
                int length_octets = 4;
                DataTable calculatedPositionCartCoord = CalculatedPositionCartCoord(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, dt);
            }

            //Calculed Track Velocity in Polar Coordinates
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 5)
            {
                string data_item = "I048/200";
                string data_item_description = "Calculated Track Velocity in Polar Representation";
                int length_octets = 4;
                DataTable trackVelPolarCoord = TrackVelPolarCoord(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2], data[octetanalyzed + 3]);
                return (data_item, data_item_description, length_octets, trackVelPolarCoord);
            }

            //Track Status
            if (fspecAnalayzedByte == 1 && fspecAnalyzedBit == 6)
            {
                string data_item = "I048/170";
                string data_item_description = "Track Status";

                int length_octets = 1;
                int bit = (data[octetanalyzed + 1] >> 7) & 1;


                if (bit == 1)
                {
                    length_octets = 2;
                }

                DataTable trackStatus = TrackStatus(data, octetanalyzed);

                return (data_item, data_item_description, length_octets, trackStatus);
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
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/110";
                string data_item_description = "Height Measured by 3D Radar";
                int length_octets = 2;
                DataTable height3DRadar = Height3DRadar(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, height3DRadar);
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
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 6)
            {
                string data_item = "I048/230";
                string data_item_description = "Communications / ACAS Capability and Flight Status";
                int length_octets = 2;
                DataTable commACAS = CommunicationACAS(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, commACAS);
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
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 5)
            {
                string data_item = "SP-Data Item";
                string data_item_description = "Special Purpose Field";
                //int length_octets = 1+1+;
                //return (data_item, data_item_description, length_octets, dt);
            }

            //Reserved Expansion Field
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 6)
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
            //var linies = File.ReadAllLines(pathCSV);//llegim el fitxer csv

            int SAC;
            int SIC;
            //int rowNumber = 0;
            //using (StreamReader reader = new StreamReader(pathCSV))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        rowNumber++;  // Comptador de files
            //        string line = reader.ReadLine();
            //        string[] columns = line.Split(';');  // Assumeix separació per comes

            //        if (columns.Length >= 3)  // Assegurar que la columna 3 existeix
            //        {
            //            string binaryValue = columns[2].Trim();  // Eliminar espais innecessaris

            //            if (binaryValue == numDecimalString)
            //            {
            //                SAC = columns[1];
            //                break;  // Si només vols la primera coincidència, trenca el bucle
            //            }
            //        }
            //    }                
            //}


            //SIC
            SAC = byte1;
            SIC = byte2;

            DataTable dt = new DataTable();
            dt.Columns.Add("SAC", typeof(int));
            dt.Columns.Add("SIC", typeof(int));
            dt.Rows.Add(SAC, SIC);

            return dt;
        }
        public static DataTable TimeofDay(byte byte1, byte byte2, byte byte3)
        {
            // 1. Concatenem els bytes en un enter de 16 bits (MSB + LSB)
            int TimeOfDay = (byte1 << 16) | (byte2 << 8) | byte3;
            DataTable dt = new DataTable();
            dt.Columns.Add("Time of day (seconds)", typeof(int));
            dt.Rows.Add(TimeOfDay);

            // 2. Retornem el nombre de segons des de mitjanit en UTC
            return dt;
        }
        public static DataTable TargetReportDescriptor(byte[] data, int octetanalyzed, int length_octets)
        {
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

            dt.Rows.Add(TYP, SIM, RDP, SPI, RAB, TST, ERR, XPP, ME, MI, FOE_FRI);

            return dt;
        }
        public static DataTable SlantPolarCoordinates(byte byte1, byte byte2, byte byte3, byte byte4)
        {

            string binaryRHO = Convert.ToString(((byte1 << 8) | byte2), 2);

            double RHO = Convert.ToInt32(binaryRHO, 2) * 0.00390625; ;

            string RawTHETA = Convert.ToString(((byte3 << 8) | byte4), 2);
            double THETA = Convert.ToInt32(RawTHETA, 2) * 0.00549316406;

            DataTable dt = new DataTable();

            dt.Columns.Add("Rho (Nautical Miles)", typeof(double));
            dt.Columns.Add("Theta (degrees)", typeof(double));
            dt.Rows.Add(RHO, THETA);

            return dt;
        }
        public static DataTable CalculatedPositionCartCoord(byte byte1, byte byte2, byte byte3, byte byte4)
        {
            string xComponent = Convert.ToString(((byte1 << 8) | byte2), 2);
            double X_Coord = Convert.ToInt32(xComponent, 2) / 128;

            string yComponent = Convert.ToString(((byte3 << 8) | byte4), 2);
            double Y_Coord = Convert.ToInt32(yComponent, 2) / 128;

            DataTable dt = new DataTable();

            dt.Columns.Add("X coordinate", typeof(int));
            dt.Columns.Add("Y coordinate", typeof(int));
            dt.Rows.Add(X_Coord, Y_Coord);

            return dt;
        }

        public static DataTable Mode3A(byte byte1, byte byte2)
        {

            string M3A_octets = Convert.ToString(((byte1 << 8) | byte2), 2).PadLeft(16, '0');

            string V = M3A_octets.Substring(0, 1);
            string G = M3A_octets.Substring(1, 1);
            string L = M3A_octets.Substring(2, 1);

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

            if (L == "0")
            {
                L = "Mode-3/A code derived from the reply of the transponder";
            }
            else
            {
                L = "Mode-3/A code not extracted during the last scan";
            }

            int A = Convert.ToInt32(M3A_octets.Substring(4, 3), 2);
            int B = Convert.ToInt32(M3A_octets.Substring(7, 3), 2);
            int C = Convert.ToInt32(M3A_octets.Substring(10, 3), 2);
            int D = Convert.ToInt32(M3A_octets.Substring(13, 3), 2);


            DataTable dt = new DataTable();

            dt.Columns.Add("V", typeof(string));
            dt.Columns.Add("G", typeof(string));
            dt.Columns.Add("L", typeof(string));


            dt.Columns.Add("Mode3A", typeof(string));
            dt.Rows.Add(V, G, L, $"A = {A:D2}, B = {B:D2}, C = {C:D2}, D = {D:D2}");

            return dt;
        }

        public static DataTable FlightLevel(byte byte1, byte byte2)
        {

            string FL_octets = Convert.ToString(((byte1 << 8) | byte2), 2).PadLeft(16, '0');

            string V_fl = FL_octets.Substring(0, 1);
            string G_fl = FL_octets.Substring(1, 1);
            double FL = ComplementADos(FL_octets.Substring(2, 14)) / 4;

            if (V_fl == "0")
            {
                V_fl = "Code validated";
            }
            else
            {
                V_fl = "Code not validated";
            }

            if (G_fl == "0")
            {
                G_fl = "Default";
            }
            else
            {
                G_fl = "Garbled Code";
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("V_fl", typeof(string));
            dt.Columns.Add("G_fl", typeof(string));
            dt.Columns.Add("Flight Level", typeof(double));

            dt.Rows.Add(V_fl, G_fl, FL);

            return dt;
        }

        public static DataTable RadarPlotCharacteristics(byte[] data, List<string> subfields, int octetanalyzed)
        {
            double SRL = 0;
            int SRR = 0;
            double SAM = 0;
            double PRL = 0;
            double PAM = 0;
            double RPD = 0;
            double APD = 0;

            for (int index = 0; index < subfields.Count; index++)
            {
                string Byte = Convert.ToString(data[octetanalyzed++ + 1], 2).PadLeft(8, '0');


                if (subfields[index] == "0") // Corresponding to subfield 1 (SSR plot runlength)
                {
                    SRL = Convert.ToInt32(Byte, 2) * 0.0439453125;
                }
                else if (subfields[index] == "1") // ( Number of received replies for M(SSR))
                {
                    SRR = Convert.ToInt32(Byte, 2);
                }
                else if (subfields[index] == "2") // (Amplitude of received replies for M(SSR))
                {
                    SAM = ComplementADos(Byte);
                }
                else if (subfields[index] == "3") // (PSR plot runlength)
                {
                    PRL = Convert.ToInt32(Byte, 2) * 0.0439453125;
                }
                else if (subfields[index] == "4") // (PSR amplitude)
                {
                    PAM = Convert.ToInt32(Byte, 2);
                }
                else if (subfields[index] == "5") // (Difference in Range)
                {
                    RPD = Convert.ToInt32(Byte, 2) * 0.00390625;
                }
                else if (subfields[index] == "6") // (Difference in Azimuth)
                {
                    APD = ComplementADos(Byte) * 0.02197265625;
                }

            }

            DataTable dt = new DataTable();

            dt.Columns.Add("SRL", typeof(double));
            dt.Columns.Add("SRR", typeof(int));
            dt.Columns.Add("SAM", typeof(double));
            dt.Columns.Add("PRL", typeof(double));
            dt.Columns.Add("PAM", typeof(double));
            dt.Columns.Add("RPD", typeof(double));
            dt.Columns.Add("APD", typeof(double));

            dt.Rows.Add(SRL, SRR, SAM, PRL, PAM, RPD, APD);

            return dt;
        }
        public static DataTable AircraftAddress(byte byte1, byte byte2, byte byte3)
        {

            string AircraftAddress = Convert.ToString(((byte1 << 16) | (byte2 << 8) | byte3), 16);

            DataTable dt = new DataTable();

            dt.Columns.Add("Aircraft Address", typeof(string));
            dt.Rows.Add(AircraftAddress);

            return dt;
        }
        public static DataTable AircraftID(byte[] data, int octetanalyzed, int length_octets)
        {
            string bits = "";
            string Aircraft_ID_bin = "";
            string Aircraft_ID = "";
            int bits_int = 0;

            for (int index = 0; index < length_octets; index++)
            {
                Aircraft_ID_bin = Aircraft_ID_bin + (Convert.ToString(data[octetanalyzed + index], 2).PadLeft(8, '0'));
            }

            for (int index1 = 0; index1 < Aircraft_ID_bin.Length; index1 += 6)
            {
                bits = "";
                bits_int = 0;
                for (int index2 = 0; index2 < 6; index2++)
                {
                    bits = bits + Aircraft_ID_bin[index1 + index2];
                }

                bits_int = Convert.ToInt32(bits, 2);

                if (bits_int >= 1 && bits_int <= 26)
                {
                    Aircraft_ID += (char)('A' + bits_int - 1);
                }
                else if (bits_int >= 48 && bits_int <= 57)
                {
                    Aircraft_ID += (char)('0' + bits_int - 48);
                }
                else
                {
                    Aircraft_ID += "";
                }

            }


            bits = "";

            DataTable dt = new DataTable();

            dt.Columns.Add("Aircraft_ID", typeof(string));
            dt.Rows.Add(Aircraft_ID);

            return dt;
        }
        public static DataTable ModeS(byte[] data, int octetanalyzed, int length_octets)
        {

            string SelectedAltitude_Status = "0";
            int SelectedAltitude = 0;
            string FMSAltitude_Status = "0";
            int FMSAltitude = 0;
            string BaroSetting_Status = "0";
            double BaroSetting = 0;
            string MCP_FCU_MODE_BITS_Status = "0";
            string VNAV = "";
            string AltHoldMode = "";
            string ApprMode = "";
            string TargetAltitudeSource_Status = "";
            string TargetAltitudeSource = "";



            string RollAngle_Status = "";
            string TrueTrackAngle_Status = "";
            string GS_Status = "";
            string TrackAngleRate_Status = "";
            string TAS_Status = "";
            string LWingD = "";
            double RollAngle = 0;
            double West = 0;
            double TrueTrackAngle = 0;
            double GS = 0;
            double TrackAngleRate = 0;
            double TAS = 0;


            string MagneticHeading_Status = "";
            string IndicatedAirspeed_Status = "";
            string Mach_Status = "";
            string BaromAltRate_Status = "";
            string InertialVertVel_Status = "";
            double MagneticHeading = 0;
            double IndicatedAirspeed = 0;
            double Mach = 0;
            double BaromAltRate = 0;
            string Below = "";
            double InertialVertVel = 0;

            int index = 0;
            while (index < length_octets)
            {
                string BDSData = Convert.ToString(data[octetanalyzed + index + 1], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 2], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 3], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 4], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 5], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 6], 2).PadLeft(8, '0') + Convert.ToString(data[octetanalyzed + index + 7], 2).PadLeft(8, '0');
                int BDS1 = data[octetanalyzed + index + 8] >> 4 & 0x0F;
                int BDS2 = data[octetanalyzed + index + 8] & 0x0F;


                if (BDS1 == 4 & BDS2 == 0)
                {
                    SelectedAltitude_Status = BDSData.Substring(0, 1);
                    SelectedAltitude = Convert.ToInt32(BDSData.Substring(1, 12), 2) * 16;

                    FMSAltitude_Status = BDSData.Substring(13, 1);
                    FMSAltitude = Convert.ToInt32(BDSData.Substring(14, 12), 2) * 16;

                    BaroSetting_Status = BDSData.Substring(26, 1);
                    BaroSetting = Convert.ToInt32(BDSData.Substring(27, 12), 2) * 0.1 + 800;

                    MCP_FCU_MODE_BITS_Status = BDSData.Substring(47, 1);

                    VNAV = "n/a";
                    if (Convert.ToString(BDSData.Substring(48, 1)) == "1") { VNAV = "active"; }
                    else { VNAV = " not active"; }

                    AltHoldMode = "n/a";
                    if (Convert.ToString(BDSData.Substring(49, 1)) == "1") { AltHoldMode = "active"; }
                    else { AltHoldMode = " not active"; }

                    ApprMode = "n/a";
                    if (Convert.ToString(BDSData.Substring(50, 1)) == "1") { ApprMode = "active"; }
                    else { ApprMode = " not active"; }

                    TargetAltitudeSource_Status = BDSData.Substring(53, 1);
                    TargetAltitudeSource = "n/a";
                    if (Convert.ToString(BDSData.Substring(54, 2)) == "00") { TargetAltitudeSource = "Unknown"; }
                    else if (Convert.ToString(BDSData.Substring(54, 2)) == "01") { TargetAltitudeSource = "Aircraft altitude"; }
                    else if (Convert.ToString(BDSData.Substring(54, 2)) == "10") { TargetAltitudeSource = "FCU/MCP selected altitude"; }
                    else if (Convert.ToString(BDSData.Substring(54, 2)) == "11") { TargetAltitudeSource = "FMS selected altitude"; }
                }


                else if (BDS1 == 5 & BDS2 == 0)
                {
                    RollAngle_Status = BDSData.Substring(0, 1);
                    LWingD = BDSData.Substring(1, 1);
                    RollAngle = ComplementADos(BDSData.Substring(2, 9)) * 0.17578125;

                    TrueTrackAngle_Status = BDSData.Substring(11, 1);
                    TrueTrackAngle = ComplementADos(BDSData.Substring(12, 11)) * 0.17578125;

                    GS_Status = BDSData.Substring(23, 1);
                    GS = Convert.ToInt32(BDSData.Substring(24, 10), 2) * 2;

                    TrackAngleRate_Status = BDSData.Substring(34, 1);
                    TrackAngleRate = ComplementADos(BDSData.Substring(36, 9)) * 0.03125;

                    TAS_Status = BDSData.Substring(45, 1);
                    TAS = Convert.ToInt32(BDSData.Substring(46, 10), 2) * 2;

                }


                else if (BDS1 == 6 & BDS2 == 0)
                {

                    MagneticHeading_Status = BDSData.Substring(0, 1);
                    MagneticHeading = ComplementADos(BDSData.Substring(1, 11)) * 0.17578125;

                    IndicatedAirspeed_Status = BDSData.Substring(12, 1);
                    IndicatedAirspeed = Convert.ToInt32(BDSData.Substring(13, 10), 2);

                    Mach_Status = BDSData.Substring(23, 1);
                    Mach = (Convert.ToInt32(BDSData.Substring(24, 10), 2) * 4) * 0.001;

                    BaromAltRate_Status = BDSData.Substring(34, 1);
                    BaromAltRate = ComplementADos(BDSData.Substring(35, 10)) * 32;

                    InertialVertVel_Status = BDSData.Substring(45, 1);
                    Below = BDSData.Substring(46, 1);
                    InertialVertVel = ComplementADos(BDSData.Substring(47, 9)) * 32;
                }

                index += 8;
            }

            DataTable dt = new DataTable();


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

            dt.Columns.Add("LWingD", typeof(string));
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
            dt.Columns.Add("Below", typeof(string));
            dt.Columns.Add("InertialVertVel_Status", typeof(string));
            dt.Columns.Add("InertialVertVel", typeof(double));

            dt.Rows.Add(SelectedAltitude_Status, SelectedAltitude, FMSAltitude_Status, FMSAltitude, BaroSetting_Status, BaroSetting, MCP_FCU_MODE_BITS_Status, VNAV, AltHoldMode, ApprMode, TargetAltitudeSource_Status, TargetAltitudeSource, LWingD, RollAngle_Status, RollAngle, TrueTrackAngle_Status, TrueTrackAngle, GS_Status, GS, TrackAngleRate_Status, TrackAngleRate, TAS_Status, TAS, MagneticHeading_Status, MagneticHeading, IndicatedAirspeed_Status, IndicatedAirspeed, Mach_Status, Mach, BaromAltRate_Status, BaromAltRate, Below, InertialVertVel_Status, InertialVertVel);

            return dt;

        }
        public static DataTable TrackVelPolarCoord(byte byte1, byte byte2, byte byte3, byte byte4)
        {
            int factconversiov = Convert.ToInt32(Math.Pow(2, -14));
            int factconversioh = 360 / (Convert.ToInt32(Math.Pow(2, 4)));
            int velocity = ((byte1 << 8) | byte2) * factconversiov;
            int heading = ((byte3 << 8) | byte4) * factconversioh;

            DataTable dt = new DataTable();

            dt.Columns.Add("Velocity", typeof(int));
            dt.Columns.Add("Heading", typeof(int));
            dt.Rows.Add(velocity, heading);

            return dt;
        }
        public static DataTable Height3DRadar(byte byte1, byte byte2)
        {

            int radarheightnon25ft = (byte1 << 8) | byte2;
            int radarheight = radarheightnon25ft * 25;

            DataTable dt = new DataTable();

            dt.Columns.Add("3D Radar Height", typeof(int));
            dt.Rows.Add(radarheight);
            return dt;
        }

        public static DataTable CommunicationACAS(byte byte1, byte byte2)
        {
            string bitsNonPadded = Convert.ToString(((byte1 << 8) | byte2), 2);
            string bits = bitsNonPadded.PadLeft(16, '0');

            //bits 1-3

            int bit1to3 = Convert.ToInt32(bits.Substring(0, 3), 2);
            string COM = "";
            if (bit1to3 == 0)
            {
                COM = "No communications capability (surveillance only)";
            }
            else if (bit1to3 == 1)
            {
                COM = "Comm. A and Comm. B capability";
            }
            else if (bit1to3 == 2)
            {
                COM = "Comm. A, Comm. B and Uplink ELM";
            }
            else if (bit1to3 == 3)
            {
                COM = "Comm. A, Comm. B, Uplink ELM and Downlink ELM";
            }
            else if (bit1to3 == 4)
            {
                COM = "Level 5 Transponder capability";
            }
            else if (bit1to3 >= 5 && bit1to3 <= 7)
            {
                COM = "Not assigned";
            }

            //bits 4-6
            int bit4to6 = Convert.ToInt32(bits.Substring(3, 3), 2);
            string STAT = "";
            if (bit4to6 == 0)
            {
                STAT = "No alert, no SPI, aircraft airborne";
            }
            else if (bit4to6 == 1)
            {
                STAT = "No alert, no SPI, aircraft on ground";
            }
            else if (bit4to6 == 2)
            {
                STAT = "Alert, no SPI, aircraft airborne";
            }
            else if (bit4to6 == 3)
            {
                STAT = "Alert, no SPI, aircraft on ground";
            }
            else if (bit4to6 == 4)
            {
                STAT = "Alert, SPI, aircraft airborne or on ground";
            }
            else if (bit4to6 == 5)
            {
                STAT = "No alert, SPI, aircraft airborne or on ground";
            }
            else if (bit4to6 == 6)
            {
                STAT = "Not assigned";
            }
            else if (bit4to6 == 7)
            {
                STAT = "Unknown";
            }

            //bit 7
            int bit7 = Convert.ToInt32(bits.Substring(6, 1), 2);
            string SI = "";
            if (bit7 == 0)
            {
                SI = "SI-Code Capable";
            }
            else if (bit7 == 1)
            {
                SI = "II-Code Capable";
            }

            //bit 8
            //int bit8 = Convert.ToInt32(bits.Substring(7, 1), 2);
            //if (bit8 == 0)
            //{

            //}
            //else if (bit8 == 1)
            //{

            //}

            //bit 9
            int bit9 = Convert.ToInt32(bits.Substring(8, 1), 2);
            string MSSC = "";
            if (bit9 == 0)
            {
                MSSC = "No";
            }
            else if (bit9 == 1)
            {
                MSSC = "Yes";
            }
            //bit 10
            int bit10 = Convert.ToInt32(bits.Substring(9, 1), 2);
            string ARC = "";
            if (bit10 == 0)
            {
                ARC = "100 ft resolution";
            }
            else if (bit10 == 1)
            {
                ARC = "25 ft resolution";
            }

            //bit 11
            int bit11 = Convert.ToInt32(bits.Substring(10, 1), 2);
            string AIC = "";
            if (bit11 == 0)
            {
                AIC = "No";
            }
            else if (bit11 == 1)
            {
                AIC = "Yes";
            }

            //bit 12 NO ELS ENTENC
            int bit12 = Convert.ToInt32(bits.Substring(11, 1), 2);
            string B1A = "";
            if (bit12 == 0)
            {
                B1A = "";
            }
            else if (bit12 == 1)
            {
                B1A = "";
            }

            //bits 13-16
            int bit13to16 = Convert.ToInt32(bits.Substring(12, 3), 2);
            string B1B = "";


            DataTable dt = new DataTable();

            dt.Columns.Add("COM", typeof(string));
            dt.Columns.Add("STAT", typeof(string));
            dt.Columns.Add("SI", typeof(string));
            dt.Columns.Add("MSSC", typeof(string));
            dt.Columns.Add("ARC", typeof(string));
            dt.Columns.Add("AIC", typeof(string));
            dt.Columns.Add("B1A", typeof(string));
            dt.Columns.Add("B1B", typeof(string));
            dt.Rows.Add(COM, STAT, SI, MSSC, ARC, AIC, B1A, B1B);
            return dt;
        }
        public static double ComplementADos(string bits)
        {
            //Check if it is negative or positive
            if (bits.Substring(0, 1) == "0")
            {
                int result = Convert.ToInt32(bits.Substring(1, bits.Length - 1), 2);
                return result;
            }
            else
            {
                int index = 1; // The first one was for the sign
                string ConvertedBits = "";

                while (index < bits.Length)
                {
                    // We exhange the bits value
                    if (bits.Substring(index, 1) == "0")
                    {
                        ConvertedBits += "1";
                    }
                    else
                    {
                        ConvertedBits += "0";
                    }
                    index++;

                }
                // Make it negative and add one
                double result = -Convert.ToInt32(ConvertedBits, 2) - 1;
                return result;
            }

        }
        public static DataTable TrackNumber(byte byte1, byte byte2)
        {
            string octet1bits = Convert.ToString(byte1, 2).PadLeft(8, '0');
            string octet2bits = Convert.ToString(byte2, 2).PadLeft(8, '0');

            string TrackNumberString = octet1bits + octet2bits;
            TrackNumberString = TrackNumberString.Substring(4, 12);

            int TrackNumber = Convert.ToInt32(TrackNumberString, 2);

            DataTable dt = new DataTable();

            dt.Columns.Add("TrackNumber", typeof(int));
            dt.Rows.Add(TrackNumber);

            return dt;
        }
        public static DataTable TrackStatus(byte[] data, int octetanalyzed)
        {
            string octet1bits = Convert.ToString(data[octetanalyzed], 2).PadLeft(8, '0');

            string CNF = octet1bits.Substring(0, 1);
            if (CNF == "0") { CNF = "Confirmed Track"; }
            else { CNF = "Tentative Track"; }

            string RAD = octet1bits.Substring(1, 2);
            if (RAD == "00") { RAD = "Combined Track"; }
            else if (RAD == "01") { RAD = "PSR Track"; }
            else if (RAD == "10") { RAD = "SSR/Mode S Track"; }
            else if (RAD == "11") { RAD = "Invalid"; }

            string DOU = octet1bits.Substring(3, 1);
            if (DOU == "0") { DOU = "Normal confidence"; }
            else { DOU = "Low confidence in plot to track association"; }

            string MAH = octet1bits.Substring(4, 1);
            if (MAH == "0") { MAH = "No horizontal man.sensed"; }
            else { MAH = "Horizontal man. sensed"; }

            string CDM = octet1bits.Substring(5, 2);
            if (CDM == "00") { CDM = "Maintaining"; }
            else if (CDM == "01") { CDM = "Climbing"; }
            else if (CDM == "10") { CDM = "Descending"; }
            else if (CDM == "11") { CDM = "Unknown"; }

            string TRE = "";
            string GHO = "";
            string SUP = "";
            string TCC = "";

            string FX = octet1bits.Substring(7, 1);
            if (FX == "1")
            {
                string octet2bits = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0');

                TRE = octet2bits.Substring(0, 1);
                if (TRE == "0") { TRE = "Confirmed Track"; }
                else { TRE = "Tentative Track"; }
                GHO = octet2bits.Substring(1, 1); ;
                if (GHO == "0") { GHO = "Confirmed Track"; }
                else { GHO = "Tentative Track"; }
                SUP = octet2bits.Substring(2, 1); ;
                if (SUP == "0") { SUP = "Confirmed Track"; }
                else { SUP = "Tentative Track"; }
                TCC = octet2bits.Substring(3, 1); ;
                if (TCC == "0") { TCC = "Confirmed Track"; }
                else { TCC = "Tentative Track"; }

            }

            DataTable dt = new DataTable();

            dt.Columns.Add("CNF", typeof(string));
            dt.Columns.Add("RAD", typeof(string));
            dt.Columns.Add("DOU", typeof(string));
            dt.Columns.Add("MAH", typeof(string));
            dt.Columns.Add("CDM", typeof(string));
            dt.Columns.Add("TRE", typeof(string));
            dt.Columns.Add("GHO", typeof(string));
            dt.Columns.Add("SUP", typeof(string));
            dt.Columns.Add("TCC", typeof(string));

            dt.Rows.Add(CNF, RAD, DOU, MAH, CDM, TRE, GHO, SUP, TCC);

            

            return dt;
        }

        
    }

}
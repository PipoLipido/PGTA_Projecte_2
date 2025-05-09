﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using I048_data_items;
using MultiCAT6.Utils;
using System.Text.RegularExpressions;

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
                DataTable Time_of_Day = TimeofDay(data[octetanalyzed], data[octetanalyzed + 1], data[octetanalyzed + 2]); 
                return (data_item, data_item_description, length_octets, Time_of_Day);
            }

            //Target Report Descriptor
            if (fspecAnalayzedByte == 0 && fspecAnalyzedBit == 2)
            {
                string data_item = "I048/020";
                string data_item_description = "Target Report Descriptor";

                
                int length_octets = 1;
                int byteIndex = 0;
                while (byteIndex < 2)
                {
                    int ultimBit = data[octetanalyzed + byteIndex] % 2;
                    

                    if (ultimBit == 1)
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
                        else 
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
                int bit = data[octetanalyzed + 1] % 2;


                if (bit == 1)
                {
                    length_octets = 2;
                }

                DataTable trackStatus = TrackStatus(data, octetanalyzed);

                return (data_item, data_item_description, length_octets, trackStatus);
            }

            //fi segon octet

            

            //Height Measured by 3D Radar
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 4)
            {
                string data_item = "I048/110";
                string data_item_description = "Height Measured by 3D Radar";
                int length_octets = 2;
                DataTable height3DRadar = Height3DRadar(data[octetanalyzed], data[octetanalyzed + 1]);
                return (data_item, data_item_description, length_octets, height3DRadar);
            }

            

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

            

            //Special Purpose Field
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 5)
            {
                string data_item = "SP-Data Item";
                string data_item_description = "Special Purpose Field";

            }

            //Reserved Expansion Field
            if (fspecAnalayzedByte == 2 && fspecAnalyzedBit == 6)
            {
                string data_item = "RE-Data Item";
                string data_item_description = "Reserved Expansion Field";
               
            }
            return ("", "", 0, dt);
        }

        public static DataTable DataSourceIdentifier(byte byte1, byte byte2)
        {
            //SAC
            string pathCSV = "SACdata.csv"; // Ruta del fitxer CSV
            int numeroDecimal = Convert.ToInt32(byte1);//passem byte a string
            string numDecimalString = Convert.ToString(numeroDecimal);

            int SAC;
            int SIC;
            
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
            string TimeOfDayString = Convert.ToString((byte1 << 16) | (byte2 << 8) | byte3, 2);
            double TimeOfDay = Convert.ToInt32(TimeOfDayString, 2);
            TimeOfDay = TimeOfDay / 128;
            TimeSpan time = TimeSpan.FromSeconds(TimeOfDay);
            string TODstr = time.ToString(@"hh\:mm\:ss\:fff");

            DataTable dt = new DataTable();
            dt.Columns.Add("Time of day (seconds)", typeof(string));
            dt.Rows.Add(TODstr);
            return dt;
        }
        public static DataTable TargetReportDescriptor(byte[] data, int octetanalyzed, int length_octets)
        {
            string TYP = "N/A";
            string SIM = "N/A";
            string RDP = "N/A";
            string SPI = "N/A";
            string RAB = "N/A";
            string TST = "N/A";
            string ERR = "N/A";
            string XPP = "N/A";
            string ME = "N/A";
            string MI = "N/A";
            string FOE_FRI = "N/A";
            string ADSB_EP = "N/A";
            string ADSB_VAL = "N/A";
            string SCN_EP = "N/A";
            string SCN_VAL = "N/A";
            string PAI_EP = "N/A";
            string PAI_VAL = "N/A";

            if (length_octets >= 1)
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
                    TYP = "Single Mode S All-Call";
                }
                else if (TYP == "101")
                {
                    TYP = "Single Mode S Roll-Call";
                }
                else if (TYP == "110")
                {
                    TYP = "Mode S All-Call + PSR";
                }
                else if (TYP == "111")
                {
                    TYP = "Mode S Roll-Call + PSR";
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
            }

            if (length_octets >= 2)
            {
                octetanalyzed = octetanalyzed + 1;

                TST = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(0, 1);

                if (TST == "1")
                {
                    TST = "Test target report";
                }
                else
                {
                    TST = "Real target report";
                }

                ERR = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(1, 1);

                if (ERR == "1")
                {
                    ERR = "Extended Range present";
                }
                else
                {
                    ERR = "No Extended Range";
                }

                XPP = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(2, 1);

                if (XPP == "1")
                {
                    XPP = "X-Pulse present";
                }
                else
                {
                    XPP = "No X-Pulse present";
                }


                ME = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(3, 1);

                if (ME == "1")
                {
                    ME = "No Military emergency";
                }
                else
                {
                    ME = "Military emergency";
                }


                MI = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(4, 1);

                if (MI == "1")
                {
                    MI = "Report from field monitor(fixed transponder)";
                }
                else
                {
                    MI = "Report from aircraft transponder";
                }


                FOE_FRI = Convert.ToString(data[octetanalyzed + 1], 2).PadLeft(8, '0').Substring(5, 2);

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
            }

            if (length_octets >= 3)
            {
                ADSB_EP = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(0, 1);

                if (ADSB_EP == "1")
                {
                    ADSB_EP = "ADSB populated";
                }
                else
                {
                    ADSB_EP = "ADSB not populated";
                }

                ADSB_VAL = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(1, 1);

                if (ADSB_VAL == "1")
                {
                    ADSB_VAL = "Available";
                }
                else
                {
                    ADSB_VAL = "NoT  available";
                }

                ADSB_EP = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(2, 1);

                if (SCN_EP == "1")
                {
                    SCN_EP = "SCN populated";
                }
                else
                {
                    SCN_EP = "SCN not populated";
                }


                ADSB_EP = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(3, 1);

                if (SCN_VAL == "1")
                {
                    SCN_VAL = "Available";
                }
                else
                {
                    SCN_VAL = "Not available";
                }


                ADSB_EP = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(4, 1);

                if (PAI_EP == "1")
                {
                    PAI_EP = "PAI populated";
                }
                else
                {
                    PAI_EP = "PAI not populated";
                }


                ADSB_EP = Convert.ToString(data[octetanalyzed + 2], 2).PadLeft(8, '0').Substring(5, 1);

                if (PAI_VAL == "1")
                {
                    PAI_VAL = "Available";
                }
                else
                {
                    PAI_VAL = "Not available";
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
            dt.Columns.Add("ADSB_EP", typeof(string));
            dt.Columns.Add("ADSB_VAL", typeof(string));
            dt.Columns.Add("SCN_EP", typeof(string));
            dt.Columns.Add("SCN_VAL", typeof(string));
            dt.Columns.Add("PAI_EP", typeof(string));
            dt.Columns.Add("PAI_VAL", typeof(string));

            dt.Rows.Add(TYP, SIM, RDP, SPI, RAB, TST, ERR, XPP, ME, MI, FOE_FRI, ADSB_EP, ADSB_VAL, SCN_EP, SCN_VAL, PAI_EP, PAI_VAL);

            return dt;
        }
        public static DataTable SlantPolarCoordinates(byte byte1, byte byte2, byte byte3, byte byte4)
        {

            string binaryRHO = Convert.ToString(((byte1 << 8) | byte2), 2);

            double RHO = Convert.ToInt32(binaryRHO, 2) * 0.00390625; ;

            string RawTHETA = Convert.ToString(((byte3 << 8) | byte4), 2);
            double THETA = Convert.ToInt32(RawTHETA, 2) * 0.00549316406;

            DataTable dt = new DataTable();

            dt.Columns.Add("Rho", typeof(double));
            dt.Columns.Add("Theta", typeof(double));
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

            string Mode3A = (A.ToString() + B.ToString() + C.ToString() + D.ToString());

            dt.Rows.Add(V, G, L, Mode3A);

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
            double? PRL = null;
            double? PAM = null;
            double? RPD = null;
            double? APD = null;

            for (int index = 0; index < subfields.Count; index++)
            {
                string Byte = Convert.ToString(data[octetanalyzed++ + 1], 2).PadLeft(8, '0');


                if (subfields[index] == "0") // Corresponding to subfield 1 (SSR plot runlength)
                {
                    SRL = Convert.ToInt32(Byte, 2) * (360 / Math.Pow(2, 13));
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
                    PRL = Convert.ToInt32(Byte, 2) * (360 / Math.Pow(2, 13));
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
                    APD = ComplementADos(Byte) * (360 / Math.Pow(2, 14));
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

            string SelectedAltitude_Status = "N/A";
            int? SelectedAltitude = null;
            string FMSAltitude_Status = "N/A";
            int? FMSAltitude = null;
            string BaroSetting_Status = "N/A";
            double? BaroSetting = null;
            string MCP_FCU_MODE_BITS_Status = "N/A";
            string VNAV = "N/A";
            string AltHoldMode = "N/A";
            string ApprMode = "N/A";
            string TargetAltitudeSource_Status = "N/A";
            string TargetAltitudeSource = "N/A";



            string RollAngle_Status = "N/A";
            string TrueTrackAngle_Status = "N/A";
            string GS_Status = "N/A";
            string TrackAngleRate_Status = "N/A";
            string TAS_Status = "N/A";
            string LWingD = "N/A";
            double? RollAngle = null;
            double? West = null;
            double? TrueTrackAngle = null;
            double? GS = null;
            double? TrackAngleRate = null;
            double? TAS = null;


            string MagneticHeading_Status = "N/A";
            string IndicatedAirspeed_Status = "N/A";
            string Mach_Status = "N/A";
            string BaromAltRate_Status = "N/A";
            string InertialVertVel_Status = "N/A";
            double? MagneticHeading = null;
            double? IndicatedAirspeed = null;
            double? Mach = null;
            double? BaromAltRate = null;
            string Below = "N/A";
            double? InertialVertVel = null;

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
            string GSsting = Convert.ToString(((byte1 << 8) | byte2), 2);
            double GroundSpeed = Convert.ToInt32(GSsting, 2);
            GroundSpeed = GroundSpeed * 0.22;

            string HeadingString = Convert.ToString(((byte3 << 8) | byte4), 2);
            double Heading = Convert.ToInt32(HeadingString, 2);
            Heading = Heading * 360 / (Math.Pow(2, 16));

            DataTable dt = new DataTable();

            dt.Columns.Add("Ground Speed", typeof(double));
            dt.Columns.Add("Heading", typeof(double));
            dt.Rows.Add(GroundSpeed, Heading);

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
            string B1A = "N/A";
            if (bit12 == 0)
            {
                B1A = "0";
            }
            else if (bit12 == 1)
            {
                B1A = "1";
            }

            //bits 13-16
            int bit13to16 = Convert.ToInt32(bits.Substring(12, 3), 2);
            string B1B = bits.Substring(12, 4).PadLeft(4, '0');


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

            string TRE = "N/A";
            string GHO = "N/A";
            string SUP = "N/A";
            string TCC = "N/A";

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
        public static DataTable LatLong(DataTable dt)
        {
            //(ρ, Az, El) _ (XL, YL, ZL) _ (Xg, Yg, Zg) _ (L, G, H) 

            // We obtain the radar latitude and longitude in degrees

            // Both positive as are in the N and E sector

            string RadLat = (41 + (18.0 / 60.0) + (2.5284 / 3600.0)).ToString();
            string RadLong = (2 + (6.0 / 60.0) + (7.4095 / 3600.0)).ToString();

            double Elevation = 2.007;
            double antennaHeight = 25.25;
            double earthRadius = 6371000.0;

            CoordinatesWGS84 radPos = new CoordinatesWGS84(RadLat, RadLong, antennaHeight + Elevation);


            // Convert from cartesian to spherical

            List<string> Lat = new List<string>();
            List<string> Long = new List<string>();
            List<string> geoAltitude = new List<string>();

            double sphericAzimuth = 0;
            double sphericRange = 0;
            double sphericElevation = 0;
            GeoUtils GeoUtils = new GeoUtils();

            foreach (DataRow row in dt.Rows)
            {
                double Altitude = 0;
                if (row["Corrected Altitude"] != "N/A")
                {
                    Altitude = Convert.ToDouble(row["Corrected Altitude"]);
                }
                else if (row["Flight Level"] != DBNull.Value)
                {
                    Altitude = Convert.ToDouble(row["Flight Level"]) * 100 * 0.3048;
                }
                if (row["Rho"] != DBNull.Value & row["Theta"] != DBNull.Value)
                {
                    //Convert to Cartesian
                    double x = Convert.ToDouble(row["Rho"]) * Math.Sin(Convert.ToDouble(row["Theta"]) * Math.PI / 180.0) * 1852.0;
                    double y = Convert.ToDouble(row["Rho"]) * Math.Cos(Convert.ToDouble(row["Theta"]) * Math.PI / 180.0) * 1852.0;

                    // Convert to radar spherical
                    sphericAzimuth = GeoUtils.CalculateAzimuth(x, y);
                    double range = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                    sphericRange = range;
                    sphericElevation = Math.Asin((2 * earthRadius * (Altitude - (antennaHeight + Elevation)) + Altitude * Altitude - (antennaHeight + Elevation) * (antennaHeight + Elevation) - range * range) / (2 * range * (earthRadius + antennaHeight + Elevation)));

                    // Convert to radar cartesian
                    double XL = sphericRange * Math.Cos(sphericElevation) * Math.Sin(sphericAzimuth);
                    double YL = sphericRange * Math.Cos(sphericElevation) * Math.Cos(sphericAzimuth);
                    double ZL = sphericRange * Math.Sin(sphericElevation);
                    CoordinatesXYZ cartesianCoords = new CoordinatesXYZ(XL, YL, ZL);

                    //Convert to geocentric radar 
                    CoordinatesXYZ geocentricCoords = GeoUtils.change_radar_cartesian2geocentric(radPos, cartesianCoords);

                    //Transform to geodesic
                    CoordinatesWGS84 LatLong = GeoUtils.change_geocentric2geodesic(geocentricCoords);

                    Lat.Add(Convert.ToString(LatLong.Lat * 180 / Math.PI));
                    Long.Add(Convert.ToString(LatLong.Lon * 180 / Math.PI));
                    geoAltitude.Add(Convert.ToString(LatLong.Height));

                }
                else
                {
                    Lat.Add("N/A");
                    Long.Add("N/A");
                    geoAltitude.Add("N/A");
                }

            }

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                dt.Rows[index]["latitud"] = Lat[index];
                dt.Rows[index]["longitud"] = Long[index];
                dt.Rows[index]["hwgs84"] = geoAltitude[index];
            }

            return dt;


        }
        public static DataTable Corrected_Altitude(DataTable dt)
        {
            List<string> Altitude_m = new List<string>();
            double baroPressureAnt = Convert.ToDouble(dt.Rows[1]["BaroSetting"]); 
            foreach (DataRow row in dt.Rows)
            {
                if ((row["Flight Level"] != DBNull.Value) & (row["BaroSetting"] != DBNull.Value))
                {


                    double FL = Convert.ToDouble(row["Flight Level"]);
                    double baroPressure = Convert.ToDouble(row["BaroSetting"]);
                    double standPress = 1013.25;
                    double standPressMin = 1013;
                    double standPressMax = 1013.3;

                    double Altitude = 0.0;

                    if (((baroPressure <= standPressMax) && (baroPressure >= standPressMin)) || baroPressure == 0)
                    {
                        if (FL <= 60) 
                        {
                            baroPressure = baroPressureAnt;
                            Altitude = FL * 100.0 + (baroPressure - standPress) * 30.0;
                        }
                        else if (FL > 60)
                        {
                            Altitude = FL * 100.0; // NO POSAR >60
                        }
                    }
                    else if (((baroPressure > standPressMax) || (baroPressure < standPressMin)) || baroPressure != 0)
                    {
                        if (FL <= 60) 
                        {
                            Altitude = FL * 100.0 + (baroPressure - standPress) * 30.0;
                        }
                        else if (FL > 60)
                        {
                            Altitude = FL * 100.0; 
                        }
                    }

                    // Save the previous value
                    baroPressureAnt = Convert.ToDouble(row["BaroSetting"]);

                    //Add it to the list
                    Altitude_m.Add(Convert.ToString(Altitude * 0.3048));
                }
                else
                {
                    Altitude_m.Add("N/A");
                }
            }

            int index = 0;
            foreach (string element in Altitude_m)
            {
                dt.Rows[index]["Corrected Altitude"] = element;
                index++;
            }

            return dt;

        }


    }
}

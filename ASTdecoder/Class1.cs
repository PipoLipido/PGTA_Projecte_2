using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTdecoder
{
    public class CAT
    {
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
        public string FL  { get; set; }

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

    //public class AsterixData
    //{
    //    public int Mode3A { get; set; }
    //    public int TimeOfDay { get; set; }
    //    public int FlightLevel { get; set; }
    //}

    public class AsterixDecoder
    {
        public static List<CAT> ParseAsterixCat48(byte[] data)
        {
            List<CAT> results = new List<CAT>();



            int indexByte = 0;

            while (indexByte < data.Length) //en comptes de mirar totes les dades com un sol vector format per tots els missatges junts, separem missatge per missatge.
            {

                if (data[indexByte] != 48) // Comprovar si és Categoria 48
                {
                    indexByte++;
                    continue;
                    
                }

                CAT record = new CAT();
                //record.DSI = data[indexByte];

                int length = (data[indexByte + 1] << 8) | data[indexByte + 2];
                record.lenght = data[indexByte + 1] | data[indexByte + 2]; //Longitud total en octets de 1 avió

                // while per mirar quants octets ocupa fspec, per poder separar fspec de la resta i mirar quines categories estan incloses
                int lastFspecByte = 0; 
                bool indexfound = false;
                List<byte> fspec = new List<byte>();

                while (indexfound == false)
                {
                    int bit= (data[indexByte + 3 + lastFspecByte] >> 7) & 1;
                    if (bit == 0)
                    {
                        indexfound = true;
                    }
                    fspec.Add(data[indexByte + 3 + lastFspecByte]);
                    lastFspecByte++;
                }

                record.fspeclength = lastFspecByte;


                //a partir d'aqui ja no ho he tocat res



                //primer byte
                int fspecAnalyzedByte = 0;
                int octetanalyzed = 3 + record.fspeclength;
                while (fspecAnalyzedByte < record.fspeclength) //itera el fspec mirant quins son 1 i quins 0
                {
                    int fspecAnalyzedBit = 1;
                    while (fspecAnalyzedBit < 7)
                    {

                        if ((fspec[fspecAnalyzedByte] & (1 << fspecAnalyzedBit)) != 0) // if per comprovar si la component de l'fspec és un 1
                        {
                            var resultDataItem = I048_data_items.data_items.GetDataItem(fspecAnalyzedBit, fspecAnalyzedByte, data, record.fspeclength, octetanalyzed); // (index de l'octet, octet de l'fspec que toca,  
                            octetanalyzed = octetanalyzed + resultDataItem.Item3;

                            //lector taula
                        }
                        fspecAnalyzedBit++;
                    }
                    fspecAnalyzedByte++;
                }

                taula(Fila, ...) =

                Fila + 1;

                // D'aqui cap abaix codi a esborrar quan l'haguem acabat de fer servir

                ////byte fspec = data[index + 3]; // No hauriem de tenir en compte els FX?

                //index += 4;



                //// Comprovar si Data Source Identifier està present (bit 1 de FSPEC)
                //if ((fspec & 0b10000000) != 0)

                //{
                //    record.SAC = Convert.ToString(data[index], 2).PadLeft(8, '0');
                //    record.SIC = Convert.ToString(data[index + 1], 2).PadLeft(8, '0');

                //    index += 2;
                //}

                //// Comprovar si Time of Day està present (bit 2 de FSPEC)
                //if ((fspec & 0b01000000) != 0)
                //{

                //    record.hour_of_day = Convert.ToString(data[index], 2).PadLeft(8, '0') + Convert.ToString(data[index + 1], 2).PadLeft(8, '0');
                //    record.seconds = Convert.ToString(data[index + 2], 2).PadLeft(8, '0');
                //    index += 3;
                //}


                //// Comprovar si Target Report Descriptor està present (bit 3 de FSPEC)
                //if ((fspec & 0b00100000) != 0)

                //{


                //    // revisar l'ultim bit (podria ser expansible)
                //    string TRD_octets = Convert.ToString(data[index], 2).PadLeft(8, '0');
                //    bool FX = Convert.ToBoolean(TRD_octets.Substring(7, 1)); ;

                //    if (FX == false)

                //    {
                //        record.TYP = TRD_octets.Substring(0, 3);
                //        record.SIM = TRD_octets.Substring(4, 1);
                //        record.RDP = TRD_octets.Substring(5, 1);
                //        record.SPI = TRD_octets.Substring(6, 1);
                //        record.RAB = TRD_octets.Substring(7, 1);

                //        index += 1;
                //    }

                //    else

                //    {
                //        record.TST = TRD_octets.Substring(0, 3);
                //        record.ERR = TRD_octets.Substring(1, 1);
                //        record.XPP = TRD_octets.Substring(2, 1);
                //        record.ME = TRD_octets.Substring(3, 1);
                //        record.MI = TRD_octets.Substring(4, 1);
                //        record.FOE_FRI = TRD_octets.Substring(5, 2);
                //        record.MI = TRD_octets.Substring(7, 1);

                //        TRD_octets = Convert.ToString(data[index], 2).PadLeft(8, '0');

                //        record.ADSB = TRD_octets.Substring(0, 3);
                //        record.ADSB_EP = TRD_octets.Substring(1, 1);
                //        record.ADSB_VAL = TRD_octets.Substring(2, 1);
                //        record.SCN = TRD_octets.Substring(3, 1);
                //        record.SCN_EP = TRD_octets.Substring(4, 1);
                //        record.SCN_VAL = TRD_octets.Substring(5, 2);
                //        record.PAI_VAL = TRD_octets.Substring(7, 1);

                //        index += 2;
                //    }


                //}

                //            // Comprovar si Measured Position in Slant Polar Coordinates està present (bit 5 de FSPEC)

                //            if ((fspec & 0b00010000) != 0)

                //            {
                //                string RHO = Convert.ToString(data[index], 2).PadLeft(8, '0') + Convert.ToString(data[index + 1], 2).PadLeft(8, '0');
                //                string THETA = Convert.ToString(data[index + 2], 2).PadLeft(8, '0') + Convert.ToString(data[index + 3], 2).PadLeft(8, '0');

                //                record.V = RHO.Substring(0, 7); //el 8e es el LSB range
                //                record.G = THETA.Substring(8, 7); //el 16e es el LSB angle

                //                index += 4;
                //            }

                //            // Comprovar si Mode-3/A Code està present (bit 5 de FSPEC)
                //            if ((fspec & 0b00001000) != 0)

                //            {
                //                string M3A_octets = Convert.ToString(data[index], 2).PadLeft(8, '0') + Convert.ToString(data[index + 1], 2).PadLeft(8, '0');

                //                record.V = M3A_octets.Substring(0, 1);
                //                record.G = M3A_octets.Substring(1, 1);
                //                record.L = M3A_octets.Substring(2, 1);

                //                record.A = M3A_octets.Substring(3, 3);
                //                record.B = M3A_octets.Substring(6, 3);
                //                record.C = M3A_octets.Substring(9, 3);
                //                record.D = M3A_octets.Substring(12, 3);


                //                index += 2;
                //            }

                //            // Comprovar si Flight Level està present (bit 6 de FSPEC)
                //            if ((fspec & 0b00000100) != 0)
                //            {
                //                string FL_octets = Convert.ToString(data[index], 2).PadLeft(8, '0') + Convert.ToString(data[index + 1], 2).PadLeft(8, '0');

                //                record.FL = FL_octets.Substring(2, 14);
                //                record.V_FL = FL_octets.Substring(0, 1);
                //                record.G_FL = FL_octets.Substring(1, 1);

                //                index += 2;
                //            }

                //            results.Add(record);
                //            index += length - 4; // Saltar a la següent dada



                //            //if (data[index + 1] != 0)
                //            //{
                //            //length = (data[index + 1] << 8) | data[index + 2];
                //            //}
                //            // else
                //            //{
                //            //break;
                //            //}

            }

            return results;
        }
    }
}

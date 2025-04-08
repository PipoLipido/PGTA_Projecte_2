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
            List<CAT> results = new List<CAT>();

            DataTable dtMain = new DataTable();



            int indexByte = 0;

            while (indexByte < data.Length) //en comptes de mirar totes les dades com un sol vector format per tots els missatges junts, separem missatge per missatge.
            {
                DataTable dtNonCompressed = new DataTable();
                int octetanalyzed = indexByte;

                if (data[indexByte] != 48) // Comprovar si és Categoria 48
                {
                    indexByte++;
                    continue;
                }

                CAT record = new CAT();
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
                while (fspecAnalyzedByte < record.fspeclength) //itera el fspec mirant quins son 1 i quins 0
                {
                    int fspecAnalyzedBit = 0;
                    while (fspecAnalyzedBit < 7)
                    {
                        if (fspec[fspecAnalyzedByte].Substring(fspecAnalyzedBit, 1) != "0") // if per comprovar si la component de l'fspec és un 1, desplaçem a la esquerra el numero 1 tantes vegades com fspecAnalyzedBit
                        {
                            var resultDataItem = I048_data_items.data_items.GetDataItem(fspecAnalyzedBit, fspecAnalyzedByte, data, record.fspeclength, octetanalyzed); // (index de l'octet, octet de l'fspec que toca,  
                            octetanalyzed = octetanalyzed + resultDataItem.Item3;
                            dtNonCompressed.Merge(resultDataItem.Item4);
                            
                        }
                        fspecAnalyzedBit++;
                    }
                    fspecAnalyzedByte++;
                }
                octetanalyzed = octetanalyzed - 3 - record.fspeclength;
                //Compressor
                List<string> valorsUnificats = new List<string>();

                foreach (DataRow fila in dtNonCompressed.Rows)
                {
                    foreach (var valor in fila.ItemArray)
                    {
                        if (valor != null && !string.IsNullOrWhiteSpace(valor.ToString()))
                        {
                            valorsUnificats.Add(valor.ToString());
                        }
                    }
                }

                for (int i = 0; i < valorsUnificats.Count; i++)
                {
                    if (!dtMain.Columns.Contains(dtNonCompressed.Columns[i].ColumnName))
                    {
                        dtMain.Columns.Add(dtNonCompressed.Columns[i].ColumnName);
                    }
                    //dtMain.Columns.Add(dtNonCompressed.Columns[i].ColumnName);
                }

                // Afegim la fila amb els valors
                dtMain.Rows.Add(valorsUnificats.ToArray());

                indexByte = indexByte + record.lenght;
            }
            if (!dtMain.Columns.Contains("Index"))
            {
                dtMain.Columns.Add("Index", typeof(int));
            }
            for (int i = 0; i < dtMain.Rows.Count; i++)
            {
                dtMain.Rows[i]["Index"] = i + 1; // o només 'i' si vols començar a 0
            }


            return results;
        }
    }
}

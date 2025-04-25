using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASTdecoder;
using System.IO;
using System.Globalization;



namespace Consola_projecte2
{
    public partial class MainConsole : Form
    {
        DataTable dt = new DataTable();
        public MainConsole()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void show_data_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Fitxers ASTERIX (*.bin)|*.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] fileData = File.ReadAllBytes(openFileDialog.FileName);
                List<CAT> result = AsterixDecoder.ParseAsterixCat48(fileData);

                int indexSeleccionat = 0; 
                dt = result[indexSeleccionat].dt;

                // Afegim columnes extres
                dt = I048_data_items.data_items.Corrected_Altitude(dt);
                dt = I048_data_items.data_items.LatLong(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void label_test_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Map_Click(object sender, EventArgs e)
        {
            
            mapconsole mapconsole = new mapconsole(dt);
            mapconsole.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PureTargetButton_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                DataTable PureTargetTable = dt;
                List<DataRow> EliminatedRows = new List<DataRow>();

                foreach (DataRow row in PureTargetTable.Rows)
                {
                    if (row["TYP"].ToString() != "Single Mode S All-Call" & row["TYP"].ToString() != "Single Mode S Roll-Call" & row["TYP"].ToString() != "Mode S All-Call + PSR" &
                        row["TYP"].ToString() != "Mode S Roll-Call + PSR")
                    {
                        EliminatedRows.Add(row);
                    }
                }

                foreach (DataRow row in EliminatedRows)
                {
                    PureTargetTable.Rows.Remove(row);
                }

                dataGridView1.DataSource = PureTargetTable;
            }
        }

        private void LLFilter_Click(object sender, EventArgs e)
        {
            DataTable LatLongLimited = dt;
            List<DataRow> EliminatedRows = new List<DataRow>();

            double maxLatitud = 360;
            double minLatitud = 0;
            double maxLongitud = 360;
            double minLongitud = 0;

            if (MaxLat.Text != "" && MinLat.Text != "")
            {
                maxLatitud = Convert.ToDouble(MaxLat.Text); // en graus
                minLatitud = Convert.ToDouble(MinLat.Text); // en graus
            }
            else if ((MaxLong.Text != "" && MaxLong.Text != ""))
            {
                maxLongitud = Convert.ToDouble(MaxLong.Text); // en graus
                minLongitud = Convert.ToDouble(MinLong.Text); // en graus
            }
            else
            {
                MessageBox.Show("Debe introducir el intervalo deseado para el filtro");
                return;
            }


            if ((minLatitud < maxLatitud) && (minLongitud < maxLongitud))
            {
                foreach (DataRow row in LatLongLimited.Rows)
                {
                    string Lat = Convert.ToString(row["latitud"]).Replace(',', '.');
                    string Lon = Convert.ToString(row["longitud"]).Replace(',', '.');

                    if (Lat == "N/A" || Lon == "N/A")
                    {
                        EliminatedRows.Add(row);
                    }

                    else if (Convert.ToDouble(Lat) <= minLatitud || Convert.ToDouble(Lat) >= maxLatitud || Convert.ToDouble(Lon) <= minLongitud || Convert.ToDouble(Lon) >= maxLongitud)
                    {
                        EliminatedRows.Add(row);
                    }
                }

            }
            else
            {
                foreach (DataRow row in LatLongLimited.Rows)
                {
                    string Lat = Convert.ToString(row["latitud"]).Replace(',', '.');
                    string Lon = Convert.ToString(row["longitud"]).Replace(',', '.');

                    if (Lat == "N/A" || Lon == "N/A")
                    {
                        EliminatedRows.Add(row);
                    }

                    else if (Convert.ToDouble(Lat) <= maxLatitud || Convert.ToDouble(Lat) >= minLatitud || Convert.ToDouble(Lon) <= maxLongitud || Convert.ToDouble(Lon) >= minLongitud)
                    {
                        EliminatedRows.Add(row);
                    }
                }
            }



            foreach (DataRow row in EliminatedRows)
            {
                LatLongLimited.Rows.Remove(row);
            }

            dataGridView1.DataSource = LatLongLimited;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void MinLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLong.Text.Contains('.') && MinLong.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void MaxLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLong.Text.Contains('.') && MinLong.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void MinLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLong.Text.Contains('.') && MinLong.Text.Contains(','))
            {
                e.Handled = true;
            }

        }

        private void MaxLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLong.Text.Contains('.') && MinLong.Text.Contains(','))
            {
                e.Handled = true;
            }
        }
    }
}

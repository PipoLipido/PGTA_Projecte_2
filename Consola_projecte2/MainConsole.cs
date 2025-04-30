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
using MultiCAT6.Utils;


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
            label9.Text = "Loading file...";
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
                label9.Text = "File loaded succesfully";
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
                maxLatitud = Convert.ToDouble(MaxLat.Text, CultureInfo.InvariantCulture); // en graus
                minLatitud = Convert.ToDouble(MinLat.Text, CultureInfo.InvariantCulture); // en graus
            }
            if ((MaxLon.Text != "" && MaxLon.Text != ""))
            {
                maxLongitud = Convert.ToDouble(MaxLon.Text, CultureInfo.InvariantCulture); // en graus
                minLongitud = Convert.ToDouble(MinLon.Text, CultureInfo.InvariantCulture); // en graus
            }
            else if ((MaxLat.Text != "" && MinLat.Text != "") && (MaxLon.Text != "" && MaxLon.Text != ""))
            {
                MessageBox.Show("Debe introducir el intervalo deseado para el filtro");
                return;
            }


            if (minLatitud >= maxLatitud)
            {
                double old_minLatitud = minLatitud;
                minLatitud = maxLatitud;
                maxLatitud = old_minLatitud;

            }

            if (minLongitud >= maxLongitud)
            {
                double old_minLongitud = minLongitud;
                minLongitud = maxLongitud;
                maxLongitud = old_minLongitud;
            }


            foreach (DataRow row in LatLongLimited.Rows)
            {
                string Lat = Convert.ToString(row["latitud"]).Replace(',', '.');
                string Lon = Convert.ToString(row["longitud"]).Replace(',', '.');

                if (Lat == "N/A" || Lon == "N/A")
                {
                    EliminatedRows.Add(row);
                }

                else
                {
                    double Latd = Convert.ToDouble(Lat, CultureInfo.InvariantCulture);
                    double Lond = Convert.ToDouble(Lon, CultureInfo.InvariantCulture);

                    if ((Latd <= minLatitud || Latd >= maxLatitud) || (Lond <= minLongitud || Lond >= maxLongitud))
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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLon.Text.Contains('.') && MinLon.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void MaxLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLon.Text.Contains('.') && MinLon.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void MinLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLon.Text.Contains('.') && MinLon.Text.Contains(','))
            {
                e.Handled = true;
            }

        }

        private void MaxLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            //Unicament permetem numeros, no lletres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.' || e.KeyChar != ',') && MinLon.Text.Contains('.') && MinLon.Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void exportCSV_Click(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hi ha dades per exportar.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sep = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dlg.DefaultExt = "csv";
                dlg.FileName = "export.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // 1) Capçalera
                        int colCount = dt.Columns.Count;
                        for (int col = 0; col < colCount; col++)
                        {
                            sb.Append(Escape(dt.Columns[col].ColumnName));
                            if (col < colCount - 1)
                            {
                                sb.Append(sep);
                            }
                        }
                        sb.AppendLine();

                        // 2) Files
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int col = 0; col < colCount; col++)
                            {
                                sb.Append(Escape(row[col]?.ToString() ?? ""));
                                if (col < dt.Columns.Count - 1)
                                {
                                    sb.Append(sep);
                                }
                            }
                            sb.AppendLine();
                        }

                        // 3) Escriure a disc
                        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show($"Taula exportada correctament a:\n{dlg.FileName}",
                                        "Exportació completada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exportant CSV:\n{ex.Message}",
                                        "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private static string Escape(string s)
        {
            if (s.Contains("\"") || s.Contains(",") || s.Contains("\n") || s.Contains("\r"))
            {
                s = s.Replace("\"", "\"\"");
                return $"\"{s}\"";
            }
            return s;
        }

        private void exportCSV_Click_1(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hi ha dades per exportar.", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sep = CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dlg.DefaultExt = "csv";
                dlg.FileName = "export.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();

                        // 1) Capçalera
                        int colCount = dt.Columns.Count;
                        for (int col = 0; col < colCount; col++)
                        {
                            sb.Append(Escape(dt.Columns[col].ColumnName));
                            if (col < colCount - 1)
                            {
                                sb.Append(sep);
                            }
                        }
                        sb.AppendLine();

                        // 2) Files
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int col = 0; col < colCount; col++)
                            {
                                sb.Append(Escape(row[col]?.ToString() ?? ""));
                                if (col < dt.Columns.Count - 1)
                                {
                                    sb.Append(sep);
                                }
                            }
                            sb.AppendLine();
                        }

                        // 3) Escriure a disc
                        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show($"Taula exportada correctament a:\n{dlg.FileName}",
                                        "Exportació completada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exportant CSV:\n{ex.Message}",
                                        "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FixedTransponder_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                DataTable NonFixedTransponderTable = dt;
                List<DataRow> EliminatedRows = new List<DataRow>();

                foreach (DataRow row in NonFixedTransponderTable.Rows)
                {
                    if (row["Mode3A"].ToString() == "7777")
                    {
                        EliminatedRows.Add(row);
                    }
                }

                foreach (DataRow row in EliminatedRows)
                {
                    NonFixedTransponderTable.Rows.Remove(row);
                }

                dataGridView1.DataSource = NonFixedTransponderTable;
            }
        }

        private void ACOnGround_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                DataTable PureTargetTable = dt;
                List<DataRow> EliminatedRows = new List<DataRow>();

                foreach (DataRow row in PureTargetTable.Rows)
                {
                    if (row["STAT"].ToString() == "No alert, no SPI, aircraft on ground" & row["STAT"].ToString() == "Alert, no SPI, aircraft on ground")
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
    }
    
}

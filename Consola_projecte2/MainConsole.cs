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

    }
    
}

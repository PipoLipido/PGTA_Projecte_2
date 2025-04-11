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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consola_projecte2
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void startSoftware_Click(object sender, EventArgs e)
        {
            var mainConsole = new Consola_projecte2.MainConsole();
            mainConsole.Show();
        }

        private void ReadMe_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/PipoLipido/PGTA_Projecte_2"; 

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No s'ha pogut obrir el navegador:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        

        private void ASTERIXsample_Click(object sender, EventArgs e)
        {
            string url = "https://drive.google.com/drive/folders/1Sm9PgPPP7WfG49U7Ry5HqHNTiKtfmVKk?usp=drive_link";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No s'ha pogut obrir el navegador:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

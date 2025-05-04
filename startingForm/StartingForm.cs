using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace startingForm
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void startSoftware_Click(object sender, EventArgs e)
        {
            Consola_projecte2.MainConsole mainConsole = new Consola_projecte2.MainConsole();
            mainConsole.Show();
        }

        private void UploadAsterix_Click(object sender, EventArgs e)
        {

        }
    }
}

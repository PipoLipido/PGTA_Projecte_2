using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "1h")
            {
                try
                {
                    // 1) Ruta del fitxer “embegut” al costat de l'exe
                    string sourceFile = Path.Combine(
                        Application.StartupPath,
                        "230502-est-080001_BCN_60MN_08_09.ast"    // substitueix per el teu nom
                    );

                    if (!File.Exists(sourceFile))
                    {
                        MessageBox.Show(
                            $"No trobo el fitxer:\n{sourceFile}",
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                        return;
                    }

                    // 2) Carpeta Downloads de l'usuari
                    string downloads = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads"
                    );

                    // 3) Destí amb mateix nom
                    string destFile = Path.Combine(downloads, Path.GetFileName(sourceFile));

                    // 4) Copiem (sobreescrivint si ja hi és)
                    File.Copy(sourceFile, destFile, overwrite: true);

                    MessageBox.Show(
                        $"Fitxer desat correctament a:\n{destFile}",
                        "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error descarregant fitxer:\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }
            else if (comboBox1.SelectedItem == "4h")
            {
                try
                {
                    // 1) Ruta del fitxer “embegut” al costat de l'exe
                    string sourceFile = Path.Combine(
                        Application.StartupPath,
                        "230502-est-080001_BCN.ast"    // substitueix per el teu nom
                    );

                    if (!File.Exists(sourceFile))
                    {
                        MessageBox.Show(
                            $"No trobo el fitxer:\n{sourceFile}",
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                        return;
                    }

                    // 2) Carpeta Downloads de l'usuari
                    string downloads = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                        "Downloads"
                    );

                    // 3) Destí amb mateix nom
                    string destFile = Path.Combine(downloads, Path.GetFileName(sourceFile));

                    // 4) Copiem (sobreescrivint si ja hi és)
                    File.Copy(sourceFile, destFile, overwrite: true);

                    MessageBox.Show(
                        $"Fitxer desat correctament a:\n{destFile}",
                        "Done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Error descarregant fitxer:\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}

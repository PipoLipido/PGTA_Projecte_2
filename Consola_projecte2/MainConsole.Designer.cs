namespace Consola_projecte2
{
    partial class MainConsole
    {


        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.show_data = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Map = new System.Windows.Forms.Button();
            this.PureTargetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FixedTransponder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LLFilter = new System.Windows.Forms.Button();
            this.exportCSV = new System.Windows.Forms.Button();
            this.MinLat = new System.Windows.Forms.TextBox();
            this.MaxLat = new System.Windows.Forms.TextBox();
            this.MinLon = new System.Windows.Forms.TextBox();
            this.MaxLon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ACOnGround = new System.Windows.Forms.Button();
            this.Original = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label_test = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // show_data
            // 
            this.show_data.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.show_data.Location = new System.Drawing.Point(1351, 76);
            this.show_data.Name = "show_data";
            this.show_data.Size = new System.Drawing.Size(75, 23);
            this.show_data.TabIndex = 0;
            this.show_data.Text = "Show data";
            this.show_data.UseVisualStyleBackColor = false;
            this.show_data.Click += new System.EventHandler(this.show_data_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1217, 638);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Map.Location = new System.Drawing.Point(1345, 522);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(92, 24);
            this.Map.TabIndex = 3;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = false;
            this.Map.Click += new System.EventHandler(this.Map_Click);
            // 
            // PureTargetButton
            // 
            this.PureTargetButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PureTargetButton.Location = new System.Drawing.Point(1324, 185);
            this.PureTargetButton.Name = "PureTargetButton";
            this.PureTargetButton.Size = new System.Drawing.Size(149, 23);
            this.PureTargetButton.TabIndex = 4;
            this.PureTargetButton.Text = "Pure Target Filter";
            this.PureTargetButton.UseVisualStyleBackColor = false;
            this.PureTargetButton.Click += new System.EventHandler(this.PureTargetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1265, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Selection:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1265, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filters:";
            // 
            // FixedTransponder
            // 
            this.FixedTransponder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FixedTransponder.Location = new System.Drawing.Point(1324, 243);
            this.FixedTransponder.Name = "FixedTransponder";
            this.FixedTransponder.Size = new System.Drawing.Size(149, 23);
            this.FixedTransponder.TabIndex = 8;
            this.FixedTransponder.Text = "Fixed Transponder Filter";
            this.FixedTransponder.UseVisualStyleBackColor = false;
            this.FixedTransponder.Click += new System.EventHandler(this.FixedTransponder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1276, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Simulation:";
            // 
            // LLFilter
            // 
            this.LLFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LLFilter.Location = new System.Drawing.Point(1325, 306);
            this.LLFilter.Name = "LLFilter";
            this.LLFilter.Size = new System.Drawing.Size(148, 23);
            this.LLFilter.TabIndex = 10;
            this.LLFilter.Text = "Lat/Long Filter";
            this.LLFilter.UseVisualStyleBackColor = false;
            this.LLFilter.Click += new System.EventHandler(this.LLFilter_Click);
            // 
            // exportCSV
            // 
            this.exportCSV.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.exportCSV.Location = new System.Drawing.Point(1358, 592);
            this.exportCSV.Margin = new System.Windows.Forms.Padding(2);
            this.exportCSV.Name = "exportCSV";
            this.exportCSV.Size = new System.Drawing.Size(55, 25);
            this.exportCSV.TabIndex = 11;
            this.exportCSV.Text = "CSV";
            this.exportCSV.UseVisualStyleBackColor = false;
            this.exportCSV.Click += new System.EventHandler(this.exportCSV_Click_1);
            // 
            // MinLat
            // 
            this.MinLat.Location = new System.Drawing.Point(1345, 374);
            this.MinLat.Margin = new System.Windows.Forms.Padding(2);
            this.MinLat.Name = "MinLat";
            this.MinLat.Size = new System.Drawing.Size(50, 20);
            this.MinLat.TabIndex = 12;
            // 
            // MaxLat
            // 
            this.MaxLat.Location = new System.Drawing.Point(1433, 373);
            this.MaxLat.Margin = new System.Windows.Forms.Padding(2);
            this.MaxLat.Name = "MaxLat";
            this.MaxLat.Size = new System.Drawing.Size(48, 20);
            this.MaxLat.TabIndex = 13;
            // 
            // MinLon
            // 
            this.MinLon.Location = new System.Drawing.Point(1345, 396);
            this.MinLon.Margin = new System.Windows.Forms.Padding(2);
            this.MinLon.Name = "MinLon";
            this.MinLon.Size = new System.Drawing.Size(50, 20);
            this.MinLon.TabIndex = 14;
            // 
            // MaxLon
            // 
            this.MaxLon.Location = new System.Drawing.Point(1433, 396);
            this.MaxLon.Margin = new System.Windows.Forms.Padding(2);
            this.MaxLon.Name = "MaxLon";
            this.MaxLon.Size = new System.Drawing.Size(48, 20);
            this.MaxLon.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1355, 351);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1276, 400);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Lon:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1276, 377);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Lat:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1441, 351);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max";
            // 
            // ACOnGround
            // 
            this.ACOnGround.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACOnGround.Location = new System.Drawing.Point(1324, 214);
            this.ACOnGround.Name = "ACOnGround";
            this.ACOnGround.Size = new System.Drawing.Size(148, 23);
            this.ACOnGround.TabIndex = 23;
            this.ACOnGround.Text = "Delete Aircrafts on ground";
            this.ACOnGround.UseVisualStyleBackColor = false;
            // 
            // Original
            // 
            this.Original.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Original.Location = new System.Drawing.Point(1346, 433);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(122, 23);
            this.Original.TabIndex = 22;
            this.Original.Text = "Recover original";
            this.Original.UseVisualStyleBackColor = false;
            this.Original.Click += new System.EventHandler(this.Original_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1277, 596);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Export as:";
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_test.Location = new System.Drawing.Point(49, 9);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(40, 16);
            this.label_test.TabIndex = 1;
            this.label_test.Text = "Data";
            this.label_test.Click += new System.EventHandler(this.label_test_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(514, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 242);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1314, 378);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "from";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1314, 400);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "from";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1407, 398);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "to";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1407, 380);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "to";
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1540, 710);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Original);
            this.Controls.Add(this.ACOnGround);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaxLon);
            this.Controls.Add(this.MinLon);
            this.Controls.Add(this.MaxLat);
            this.Controls.Add(this.MinLat);
            this.Controls.Add(this.exportCSV);
            this.Controls.Add(this.LLFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FixedTransponder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PureTargetButton);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_test);
            this.Controls.Add(this.show_data);
            this.Name = "MainConsole";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button show_data;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Map;
        private System.Windows.Forms.Button PureTargetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LatLongFilter;
        private System.Windows.Forms.Button FixedTransponder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Original;
        private System.Windows.Forms.Button LLFilter;
        private System.Windows.Forms.Button exportCSV;
        private System.Windows.Forms.TextBox MinLat;
        private System.Windows.Forms.TextBox MaxLat;
        private System.Windows.Forms.TextBox MinLon;
        private System.Windows.Forms.TextBox MaxLon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ACOnGround;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_test;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        //private System.Windows.Forms.Button exportCSV;
    }
}


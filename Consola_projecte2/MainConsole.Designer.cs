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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // show_data
            // 
            this.show_data.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.show_data.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.show_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_data.Location = new System.Drawing.Point(144, 53);
            this.show_data.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.show_data.Name = "show_data";
            this.show_data.Size = new System.Drawing.Size(191, 52);
            this.show_data.TabIndex = 0;
            this.show_data.Text = "Show data";
            this.show_data.UseVisualStyleBackColor = false;
            this.show_data.Click += new System.EventHandler(this.show_data_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-3, -2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1629, 878);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.White;
            this.Map.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Map.Location = new System.Drawing.Point(141, 633);
            this.Map.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(200, 46);
            this.Map.TabIndex = 3;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = false;
            this.Map.Click += new System.EventHandler(this.Map_Click);
            // 
            // PureTargetButton
            // 
            this.PureTargetButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PureTargetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PureTargetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PureTargetButton.Location = new System.Drawing.Point(143, 169);
            this.PureTargetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PureTargetButton.Name = "PureTargetButton";
            this.PureTargetButton.Size = new System.Drawing.Size(199, 47);
            this.PureTargetButton.TabIndex = 4;
            this.PureTargetButton.Text = "Pure Target Filter";
            this.PureTargetButton.UseVisualStyleBackColor = false;
            this.PureTargetButton.Click += new System.EventHandler(this.PureTargetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.label2.Location = new System.Drawing.Point(39, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filters:";
            // 
            // FixedTransponder
            // 
            this.FixedTransponder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FixedTransponder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FixedTransponder.Location = new System.Drawing.Point(141, 276);
            this.FixedTransponder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FixedTransponder.Name = "FixedTransponder";
            this.FixedTransponder.Size = new System.Drawing.Size(200, 47);
            this.FixedTransponder.TabIndex = 8;
            this.FixedTransponder.Text = "Fixed Transponder Filter";
            this.FixedTransponder.UseVisualStyleBackColor = false;
            this.FixedTransponder.Click += new System.EventHandler(this.FixedTransponder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 609);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Simulation:";
            // 
            // LLFilter
            // 
            this.LLFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LLFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LLFilter.Location = new System.Drawing.Point(141, 330);
            this.LLFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LLFilter.Name = "LLFilter";
            this.LLFilter.Size = new System.Drawing.Size(200, 46);
            this.LLFilter.TabIndex = 10;
            this.LLFilter.Text = "Lat/Long Filter";
            this.LLFilter.UseVisualStyleBackColor = false;
            this.LLFilter.Click += new System.EventHandler(this.LLFilter_Click);
            // 
            // exportCSV
            // 
            this.exportCSV.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.exportCSV.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportCSV.Location = new System.Drawing.Point(143, 810);
            this.exportCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exportCSV.Name = "exportCSV";
            this.exportCSV.Size = new System.Drawing.Size(199, 46);
            this.exportCSV.TabIndex = 11;
            this.exportCSV.Text = "CSV";
            this.exportCSV.UseVisualStyleBackColor = false;
            this.exportCSV.Click += new System.EventHandler(this.exportCSV_Click_1);
            // 
            // MinLat
            // 
            this.MinLat.Location = new System.Drawing.Point(159, 425);
            this.MinLat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinLat.Name = "MinLat";
            this.MinLat.Size = new System.Drawing.Size(65, 22);
            this.MinLat.TabIndex = 12;
            // 
            // MaxLat
            // 
            this.MaxLat.Location = new System.Drawing.Point(276, 423);
            this.MaxLat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaxLat.Name = "MaxLat";
            this.MaxLat.Size = new System.Drawing.Size(63, 22);
            this.MaxLat.TabIndex = 13;
            // 
            // MinLon
            // 
            this.MinLon.Location = new System.Drawing.Point(159, 452);
            this.MinLon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinLon.Name = "MinLon";
            this.MinLon.Size = new System.Drawing.Size(65, 22);
            this.MinLon.TabIndex = 14;
            // 
            // MaxLon
            // 
            this.MaxLon.Location = new System.Drawing.Point(276, 452);
            this.MaxLon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaxLon.Name = "MaxLon";
            this.MaxLon.Size = new System.Drawing.Size(63, 22);
            this.MaxLon.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(67, 457);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Lon:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Lat:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max";
            // 
            // ACOnGround
            // 
            this.ACOnGround.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACOnGround.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ACOnGround.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACOnGround.Location = new System.Drawing.Point(144, 223);
            this.ACOnGround.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ACOnGround.Name = "ACOnGround";
            this.ACOnGround.Size = new System.Drawing.Size(197, 46);
            this.ACOnGround.TabIndex = 23;
            this.ACOnGround.Text = "Delete Aircrafts on ground";
            this.ACOnGround.UseVisualStyleBackColor = false;
            this.ACOnGround.Click += new System.EventHandler(this.ACOnGround_Click_1);
            // 
            // Original
            // 
            this.Original.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Original.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Original.Location = new System.Drawing.Point(141, 501);
            this.Original.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(203, 46);
            this.Original.TabIndex = 22;
            this.Original.Text = "Recover original";
            this.Original.UseVisualStyleBackColor = false;
            this.Original.Click += new System.EventHandler(this.Original_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 822);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Export as:";
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_test.Location = new System.Drawing.Point(65, 11);
            this.label_test.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(40, 16);
            this.label_test.TabIndex = 1;
            this.label_test.Text = "Data";
            this.label_test.Click += new System.EventHandler(this.label_test_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(685, 299);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 298);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(117, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "from";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "from";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 454);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "to";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 432);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "to";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.Original);
            this.panel1.Controls.Add(this.ACOnGround);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.MaxLon);
            this.panel1.Controls.Add(this.MinLon);
            this.panel1.Controls.Add(this.MaxLat);
            this.panel1.Controls.Add(this.MinLat);
            this.panel1.Controls.Add(this.exportCSV);
            this.panel1.Controls.Add(this.LLFilter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.FixedTransponder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PureTargetButton);
            this.panel1.Controls.Add(this.Map);
            this.panel1.Controls.Add(this.show_data);
            this.panel1.Location = new System.Drawing.Point(1623, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 4923);
            this.panel1.TabIndex = 33;
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(2053, 874);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_test);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainConsole";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        //private System.Windows.Forms.Button exportCSV;
    }
}


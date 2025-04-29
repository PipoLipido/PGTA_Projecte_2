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
            this.label_test = new System.Windows.Forms.Label();
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
            this.label8 = new System.Windows.Forms.Label();
            this.ACOnGround = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // show_data
            // 
            this.show_data.Location = new System.Drawing.Point(1342, 57);
            this.show_data.Name = "show_data";
            this.show_data.Size = new System.Drawing.Size(75, 23);
            this.show_data.TabIndex = 0;
            this.show_data.Text = "Show data";
            this.show_data.UseVisualStyleBackColor = true;
            this.show_data.Click += new System.EventHandler(this.show_data_Click);
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Location = new System.Drawing.Point(49, 9);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(30, 13);
            this.label_test.TabIndex = 1;
            this.label_test.Text = "Data";
            this.label_test.Click += new System.EventHandler(this.label_test_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1244, 638);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(1342, 432);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(92, 24);
            this.Map.TabIndex = 3;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = true;
            this.Map.Click += new System.EventHandler(this.Map_Click);
            // 
            // PureTargetButton
            // 
            this.PureTargetButton.Location = new System.Drawing.Point(1342, 154);
            this.PureTargetButton.Name = "PureTargetButton";
            this.PureTargetButton.Size = new System.Drawing.Size(122, 23);
            this.PureTargetButton.TabIndex = 4;
            this.PureTargetButton.Text = "Pure Target Filter";
            this.PureTargetButton.UseVisualStyleBackColor = true;
            this.PureTargetButton.Click += new System.EventHandler(this.PureTargetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1339, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Selection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1339, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filters";
            // 
            // FixedTransponder
            // 
            this.FixedTransponder.Location = new System.Drawing.Point(1334, 206);
            this.FixedTransponder.Name = "FixedTransponder";
            this.FixedTransponder.Size = new System.Drawing.Size(143, 23);
            this.FixedTransponder.TabIndex = 8;
            this.FixedTransponder.Text = "Fixed Transponder Filter";
            this.FixedTransponder.UseVisualStyleBackColor = true;
            this.FixedTransponder.Click += new System.EventHandler(this.FixedTransponder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1339, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Simulation";
            // 
            // LLFilter
            // 
            this.LLFilter.Location = new System.Drawing.Point(1342, 235);
            this.LLFilter.Name = "LLFilter";
            this.LLFilter.Size = new System.Drawing.Size(122, 23);
            this.LLFilter.TabIndex = 10;
            this.LLFilter.Text = "Lat/Long Filter";
            this.LLFilter.UseVisualStyleBackColor = true;
            this.LLFilter.Click += new System.EventHandler(this.LLFilter_Click);
            // 
            // exportCSV
            // 
            this.exportCSV.Location = new System.Drawing.Point(1332, 509);
            this.exportCSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exportCSV.Name = "exportCSV";
            this.exportCSV.Size = new System.Drawing.Size(123, 19);
            this.exportCSV.TabIndex = 11;
            this.exportCSV.Text = "Export CSV";
            this.exportCSV.UseVisualStyleBackColor = true;
            this.exportCSV.Click += new System.EventHandler(this.exportCSV_Click_1);
            // 
            // MinLat
            // 
            this.MinLat.Location = new System.Drawing.Point(1367, 302);
            this.MinLat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinLat.Name = "MinLat";
            this.MinLat.Size = new System.Drawing.Size(50, 20);
            this.MinLat.TabIndex = 12;
            // 
            // MaxLat
            // 
            this.MaxLat.Location = new System.Drawing.Point(1444, 302);
            this.MaxLat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaxLat.Name = "MaxLat";
            this.MaxLat.Size = new System.Drawing.Size(40, 20);
            this.MaxLat.TabIndex = 13;
            // 
            // MinLon
            // 
            this.MinLon.Location = new System.Drawing.Point(1367, 325);
            this.MinLon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinLon.Name = "MinLon";
            this.MinLon.Size = new System.Drawing.Size(50, 20);
            this.MinLon.TabIndex = 14;
            // 
            // MaxLon
            // 
            this.MaxLon.Location = new System.Drawing.Point(1444, 325);
            this.MaxLon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaxLon.Name = "MaxLon";
            this.MaxLon.Size = new System.Drawing.Size(40, 20);
            this.MaxLon.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1375, 287);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1329, 327);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Lon";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1329, 302);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Lat";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1450, 287);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1339, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Export To";
            // 
            // ACOnGround
            // 
            this.ACOnGround.Location = new System.Drawing.Point(1332, 183);
            this.ACOnGround.Name = "ACOnGround";
            this.ACOnGround.Size = new System.Drawing.Size(143, 23);
            this.ACOnGround.TabIndex = 21;
            this.ACOnGround.Text = "Delete Aircrafts on ground";
            this.ACOnGround.UseVisualStyleBackColor = true;
            this.ACOnGround.Click += new System.EventHandler(this.ACOnGround_Click);
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 691);
            this.Controls.Add(this.ACOnGround);
            this.Controls.Add(this.label8);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button show_data;
        private System.Windows.Forms.Label label_test;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Map;
        private System.Windows.Forms.Button PureTargetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LatLongFilter;
        private System.Windows.Forms.Button FixedTransponder;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ACOnGround;
        //private System.Windows.Forms.Button exportCSV;
    }
}


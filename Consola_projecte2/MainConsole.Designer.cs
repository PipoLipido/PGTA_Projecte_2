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
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LLFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // show_data
            // 
            this.show_data.Location = new System.Drawing.Point(1284, 57);
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
            this.dataGridView1.Location = new System.Drawing.Point(52, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1223, 556);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(1284, 432);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(92, 24);
            this.Map.TabIndex = 3;
            this.Map.Text = "Map";
            this.Map.UseVisualStyleBackColor = true;
            this.Map.Click += new System.EventHandler(this.Map_Click);
            // 
            // PureTargetButton
            // 
            this.PureTargetButton.Location = new System.Drawing.Point(1284, 126);
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
            this.label1.Location = new System.Drawing.Point(1281, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File Selection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1281, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filters";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1284, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Pure Target Filter";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1281, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Simulation";
            // 
            // LLFilter
            // 
            this.LLFilter.Location = new System.Drawing.Point(1284, 155);
            this.LLFilter.Name = "LLFilter";
            this.LLFilter.Size = new System.Drawing.Size(122, 23);
            this.LLFilter.TabIndex = 10;
            this.LLFilter.Text = "Lat/Long Filter";
            this.LLFilter.UseVisualStyleBackColor = true;
            this.LLFilter.Click += new System.EventHandler(this.LLFilter_Click);
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 633);
            this.Controls.Add(this.LLFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LLFilter;
    }
}


using System.Reflection.Emit;
using System.Windows.Forms;

namespace Consola_projecte2
{
    partial class mapconsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.velocitat = new System.Windows.Forms.Label();
            this.accelerar = new System.Windows.Forms.Button();
            this.reduir = new System.Windows.Forms.Button();
            this.temps = new System.Windows.Forms.Label();
            this.reverse = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Stop = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Panel1.Controls.Add(this.velocitat);
            this.splitContainer1.Panel1.Controls.Add(this.accelerar);
            this.splitContainer1.Panel1.Controls.Add(this.reduir);
            this.splitContainer1.Panel1.Controls.Add(this.temps);
            this.splitContainer1.Panel1.Controls.Add(this.reverse);
            this.splitContainer1.Panel1.Controls.Add(this.Reset);
            this.splitContainer1.Panel1.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel1.Controls.Add(this.Stop);
            this.splitContainer1.Panel1.Controls.Add(this.Play);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // velocitat
            // 
            this.velocitat.AutoSize = true;
            this.velocitat.Location = new System.Drawing.Point(733, 18);
            this.velocitat.Name = "velocitat";
            this.velocitat.Size = new System.Drawing.Size(18, 13);
            this.velocitat.TabIndex = 8;
            this.velocitat.Text = "x1";
            // 
            // accelerar
            // 
            this.accelerar.Location = new System.Drawing.Point(757, 12);
            this.accelerar.Name = "accelerar";
            this.accelerar.Size = new System.Drawing.Size(31, 23);
            this.accelerar.TabIndex = 7;
            this.accelerar.Text = ">>";
            this.accelerar.UseVisualStyleBackColor = true;
            this.accelerar.Click += new System.EventHandler(this.accelerar_Click);
            // 
            // reduir
            // 
            this.reduir.Location = new System.Drawing.Point(697, 12);
            this.reduir.Name = "reduir";
            this.reduir.Size = new System.Drawing.Size(31, 23);
            this.reduir.TabIndex = 6;
            this.reduir.Text = "<<";
            this.reduir.UseVisualStyleBackColor = true;
            this.reduir.Click += new System.EventHandler(this.reduir_Click);
            // 
            // temps
            // 
            this.temps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.temps.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temps.Location = new System.Drawing.Point(3, 8);
            this.temps.Name = "temps";
            this.temps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.temps.Size = new System.Drawing.Size(158, 37);
            this.temps.TabIndex = 5;
            this.temps.Text = "00:00:00";
            this.temps.Click += new System.EventHandler(this.temps_Click);
            // 
            // reverse
            // 
            this.reverse.Location = new System.Drawing.Point(329, 12);
            this.reverse.Name = "reverse";
            this.reverse.Size = new System.Drawing.Size(75, 23);
            this.reverse.TabIndex = 4;
            this.reverse.Text = "Reverse";
            this.reverse.UseVisualStyleBackColor = true;
            this.reverse.Click += new System.EventHandler(this.reverse_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(410, 12);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(3, 41);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(791, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(248, 12);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.White;
            this.Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Play.Location = new System.Drawing.Point(167, 12);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select two aircrafts";
            // 
            // mapconsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "mapconsole";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button reverse;
        private System.Windows.Forms.Label temps;
        private System.Windows.Forms.Label velocitat;
        private Button accelerar;
        private Button reduir;
        private System.Windows.Forms.Label label1;
    }
}
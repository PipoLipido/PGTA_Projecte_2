namespace Consola_projecte2
{
    partial class StartingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            this.startSoftware = new System.Windows.Forms.Button();
            this.ReadMe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ASTERIXsample = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startSoftware
            // 
            this.startSoftware.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startSoftware.BackColor = System.Drawing.Color.Transparent;
            this.startSoftware.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startSoftware.Location = new System.Drawing.Point(287, 390);
            this.startSoftware.Name = "startSoftware";
            this.startSoftware.Size = new System.Drawing.Size(229, 46);
            this.startSoftware.TabIndex = 0;
            this.startSoftware.Text = "Start Software";
            this.startSoftware.UseVisualStyleBackColor = false;
            this.startSoftware.Click += new System.EventHandler(this.startSoftware_Click);
            // 
            // ReadMe
            // 
            this.ReadMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadMe.Location = new System.Drawing.Point(651, 390);
            this.ReadMe.Name = "ReadMe";
            this.ReadMe.Size = new System.Drawing.Size(137, 46);
            this.ReadMe.TabIndex = 1;
            this.ReadMe.Text = "ReadMe";
            this.ReadMe.UseVisualStyleBackColor = true;
            this.ReadMe.Click += new System.EventHandler(this.ReadMe_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans JP", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 139);
            this.label2.TabIndex = 4;
            this.label2.Text = "ASTERIX";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans JP", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(294, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 70);
            this.label3.TabIndex = 5;
            this.label3.Text = "decoder";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(718, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 42);
            this.label4.TabIndex = 6;
            this.label4.Text = "G4";
            // 
            // ASTERIXsample
            // 
            this.ASTERIXsample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ASTERIXsample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ASTERIXsample.Location = new System.Drawing.Point(12, 390);
            this.ASTERIXsample.Name = "ASTERIXsample";
            this.ASTERIXsample.Size = new System.Drawing.Size(137, 46);
            this.ASTERIXsample.TabIndex = 7;
            this.ASTERIXsample.Text = "Download ASTERIX sample";
            this.ASTERIXsample.UseVisualStyleBackColor = true;
            this.ASTERIXsample.Click += new System.EventHandler(this.ASTERIXsample_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ASTERIXsample);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReadMe);
            this.Controls.Add(this.startSoftware);
            this.DoubleBuffered = true;
            this.Name = "StartingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startSoftware;
        private System.Windows.Forms.Button ReadMe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ASTERIXsample;
    }
}
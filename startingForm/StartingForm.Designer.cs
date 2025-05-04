namespace startingForm
{
    partial class StartingForm
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
            this.startSoftware = new System.Windows.Forms.Button();
            this.ReadMe = new System.Windows.Forms.Button();
            this.DownloadAsterix = new System.Windows.Forms.Button();
            this.UploadAsterix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startSoftware
            // 
            this.startSoftware.Location = new System.Drawing.Point(385, 92);
            this.startSoftware.Name = "startSoftware";
            this.startSoftware.Size = new System.Drawing.Size(180, 36);
            this.startSoftware.TabIndex = 0;
            this.startSoftware.Text = "Start software";
            this.startSoftware.UseVisualStyleBackColor = true;
            this.startSoftware.Click += new System.EventHandler(this.startSoftware_Click);
            // 
            // ReadMe
            // 
            this.ReadMe.Location = new System.Drawing.Point(386, 162);
            this.ReadMe.Name = "ReadMe";
            this.ReadMe.Size = new System.Drawing.Size(243, 77);
            this.ReadMe.TabIndex = 1;
            this.ReadMe.Text = "ReadMe";
            this.ReadMe.UseVisualStyleBackColor = true;
            // 
            // DownloadAsterix
            // 
            this.DownloadAsterix.Location = new System.Drawing.Point(383, 277);
            this.DownloadAsterix.Name = "DownloadAsterix";
            this.DownloadAsterix.Size = new System.Drawing.Size(275, 93);
            this.DownloadAsterix.TabIndex = 2;
            this.DownloadAsterix.Text = "Download Asterix sample";
            this.DownloadAsterix.UseVisualStyleBackColor = true;
            // 
            // UploadAsterix
            // 
            this.UploadAsterix.Location = new System.Drawing.Point(246, 162);
            this.UploadAsterix.Name = "UploadAsterix";
            this.UploadAsterix.Size = new System.Drawing.Size(69, 50);
            this.UploadAsterix.TabIndex = 3;
            this.UploadAsterix.Text = "Upload Asterix File";
            this.UploadAsterix.UseVisualStyleBackColor = true;
            this.UploadAsterix.Click += new System.EventHandler(this.UploadAsterix_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UploadAsterix);
            this.Controls.Add(this.DownloadAsterix);
            this.Controls.Add(this.ReadMe);
            this.Controls.Add(this.startSoftware);
            this.Name = "StartingForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startSoftware;
        private System.Windows.Forms.Button ReadMe;
        private System.Windows.Forms.Button DownloadAsterix;
        private System.Windows.Forms.Button UploadAsterix;
    }
}


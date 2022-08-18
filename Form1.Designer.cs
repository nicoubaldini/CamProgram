namespace CamProgram
{
    partial class Form1
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
            this.btnDetect = new System.Windows.Forms.Button();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(529, 12);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(123, 23);
            this.btnDetect.TabIndex = 0;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(12, 12);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(511, 21);
            this.cbDevice.TabIndex = 1;
            // 
            // pbMedia
            // 
            this.pbMedia.Location = new System.Drawing.Point(12, 39);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(640, 480);
            this.pbMedia.TabIndex = 2;
            this.pbMedia.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 536);
            this.Controls.Add(this.pbMedia);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.btnDetect);
            this.Name = "Form1";
            this.Text = "Roomie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.PictureBox pbMedia;
    }
}


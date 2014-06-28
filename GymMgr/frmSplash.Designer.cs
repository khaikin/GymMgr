namespace GymMgr
{
    partial class frmSplash
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSuscription = new System.Windows.Forms.Label();
            this.pbSubscription = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubscription)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Image = global::GymMgr.Properties.Resources.user_6;
            this.pbImage.Location = new System.Drawing.Point(12, 10);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(215, 175);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(28, 195);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            // 
            // lblSuscription
            // 
            this.lblSuscription.AutoSize = true;
            this.lblSuscription.Location = new System.Drawing.Point(28, 225);
            this.lblSuscription.Name = "lblSuscription";
            this.lblSuscription.Size = new System.Drawing.Size(35, 13);
            this.lblSuscription.TabIndex = 2;
            this.lblSuscription.Text = "label2";
            // 
            // pbSubscription
            // 
            this.pbSubscription.Location = new System.Drawing.Point(193, 211);
            this.pbSubscription.Name = "pbSubscription";
            this.pbSubscription.Size = new System.Drawing.Size(34, 29);
            this.pbSubscription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSubscription.TabIndex = 3;
            this.pbSubscription.TabStop = false;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(255, 260);
            this.ControlBox = false;
            this.Controls.Add(this.pbSubscription);
            this.Controls.Add(this.lblSuscription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSplash";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubscription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbImage;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblSuscription;
        public System.Windows.Forms.PictureBox pbSubscription;

    }
}
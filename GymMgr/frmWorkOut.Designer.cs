namespace GymMgr
{
    partial class frmWorkOut
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
            System.Windows.Forms.Label repetitionsLabel;
            System.Windows.Forms.Label setsLabel;
            System.Windows.Forms.Label label1;
            this.convertedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.cbExercise = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nmRepetitions = new System.Windows.Forms.NumericUpDown();
            this.nmSets = new System.Windows.Forms.NumericUpDown();
            repetitionsLabel = new System.Windows.Forms.Label();
            setsLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.convertedImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSets)).BeginInit();
            this.SuspendLayout();
            // 
            // repetitionsLabel
            // 
            repetitionsLabel.AutoSize = true;
            repetitionsLabel.Location = new System.Drawing.Point(12, 60);
            repetitionsLabel.Name = "repetitionsLabel";
            repetitionsLabel.Size = new System.Drawing.Size(40, 13);
            repetitionsLabel.TabIndex = 5;
            repetitionsLabel.Text = "חזרות:";
            // 
            // setsLabel
            // 
            setsLabel.AutoSize = true;
            setsLabel.Location = new System.Drawing.Point(12, 86);
            setsLabel.Name = "setsLabel";
            setsLabel.Size = new System.Drawing.Size(36, 13);
            setsLabel.TabIndex = 7;
            setsLabel.Text = "סטים:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 13);
            label1.TabIndex = 12;
            label1.Text = "תרגיל:";
            // 
            // convertedImagePictureBox
            // 
            this.convertedImagePictureBox.Location = new System.Drawing.Point(207, 28);
            this.convertedImagePictureBox.Name = "convertedImagePictureBox";
            this.convertedImagePictureBox.Size = new System.Drawing.Size(137, 107);
            this.convertedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.convertedImagePictureBox.TabIndex = 10;
            this.convertedImagePictureBox.TabStop = false;
            // 
            // cbExercise
            // 
            this.cbExercise.DisplayMember = "\"Name\"";
            this.cbExercise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExercise.FormattingEnabled = true;
            this.cbExercise.Location = new System.Drawing.Point(66, 28);
            this.cbExercise.Name = "cbExercise";
            this.cbExercise.Size = new System.Drawing.Size(121, 21);
            this.cbExercise.TabIndex = 11;
            this.cbExercise.ValueMember = "\"id\"";
            this.cbExercise.SelectedIndexChanged += new System.EventHandler(this.cbExercise_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(269, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "בטל";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(188, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "שמור";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // nmRepetitions
            // 
            this.nmRepetitions.Location = new System.Drawing.Point(66, 58);
            this.nmRepetitions.Name = "nmRepetitions";
            this.nmRepetitions.Size = new System.Drawing.Size(73, 20);
            this.nmRepetitions.TabIndex = 15;
            // 
            // nmSets
            // 
            this.nmSets.Location = new System.Drawing.Point(66, 84);
            this.nmSets.Name = "nmSets";
            this.nmSets.Size = new System.Drawing.Size(73, 20);
            this.nmSets.TabIndex = 16;
            // 
            // frmWorkOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 196);
            this.Controls.Add(this.nmSets);
            this.Controls.Add(this.nmRepetitions);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(this.cbExercise);
            this.Controls.Add(this.convertedImagePictureBox);
            this.Controls.Add(repetitionsLabel);
            this.Controls.Add(setsLabel);
            this.Name = "frmWorkOut";
            this.Text = "frmWorkOut";
            this.Load += new System.EventHandler(this.frmWorkOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.convertedImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmRepetitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.PictureBox convertedImagePictureBox;
        public System.Windows.Forms.ComboBox cbExercise;
        public System.Windows.Forms.NumericUpDown nmRepetitions;
        public System.Windows.Forms.NumericUpDown nmSets;
    }
}
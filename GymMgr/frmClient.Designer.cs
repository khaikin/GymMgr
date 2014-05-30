namespace GymMgr
{
    partial class frmClient
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
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label identificationNumberLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label label1;
            this.btnAction = new System.Windows.Forms.Button();
            this.btnCalcel = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.birthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.identificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.txtCardSN = new System.Windows.Forms.TextBox();
            this.tbnReadOnce = new System.Windows.Forms.Button();
            addressLabel = new System.Windows.Forms.Label();
            birthDateLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            identificationNumberLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(11, 119);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(43, 13);
            addressLabel.TabIndex = 17;
            addressLabel.Text = "כתובת:";
            // 
            // birthDateLabel
            // 
            birthDateLabel.AutoSize = true;
            birthDateLabel.Location = new System.Drawing.Point(11, 95);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new System.Drawing.Size(72, 13);
            birthDateLabel.TabIndex = 19;
            birthDateLabel.Text = "תאריך לידה:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(11, 145);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(34, 13);
            emailLabel.TabIndex = 23;
            emailLabel.Text = "מייל:";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(11, 16);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(26, 13);
            firstNameLabel.TabIndex = 25;
            firstNameLabel.Text = "שם:";
            // 
            // identificationNumberLabel
            // 
            identificationNumberLabel.AutoSize = true;
            identificationNumberLabel.Location = new System.Drawing.Point(11, 68);
            identificationNumberLabel.Name = "identificationNumberLabel";
            identificationNumberLabel.Size = new System.Drawing.Size(70, 13);
            identificationNumberLabel.TabIndex = 29;
            identificationNumberLabel.Text = "תעודת זהות:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(11, 42);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(47, 13);
            lastNameLabel.TabIndex = 31;
            lastNameLabel.Text = "משפחה:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 171);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 33;
            label1.Text = "כרטיס";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(170, 216);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 34);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "OK";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCalcel
            // 
            this.btnCalcel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalcel.Location = new System.Drawing.Point(252, 216);
            this.btnCalcel.Name = "btnCalcel";
            this.btnCalcel.Size = new System.Drawing.Size(75, 34);
            this.btnCalcel.TabIndex = 8;
            this.btnCalcel.Text = "ביטול";
            this.btnCalcel.UseVisualStyleBackColor = true;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(127, 116);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addressTextBox.Size = new System.Drawing.Size(200, 20);
            this.addressTextBox.TabIndex = 4;
            // 
            // birthDateDateTimePicker
            // 
            this.birthDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.birthDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthDateDateTimePicker.Location = new System.Drawing.Point(127, 91);
            this.birthDateDateTimePicker.Name = "birthDateDateTimePicker";
            this.birthDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.birthDateDateTimePicker.TabIndex = 3;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(127, 142);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 20);
            this.emailTextBox.TabIndex = 5;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(127, 13);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.firstNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.firstNameTextBox.TabIndex = 0;
            // 
            // identificationNumberTextBox
            // 
            this.identificationNumberTextBox.Location = new System.Drawing.Point(127, 65);
            this.identificationNumberTextBox.MaxLength = 10;
            this.identificationNumberTextBox.Name = "identificationNumberTextBox";
            this.identificationNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.identificationNumberTextBox.TabIndex = 2;
            this.identificationNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.identificationNumberTextBox_KeyPress);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(127, 39);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lastNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.lastNameTextBox.TabIndex = 1;
            // 
            // txtCardSN
            // 
            this.txtCardSN.Location = new System.Drawing.Point(127, 168);
            this.txtCardSN.Name = "txtCardSN";
            this.txtCardSN.Size = new System.Drawing.Size(149, 20);
            this.txtCardSN.TabIndex = 32;
            // 
            // tbnReadOnce
            // 
            this.tbnReadOnce.Location = new System.Drawing.Point(283, 167);
            this.tbnReadOnce.Name = "tbnReadOnce";
            this.tbnReadOnce.Size = new System.Drawing.Size(44, 23);
            this.tbnReadOnce.TabIndex = 34;
            this.tbnReadOnce.Text = "...";
            this.tbnReadOnce.UseVisualStyleBackColor = true;
            this.tbnReadOnce.Click += new System.EventHandler(this.tbnReadOnce_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 262);
            this.Controls.Add(this.tbnReadOnce);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtCardSN);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(birthDateLabel);
            this.Controls.Add(this.birthDateDateTimePicker);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(identificationNumberLabel);
            this.Controls.Add(this.identificationNumberTextBox);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.btnCalcel);
            this.Controls.Add(this.btnAction);
            this.Name = "frmClient";
            this.Text = "frmClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.Load += new System.EventHandler(this.frmClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnAction;
        public System.Windows.Forms.Button btnCalcel;
        public System.Windows.Forms.TextBox addressTextBox;
        public System.Windows.Forms.DateTimePicker birthDateDateTimePicker;
        public System.Windows.Forms.TextBox emailTextBox;
        public System.Windows.Forms.TextBox firstNameTextBox;
        public System.Windows.Forms.TextBox identificationNumberTextBox;
        public System.Windows.Forms.TextBox lastNameTextBox;
        public System.Windows.Forms.TextBox txtCardSN;
        private System.Windows.Forms.Button tbnReadOnce;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using RfIdhlpr;

namespace GymMgr
{
    public partial class frmClient : Form
    {
        /// <summary>
        /// Return true if current sn already exists
        /// </summary>
        public Func<string, bool> CardSnExists;

        public Action<string> RemoveCardSnFromPrevious;


        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }



        private void stateTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAction_Click(object sender, EventArgs e)
        {

            var sn = txtCardSN.Text;
            if (!string.IsNullOrEmpty(sn))
            {
                if (CardSnExists != null)
                    if (CardSnExists(sn))
                    {
                        if (MessageBox.Show("הכרטיס כבר שימוש. האם לשייך מחדש?", "Validation Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (RemoveCardSnFromPrevious != null)
                                RemoveCardSnFromPrevious(sn);
                        }
                        else
                            return;
                    }
            }
            else
            {
                txtCardSN.Text = "0";
            }


            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("קיימים שדות ריקים", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (!Regex.IsMatch(emailTextBox.Text, MatchEmailPattern))
            {
                MessageBox.Show("כתובת המייל אינה תקינה", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void identificationNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RfIdhlpr.RfIdhpr.Reader != null)
                RfIdhlpr.RfIdhpr.Reader.ResumePolling();
        }

        private void tbnReadOnce_Click(object sender, EventArgs e)
        {
            var reader = RfIdhlpr.RfIdhpr.Reader;
            if (reader == null)
            {
                MessageBox.Show("קורא כרטיסים איננו מחובר", "שגיא", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            reader.PostponePolling();
            MessageBox.Show("'OK' נא להניח כרטיס על משטח וללחוץ", "עידכון מספר כרטיס", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCardSN.Text = reader.ReadOnce();

            //            MessageBox.Show("תודה", "עידכון מספר כרטיס", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}

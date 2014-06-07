using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMgr
{
    public partial class frmPayment : Form
    {
        public Func<DateTime, bool> ToDateIsValid;
        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsValid())
            {
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        bool IsValid()
        {
            bool res = true;
            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                MessageBox.Show("תאריכים אינם נכונים", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res = false;
            }

            double val;
            if (!double.TryParse(amountTextBox.Text, out val))
            {
                MessageBox.Show("הסכום אינו תקין", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res = false;
            }

            if(ToDateIsValid!=null)
                if (!ToDateIsValid(toDateTimePicker.Value))
                {
                    MessageBox.Show("תאריך 'עד' אינו תקין. כנראה קיים רישום מאוחר יותר.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    res = false;
                }

            return res;
        }


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

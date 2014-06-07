using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymDal;

namespace GymMgr
{
    public partial class frmPayments : Form
    {
        AdoDal _dal = new AdoDal();

        int _custId;
        public frmPayments(int custId)
        {
            _custId = custId;
            InitializeComponent();
        }

        void LoadPaymentsPerCustomer()
        {
            var cust = _custId;
            if (cust == -1) return;
            paymentBindingSource.DataSource = _dal.GetPaymentsPerCustomer(cust);


        }


        private void btnAddSubscr_Click(object sender, EventArgs e)
        {

            using (var frm = new frmPayment())
            {
                frm.ToDateIsValid = (d) =>
                {
                    var pay = _dal.GetPaymentsPerCustomer(_custId);
                    DateTime max = DateTime.MinValue;
                    if (pay.Rows.Count > 0)
                        max = pay.AsEnumerable().Cast<DataRow>().Max(r => r.Field<DateTime>("To"));
                    return d > max;
                };
                if (frm.ShowDialog() == DialogResult.Cancel) return;

                var cst = _custId;
                var amount = double.Parse(frm.amountTextBox.Text.Trim());
                var comments = frm.commentsTextBox.Text.Trim();
                var From = frm.fromDateTimePicker.Value;
                var To = frm.toDateTimePicker.Value;
                _dal.AddSubscription(_custId, amount, comments, From, To);
            }

            LoadPaymentsPerCustomer();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            LoadPaymentsPerCustomer();
        }




    }
}

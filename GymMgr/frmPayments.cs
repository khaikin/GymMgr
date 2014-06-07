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
        int viewColumnIndex;
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
            viewColumnIndex = dgvPayment.Columns.Add(new DataGridViewButtonColumn { Name = "View", HeaderText = "", Text = "נוכחות", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });

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

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != viewColumnIndex) return;

             var s =(int) ((DataRowView)paymentBindingSource.Current).Row["id"]; 


           // var id =(int) dgvPayment["id",e.RowIndex].Value;
            DataTable data = _dal.GetLogins(s,_custId);


            var lst = new List<string>{"id","Customer_id"};

            using (var frm  = new frmView(data,lst))
            {
                frm.ShowDialog();
            }
        }




    }
}

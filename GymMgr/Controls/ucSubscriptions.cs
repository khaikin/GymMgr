using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymDal;

namespace GymMgr
{

 


    public partial class ucSubscriptions : BaseUc
    {
        public ucSubscriptions()
        {
            InitializeComponent();
        }



        private void ucSubscriptions_Load(object sender, EventArgs e)
        {
            customerBindingSource.DataSource = Customers;
            var btn = new DataGridViewButtonColumn { Name = "Add", HeaderText = "", Text = "הוסף תקופה", UseColumnTextForButtonValue = true, Width = 80, AutoSizeMode = DataGridViewAutoSizeColumnMode.None };
            
            dgvClient.Columns.Add(btn);
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex == dgvClient.Columns["Add"].Index)
            {
                AddPayment();
            }
        }



        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            paymentBindingSource.DataSource = Dal.GetPaymentsPerCustomer(CurrentCustomerId);
        }


        private int CurrentCustomerId
        {
            get
            {
                var f = (customerBindingSource.Current as DataRowView);
                return (int)f.Row["id"];
            }
        }


        void AddPayment()
        {

            using (var frm = new frmPayment())
            {
                if (frm.ShowDialog() == DialogResult.Cancel) return;

                var cst = CurrentCustomerId;
                var amount = double.Parse(frm.amountTextBox.Text.Trim());
                var comments = frm.commentsTextBox.Text.Trim();
                var From = frm.fromDateTimePicker.Value;
                var To = frm.toDateTimePicker.Value;
                Dal.AddSubscription(CurrentCustomerId, amount, comments, From, To);
            }
            //  paymentBindingSource.ResetBindings(true);
            customerBindingSource.ResetBindings(true);


        }

        private void dgvClient_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex == 3 && e.RowIndex > -1)
            //{
            //    Image img = GymMgr.Properties.Resources.add;
            //    e.Graphics.DrawImage(img, e.CellBounds.Location);
            //    e.PaintContent(e.CellBounds);
            //    e.Handled = true;
            //}
        }




    }
}

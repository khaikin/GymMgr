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
    public partial class ucClients : BaseUc
    {
        public ucClients()
        {
            InitializeComponent();
        }




        void LoadData()
        {
            LoadData(Customers.Select("Active=1").CopyToDataTable());
        }


        void LoadData(DataTable data)
        {
            dgvClients.Columns.Clear();



            dgvClients.DataSource = data;

            if (data.Rows.Count == 0) return;


            dgvClients.Columns.Add(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "ערוך", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvClients.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "מחק", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvClients.Columns.Add(new DataGridViewButtonColumn { Name = "Login", HeaderText = "", Text = "כניסה", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvClients.Columns.Add(new DataGridViewButtonColumn { Name = "Payments", HeaderText = "", Text = "תשלומים", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });

            dgvClients.Columns["id"].Visible = false;
            dgvClients.Columns["WorkoutProgram_Id"].Visible = false;
            dgvClients.Columns["Active"].Visible = false;
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new frmClient() { Text = "הוסף מנוי" })
                {

                    frm.btnAction.Text = "הוסף";
                    frm.CardSnExists = sn =>
                    {
                        var clientID = Dal.GetClientIdByCardSn(sn);
                        return clientID != 0;
                    };
                    frm.RemoveCardSnFromPrevious = sn => Dal.DeleteCardSn(sn);



                    if (frm.ShowDialog() == DialogResult.Cancel)
                        return;

                    var client = Customers.NewRow();

                    client["FirstName"] = frm.firstNameTextBox.Text;
                    client["LastName"] = frm.lastNameTextBox.Text;
                    client["IdentificationNumber"] = frm.identificationNumberTextBox.Text;
                    client["Address"] = frm.addressTextBox.Text;
                    client["Email"] = frm.emailTextBox.Text;
                    client["BirthDate"] = frm.birthDateDateTimePicker.Value;
                    client["Active"] = 1;
                    client["CreationTimeStamp"] = DateTime.Now;
                    client["CardSN"] = frm.txtCardSN.Text;


                    Dal.AddOrUpdateCustomer(client);
                }

                LoadData();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.GetAllMessages());
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex != 2 && string.IsNullOrEmpty(txtSearchValue.Text.Trim()))
            {
                LoadData();
                return;
            }

            var s = txtSearchValue.Text.Trim();
            var namestr = "FirstName Like '%{0}%' or LastName like '%{0}%' and Active=1";
            var idstr = "IdentificationNumber like '%{0}%' and Active=1";
            var cardStr = "CardSn like '%{0}%' and Active=1";
            DataRow[] rows = null;
            switch (cbSearch.SelectedIndex)
            {
                case 0:
                    rows = Customers.Select(string.Format(namestr, s));
                    break;
                case 1:
                    rows = Customers.Select(string.Format(idstr, s));
                    break;

                default:
                    var reader = RfIdhlpr.RfIdhpr.Reader;
                    if (reader == null)
                    {
                        MessageBox.Show("קורא כרטיסים איננו מחובר", "שגיא", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    reader.PostponePolling();
                    MessageBox.Show("'OK' נא להניח כרטיס על משטח וללחוץ ", "חיפוש לפי מספר כרטיס", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var num = reader.ReadOnce();
                    if (string.IsNullOrEmpty(num))
                    {
                        MessageBox.Show("כרטיס לא זוהה", "חיפוש לפי מספר כרטיס", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        rows = Customers.Select(string.Format(cardStr, num));
                    }
                    reader.ResumePolling();
                    break;
            }
            if (rows != null)
                if (rows.Length > 0)
                    LoadData(rows.CopyToDataTable());
                else
                    LoadData(new DataTable());

        }


        private void ErrorMessage(string message)
        {
            MessageBox.Show(message, "שגיעת מערכת", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && e.ColumnIndex == dgvClients.Columns["Edit"].Index)
            {
                var dr = dgvClients.Rows[e.RowIndex].DataBoundItem as DataRowView;
                EditCUstomer(dr.Row);
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvClients.Columns["Delete"].Index)
            {
                var id = (int)dgvClients["id", e.RowIndex].Value;
                DeleteCustomer(id);

            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvClients.Columns["Login"].Index)
            {

                var id = (int)dgvClients["id", e.RowIndex].Value;
                CreateLogIn(id);
            }

            else if (e.RowIndex != -1 && e.ColumnIndex == dgvClients.Columns["Payments"].Index)
            {

                var id = (int)dgvClients["id", e.RowIndex].Value;
                using (var frm = new frmPayments(id))
                {
                    frm.lblName.Text = dgvClients["FirstName", e.RowIndex].Value.ToString();
                    frm.lblLastName.Text = dgvClients["LastName", e.RowIndex].Value.ToString();
                    frm.lblTel.Text = dgvClients["Phone", e.RowIndex].Value.ToString();
                    frm.ShowDialog();
                }

                //    OpenPayments(id);
            }
            else return;

            LoadData();


        }

        private void OpenPayments(int id)
        {
            using (var frm = new frmPayments(id))
            {
                frm.ShowDialog();
            }

        }



        private void DeleteCustomer(int id)
        {
            Dal.DeleteCustomer(id);
        }

        private void CreateLogIn(int id)
        {

            Dal.AddLogin(id);
        }


        private void EditCUstomer(DataRow client)
        {
            if (client == null)
            {
                ErrorMessage("Failed to get customer record");
                return;
            }
            using (var frm = new frmClient() { Text = "עריכת מנוי" })
            {
                frm.btnAction.Text = "שמור";

                frm.firstNameTextBox.Text = client.Field<string>("FirstName");
                frm.lastNameTextBox.Text = client.Field<string>("LastName");
                frm.identificationNumberTextBox.Text = client.Field<string>("IdentificationNumber");
                frm.addressTextBox.Text = client.Field<string>("Address");
                frm.emailTextBox.Text = client.Field<string>("Email");
                frm.birthDateDateTimePicker.Value = client.Field<DateTime>("BirthDate");
                frm.txtCardSN.Text = client.Field<string>("CardSN");
                frm.mtxtPhone.Text = client.Field<string>("Phone");
                frm.CardSnExists = sn =>
                {
                    var clientID = Dal.GetClientIdByCardSn(sn);
                    return clientID != 0 && clientID != client.Field<int>("Id");
                };
                frm.RemoveCardSnFromPrevious = sn => Dal.DeleteCardSn(sn);


                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                client["FirstName"] = frm.firstNameTextBox.Text;
                client["LastName"] = frm.lastNameTextBox.Text;
                client["IdentificationNumber"] = frm.identificationNumberTextBox.Text;
                client["Address"] = frm.addressTextBox.Text;
                client["Email"] = frm.emailTextBox.Text;
                client["BirthDate"] = frm.birthDateDateTimePicker.Value;
                client["CardSN"] = frm.txtCardSN.Text;
                client["Phone"] = frm.mtxtPhone.Text;
            }

            UpdateCustomer(client);
            // LoadData();

        }


        void UpdateCustomer(DataRow client)
        {

            Dal.AddOrUpdateCustomer(client);

        }

        private void ucClients_Load(object sender, EventArgs e)
        {
            cbSearch.SelectedIndex = 0;

            LoadData();
        }



        private int CurrentCustomerId
        {
            get
            {
                if (dgvClients.SelectedRows.Count == 0) return -1;
                return int.Parse(dgvClients.SelectedRows[0].Cells["id"].Value.ToString());
            }
        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 2)
                txtSearchValue.Enabled = false;
            else
                txtSearchValue.Enabled = true;
        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSearch.PerformClick();
        }

        private void dgvClients_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // var row = dgvClients.Rows[e.RowIndex];


        }

        private void dgvClients_Paint(object sender, PaintEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvClients.Rows)
            //{
            //    var to = DateTime.Parse(row.Cells["SubscriptionTo"].Value.ToString());


            //    if (to <= DateTime.Now)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //        //   row.DefaultCellStyle.ForeColor = Color.White;
            //    }
            //    else if (to.AddDays(-7) <= DateTime.Now)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Yellow;
            //        //  row.DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //}
        }

        private void dgvClients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var ind = dgvClients.Columns["SubscriptionTo"].Index;
            if (e.ColumnIndex != ind) return;


            dgvClients.EnableHeadersVisualStyles = false;

            //DataGridViewCellStyle rowStyle = Grid.RowHeadersDefaultCellStyle;
            //rowStyle.BackColor = Color.Wheat;
            //Grid.Rows[i].HeaderCell.Style = rowStyle;





            var to = DateTime.Parse(dgvClients[ind, e.RowIndex].Value.ToString());

            if (to <= DateTime.Now)
            {
                dgvClients.Rows[e.RowIndex].HeaderCell.Style.BackColor = Color.Red;
                //e.CellStyle.BackColor = Color.Red;
                //   row.DefaultCellStyle.ForeColor = Color.White;
            }
            else if (to.AddDays(-7) <= DateTime.Now)
            {
                dgvClients.Rows[e.RowIndex].HeaderCell.Style.BackColor = Color.Yellow;
                //  e.CellStyle.BackColor = Color.Yellow;
                //  row.DefaultCellStyle.ForeColor = Color.Black;
            }

        }


    }





}

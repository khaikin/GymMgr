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
            if (string.IsNullOrEmpty(txtSearchValue.Text.Trim()))
            {
                LoadData();
                return;
            }

            var s = txtSearchValue.Text.Trim();
            var namestr = "FirstName Like '%{0}%' or LastName like '%{0}%' and Active=1";
            var idstr = "IdentificationNumber like '%{0}%' and Active=1";
            DataRow[] rows;
            switch (cbSearch.SelectedIndex)
            {
                case 0:
                    rows = Customers.Select(string.Format(namestr, s));
                    break;
                default:
                    rows = Customers.Select(string.Format(idstr, s));
                    break;
            }

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
            else return;

            LoadData();


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


                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                client["FirstName"] = frm.firstNameTextBox.Text;
                client["LastName"] = frm.lastNameTextBox.Text;
                client["IdentificationNumber"] = frm.identificationNumberTextBox.Text;
                client["Address"] = frm.addressTextBox.Text;
                client["Email"] = frm.emailTextBox.Text;
                client["BirthDate"] = frm.birthDateDateTimePicker.Value;
                client["CardSN"] = frm.txtCardSN.Text;
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

        private void btnObligors_Click(object sender, EventArgs e)
        {
            //  LoadData(Clients.Where(c => c.IsObligor));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }





}

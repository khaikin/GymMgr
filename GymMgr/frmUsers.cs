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
    public partial class frmUsers : Form
    {
        int lastId;
        AdoDal _dal = new AdoDal();
        List<User> _users;

        public frmUsers()
        {
            InitializeComponent();
            SetDataSource();
        }


        private void SetDataSource()
        {

            _users = _dal.GetListOfUsers();
            lstUsers.DataSource = null;
            lstUsers.DataSource = _users;
            btnDelete.Enabled = _users.Count > 1;
        }


        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = lstUsers.SelectedItem as User;

            if (user == null) return;
            txtName.Text = user.Name.Trim();
            txtUserName.Text = user.UserName.Trim();
            txtPassword.Text = user.Password.Trim(); ;
            cbAdmin.Checked = user.IsAdmin;
            txtConfirm.Text = user.Password.Trim(); ;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newu = new User { Name = "חדש", UserName = "", Password = "" };
            _users.Add(newu);
            lstUsers.DataSource = null;
            lstUsers.DataSource = _users;
            lstUsers.SelectedItem = newu;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = lstUsers.SelectedItem as User;
            if (user == null) return;

            if (user.Id == 0 && _dal.GetUser(txtUserName.Text.ToLower()) != null)
            {
                MessageBox.Show("שם משתמש כבר קיים");
                return;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("סיסמה לא תואמת");

                txtPassword.Text = "";
                txtConfirm.Text = "";
                return;
            }
            user.Name = txtName.Text;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.IsAdmin = cbAdmin.Checked;

            _dal.AddUpdateUser(user);
            SetDataSource();
            lstUsers.SelectedItem = _users.FirstOrDefault(c => c.UserName == user.UserName);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = lstUsers.SelectedItem as User;
            if (user == null) return;


            if (user.Id != 0)// not new
            {
                _dal.DeleteUser(user.Id);
            }
            SetDataSource();



        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

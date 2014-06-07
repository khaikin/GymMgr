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
    public partial class frmLogIn : Form
    {
        public Func<string, string, bool> ValidateUser;
        public frmLogIn()
        {
            InitializeComponent();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUser != null)
                if (ValidateUser(txtUser.Text, txtPass.Text))
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    MessageBox.Show("שם משתמש או סיסמה לא נכונים");
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
         
        }
    }
}

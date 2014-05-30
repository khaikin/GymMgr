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
    public partial class frmSet : Form
    {
        public frmSet()
        {
            InitializeComponent();
        }

     
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fg = new OpenFileDialog())
            {
                fg.Filter = "(*.jpg)|*.jpg";
                if (fg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

                Image img = Image.FromFile(fg.FileName);



                pbImage.Image = img.ScaleImage(200,150);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("קיימים שדות ריקים", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

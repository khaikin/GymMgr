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
        public partial class frmView : Form
        {
            DataTable _data;
            List<string> _hide;
            public frmView(DataTable data, List<string > hide)
            {
                InitializeComponent();
                _data = data;
                _hide = hide;
            }




            private void frmView_Load(object sender, EventArgs e)
            {
                dgvView.DataSource = _data;

                foreach (var col in _hide)
                {
                    if (dgvView.Columns.Contains(col))
                        dgvView.Columns[col].Visible = false;
                }

            }
        }
    }

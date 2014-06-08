using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMgr
{
    public partial class ucObligors : UserControl
    {
        public ucObligors()
        {
            InitializeComponent();
        }

        private void ucObligors_Load(object sender, EventArgs e)
        {
            var dal = new GymDal.AdoDal();

            var data = dal.GetObligorsReportData();

            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Obligors", data));
            this.reportViewer1.RefreshReport();
        }

      
    }
}

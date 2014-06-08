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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        public int ProgramID { get; set; }


        private void frmReport_Load(object sender, EventArgs e)
        {
    
            var dal = new AdoDal();

            var data = dal.GetReportData(ProgramID);

            reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ProgramReport", data));
            this.reportViewer1.RefreshReport();
        }
    }
}

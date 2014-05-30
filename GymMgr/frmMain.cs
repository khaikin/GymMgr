using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GymDal;
using System.Reflection;
using System.Data.Entity.Validation;
using System.Configuration;
using System.Threading.Tasks;
using System.Threading;
using RfIdhlpr;

namespace GymMgr
{
    public partial class frmMain : Form
    {
        bool _pollReader;
        RfIdhpr reader;
        AdoDal _dal;


        public frmMain()
        {
            InitializeComponent();
            AdoDal.OnLogin += (o, ev) => notifyIcon1.ShowBalloonTip(3000, "כניסה", ev.ToString(), ev.IsObligor ? ToolTipIcon.Warning : ToolTipIcon.Info);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new ucClients() { Dock = DockStyle.Fill });
        }

        private void btnSubs_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new ucSubscriptions() { Dock = DockStyle.Fill });


        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new ucProgram() { Dock = DockStyle.Fill });
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new ucExercise() { Dock = DockStyle.Fill });
        }



        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

            Show();
            WindowState = FormWindowState.Normal;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Add(new ucSubscriptions() { Dock = DockStyle.Fill });
            Properties.Settings.Default.Reload();

            cbBaud.SelectedItem = Baud;
            cbPort.SelectedItem = Port;
            checkBoxConnect.Checked = ConnectOnStart;
            _dal = new AdoDal();

            UpdateStatus(false);  // just set defaul lebel value


            if (ConnectOnStart)
                ActivateReader();



        }

        #region Configurations

        private int Port
        {
            get
            {
                return Properties.Settings.Default.SelectedPort;
            }
            set
            {
                Properties.Settings.Default.SelectedPort = value;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private int Baud
        {
            get
            {
                return Properties.Settings.Default.SelectedBaudRate;
            }
            set
            {
                Properties.Settings.Default.SelectedBaudRate = value;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private bool ConnectOnStart
        {
            get { return Properties.Settings.Default.ConnectReader; }
            set
            {
                Properties.Settings.Default.ConnectReader = value;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        #endregion
        /// <summary>
        /// Start polling the reader
        /// </summary>
        private void ActivateReader()
        {
            if (reader != null)
            {
                reader.Dispose();
                reader = null;
                return;

            }


            reader = RfIdhpr.GetReader(Port, Baud);
            reader.ReaderConnectionStateChanged += (o, e) => { UpdateStatus(e.Connected); };
            if (reader.Connect())
            {

                reader.CardRead += (o, e) =>
                                            {
                                                if (!string.IsNullOrEmpty(e.CardSN))
                                                    _dal.AddLogin(e.CardSN);
                                            };
                reader.StartPolling();
            }
            else
            {
                MessageBox.Show("קורא כרטיסים איננו מחובר", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }


            }

        }

        private void cbBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            Baud = int.Parse(cbBaud.SelectedItem.ToString());
        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Port = int.Parse(cbPort.SelectedItem.ToString());
        }

        private void checkBoxConnect_Click(object sender, EventArgs e)
        {
            ConnectOnStart = checkBoxConnect.Checked;
        }
      

        private void UpdateStatus(bool isConnected)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                    {
                        tsmConnect.Text = isConnected ? "Disconnect" : "Connect";
                    lblConnected.Text = isConnected ? "מחובר" : "לא מחובר";
                    }));
            else
            {
                tsmConnect.Text = isConnected ? "Disconnect" : "Connect";
                lblConnected.Text = isConnected ? "מחובר" : "לא מחובר";
            }
          


        }

        private void tsmConnect_Click(object sender, EventArgs e)
        {
            ActivateReader();
        }


    }

    public static class Extentions
    {
        #region Exceptions
        private static IEnumerable<TSource> FromHierarchy<TSource>(this TSource source, Func<TSource, TSource> nextItem, Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        /// <summary>
        /// Get All inner exception error messages
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetAllMessages(this Exception exception)
        {
            if (exception is DbEntityValidationException)
                return ParseDbEF(exception as DbEntityValidationException);

            var messages = exception.FromHierarchy(ex => ex.InnerException)
                .Select(ex => ex.Message);


            return String.Join(Environment.NewLine, messages);
        }



        static string ParseErrorMessage(Exception ex)
        {
            if (ex is DbEntityValidationException)
                return ParseDbEF(ex as DbEntityValidationException);
            else
                return ex.GetAllMessages();
        }



        static private string ParseDbEF(DbEntityValidationException e)
        {
            if (e == null)
                return "";

            var strb = new StringBuilder();
            foreach (var eve in e.EntityValidationErrors)
            {
                strb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State));
                foreach (var ve in eve.ValidationErrors)
                {
                    strb.AppendLine(string.Format("- JobName: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage));
                }
            }
            return strb.ToString();
        }





        #endregion
    }
}

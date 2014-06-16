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
using System.Configuration;
using System.Threading.Tasks;
using System.Threading;
using RfIdhlpr;
using System.Media;

namespace GymMgr
{
    public partial class frmMain : Form
    {

        RfIdhpr reader;
        AdoDal _dal;
        private bool _loggedIn = false;

        private User _user;

        public frmMain()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("he-IL");
            InitializeComponent();
            AdoDal.OnLogin += (o, ev) =>
            {
                if (ev.IsObligor && reader != null)
                {
                    Thread.Sleep(300);
                    //Console.Beep();
                    reader.Beep();
                    Thread.Sleep(300);
                    //Console.Beep();
                    reader.Beep();
                }
                notifyIcon1.ShowBalloonTip(3000,ev.State, ev.ToString(), ev.IsObligor ? ToolTipIcon.Warning : ToolTipIcon.Info);
                SetLastLogin(ev.Name);

            };
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

        private void btnObligors_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(new ucObligors() { Dock = DockStyle.Fill });
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
            // splitContainer1.Panel2.Controls.Add(new ucClients() { Dock = DockStyle.Fill });
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

        private string User
        {
            get { return Properties.Settings.Default.LastUser; }
            set
            {
                Properties.Settings.Default.LastUser = value;
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
                        lblConnected.Image = isConnected ? GymMgr.Properties.Resources.link : GymMgr.Properties.Resources.link_break;
                        //  if (!isConnected)
                        //   Console.Beep(5000, 1000);
                    }));
            else
            {
                tsmConnect.Text = isConnected ? "Disconnect" : "Connect";
                lblConnected.Text = isConnected ? "מחובר" : "לא מחובר";
                lblConnected.Image = isConnected ? GymMgr.Properties.Resources.link : GymMgr.Properties.Resources.link_break;
                //Console.Beep(200,1000);
            }
        }


        private void SetLastLogin(string p)
        {
            var str = "כניסה אחרונה: {0}";
            if (InvokeRequired)
                Invoke(new MethodInvoker(delegate
                     {
                         lblLastLogin.Text = string.Format(str, p);
                     }));
            else
            {
                lblLastLogin.Text = string.Format(str, p);
            }
        }


        private void tsmConnect_Click(object sender, EventArgs e)
        {
            ActivateReader();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            using (var frm = new frmLogIn())
            {
                frm.txtUser.Text = User;
                frm.ValidateUser = (u, p) =>
                {
                    if (u == "admin" && p == "5486")
                    {
                        _user = new User { IsAdmin = true, Name = "admin" };
                        return true;
                    }



                    _user = _dal.GetUser(u);

                    if (_user == null)
                        return false;

                    return _user.Password == p;
                };

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    splitContainer1.Panel1.Enabled = true;
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(new ucClients() { Dock = DockStyle.Fill });

                    if (_user.IsAdmin)
                    {
                        usersToolStripMenuItem.Visible = true;
                        btnObligors.Visible = true;
                    }
                    else
                    {
                        usersToolStripMenuItem.Visible = false;
                        btnObligors.Visible = false;
                    }

                    this.Text = "Gym Manager " + _user.Name;

                    _loggedIn = true;
                    if (_user.Name != "admin")
                        User = _user.UserName;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(btnLogIn);
            _loggedIn = false;
            usersToolStripMenuItem.Visible = false;
            btnObligors.Visible = false;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmUsers())
            {
                frm.ShowDialog();
            }
        }

        




    }


}
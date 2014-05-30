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
    public partial class ucExercise : BaseUc
    {
        public ucExercise()
        {
            InitializeComponent();
        }




        private void ucExercise_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvSet.Columns.Add(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "ערוך", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvSet.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "מחק", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
        }


        private void LoadData()
        {
            workoutSetBindingSource.DataSource = Dal.GetExercises();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSet())
            {
                if (frm.ShowDialog() == DialogResult.Cancel) return;


                var image = frm.pbImage.Image;
                var name = frm.txtName.Text.Trim();

                Dal.AddOrUpdateExercise(null, image.ConvertTo64BaseString(), name);


            }

            LoadData();


        }


        void EditExercise(DataRow set)
        {

            using (var frm = new frmSet())
            {
                frm.btnAdd.Text = "שמור";
                frm.Text = "עריכת תרגיל";
                frm.txtName.Text = set["Name"].ToString();
                //  frm.pbImage.Image = set.ConvertedImage;

                if (frm.ShowDialog() == DialogResult.Cancel) return;

                //set["Name"] = frm.txtName.Text;
                //set["Image"] = frm.pbImage.Image.ConvertTo64BaseString();
                Dal.AddOrUpdateExercise((int)set["id"], frm.pbImage.Image.ConvertTo64BaseString(), frm.txtName.Text);
            }

        }

        private void workoutSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

            var dd = workoutSetBindingSource.Current as DataRowView;
            var d = Dal.GetExercises((int)dd.Row["id"]);
            pbImage.Image = d.Rows[0]["Image"].ToString().Base64StringToImage();
        }

        private void dgvSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == dgvSet.Columns["Edit"].Index)
            {
                var dr = dgvSet.Rows[e.RowIndex].DataBoundItem as DataRowView;
                EditExercise(dr.Row);
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvSet.Columns["Delete"].Index)
            {
                var dr = dgvSet.Rows[e.RowIndex].DataBoundItem as DataRowView;
                Delete((int)dr.Row["id"]);
            }
            else return;

            LoadData();
        }





        private void Delete(int id)
        {
            var td = Dal.GetWorkouts().Select("WorkoutExercise_Id = " + id);
            if (td.Length > 0)
            {
                MessageBox.Show("לא ניתן למחק. התרגיל נמצא בתוכניות אימונים", "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Dal.DeleteExrcise(id);

        }


    }
}

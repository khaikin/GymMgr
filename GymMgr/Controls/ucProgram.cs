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
    public partial class ucProgram : BaseUc
    {
        public ucProgram()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            workoutProgramBindingSource.DataSource = Dal.GetPrograms();
        }

        private void workoutProgramBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (workoutProgramBindingSource.Current == null) return;

            var dd = workoutProgramBindingSource.Current as DataRowView;
            workoutBindingSource1.DataSource = Dal.GetWorkouts((int)dd.Row["id"]); ;
        }

        private void ucProgram_Load(object sender, EventArgs e)
        {
            LoadData();

            dgvExercise.Columns.Add(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "ערוך", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvExercise.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "מחק", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });


            dgvProgram.Columns.Add(new DataGridViewButtonColumn { Name = "Edit", HeaderText = "", Text = "ערוך", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvProgram.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Text = "מחק", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvProgram.Columns.Add(new DataGridViewButtonColumn { Name = "Print", HeaderText = "", Text = "הדפס", UseColumnTextForButtonValue = true, Width = 60, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
        }

        private void dgvExercise_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == dgvExercise.Columns["Edit"].Index)
            {
                var dr = workoutBindingSource1.Current as DataRowView;
                EditWorkout(dr.Row);
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvExercise.Columns["Delete"].Index)
            {
                var dr = workoutBindingSource1.Current as DataRowView;
                DeleteWorkout(dr.Row);
            }
            else return;
            LoadData();
        }

        private void DeleteWorkout(DataRow c)
        {
            Dal.DeleteWorkOut((int)c["Id"]);
        }

        private void UpdateWorkout(DataRow c)
        {
            Dal.AddOrUpdateWorkout(c);
        }

        private void EditWorkout(DataRow workout)
        {
            using (var frm = new frmWorkOut())
            {

                var exercises = Dal.GetExercises();

                frm.cbExercise.DataSource = exercises;
                frm.cbExercise.DisplayMember = "Name";
                frm.cbExercise.ValueMember = "Id";

                frm.cbExercise.SelectedValue = workout["WorkoutExercise_Id"];
                frm.convertedImagePictureBox.Image = Dal.GetExercises((int)workout["WorkoutExercise_Id"]).Rows[0]["Image"].ToString().Base64StringToImage();
                frm.cbExercise.SelectedValueChanged += (o, e) =>
                {
                    frm.convertedImagePictureBox.Image = exercises.Select("id=" + ((int)frm.cbExercise.SelectedValue))[0]["Image"].ToString().Base64StringToImage();
                };
                frm.nmSets.Value = (int)workout["Sets"];
                frm.nmRepetitions.Value = (int)workout["Repetitions"];

                if (frm.ShowDialog() == DialogResult.Cancel)
                    return;

                workout["Repetitions"] = (int)frm.nmRepetitions.Value;
                workout["Sets"] = (int)frm.nmSets.Value;
                workout["WorkoutExercise_id"] = frm.cbExercise.SelectedValue;



            }

            UpdateWorkout(workout);
        }

        private void btnAddExrcise_Click(object sender, EventArgs e)
        {
            using (var frm = new frmWorkOut())
            {
                var exercises = Dal.GetExercises();
                frm.cbExercise.DisplayMember = "Name";
                frm.cbExercise.ValueMember = "Id";

                frm.cbExercise.SelectedValueChanged += (o, es) =>
                {
                    frm.convertedImagePictureBox.Image = exercises.Select("id=" + ((int)frm.cbExercise.SelectedValue))[0]["Image"].ToString().Base64StringToImage();
                };
                frm.cbExercise.DataSource = exercises;

                frm.cbExercise.SelectedIndex = 0;
                if (frm.ShowDialog() == DialogResult.Cancel)
                    return;


                var Repetitions = (int)frm.nmRepetitions.Value;
                var Sets = (int)frm.nmSets.Value;
                var WorkoutExercise = (int)frm.cbExercise.SelectedValue;


                var w = Dal.GetWorkouts().NewRow();
                Dal.AddOrUpdateWorkout(null, Sets, Repetitions, WorkoutExercise, (int)(workoutProgramBindingSource.Current as DataRowView).Row["id"]);
            }

            LoadData();
        }

        private void dgvProgram_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == dgvProgram.Columns["Edit"].Index)
            {
                var dr = workoutProgramBindingSource.Current as DataRowView;
                EditProgram(dr.Row);
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvProgram.Columns["Delete"].Index)
            {
                var dr = workoutProgramBindingSource.Current as DataRowView;
                DeleteProgram(dr.Row);
            }
            else if (e.RowIndex != -1 && e.ColumnIndex == dgvProgram.Columns["Print"].Index)
            {
                var dr = workoutProgramBindingSource.Current as DataRowView;
             
                OpenReportForm((int)dr.Row["id"]);
            }
            else return;
            LoadData();
        }

        private void OpenReportForm(int id )
        {
            using (var rep = new frmReport())
            {
                rep.ProgramID = id;
                rep.ShowDialog();
            }
        }

        private void EditProgram(DataRow workoutProgram)
        {
            using (var frm = new frmProgram())
            {
                frm.textBox1.Text = workoutProgram["Name"].ToString();
                frm.btnOk.Text = "שמור";
                if (frm.ShowDialog() == DialogResult.Cancel) return;

                Dal.AddOrUpdateProgram(workoutProgram["id"] as int?, frm.textBox1.Text);
            }
            LoadData();
        }

        private void DeleteProgram(DataRow c)
        {
            Dal.DeleteProgram((int)c["id"]);
        }

        private void btnAddProg_Click(object sender, EventArgs e)
        {
            using (var frm = new frmProgram())
            {
                if (frm.ShowDialog() == DialogResult.Cancel) return;

                Dal.AddOrUpdateProgram(null, frm.textBox1.Text);

            }
            LoadData();
        }




    }
}

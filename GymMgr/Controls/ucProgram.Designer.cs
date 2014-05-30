namespace GymMgr
{
    partial class ucProgram
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProgram = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvExercise = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repetitionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workoutBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddExrcise = new System.Windows.Forms.Button();
            this.btnAddProg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExercise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProgram
            // 
            this.dgvProgram.AllowUserToAddRows = false;
            this.dgvProgram.AllowUserToDeleteRows = false;
            this.dgvProgram.AllowUserToResizeColumns = false;
            this.dgvProgram.AllowUserToResizeRows = false;
            this.dgvProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProgram.AutoGenerateColumns = false;
            this.dgvProgram.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
            this.dgvProgram.DataSource = this.workoutProgramBindingSource;
            this.dgvProgram.Location = new System.Drawing.Point(0, 0);
            this.dgvProgram.Name = "dgvProgram";
            this.dgvProgram.ReadOnly = true;
            this.dgvProgram.RowHeadersVisible = false;
            this.dgvProgram.Size = new System.Drawing.Size(335, 354);
            this.dgvProgram.TabIndex = 0;
            this.dgvProgram.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProgram_CellClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "אימון";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workoutProgramBindingSource
            // 
            this.workoutProgramBindingSource.DataSource = typeof(GymDal.WorkoutProgram);
            this.workoutProgramBindingSource.CurrentChanged += new System.EventHandler(this.workoutProgramBindingSource_CurrentChanged);
            // 
            // dgvExercise
            // 
            this.dgvExercise.AllowUserToAddRows = false;
            this.dgvExercise.AllowUserToDeleteRows = false;
            this.dgvExercise.AllowUserToResizeColumns = false;
            this.dgvExercise.AllowUserToResizeRows = false;
            this.dgvExercise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExercise.AutoGenerateColumns = false;
            this.dgvExercise.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExercise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExercise.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.setsDataGridViewTextBoxColumn,
            this.repetitionsDataGridViewTextBoxColumn});
            this.dgvExercise.DataSource = this.workoutBindingSource1;
            this.dgvExercise.Location = new System.Drawing.Point(341, 0);
            this.dgvExercise.Name = "dgvExercise";
            this.dgvExercise.ReadOnly = true;
            this.dgvExercise.RowHeadersVisible = false;
            this.dgvExercise.Size = new System.Drawing.Size(394, 354);
            this.dgvExercise.TabIndex = 1;
            this.dgvExercise.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExercise_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "שם";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // setsDataGridViewTextBoxColumn
            // 
            this.setsDataGridViewTextBoxColumn.DataPropertyName = "Sets";
            this.setsDataGridViewTextBoxColumn.HeaderText = "סטים";
            this.setsDataGridViewTextBoxColumn.Name = "setsDataGridViewTextBoxColumn";
            this.setsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repetitionsDataGridViewTextBoxColumn
            // 
            this.repetitionsDataGridViewTextBoxColumn.DataPropertyName = "Repetitions";
            this.repetitionsDataGridViewTextBoxColumn.HeaderText = "חזרות";
            this.repetitionsDataGridViewTextBoxColumn.Name = "repetitionsDataGridViewTextBoxColumn";
            this.repetitionsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workoutBindingSource1
            // 
            this.workoutBindingSource1.DataSource = typeof(GymDal.Workout);
            // 
            // btnAddExrcise
            // 
            this.btnAddExrcise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExrcise.Location = new System.Drawing.Point(659, 358);
            this.btnAddExrcise.Name = "btnAddExrcise";
            this.btnAddExrcise.Size = new System.Drawing.Size(76, 51);
            this.btnAddExrcise.TabIndex = 2;
            this.btnAddExrcise.Text = "הוסף תרגיל";
            this.btnAddExrcise.UseVisualStyleBackColor = true;
            this.btnAddExrcise.Click += new System.EventHandler(this.btnAddExrcise_Click);
            // 
            // btnAddProg
            // 
            this.btnAddProg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddProg.Location = new System.Drawing.Point(3, 360);
            this.btnAddProg.Name = "btnAddProg";
            this.btnAddProg.Size = new System.Drawing.Size(75, 49);
            this.btnAddProg.TabIndex = 3;
            this.btnAddProg.Text = "הוסף אימון";
            this.btnAddProg.UseVisualStyleBackColor = true;
            this.btnAddProg.Click += new System.EventHandler(this.btnAddProg_Click);
            // 
            // ucProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddProg);
            this.Controls.Add(this.btnAddExrcise);
            this.Controls.Add(this.dgvExercise);
            this.Controls.Add(this.dgvProgram);
            this.Name = "ucProgram";
            this.Size = new System.Drawing.Size(738, 420);
            this.Load += new System.EventHandler(this.ucProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExercise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workoutBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProgram;
        private System.Windows.Forms.DataGridView dgvExercise;
        private System.Windows.Forms.BindingSource workoutProgramBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddExrcise;
        private System.Windows.Forms.BindingSource workoutBindingSource1;
        private System.Windows.Forms.Button btnAddProg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repetitionsDataGridViewTextBoxColumn;
    }
}

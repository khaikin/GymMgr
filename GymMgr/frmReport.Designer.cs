﻿namespace GymMgr
{
    partial class frmReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.view_ProgramReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GymDBDataSet1 = new GymMgr.GymDBDataSet1();
            this.view_ProgramReportTableAdapter = new GymMgr.GymDBDataSet1TableAdapters.view_ProgramReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.view_ProgramReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GymDBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GymMgr.WorkOutRep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(872, 530);
            this.reportViewer1.TabIndex = 0;
            // 
            // view_ProgramReportBindingSource
            // 
            this.view_ProgramReportBindingSource.DataMember = "view_ProgramReport";
            this.view_ProgramReportBindingSource.DataSource = this.GymDBDataSet1;
            // 
            // GymDBDataSet1
            // 
            this.GymDBDataSet1.DataSetName = "GymDBDataSet1";
            this.GymDBDataSet1.EnforceConstraints = false;
            this.GymDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_ProgramReportTableAdapter
            // 
            this.view_ProgramReportTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 530);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view_ProgramReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GymDBDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private GymDBDataSet1 GymDBDataSet1;
        private System.Windows.Forms.BindingSource view_ProgramReportBindingSource;
        private GymDBDataSet1TableAdapters.view_ProgramReportTableAdapter view_ProgramReportTableAdapter;
    }
}
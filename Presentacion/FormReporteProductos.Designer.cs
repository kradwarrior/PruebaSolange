﻿namespace Presentacion
{
    partial class FormReporteProductos
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
            this.bddEmpresaEnkantaDataSet1 = new Presentacion.BDDEmpresaEnkantaDataSet();
            this.productosTableAdapter1 = new Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.productosTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport21 = new Presentacion.CrystalReport2();
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // bddEmpresaEnkantaDataSet1
            // 
            this.bddEmpresaEnkantaDataSet1.DataSetName = "BDDEmpresaEnkantaDataSet";
            this.bddEmpresaEnkantaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productosTableAdapter1
            // 
            this.productosTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport21;
            this.crystalReportViewer1.Size = new System.Drawing.Size(470, 320);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // FormReporteProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 320);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormReporteProductos";
            this.Text = "FormReporteProductos";
            this.Load += new System.EventHandler(this.FormReporteProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BDDEmpresaEnkantaDataSet bddEmpresaEnkantaDataSet1;
        private Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.productosTableAdapter productosTableAdapter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport2 CrystalReport21;
    }
}
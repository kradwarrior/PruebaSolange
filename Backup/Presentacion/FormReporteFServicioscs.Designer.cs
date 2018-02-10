namespace Presentacion
{
    partial class FormReporteFServicioscs
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
            this.vista_DetalleFServiciosTableAdapter1 = new Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.Vista_DetalleFServiciosTableAdapter();
            this.bddEmpresaEnkantaDataSet1 = new Presentacion.BDDEmpresaEnkantaDataSet();
            this.serviciosTableAdapter1 = new Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.ServiciosTableAdapter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport61 = new Presentacion.CrystalReport6();
            this.facturaServiciosTableAdapter1 = new Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.FacturaServiciosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // vista_DetalleFServiciosTableAdapter1
            // 
            this.vista_DetalleFServiciosTableAdapter1.ClearBeforeFill = true;
            // 
            // bddEmpresaEnkantaDataSet1
            // 
            this.bddEmpresaEnkantaDataSet1.DataSetName = "BDDEmpresaEnkantaDataSet";
            this.bddEmpresaEnkantaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serviciosTableAdapter1
            // 
            this.serviciosTableAdapter1.ClearBeforeFill = true;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport61;
            this.crystalReportViewer1.Size = new System.Drawing.Size(456, 326);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // facturaServiciosTableAdapter1
            // 
            this.facturaServiciosTableAdapter1.ClearBeforeFill = true;
            // 
            // FormReporteFServicioscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 326);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormReporteFServicioscs";
            this.Text = "FormReporteFServicioscs";
            this.Load += new System.EventHandler(this.FormReporteFServicioscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.Vista_DetalleFServiciosTableAdapter vista_DetalleFServiciosTableAdapter1;
        private BDDEmpresaEnkantaDataSet bddEmpresaEnkantaDataSet1;
        private Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.ServiciosTableAdapter serviciosTableAdapter1;
        private CrystalReport6 CrystalReport61;
        private Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.FacturaServiciosTableAdapter facturaServiciosTableAdapter1;
    }
}
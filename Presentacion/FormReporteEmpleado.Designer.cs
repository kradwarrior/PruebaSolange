namespace Presentacion
{
    partial class FormReporteEmpleado
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.vista_EmpleadoTableAdapter1 = new Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.Vista_EmpleadoTableAdapter();
            this.CrystalReport41 = new Presentacion.CrystalReport4();
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // bddEmpresaEnkantaDataSet1
            // 
            this.bddEmpresaEnkantaDataSet1.DataSetName = "BDDEmpresaEnkantaDataSet";
            this.bddEmpresaEnkantaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport41;
            this.crystalReportViewer1.Size = new System.Drawing.Size(640, 433);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // vista_EmpleadoTableAdapter1
            // 
            this.vista_EmpleadoTableAdapter1.ClearBeforeFill = true;
            // 
            // FormReporteEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 433);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormReporteEmpleado";
            this.Text = "FormReporteEmpleado";
            this.Load += new System.EventHandler(this.FormReporteEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bddEmpresaEnkantaDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BDDEmpresaEnkantaDataSet bddEmpresaEnkantaDataSet1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Presentacion.BDDEmpresaEnkantaDataSetTableAdapters.Vista_EmpleadoTableAdapter vista_EmpleadoTableAdapter1;
        private CrystalReport4 CrystalReport41;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormReporteClientes : Form
    {
        public FormReporteClientes()
        {
            InitializeComponent();
        }

        private void FormReporteClientes_Load(object sender, EventArgs e)
        {

            this.vista_ClienteTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.Vista_Cliente);

            CrystalReport3 reporte = new CrystalReport3 ();
            reporte.SetDataSource(bddEmpresaEnkantaDataSet1);
            crystalReportViewer4.ReportSource = reporte;
            

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer4_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormReporteFactura : Form
    {
        public FormReporteFactura()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FormReporteFactura_Load(object sender, EventArgs e)
        {


   
            this.vista_DetalleFacturaTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.Vista_DetalleFactura);

            this.productosTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.productos);

            CrystalReport8 reporte = new CrystalReport8();
            reporte.SetDataSource(bddEmpresaEnkantaDataSet1);
            crystalReportViewer1.ReportSource = reporte;

            
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

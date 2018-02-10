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
    public partial class FormReporteProductos : Form
    {
        public FormReporteProductos()
        {
            InitializeComponent();
        }

        private void FormReporteProductos_Load(object sender, EventArgs e)
        {
            this.productosTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.productos);

            CrystalReport2 reporte = new CrystalReport2();
            reporte.SetDataSource(bddEmpresaEnkantaDataSet1);
            crystalReportViewer1.ReportSource = reporte;
            
        }
    }
}

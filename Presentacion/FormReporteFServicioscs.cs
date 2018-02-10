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
    public partial class FormReporteFServicioscs : Form
    {
        public FormReporteFServicioscs()
        {
            InitializeComponent();
        }

        private void FormReporteFServicioscs_Load(object sender, EventArgs e)
        {
            this.serviciosTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.Servicios);
            this.vista_DetalleFServiciosTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.Vista_DetalleFServicios);
            


            ReporteFS reporte = new ReporteFS();
            reporte.SetDataSource(bddEmpresaEnkantaDataSet1);
            crystalReportViewer1.ReportSource = reporte;

        }
    }
}

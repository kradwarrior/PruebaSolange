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
    public partial class FormReporteEmpleado : Form
    {
        public FormReporteEmpleado()
        {
            InitializeComponent();
        }

        private void FormReporteEmpleado_Load(object sender, EventArgs e)
        {
            this.vista_EmpleadoTableAdapter1.Fill(this.bddEmpresaEnkantaDataSet1.Vista_Empleado);
       
            CrystalReport4 reporte = new CrystalReport4();
            reporte.SetDataSource(bddEmpresaEnkantaDataSet1);
            crystalReportViewer1.ReportSource = reporte;
    
        }

       
    }
}

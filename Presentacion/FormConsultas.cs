using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class FormConsultas : Form
    {
        public FormConsultas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormConsultas_Load(object sender, EventArgs e)
        {
            ClaseConsultas ObjConsultas = new ClaseConsultas();
            int numregistros = 0;


            try
            {
                DataSet DatosEmpleados = ObjConsultas.ConsultarTodosEmpleado();

                numregistros = DatosEmpleados.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No hay ningun Empleado en la Base de Datos");

                }
                else
                {
                    dataGridView1.DataSource = DatosEmpleados.Tables["DatosConsultados"];

                }

                DataSet DatosProductos = ObjConsultas.ConsultarTodosProductos();

                numregistros = DatosProductos.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No hay ningun Producto en la Base de Datos");
                }
                else
                {
                    dataGridView2.DataSource = DatosProductos.Tables["DatosConsultados"];
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error!: " + Ex.Message);
            }
        }
    }
}

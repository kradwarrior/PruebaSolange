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
    public partial class Principal : Form
    {
        
        
            public int TipoDeUsuario;
        public string Usuarios;
        public string Nombre;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Usuarios ObjUsuarios = new Usuarios();

            if ((TipoDeUsuario == 1))
            {
                formularioAdmissToolStripMenuItem.Visible = true;
                formularioEmpleadosToolStripMenuItem.Visible = true;
                formulariosToolStripMenuItem.Visible = true;
                archivoToolStripMenuItem.Visible = true;
                ventanaToolStripMenuItem.Visible = true;
                ayudaToolStripMenuItem.Visible = true;
                MessageBox.Show("Bienvenido Propietario" + ObjUsuarios.Nombre + " , Esta Ingresando Al Sistema El " + DateTime.Now.ToShortDateString() + " A Las " + DateTime.Now.ToShortTimeString(), "Enkanta Eventos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if ((TipoDeUsuario == 2))
            {

              formularioEmpleadosToolStripMenuItem.Visible = true;
               formularioEmpleadosToolStripMenuItem.Visible = true;
                formulariosToolStripMenuItem.Visible = false;
                archivoToolStripMenuItem.Visible = true;
                ventanaToolStripMenuItem.Visible = true;
                ayudaToolStripMenuItem.Visible = true;
                MessageBox.Show("Bienvenido Administrador" + ObjUsuarios.Nombre + " , Esta Ingresando Al Sistema El " + DateTime.Now.ToShortDateString() + " A Las " + DateTime.Now.ToShortTimeString(), "Enkanta Eventos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            else if ((TipoDeUsuario == 3))
            {
               formularioEmpleadosToolStripMenuItem.Visible = true;
               formularioAdmissToolStripMenuItem.Visible = false;
                formulariosToolStripMenuItem.Visible = false;
                archivoToolStripMenuItem.Visible = true;
                ventanaToolStripMenuItem.Visible = true;
                ayudaToolStripMenuItem.Visible = true;
                MessageBox.Show("Bienvenido Empleado" + ObjUsuarios.Nombre + " , Esta Ingresando Al Sistema El " + DateTime.Now.ToShortDateString() + " A Las " + DateTime.Now.ToShortTimeString(), "Enkanta Eventos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           

            toolStripStatusLabel1.Text = "Bienvenido" + ObjUsuarios.Nombre + ", Hoy Es " + DateTime.Now.ToShortDateString();
            Login ObjLogin = new Login();
            DataSet DatosLogin = ObjLogin.ConsultarTodosLosUsuarios();
            DataTable DatosConsultados = DatosLogin.Tables["DatosConsultados"];
            int numregistros = DatosConsultados.Rows.Count;
            if (numregistros == 0)
            {
                MessageBox.Show("Se ha presentado un error en el proceso de inicio de sesión. Intente Nuevamente");
                Principal acceso = new Principal();
                acceso.Show();
                this.Hide();
            }
            else
            {
                //combobox1.DataSource = DatosConsultados;
                //comboBox1.DisplayMember = DatosConsultados.Columns["Nombre"].ToString();
                //comboBox1.ValueMember = DatosConsultados.Columns["Id_Usuario"].ToString();
            }
            }

         private void formulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

      

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cerrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }


        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void serviciosPrestadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
          

        }

      

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromProductos Fomulario1 = new FromProductos();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();

        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }


        private void cascadaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void inventarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false; 
            FromProductos Fomulario1 = new FromProductos();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void serviciosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Servicios Fomulario1 = new Servicios();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();

        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormClientes Fomulario1 = new FormClientes();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();

        }

        private void provedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProvedores Fomulario1 = new FormProvedores();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();

        }

        private void serviciosPrestadosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           

        }

        private void empleadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormEmpleado Fomulario1 = new FormEmpleado();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();

        }

        private void facturacionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           

        }

        private void mosaicoVerticalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);

        }

        private void cerrarTodoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void mosaicoHorizontalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formulariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromProductos Fomulario1 = new FromProductos();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormClientes Fomulario1 = new FormClientes();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormProvedores Fomulario1 = new FormProvedores ();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void serviciosPrestadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void facturacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFactura Fomulario1 = new FormFactura();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           FormEmpleado Fomulario1 = new  FormEmpleado();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FromProductos Fomulario1 = new FromProductos();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes Fomulario1 = new FormClientes ();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProvedores Fomulario1 = new FormProvedores ();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void facturacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormFactura Fomulario1 = new FormFactura ();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultarFactura FormC = new FormConsultarFactura();
            FormC.MdiParent = this;
            FormC.Show(); 
        }

        private void consultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultarUsuarios FormUsusarios = new FormConsultarUsuarios();
            FormUsusarios.MdiParent = this;
            FormUsusarios.Show();

        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultas FormCc = new FormConsultas();
            FormCc.MdiParent = this;
            FormCc.Show();

        }

        private void facturaServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void consultarFacturaServicioToolStripMenuItem_Click(object sender, EventArgs e)

        {
           

        }

        private void formularioAdmissToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactura Fomulario1 = new FormFactura();
            Fomulario1.MdiParent = this;
            Fomulario1.Show();
        }

        private void consultarFacturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormConsultarFactura Formulario1 = new FormConsultarFactura();
            Formulario1.MdiParent = this;
            Formulario1.Show();
        }

        private void generarFacturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFacturaServicios FormCc = new FormFacturaServicios();
            FormCc.MdiParent = this;
            FormCc.Show();

        }

        private void consultarFacturaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConFacServicios FormCc = new FormConFacServicios();
            FormCc.MdiParent = this;
            FormCc.Show(); 
        }

        private void formularioEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteFactura FormCc = new FormReporteFactura();
            FormCc.MdiParent = this;
            FormCc.Show();

        }

        private void facturaServiciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           FormReporteFServicioscs FormCc = new FormReporteFServicioscs();
            FormCc.MdiParent = this;
            FormCc.Show();
        }

       

        private void clientesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            {
                FormReporteClientes FormCc = new FormReporteClientes();
                FormCc.MdiParent = this;
                FormCc.Show();
            }
              
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormReporteEmpleado FormCc = new FormReporteEmpleado();
                FormCc.MdiParent = this;
                FormCc.Show();
            }
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistrarU FormCc = new FormRegistrarU();
            FormCc.MdiParent = this;
            FormCc.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void eNSAYOToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteProductos FormCc = new FormReporteProductos ();
            FormCc.MdiParent = this;
            FormCc.Show();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManual form = new FormManual();
            form.MdiParent = this;
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
}
}
 








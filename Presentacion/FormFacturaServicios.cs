using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;
using System.Text.RegularExpressions;

namespace Presentacion
{
    public partial class FormFacturaServicios : Form

    {
  

        public FormFacturaServicios()
        {
            InitializeComponent();
        }
        public bool ValidarCampoVacio(TextBox CuadroTexto, string nombrecampo)
        {
            string valoringresado = CuadroTexto.Text.Trim();
            if (valoringresado == "")
            {
                MessageBox.Show("El Campo " + nombrecampo + "No Puede Estar Vacio ", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CuadroTexto.BackColor = Color.Tomato;
                return false;
            }
            else
            {
                CuadroTexto.BackColor = Color.White;
                return true;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormClientes FCliente = new FormClientes();
            FCliente.MdiParent = Principal.ActiveForm;
            FCliente.Show();
        }

        private void FormFacturaServicios_Load(object sender, EventArgs e)
        {
            ClaseConsultas ObjConsultas = new ClaseConsultas();
            ClaseFacturaServicios  ObjFactura = new ClaseFacturaServicios();

            int numregistros = 0;
            try
            {
                
                DataSet DatosEmpresa = ObjConsultas.ConsultarEmpresa();

                long NitEmpresa = long.Parse(DatosEmpresa.Tables["DatosConsultados"].Rows[0]["NitEmpresa"].ToString());
                String  NombreEmpresa = (DatosEmpresa.Tables["DatosConsultados"].Rows[0]["Nombre"].ToString());
                label9.Text = NitEmpresa.ToString();
                label10.Text = NombreEmpresa;


                



                DataSet DatosUltimaFactura = ObjFactura.ConsultarUltimaFServicios();
                numregistros = DatosUltimaFactura.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("Importante: No hay ninguna Factura Generada Aun, Por favor Ingrese una Primera Factura De Prueba Para Ajustar El Sistema");
                    label6.Text = "1";
                }
                else
                {
                    int NumUltimaFactura = int.Parse(DatosUltimaFactura.Tables["DatosConsultados"].Rows[0]["NumFactura"].ToString());
                    int NumNuevaFactura = NumUltimaFactura+1;
                    label6.Text = NumNuevaFactura.ToString();
                    MessageBox.Show("Bienvenido, Ingrese su Factura N°" + NumNuevaFactura);
                }

                DataSet DatosEmpleados = ObjConsultas.ConsultarListadoEmpleado();
                numregistros = DatosEmpleados.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No hay empleados registrados en el sistema");
                }
                else
                {
                    comboBox1.DataSource = DatosEmpleados.Tables["DatosConsultados"];
                    comboBox1.DisplayMember = DatosEmpleados.Tables["DatosConsultados"].Columns["NombreCompleto"].ToString();
                    comboBox1.ValueMember = DatosEmpleados.Tables["DatosConsultados"].Columns["IdEmpleado"].ToString();
                }

                DataSet DatosServicios = ObjConsultas.ConsultarListadoServicios ();
                numregistros = DatosServicios.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No hay Servicios registrados en el sistema");
                }
                else
                {
                    comboBox2.DataSource = DatosServicios.Tables["DatosConsultados"];
                    comboBox2.DisplayMember = DatosServicios.Tables["DatosConsultados"].Columns["Nombre"].ToString();
                    comboBox2.ValueMember = DatosServicios.Tables["DatosConsultados"].Columns["IdServicios"].ToString();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Se ha presentado un error, Cierre e Intente nuevamente. " + Ex.Message);
            }



        }
    



        


        private void button1_Click(object sender, EventArgs e)


        {
            Clientes ObjCliente = new Clientes();
            try
            {
                DataSet DatosCliente = ObjCliente.ConsultarCliente(textBox1.Text );

                int numregistros = DatosCliente.Tables["DatosConsultados"].Rows.Count;
                if (numregistros == 0)
                {
                    MessageBox.Show("No existe en la Base de Datos Cliente con esta identificación");
                    label2.Visible = true;
                    linkLabel1.Visible = true;
                }
                else
                {
                    //label10.Text = textBox1.Text;
                    string nombrecliente = DatosCliente.Tables["DatosConsultados"].Rows[0]["Nombre"].ToString();
                    string apellidocliente = DatosCliente.Tables["DatosConsultados"].Rows[0]["Apellidos"].ToString();
                    label8.Text = nombrecliente + " " + apellidocliente;

                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    button3.Visible = true;

                    textBox1.Enabled = false;
                    label2.Visible = false;
                    linkLabel1.Visible = false;
                }
            }
            catch (Exception Ex)

            {
            
                MessageBox.Show("Error!: " + Ex.Message + " " + ObjCliente.Mensaje);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClaseConsultas ObjConsultas = new ClaseConsultas();
            try
            {
                long IdServicios = long.Parse(comboBox2.SelectedValue.ToString());
                DataSet DatosServicios = ObjConsultas.ConsultarServicios(IdServicios);

                string Nombre = DatosServicios.Tables["DatosConsultados"].Rows[0]["Nombre"].ToString();
              
                long ValorUnitario = long.Parse(DatosServicios.Tables["DatosConsultados"].Rows[0]["PrecioServicio"].ToString());
          
                int PorcentajeIva = 19;
                int CantidadDisponible = int.Parse(DatosServicios.Tables["DatosConsultados"].Rows[0]["Cantidad"].ToString());
                int Cantidad = int.Parse(numericUpDown1.Value.ToString());
                long SubTotalSinIva = Cantidad * ValorUnitario;

                long ValorIva = SubTotalSinIva * PorcentajeIva / 100;
                long SubTotal = SubTotalSinIva + ValorIva;

                int Inventario = CantidadDisponible - Cantidad;

                if (Inventario < 0)
                {
                    MessageBox.Show("Solo Hay " + CantidadDisponible + " Unidades Disponibles De Este Servicio");

                }
                else
                {
                    dataGridView1.Rows.Add(IdServicios, Nombre, ValorUnitario, Cantidad, ValorIva, SubTotal);

                }




            }
            catch (Exception Ex)
            {
                MessageBox.Show("Se ha presentado un error, Cierre e Intente nuevamente. " + Ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            ClaseFacturaServicios  ObjFactura = new ClaseFacturaServicios();
            try
            {
                ObjFactura.NumFactura = int.Parse(label6.Text);
                ObjFactura.NitEmpresa = long.Parse(label9.Text);
            ObjFactura.Fecha = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
            ObjFactura.IdEmpleado = long.Parse(comboBox1.SelectedValue.ToString());
            ObjFactura.IdCliente = long.Parse(textBox1.Text);
   


            bool insertarfacturaOK = ObjFactura.InsertarFacturaServicios(); 

            if (insertarfacturaOK == true)
             {
                 bool insertardetalleOK = false;
                 int filas = dataGridView1.Rows.Count; 
                
                for (int i = 0; i<filas-1;i++)
                {
                    ObjFactura.NitEmpresa = long.Parse(label9.Text);
                    ObjFactura.NumFactura = int.Parse(label6.Text);
                    ObjFactura.IdServicios = long.Parse(dataGridView1.Rows[i].Cells["IdServicios"].Value.ToString());
                    ObjFactura.Cantidad = int.Parse(dataGridView1.Rows[i].Cells["Cantidad"].Value.ToString()); 
                    ObjFactura.ValorIva = long.Parse(dataGridView1.Rows[i].Cells["ValorIva"].Value.ToString());
                    ObjFactura.SubTotal = long.Parse(dataGridView1.Rows[i].Cells["SubTotal"].Value.ToString());

                    insertardetalleOK = ObjFactura.InsertarDetalleFServicios();

                }

                if (insertardetalleOK == true)
                {
                    
                    MessageBox.Show("La Factura Fue Generada correctamente");
                    FormConFacServicios FConsultarFactura = new FormConFacServicios();
                    FConsultarFactura.MdiParent = Principal.ActiveForm;
                    FConsultarFactura.NumFactura = int.Parse(label6.Text);
                    FConsultarFactura.Show();

                    this.Close();


                }
                else
                {
                    if (ObjFactura.NumFactura == 1)
                    {
                        MessageBox.Show("El Sistema Fue ajustado con exito, puede iniciar a generar sus facturas");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La Factura Fue Generada pero no se pudo completar  el detalle");
                    }
                }
        
             }
            else
             {
                 MessageBox.Show("La Factura No Pudo Generarse. " + ObjFactura.Mensaje);
             }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error!: " + Ex.Message + " " + ObjFactura.Mensaje);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        }

        }



        
    




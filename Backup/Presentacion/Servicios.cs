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
    public partial class Servicios : Form
    {
        public Servicios()
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
        public bool validarEmail(TextBox cuadroTexto)
        {
            string email = cuadroTexto.Text;

            bool emailvalido = false;
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                cuadroTexto.BackColor = Color.White;
                emailvalido = true;
            }
            else
            {
                MessageBox.Show("Desde Ingresar Un Valor De E-Mail Valido(Ejemplo: correo@servidor.com)", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cuadroTexto.BackColor = Color.Tomato;
                emailvalido = false;
            }
            return emailvalido;
        }
        private void Servicios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox1, "IdServicios") && ValidarCampoVacio(textBox5, "Nombre") && ValidarCampoVacio(textBox2, "TipoDeServicio") && ValidarCampoVacio(textBox3, "Cantidad")&& ValidarCampoVacio(textBox10, "TipoServicio"))
            {
                ClaseServicios ObjServicios = new ClaseServicios();
                try
                {
                    ObjServicios.IdServicios = long.Parse(textBox1.Text);
                    ObjServicios.Nombre = textBox5.Text;
                    ObjServicios.TipoDeServicio = textBox2.Text;
                    ObjServicios.Cantidad = textBox3.Text;
                    ObjServicios.PrecioServicio = long.Parse(textBox10.Text);



                    bool respuestaSQL = ObjServicios.InsertServicio();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos Del Nuevo Servicio Fueron Insertados Correctamente");
                        textBox1.Text = ""; textBox5.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox10.Text = ""; 
                    }
                    else
                    {
                        MessageBox.Show(ObjServicios.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjServicios.Mensaje);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox8, "IdServicios"))
            {
                ClaseServicios ObjServicios = new ClaseServicios();
                try
                {
                    DataSet DatosServicios = ObjServicios.ConsultarServicios(textBox8.Text);
                    DataTable DatosConsultados = DatosServicios.Tables["DatosConsultados"];

                    int numregistros = DatosConsultados.Rows.Count;

                    if (numregistros == 0)
                    {
                        MessageBox.Show("No Existe En La Base De Datos Un Servicio Con Esta Identificacion");
                    }
                    else
                    {
                        textBox7.Text = DatosConsultados.Rows[0]["Nombre"].ToString();
                        textBox6.Text = DatosConsultados.Rows[0]["TipoDeServicio"].ToString();
                        textBox4.Text = DatosConsultados.Rows[0]["Cantidad"].ToString();
                        textBox11.Text = DatosConsultados.Rows[0]["PrecioServicio"].ToString();


                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjServicios.Mensaje);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox7, "Nombre") && ValidarCampoVacio(textBox6, "TipoDeServicio") && ValidarCampoVacio(textBox4, "Cantidad")& ValidarCampoVacio(textBox11, "PrecioServicio"))
            {

                ClaseServicios ObjServicios = new ClaseServicios();

                try
                {
                    ObjServicios.IdServicios = long.Parse(textBox8.Text);
                    ObjServicios.Nombre = textBox7.Text;
                    ObjServicios.TipoDeServicio = textBox6.Text;
                    ObjServicios.Cantidad = textBox4.Text;
                    ObjServicios.PrecioServicio = long.Parse(textBox11.Text);



                    bool respuestaSQL = ObjServicios.ActualizarServicios();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Servicio Fueron Actualizados Correctamente");
                        textBox8.Text = ""; textBox7.Text = ""; textBox6.Text = ""; textBox4.Text = ""; textBox11.Text = "";

                    }
                    else
                    {
                        MessageBox.Show(ObjServicios.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjServicios.Mensaje);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult seleccion = MessageBox.Show("Seguro Que Quieres Eliminar Este Servicio ", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (seleccion == DialogResult.Yes)
            {


                ClaseServicios ObjServicios = new ClaseServicios();
                try
                {
                    bool respuestaSQL = ObjServicios.EliminarServicios(textBox8.Text);
                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Servicio Fueron Eliminados Correctamente");
                        textBox8.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox4.Text = ""; textBox11.Text =  ".l.";

                    }
                    else
                    {
                        MessageBox.Show(ObjServicios.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!:" + Ex.Message + " " + ObjServicios.Mensaje);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox9, "IdServicios"))
            {

                ClaseServicios ObjServicios = new ClaseServicios();
                try
                {
                    DataSet datosServicios = ObjServicios.ConsultarServicios(textBox9.Text);

                    DataTable DatosConsultados = datosServicios.Tables["DatosConsultados"];
                    int numregistros = DatosConsultados.Rows.Count;
                    if (numregistros == 0)
                    {

                        MessageBox.Show("No Existe En La Base De Datos Un Servicio Con Esta Identificacion");
                    }
                    else
                    {
                        dataGridView1.DataSource = DatosConsultados;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjServicios.Mensaje);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            ClaseServicios ObjServicios = new ClaseServicios();


            try
            {
                DataSet DatosServicios = ObjServicios.ConsultarTodosServicios();
                DataTable DatosConsultados = DatosServicios.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Servicio En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjServicios.Mensaje);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}


        
        

        
    

    

    


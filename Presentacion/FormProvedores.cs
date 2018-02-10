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
    public partial class FormProvedores : Form
    {
        public FormProvedores()
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



        private void Provedores_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox1, "Identificacion") && ValidarCampoVacio(textBox5, "Nombre") && ValidarCampoVacio(textBox3, "Direccion") && ValidarCampoVacio(textBox7, "Telefono")
               && ValidarCampoVacio(textBox7, "tipodeproveedor") && validarEmail(textBox6))
                { 

            Proveedor ObjProveedores = new Proveedor();
            try
            {
                ObjProveedores.IdentificacionPro = long.Parse(textBox1.Text);
                ObjProveedores.Nombre = textBox5.Text;
                ObjProveedores.Direccion = textBox3.Text;
                ObjProveedores.Email = textBox6.Text;
                ObjProveedores.Telefono = long.Parse(textBox7.Text);
                ObjProveedores.TipoDeProveedor = textBox4.Text;
                bool respuestaSQL = ObjProveedores.InsertProveedor();

                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos Del Nuevo Proveedor Fueron Insertados Correctamente");
                    textBox1.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
                }
                else
                {
                    MessageBox.Show(ObjProveedores.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProveedores.Mensaje);
            }
        }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Proveedor ObjProveedor = new Proveedor();
            try
            {
                DataSet DatosProveedor = ObjProveedor.ConsultarProveedor(textBox8.Text);
                DataTable DatosConsultados = DatosProveedor.Tables["DatosConsultados"];

                int numregistros = DatosConsultados.Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Proveedores Con Esta Identificacion");
                }
                else
                {
                    textBox13.Text = DatosConsultados.Rows[0]["Nombre"].ToString();
                    textBox10.Text = DatosConsultados.Rows[0]["Email"].ToString();
                    textBox11.Text = DatosConsultados.Rows[0]["Telefono"].ToString();
                    textBox12.Text = DatosConsultados.Rows[0]["Direccion"].ToString();
                    textBox15.Text = DatosConsultados.Rows[0]["TipoDeProveedor"].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProveedor.Mensaje);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             Proveedor ObjProveedor = new Proveedor();

            try
            {
                ObjProveedor.IdentificacionPro = long.Parse(textBox8.Text);
                ObjProveedor.Nombre = textBox13.Text;
                ObjProveedor.Direccion = textBox12.Text;
                ObjProveedor.Telefono = long.Parse(textBox11.Text);
                ObjProveedor.Email = textBox10.Text;
                ObjProveedor.TipoDeProveedor = textBox15.Text;
                bool respuestaSQL = ObjProveedor.ActualizarProveedor();

                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos De Este Proveedor Fueron Actualizados Coreectamente");
                    textBox8.Text = ""; textBox13.Text = ""; textBox12.Text = ""; textBox11.Text = ""; textBox10.Text = ""; textBox15.Text = "";
                }
                else
                {
                    MessageBox.Show(ObjProveedor.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProveedor.Mensaje);
            }

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Proveedor ObjProveedor = new Proveedor();
            try
            {
                bool respuestaSQL = ObjProveedor.EliminarProveedor(textBox8.Text);
                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos De Este Proveedor Fueron Eliminados Correctamente");
                    textBox8.Text =  ""; textBox13.Text = ""; textBox12.Text = ""; textBox11.Text = ""; textBox10.Text = ""; textBox15.Text = "";
                }
                else
                {
                    MessageBox.Show(ObjProveedor.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!:" + Ex.Message + " " + ObjProveedor.Mensaje);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Proveedor ObjProveedor = new Proveedor();
            try
            {
                DataSet DatosProveedor = ObjProveedor.ConsultarProveedor(textBox14.Text);
                DataTable DatosConsultados = DatosProveedor.Tables["DatosConsultados"];
                int numregistros = DatosConsultados.Rows.Count;
                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Proveedor Con Esta Identificacion");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProveedor.Mensaje);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Proveedor ObjProveedor = new Proveedor();
            try
            {
                DataSet DatosProveedor = ObjProveedor.ConsultarTodosProveedores();
                DataTable DatosConsultados = DatosProveedor.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Proveedor En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show ("ERROR!: " + Ex.Message + " " + ObjProveedor.Mensaje);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
              if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox5.Focus(); 
        }
        }


        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                
            }
        
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

              if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox4.Focus(); 
        }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox3.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button2.Focus(); 
            }

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox12.Focus(); 
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button3.Focus();

        }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button5.Focus();  
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
        
   
}

    



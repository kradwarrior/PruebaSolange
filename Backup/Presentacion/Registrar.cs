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
    public partial class Registrar : Form
    {
        public Registrar()
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

        private void button3_Click(object sender, EventArgs e)
        {
            loginad lg = new loginad();
            lg.Show();
            this.Hide(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loginad lg = new loginad();
            lg.Show();
            this.Hide(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ValidarCampoVacio(textBox16, "Id_Usuario") && ValidarCampoVacio(textBox15, "Nombre") && ValidarCampoVacio(textBox14, "Apellido") && ValidarCampoVacio(textBox12, "Telefono") && validarEmail(textBox13) && ValidarCampoVacio(textBox9, "Direccion") && ValidarCampoVacio(textBox11, "Salario") && ValidarCampoVacio(textBox18, "Usuario"))
            
            {
                Usuarios ObjUsuarios = new Usuarios();
                try
                {
                    ObjUsuarios.Id_Usuario = long.Parse(textBox16.Text);
                    ObjUsuarios.Nombre = textBox15.Text;
                    ObjUsuarios.Apellido = textBox14.Text;
                    ObjUsuarios.Email = textBox13.Text;
                    ObjUsuarios.Telefono = long.Parse(textBox12.Text);
                    ObjUsuarios.Direccion = textBox9.Text;
                    ObjUsuarios.Salario = long.Parse(textBox11.Text);
  
            
                    ObjUsuarios.Contraseña = textBox17.Text;
                    ObjUsuarios.Usuario = textBox18.Text;
                    ObjUsuarios.TipoDeUsuario = Convert.ToInt32(comboBox1.Text);


                    bool respuestaSQL = ObjUsuarios.InsertUsuarios();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos Del Nuevo Usuario Fueron Insertados Correctamente");
                        textBox16.Text = ""; textBox15.Text = ""; textBox14.Text = ""; textBox13.Text = ""; textBox12.Text = ""; textBox9.Text = ""; textBox11.Text = ""; textBox17.Text = ""; textBox18.Text = "";
                        loginad acceso = new loginad();
                        acceso.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(ObjUsuarios.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjUsuarios.Mensaje);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Registrar_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

     

      

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox8.Focus();
            }
        }

      

        

     

        

       

      

        private void textBox16_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox15.Focus();
            }
        }

        private void textBox15_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            

            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox14.Focus();
            }
        }

        private void textBox14_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox12.Focus();
            }
        }

        private void textBox12_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox11.Focus();
            }
        }

        private void textBox11_KeyPress_1(object sender, KeyPressEventArgs e)
        {
    
        }

        private void textBox9_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox17.Focus();
            }
        }

        private void textBox17_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox12.Focus();
            }
        }

   

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == 13)
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
                {
                    MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                if (e.KeyChar == 13)
                {
                    comboBox1.Focus();
                }
            }
       
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}

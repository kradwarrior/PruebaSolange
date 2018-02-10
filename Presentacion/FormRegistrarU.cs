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
    public partial class FormRegistrarU : Form
    {
        public FormRegistrarU()
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void FormRegistrarU_Load(object sender, EventArgs e)
        {
        
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
                {
                    MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                if (e.KeyChar == 13)
                {
                    textBox17.Focus();
                }
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
                {
                    MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                if (e.KeyChar == 13)
                {
                    textBox9.Focus();
                }
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)

        { }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {


          
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        
            {


                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
                {
                    MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                if (e.KeyChar == 13)
                {
                    textBox13.Focus();
                }
            }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
           
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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        
        

        }
    }



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
    public partial class loginad : Form
    {
        public loginad()
        {
            InitializeComponent();
        }
     


        private void button1_Click(object sender, EventArgs e)

        {
            Login ObjLogin = new Login();
            try
            {
                DataSet DatosLogin = ObjLogin.ConsultarUsuario(textBox1.Text);
                DataTable DatosConsultados = DatosLogin.Tables["DatosConsultados"];
                int numregistros = DatosConsultados.Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No se pudo iniciar sesión, verifique su usuario y/o contraseña");

                }
                else
                {
                    string PasswordAlmacenado =
                    DatosConsultados.Rows[0]["Contraseña"].ToString();


                    ObjLogin.Usuario =
                    DatosConsultados.Rows[0]["Usuario"].ToString();


                    ObjLogin.TipoDeUsuario = int.Parse
                    (DatosConsultados.Rows[0]["TipoDeUsuario"].ToString());



                    ObjLogin.Nombre =
                    DatosConsultados.Rows[0]["Nombre"].ToString();
                    if (PasswordAlmacenado == textBox2.Text)
                    {


                        Principal acceso = new Principal();
                        acceso.Nombre = ObjLogin.Nombre;
                        acceso.Usuarios = ObjLogin.Usuario;
                        acceso.TipoDeUsuario = ObjLogin.TipoDeUsuario;

                        acceso.Show();
                        this.Hide();



                    }
                    else
                    {

                        MessageBox.Show("No se pudo inciar sesión, verifique su usuario y/o contraseña");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo inciar sesión, verifique su usuario y/o contraseña");
            }

            {   
            //label4.Text = "La Llave primaria(Id_Usuario) de " + comboBox1.Text + " es " + comboBox1.SelectedValue;
            }
        }



     








  
                    

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void loginad_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Se ha presentado un error en el proceso de inicio de sesión. Intente Nuevamente");
            //    Principal acceso = new Principal();
            //    acceso.Show();
            //    this.Hide();
            
  
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Registrar  lg = new Registrar();
            lg.Show();
            this.Hide();
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         

            //e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}

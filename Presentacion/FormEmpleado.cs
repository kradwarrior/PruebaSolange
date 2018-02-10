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
    public partial class FormEmpleado : Form
    {
        public FormEmpleado()
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


        private void Empleados_Load(object sender, EventArgs e)
        {

        }
   


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




        private void button1_Click_1(object sender, EventArgs e)
        {


            if (ValidarCampoVacio(textBox1, "Identificacion") && ValidarCampoVacio(textBox2, "Nombre") && ValidarCampoVacio(textBox3, "apellido") && ValidarCampoVacio(textBox4, "Apellido")
              && ValidarCampoVacio(textBox5, "Telefono") && validarEmail(textBox6) && ValidarCampoVacio(textBox8, "Salario"))
            {

                Empleado ObjEmpleados = new Empleado();
                try
                {
                    ObjEmpleados.IdEmpleado = long.Parse(textBox1.Text);
                    ObjEmpleados.Nombre = textBox2.Text;
                    ObjEmpleados.Apellidos = textBox3.Text;
                    ObjEmpleados.Direccion = textBox4.Text;
                    ObjEmpleados.Telefono = long.Parse(textBox5.Text);
                    ObjEmpleados.Email = textBox6.Text;
                    
                    ObjEmpleados.Salario = long.Parse(textBox8.Text);



                    bool respuestaSQL = ObjEmpleados.InsertEmpleado();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Empleado Fueron Guardados Coreectamente");
                        textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox8.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(ObjEmpleados.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjEmpleados.Mensaje);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

             if (ValidarCampoVacio(textBox9, "Identificacion"))

             {

            Empleado ObjEmpleados = new Empleado();
            try
            {
                DataSet DatosEmpleado = ObjEmpleados.ConsultarEmpleado(textBox9.Text);
                DataTable DatosConsultados = DatosEmpleado.Tables["DatosConsultados"];

                int numregistros = DatosConsultados.Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Empleados Con Esta Identificacion");
                }
                else
                {
                    textBox10.Text = DatosConsultados.Rows[0]["Nombre"].ToString();
                    textBox11.Text = DatosConsultados.Rows[0]["Apellidos"].ToString();
                    textBox12.Text = DatosConsultados.Rows[0]["Direccion"].ToString();
                    textBox13.Text = DatosConsultados.Rows[0]["Telefono"].ToString();
                    textBox14.Text = DatosConsultados.Rows[0]["Email"].ToString();
                   
                    textBox16.Text = DatosConsultados.Rows[0]["Salario"].ToString();
                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjEmpleados.Mensaje);
            }
        }
    }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

             Empleado ObjEmpleado = new Empleado();

            try
            {
                ObjEmpleado.IdEmpleado = long.Parse(textBox9.Text);
                ObjEmpleado.Nombre = textBox10.Text;
                ObjEmpleado.Apellidos = textBox11.Text;
                ObjEmpleado.Direccion = textBox12.Text;
                ObjEmpleado.Telefono = long.Parse(textBox13.Text);
                ObjEmpleado.Email = textBox14.Text;
              
                ObjEmpleado.Salario = long.Parse(textBox16.Text);
                bool respuestaSQL = ObjEmpleado.ActualizarEmpleado();

                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos De Este Empleado Fueron Actualizados Coreectamente");
                    textBox9.Text = ""; textBox10.Text = ""; textBox11.Text = "";  textBox13.Text = ""; textBox14.Text = "";textBox16.Text = "";
                }
                else
                {
                    MessageBox.Show(ObjEmpleado.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjEmpleado.Mensaje);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Empleado ObjEmpleado = new Empleado();
            try
            {
                bool respuestaSQL = ObjEmpleado.EliminarEmpleado(textBox9.Text);
                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos De Este Empleado Fueron Eliminados Correctamente");
                    textBox9.Text =  ""; textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; textBox13.Text = ""; textBox14.Text =  "";textBox16.Text = "";
                }
                else
                {
                    MessageBox.Show(ObjEmpleado.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!:" + Ex.Message + " " + ObjEmpleado.Mensaje);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox17, "Identificacion"))
            {

                Empleado ObjEmpleado = new Empleado();
                try
                {
                    DataSet DatosEmpleado = ObjEmpleado.ConsultarEmpleado(textBox17.Text);
                    DataTable DatosConsultados = DatosEmpleado.Tables["DatosConsultados"];
                    int numregistros = DatosConsultados.Rows.Count;
                    if (numregistros == 0)
                    {
                        MessageBox.Show("No Existe En La Base De Datos Empleado Con Esta Identificacion");
                    }
                    else
                    {
                        dataGridView1.DataSource = DatosConsultados;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjEmpleado.Mensaje);
                }
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
             Empleado ObjEmpleado = new Empleado();
            try
            {
                DataSet DatosEmpleado = ObjEmpleado.ConsultarTodosEmpleado();
                DataTable DatosConsultados = DatosEmpleado.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Empleado En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show ("ERROR!: " + Ex.Message + " " + ObjEmpleado.Mensaje);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                textBox2.Focus();
            }
        
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox4.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox6.Focus();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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
                button1.Focus(); 
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox11.Focus();
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
                textBox16.Focus();
            }
        }
        
        

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox12.Focus();
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox14.Focus();
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button3.Focus();
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FormEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
        }
        
    


        
        



        







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
    public partial class FormClientes : Form
    {
        public FormClientes()
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



        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox1, "Identificacion") && ValidarCampoVacio(textBox2, "Nombre") && ValidarCampoVacio(textBox3, "apellido") && ValidarCampoVacio(textBox6, "Direccion")
               && ValidarCampoVacio(textBox7, "Telefono") && validarEmail(textBox5))
            {
                Clientes ObjClientes = new Clientes();
                try
                {
                    ObjClientes.IdCliente = long.Parse(textBox1.Text);
                    ObjClientes.Apellidos = textBox2.Text;
                    ObjClientes.Nombre = textBox3.Text;
                    ObjClientes.Direccion = textBox6.Text;
                    ObjClientes.Telefono = long.Parse(textBox7.Text);
                    ObjClientes.Email = textBox5.Text;

                    bool respuestaSQL = ObjClientes.InsertarCliente();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos Del Nuevo Cliente Fueron Insertados Correctamente");
                        textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox5.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(ObjClientes.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjClientes.Mensaje);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ValidarCampoVacio(textBox4, "IdCliente"))

            {
                Clientes ObjClientes = new Clientes();
                try
                {
                    DataSet DatosCliente = ObjClientes.ConsultarCliente(textBox4.Text);
                    DataTable DatosConsultados = DatosCliente.Tables["DatosConsultados"];

                    int numregistros = DatosConsultados.Rows.Count;

                    if (numregistros == 0)
                    {
                        MessageBox.Show("No Existe En La Base De Datos Clientes Con Esta Identificacion");
                    }
                    else
                    {
                        textBox8.Text = DatosConsultados.Rows[0]["Nombre"].ToString();
                        textBox9.Text = DatosConsultados.Rows[0]["Apellidos"].ToString();
                        textBox10.Text = DatosConsultados.Rows[0]["Direccion"].ToString();
                        textBox11.Text = DatosConsultados.Rows[0]["Telefono"].ToString();
                        textBox12.Text = DatosConsultados.Rows[0]["Email"].ToString();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjClientes.Mensaje);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox8, "Nombre") && ValidarCampoVacio(textBox9, "apellido") && ValidarCampoVacio(textBox10, "Direccion")
               && ValidarCampoVacio(textBox11, "Telefono") && validarEmail(textBox12))
            {

                Clientes ObjClientes = new Clientes();

                try
                {
                    ObjClientes.IdCliente = long.Parse(textBox4.Text);
                    ObjClientes.Nombre = textBox8.Text;
                    ObjClientes.Apellidos = textBox9.Text;
                    ObjClientes.Direccion = textBox10.Text;
                    ObjClientes.Telefono = long.Parse(textBox11.Text);
                    ObjClientes.Email = textBox12.Text;

                    bool respuestaSQL = ObjClientes.ActualizarCliente();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Cliente Fueron Actualizados Coreectamente");
                        textBox4.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(ObjClientes.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjClientes.Mensaje);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult seleccion = MessageBox.Show("Seguro que quieres eliminar el cliente ", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (seleccion == DialogResult.Yes)
            {


                Clientes ObjClientes = new Clientes();
                try
                {
                    bool respuestaSQL = ObjClientes.ElminarCliente(textBox4.Text);
                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Cliente Fueron Eliminados Correctamente");
                        textBox4.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(ObjClientes.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!:" + Ex.Message + " " + ObjClientes.Mensaje);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (ValidarCampoVacio(textBox13, "IdCliente"))

            {

            Clientes ObjCliente = new Clientes();
            try
            {
                DataSet datosCliente = ObjCliente.ConsultarCliente(textBox13.Text);

                DataTable DatosConsultados = datosCliente.Tables["DatosConsultados"];
                int numregistros = DatosConsultados.Rows.Count;
                if (numregistros == 0)

                {

                    MessageBox.Show("No Existe En La Base De Datos  Cliente Con Esta Identificacion");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjCliente.Mensaje);
            }
        }
    }

        private void button6_Click(object sender, EventArgs e)
        {
            Clientes ObjClientes = new Clientes();
            try
            {
                DataSet DatosCliente = ObjClientes.ConsultarTodosClientes();
                DataTable DatosConsultados = DatosCliente.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Cliente En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjClientes.Mensaje);
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
                textBox2.Focus();
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
                textBox5.Focus();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
            {
                MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox10.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        { if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)

            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                button2.Focus(); 
            }

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 32)
                {
                    MessageBox.Show("Debe Ingresar Solo Letras En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                if (e.KeyChar == 13)
                {
                    textBox9.Focus();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
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

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

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
                button5.Focus();
            }


        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        //internal DataSet ConsultarClientes(string p, string p_2)
        //{
        //    throw new NotImplementedException();
            
        }
    }

        
        
        
    




        

        

        
        
    


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
    public partial class FromProductos : Form
    {
        public FromProductos()
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Inventario_Load(object sender, EventArgs e)
        {
          Proveedor ObjProveedor = new Proveedor ();

            int numregistros = 0;
            try
            {
                DataSet DatosProveedor = ObjProveedor.ConsultarTodosProveedores();
                numregistros = DatosProveedor.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No Hay Proveedores Registrados En El Sistema");
                }
                else
                {
                    comboBox1.DataSource = DatosProveedor.Tables["DatosConsultados"];
                    comboBox1.DisplayMember = DatosProveedor.Tables["DatosConsultados"].Columns["Nombre"].ToString();
                    comboBox1.ValueMember = DatosProveedor.Tables["DatosConsultados"].Columns["IdentificacionPro"].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Se ha presentado un error, Cierre e Intente nuevamente. " + Ex.Message);
            }

            try
            {
                DataSet DatosProveedor = ObjProveedor.ConsultarTodosProveedores();
                numregistros = DatosProveedor.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No Hay Proveedores Registrados En El Sistema");
                }
                else
                {
                    comboBox2.DataSource = DatosProveedor.Tables["DatosConsultados"];
                    comboBox2.DisplayMember = DatosProveedor.Tables["DatosConsultados"].Columns["Nombre"].ToString();
                    comboBox2.ValueMember = DatosProveedor.Tables["DatosConsultados"].Columns["IdentificacionPro"].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Se ha presentado un error, Cierre e Intente nuevamente. " + Ex.Message);
            }


        }
           

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarCampoVacio(textBox1, "IdProducto") && ValidarCampoVacio(textBox2, "Nombre") && ValidarCampoVacio(textBox5, "Descripcion") && ValidarCampoVacio(textBox3, "Cantidad")
                && ValidarCampoVacio(textBox4, "PrecioVenta") && ValidarCampoVacio(textBox6, "PrecioCompra"))
            {





                Productos ObjProducto = new Productos();
                try
                {
                    ObjProducto.IdProducto = long.Parse(textBox1.Text);
                    ObjProducto.Nombre = textBox2.Text;
                    ObjProducto.Cantidad = long.Parse(textBox3.Text);
                    ObjProducto.Descripcion = textBox5.Text;
                    ObjProducto.PrecioVenta = long.Parse(textBox4.Text);
                    ObjProducto.PrecioCompra = long.Parse(textBox6.Text);
                    ObjProducto.FechaDeEntrada = dateTimePicker1.Value.ToShortDateString();
                    ObjProducto.IdentificacionPro = long.Parse(comboBox1.SelectedValue.ToString());
                    bool respuestaSQL = ObjProducto.InsertProductos();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos Del Nuevo Producto Fueron Insertados Correctamente");
                        textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; 
                    }
                    else
                    {
                        MessageBox.Show(ObjProducto.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProducto.Mensaje);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
             if (ValidarCampoVacio(textBox7, "IdProducto")) 

             {

            Productos ObjProducto = new Productos();
            try
            {
                DataSet DatosProducto = ObjProducto.ConsultarProductos(textBox7.Text);
                DataTable DatosConsultados = DatosProducto.Tables["DatosConsultados"];

                int numregistros = DatosConsultados.Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Productos Con Este Id");
                }
                else
                {
                    textBox8.Text = DatosConsultados.Rows[0]["Nombre"].ToString();
                    textBox9.Text = DatosConsultados.Rows[0]["Cantidad"].ToString();
                    textBox10.Text = DatosConsultados.Rows[0]["Descripcion"].ToString();
                    textBox11.Text = DatosConsultados.Rows[0]["PrecioVenta"].ToString();
                    textBox12.Text = DatosConsultados.Rows[0]["PrecioCompra"].ToString();
                    dateTimePicker2.Text = DatosConsultados.Rows[0]["FechaDeEntrada"].ToString();
                    comboBox2.Text = DatosConsultados.Rows[0]["IdentificacionPro"].ToString();
                   
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProducto.Mensaje);
            }
        }
    }

        private void button3_Click(object sender, EventArgs e)
        {

            if ( ValidarCampoVacio(textBox8, "Nombre") && ValidarCampoVacio(textBox9, "Descripcion") && ValidarCampoVacio(textBox10, "Cantidad")
                && ValidarCampoVacio(textBox11, "PrecioVenta") && ValidarCampoVacio(textBox12, "PrecioCompra") )
            {


                Productos ObjProducto = new Productos();

                try
                {
                    ObjProducto.IdProducto = long.Parse(textBox7.Text);
                    ObjProducto.Nombre = textBox8.Text;
                    ObjProducto.Cantidad = long.Parse(textBox9.Text);
                    ObjProducto.Descripcion = textBox10.Text;
                    ObjProducto.PrecioVenta = long.Parse(textBox11.Text);
                    ObjProducto.PrecioCompra = long.Parse(textBox12.Text);
                    ObjProducto.FechaDeEntrada = dateTimePicker2.Value.ToShortDateString();
                    ObjProducto.IdentificacionPro = long.Parse(comboBox1.SelectedValue.ToString());
                   
                    bool respuestaSQL = ObjProducto.ActualizarProductos();

                    if (respuestaSQL == true)
                    {
                        MessageBox.Show("Los Datos De Este Producto Fueron Actualizados Coreectamente");
                        textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; dateTimePicker2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(ObjProducto.Mensaje);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProducto.Mensaje);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        { if (ValidarCampoVacio(textBox7, "IdProducto")) 

        {
            Productos ObjProducto = new Productos();
            try
            {
                bool respuestaSQL = ObjProducto.EliminarProductos(textBox7.Text);
                if (respuestaSQL == true)
                {
                    MessageBox.Show("Los Datos De Este Producto Fueron Eliminados Correctamente");
                    textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = ""; textBox11.Text = ""; textBox12.Text = ""; dateTimePicker2.Text = ""; 
                }
                else
                {
                    MessageBox.Show(ObjProducto.Mensaje);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!:" + Ex.Message + " " + ObjProducto.Mensaje);
            }
        }
    }

        private void button5_Click(object sender, EventArgs e)
        {
             Productos ObjProducto = new Productos();
            try
            {
                DataSet DatosProducto = ObjProducto.ConsultarProductos(textBox15.Text);
                DataTable DatosConsultados = DatosProducto.Tables["DatosConsultados"];
                int numregistros = DatosConsultados.Rows.Count;
                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Productos Con Esta Id");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjProducto.Mensaje);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Productos ObjProducto = new Productos ();
            try
            {
                DataSet DatosProducto = ObjProducto.ConsultarTodosProductos();
                DataTable DatosConsultados = DatosProducto.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Producto En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show ("ERROR!: " + Ex.Message + " " + ObjProducto.Mensaje);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar)&& e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
            }
            if (e.KeyChar ==13)
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
                textBox5.Focus();
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
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox6.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
          
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

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
                textBox8.Focus();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                textBox10.Focus();
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                MessageBox.Show("Debe Ingresar Solo Numeros En Este Campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                
            }


        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        }
}

        
        
        
        
    

        

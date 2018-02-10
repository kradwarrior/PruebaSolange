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
    public partial class FormConsultarUsuarios : Form
    {
        public FormConsultarUsuarios()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         Usuarios ObjUsuario = new Usuarios();
            try
            {
                DataSet DatosUsuario = ObjUsuario.ConsultarUsuarios(textBox1.Text);
                DataTable DatosConsultados = DatosUsuario.Tables["DatosConsultados"];
                int numregistros = DatosConsultados.Rows.Count;
                if (numregistros == 0)
                {
                    MessageBox.Show("No Existe En La Base De Datos Un Usuario Con Esta Id");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR!: " + Ex.Message + " " + ObjUsuario.Mensaje);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         Usuarios ObjUsuario = new Usuarios ();
            try
            {
                DataSet DatosUsuario = ObjUsuario.ConsultarTodosUsuarios();
                DataTable DatosConsultados = DatosUsuario.Tables["DatosConsultados"];
                int numresgitros = DatosConsultados.Rows.Count;
                if (numresgitros == 0)
                {
                    MessageBox.Show("No Hay Ningun Usuario En La Base De Datos");
                }
                else
                {
                    dataGridView1.DataSource = DatosConsultados;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show ("ERROR!: " + Ex.Message + " " + ObjUsuario.Mensaje);
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
                button1.Focus();
            }
        }

        }
        }
    


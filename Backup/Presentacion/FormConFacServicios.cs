﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks.Printing;
using Logica; 

namespace Presentacion
{
    public partial class FormConFacServicios : Form
    {
        public int NumFactura = 0;

        public FormConFacServicios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarFactura(int.Parse(textBox1.Text));
        }

        private void FormConFacServicios_Load(object sender, EventArgs e)
        {
            if (NumFactura != 0)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;

                MostrarFactura(NumFactura);

            }
          
        }
        public void MostrarFactura(int NumFactura)
        {
            ClaseFacturaServicios ObjFactura = new ClaseFacturaServicios(); 


            try
            {
                DataSet DatosFactura = ObjFactura.ConsultarFServicios(NumFactura);


                int numregistros = DatosFactura.Tables["DatosConsultados"].Rows.Count;

                if (numregistros == 0)
                {
                    MessageBox.Show("La Factura N° " + NumFactura + "Aun No Ha Sido Creada ");
                }
                else
                {
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;



                    label5.Text = label5.Text + "" + NumFactura;

                    String Fecha ="Fecha: " + DatosFactura.Tables["DatosConsultados"].Rows[0]["Fecha"].ToString();
                    label6.Text = label6.Text + " " + Fecha;

                    String Cliente = DatosFactura.Tables["DatosConsultados"].Rows[0]["Cliente"].ToString();
                    label2.Text = label2.Text + " " + Cliente;

                    String IdCliente = DatosFactura.Tables["DatosConsultados"].Rows[0]["IdCliente"].ToString();
                    label7.Text = label7.Text + " " + IdCliente;

                    String Telefono = DatosFactura.Tables["DatosConsultados"].Rows[0]["Telefono"].ToString();
                    label8.Text = label8.Text + " " + Telefono;

                  

                    String Vendedor = DatosFactura.Tables["DatosConsultados"].Rows[0]["Empleado"].ToString();
                    label10.Text = label10.Text + " " + Vendedor;

                    DataSet DatosDetalleFactura = ObjFactura.ConsultarDetalleFServicios(NumFactura);
                    dataGridView1.DataSource = DatosDetalleFactura.Tables["DatosConsultados"];

                    DataSet DatosTotalFactura = ObjFactura.ConsultarValorTotalS(NumFactura);
                   label11.Text = label11.Text + " " + DatosTotalFactura.Tables["DatosConsultados"].Rows[0]["TotalFactura"].ToString();


                   String NitEmpresa = "NitEmpresa: " + DatosFactura.Tables["DatosConsultados"].Rows[0]["NitEmpresa"].ToString();
                   label4.Text = label4.Text + " " + NitEmpresa;

                   String Nombre = DatosFactura.Tables["DatosConsultados"].Rows[0]["Nombre"].ToString();
                   label3.Text = label3.Text + " " + Nombre;

                   String Direccion = "Direccion: " + DatosFactura.Tables["DatosConsultados"].Rows[0]["Direccion"].ToString();
                   label12.Text = label12.Text + " " + Direccion;
                }





            }
            catch (Exception Ex)
            {
                MessageBox.Show("Se ha presentado Un Error Al Intentar Consultar Esta Factura. Cierre e intente Nuevamente.  " + Ex.Message);

            }
        } 

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                panel1.Visible = false;

                try
                {

                    if (printDialog1.ShowDialog() == DialogResult.OK)
                    {

                        printForm1.PrinterSettings = printDialog1.PrinterSettings;
                        printForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 150;
                        printForm1.Print(this, PrintForm.PrintOption.ClientAreaOnly);
                        panel1.Visible = true;
                    }

                }
                catch (Exception Ex)
                {
                    panel1.Visible = true;
                    MessageBox.Show("No se pudo enviar la impresión. " + Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                FormConFacServicios FConsultarFactura = new FormConFacServicios();
                FConsultarFactura.MdiParent = Principal.ActiveForm;
                FConsultarFactura.StartPosition = FormStartPosition.CenterScreen;
                FConsultarFactura.Show();

                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormConFacServicios acceso = new FormConFacServicios();
            acceso.Close();
            this.Hide();    
       
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

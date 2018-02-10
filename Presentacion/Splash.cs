using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Presentacion 
{
    public partial class Splash : Form
    {
        int Progreso;


        
        public Splash()
        {
            InitializeComponent();
            
        
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Progreso = 0;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            


            Progreso = Progreso + 1;
            progressBar1.Value = Progreso;
            label1.Text = Progreso + "%";

            if (Progreso == 100)
            {
                loginad lg = new loginad();
                lg.Show();
                this.Hide();
                timer1.Enabled = false;
            }

        }







        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
     

      

}
}

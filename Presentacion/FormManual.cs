using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Presentacion
{
    public partial class FormManual : Form
    {
        public FormManual()
        {
            InitializeComponent();
        }

        private void FormManual_Load(object sender, EventArgs e)
        {
            string pdfpath = Path.Combine(Application.StartupPath, "manual.pdf");
            Process.Start(pdfpath);
            Uri dirdpdf = new Uri(pdfpath);
            webBrowser1.Url = dirdpdf; 
        }
    }
}

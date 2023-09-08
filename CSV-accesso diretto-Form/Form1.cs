using CSV_accesso_diretto_Form.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_accesso_diretto_Form
{

    public struct classe
    {
        public string Comune;
        public string Provincia;
        public string Regione;
    }
    public partial class Form1 : Form
    {
        Funzioni f;
        public classe[] p;
        public int dim;
        public string nomefile;
        public Form1()
        {
            InitializeComponent();
            f = new Funzioni();
            p = new classe[100];
            dim = 0;
            nomefile = @"";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

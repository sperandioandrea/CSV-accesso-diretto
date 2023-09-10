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
    
        public string nomefile;
        public Form1()
        {
            InitializeComponent();
            f = new Funzioni();
            nomefile = @"Sperandio1-cor.csv";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //BOTTONE FUNZIONE 1
        private void button1_Click(object sender, EventArgs e)
        {
            f.Aggiunta();
        }
    }
}

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
        public int lunghezza = 0;
        public int lunghezza1 = 0;
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

        //BOTTONE FUNZIONE 2
        private void button2_Click(object sender, EventArgs e)
        {
            int ncampi = f.Contacampi();
            MessageBox.Show("Il nunero dei campi è:" + ncampi);
        }
        //BOTTONE FUNZIONE 3
        private void button3_Click(object sender, EventArgs e)
        {
            f.LunghezzaMaxRecord(lunghezza1);
            MessageBox.Show("La lunghezza massima è" + lunghezza1);
        }
    }
}

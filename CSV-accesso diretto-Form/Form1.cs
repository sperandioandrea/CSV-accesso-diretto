using CSV_accesso_diretto_Form.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            MessageBox.Show("La lunghezza massima del record è:" + lunghezza1);
        }
        //BOTTONE FUNIONE 4
        private void button4_Click(object sender, EventArgs e)
        {

        }
        //BOTTONE FUNIONE 5
        private void button5_Click(object sender, EventArgs e)
        {
            f.AggiuntaCoda(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
        //BOTTONE FUNZIONE 7
        private void button6_Click(object sender, EventArgs e)
        {
            string b = f.Ricerca(textBox5.Text);

            
            MessageBox.Show("Parola nel campo " + textBox10.Text + " è :");
            MessageBox.Show(b);

            textBox10.Text = "";
        }
        //BOTTONE FUNZIONE 8
        private void button8_Click(object sender, EventArgs e)
        {
            f.Modifica();
        }
        //BOTTONE FUNZIONE 9
        private void button7_Click(object sender, EventArgs e)
        {
            f.CancellazioneLogica(textBox11.Text);
            textBox11.Text = "";
        }
      
    }
}

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
        //BOTTNE FUNZIONE 7
        private void button6_Click(object sender, EventArgs e)
        {
            string a = textBox10.Text;
            string b = textBox11.Text;
            string c = textBox12.Text;

            int a1 = 0;
            int b1 = 0;
            int c1 = 0;

            bool a2 = false;
            bool b2 = false;
            bool c2 = false;

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                int dim = 0;

                for (int i = 0; i < campi.Length; i++)
                {
                    if (a == campi[dim])
                    {
                        a1 = dim;
                    }
                    if (b == campi[dim])
                    {
                        b1 = dim;
                    }
                    if (c == campi[dim])
                    {
                        c1 = dim;
                    }

                    if (a == "")
                    {
                        a2 = true;
                    }
                    if (b == "")
                    {
                        b2 = true;
                    }
                    if (c == "")
                    {
                        c2 = true;
                    }

                    dim++;
                }
            }

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string d = sw.ReadLine();

                while (d != null)
                {

                    string[] campi = d.Split(';');

                    if (a2 == true)
                    {
                        MessageBox.Show("Campo1: ");
                    }
                    else
                    {
                        MessageBox.Show("Campo1: " + campi[a1]);
                    }
                    if (b2 == true)
                    {
                        MessageBox.Show("Campo2: ");
                    }
                    else
                    {
                        MessageBox.Show("Campo2: " + campi[b1]);
                    }
                    if (c2 == true)
                    {
                        MessageBox.Show("Campo3: ");
                    }
                    else
                    {
                        MessageBox.Show("Campo3: " + campi[c1]);
                    }
                    MessageBox.Show("");
                    d = sw.ReadLine();
                }

            }
        }
    }
}

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
            using (StreamReader sw = new StreamReader(nomefile))
            {
                int dim = 0;

                string a = sw.ReadLine();

                string[] campi = a.Split(';');

                int[] arr = new int[(campi.Length) + 1];

                for (int i = 0; i < campi.Length; i++)
                {
                    arr[dim] = campi[i].Length;
                    dim++;
                }
                arr[(arr.Length) - 1] = a.Length;

                while (a != null)
                {
                    dim = 0;

                    string[] campi2 = a.Split(';');

                    for (int i = 0; i < campi2.Length; i++)
                    {
                        if (arr[dim] < campi2[i].Length)
                        {
                            arr[dim] = campi2[i].Length;
                        }

                        dim++;
                    }

                    if (arr[(arr.Length) - 1] < a.Length)
                    {
                        arr[(arr.Length) - 1] = a.Length;
                    }

                    a = sw.ReadLine();

                }

                dim = 0;
             
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != arr.Length - 1)
                    {
                        MessageBox.Show("Lunghezza campo " + dim.ToString() + ": " + arr[i]);
                    }
                    else
                    {
                        MessageBox.Show(("Lunghezza record " + dim.ToString() + ": " + (arr[arr.Length - 1] + 1)));
                    }
                    dim++;
                }
                lunghezza1 = arr[arr.Length - 1];
            }

        }
        //BOTTONE FUNIONE 4
        private void button4_Click(object sender, EventArgs e)
        {
            if (lunghezza1 == 0)
            {
            
                MessageBox.Show("Calcolare prima lunghezza del record più lungo che compone il file");
            }
            else
            {
                f.NumeroSpazi(lunghezza1);
                MessageBox.Show("Tutti i record hanno la stessa lunghezza");
            }

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
        //BOTTONE FUNZIONE 9
        private void button7_Click(object sender, EventArgs e)
        {
            f.CancellazioneLogica(textBox11.Text);
            textBox11.Text = "";
        }
        //BOTTONE FUNZIONE 8
        private void button8_Click(object sender, EventArgs e)
        {
            f.Modifica(textBox12.Text, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
            textBox6.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            f.CancellazioneLogica(textBox8.Text);
            textBox8.Text = "";
        }
    }

}
        
 
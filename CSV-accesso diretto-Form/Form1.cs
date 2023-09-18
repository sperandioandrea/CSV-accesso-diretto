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

    
    public partial class Form1 : Form
    {
        Funzioni f;
        public string nomefile;
        public int lunghezza = 0;
        public int lunghezza1 = 0;
        public int lunghezzamassima = 0;
       
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
            MessageBox.Show("Il nunero dei campi è: " + ncampi);
        }
        //BOTTONE FUNZIONE 3
        private void button3_Click(object sender, EventArgs e)
        {
            f.LunghezzaMaxRecord();
            MessageBox.Show("La lunghezza massima dei record presenti è: " + lunghezzamassima);
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
        //BOTTONE FUNZIONE 6
        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] record = File.ReadAllLines(nomefile);
            for (int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(';');
                if (campi[1] == "")
                {
                    dataGridView1.Rows.Add(campi[0]);
                }
                else
                {
                    dataGridView1.Rows.Add(campi[0], campi[1], campi[2]);
                }
            }
        }
       




        //FUNZIONE 7
        private void ModificaRecord(string filePath, string parolaDaCercare, string parolaNuova)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Contains(parolaDaCercare))
                        {
                            lines[i] = lines[i].Replace(parolaDaCercare, parolaNuova);
                        }
                    }

                    File.WriteAllLines(filePath, lines);
                }
                else
                {
                    throw new FileNotFoundException("Il file specificato non esiste.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante la modifica del file: {ex.Message}");
            }
        }
        
        
        
        
        //BOTTONE FUNZIONE 7
        private void button6_Click(object sender, EventArgs e)
        {
            string parolaDaCercare = txtParolaDaCercare.Text;
            string parolaNuova = textBox11.Text;
            string nomeFile = "Sperandio1-cor.csv"; 

            if (string.IsNullOrWhiteSpace(parolaDaCercare) || string.IsNullOrWhiteSpace(parolaNuova))
            {
                MessageBox.Show("Inserisci sia la parola da cercare che la parola nuova.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               ModificaRecord(nomeFile, parolaDaCercare, parolaNuova); 

                MessageBox.Show("Modifica completata.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        //BOTTONE FUNZIONE 8
        private void button7_Click(object sender, EventArgs e)
        {
            string elementoDaRicercare = txtElementoDaRicercare.Text;

            if (string.IsNullOrWhiteSpace(elementoDaRicercare))
            {
                MessageBox.Show("Inserisci un elemento da cercare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomeFile = "Sperandio1-cor.csv"; // Sostituisci con il percorso del tuo file

            try
            {
                // Leggi il contenuto del file
                string testoFile = File.ReadAllText(nomeFile);

                // Esegui la ricerca dell'elemento
                if (testoFile.Contains(elementoDaRicercare))
                {
                    MessageBox.Show($"L'elemento '{elementoDaRicercare}' è stato trovato nel file.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"L'elemento '{elementoDaRicercare}' non è stato trovato nel file.", "Risultato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        




        //BOTTONE FUNZIONE 9
        private void button9_Click(object sender, EventArgs e)
        {
            string parolaDaCancellare = txtParolaDaCancellare.Text;

            if (string.IsNullOrWhiteSpace(parolaDaCancellare))
            {
                MessageBox.Show("Inserisci una parola da cancellare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomefile = "Sperandio1-cor.csv"; 

            try
            {
                // Leggi il contenuto del file
                string testoFile = File.ReadAllText(nomefile);

                // Esegui la cancellazione logica
                testoFile = testoFile.Replace(parolaDaCancellare, string.Empty);

                // Sovrascrivi il file con il nuovo contenuto
                File.WriteAllText(nomefile, testoFile);

                MessageBox.Show("Cancellazione logica completata.", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

     
    }
}


        
 
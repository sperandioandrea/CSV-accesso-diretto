﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSV_accesso_diretto_Form.Properties
{
    internal class Funzioni
    {
        public int numerocampi = 0;
        public int lunghezzamassima = 0;

        public string nomefile = @"Sperandio1-cor.csv";
        //FUNZIONE 1
        public void Aggiunta()
        {
            Random num = new Random();

            string[] arr = new string[1000];
            int dim = 0;

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string a = sw.ReadLine();

                while (a != null)
                {
                    if (dim == 0)
                    {
                        arr[dim] = a + ";miovalore";
                    }
                    else
                    {
                        string b = (num.Next(10, 21)).ToString();
                        arr[dim] = a + ";" + b;
                    }
                    dim++;
                    a = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(nomefile))
            {
                dim = 0;

                while (arr[dim] != null)
                {
                    sw.WriteLine(arr[dim]);
                    dim++;
                }
            }
        }

        //FUNZIONE 2
        public int Contacampi()
        {

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string ncampi = sw.ReadLine();
                string[] campi = ncampi.Split(';');
                int c = campi.Length;
                return c;
            }

        }

        //FUNZIONE 3
        public int LunghezzaMaxRecord(char a = ';')
        {   
            string[] record = File.ReadAllLines(nomefile);
            for (int i = 0; i < record.Length; i++)
            {
                string[] campi = record[i].Split(a);
                for (int j = 0; j < numerocampi; j++)
                {
                    if (campi[j].Length > lunghezzamassima)
                    {
                        lunghezzamassima = campi[j].Length;
                    }
                    if (campi[j].Length == 0)
                    {
                        break;
                    }
                }
            }
            return lunghezzamassima;
        }

        //FUNZIONE 4
        public void NumeroSpazi(int lunghezza1)
        {
            int[] cont = new int[1000];
            string[] cont2 = new string[1000];
            int dim = 0;

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string a;
               
                a = sw.ReadLine();

                while (a != null)
                {
                    int b = a.Length;

                    cont[dim] = lunghezza1 - b;

                    cont2[dim] = a;

                    dim++;

                    a = sw.ReadLine();
                }

            }

            using (StreamWriter sw = new StreamWriter(nomefile))
            {
                dim = 0;

                while (cont2[dim] != null)
                {

                    string a = null;

                    for (int j = 0; j < cont[dim]; j++)
                    {
                        a = a + " ";
                    }

                    sw.WriteLine(cont2[dim] + a);

                    dim++;
                }
            }

        }

        //FUNZIONE 5
        public void AggiuntaCoda(string a1, string a2, string a3, string a4, string a5, string a6, string a7, string a8, string a9)
        {
            bool[] a = new bool[1000];

            string[] p = new string[1000];

            int dim = 0;

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    a[dim] = true;
                    p[dim] = b;
                    b = sw.ReadLine();
                    dim++;
                }
                if (b == null)
                {
                    a[dim] = false;
                }

            }

            using (StreamWriter sw = new StreamWriter(nomefile))
            {
                dim = 0;
                while (dim < 1000)
                {
                    if (a[dim] == false)
                    {
                        sw.WriteLine(a1 + ";" + a2 + ";" + a3 + ";" + a4 + ";" + a5 + ";" + a6 + ";" + a7 + ";" + a8 + ";" + a9);
                        break;
                    }
                    sw.WriteLine(p[dim]);
                    dim++;
                }
            }
        }

        /*/FUNZIONE 7
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
        }/*/

    }
}

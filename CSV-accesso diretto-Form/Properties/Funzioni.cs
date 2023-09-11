using System;
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
        public void LunghezzaMaxRecord(int lunghezza1)
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

        //FUNZIONE 4
        public void NumeroSpazi()
        {
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

        //FUNZIONE 7
        public string Ricerca(string a1)
        {
            string a = a1;

            int cont = 0;

            int dim = 0;

            string[] ele = new string[1000];

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string d = sw.ReadLine();

                string[] campi = d.Split(';');

                dim = 0;

                for (int i = 0; i < campi.Length; i++)
                {
                    if ("miovalore" == a)
                    {
                        cont = 11;
                    }
                    else
                    {
                        if (campi[dim] == a)
                        {
                            cont = dim;
                        }
                    }

                    dim++;
                }

                dim = 0;

                while (d != null)
                {
                    string[] campi2 = d.Split(';');

                    ele[dim] = campi2[cont];

                    d = sw.ReadLine();
                    dim++;
                }
            }

            string b = "";

            int t = 0;

            for (int i = 0; i < ele.Length; i++)
            {
                if (ele[i + 1] != null)
                {
                    if (ele[t].Length >= ele[i + 1].Length)
                    {
                        b = ele[t];
                    }
                    else
                    {
                        b = ele[i + 1];
                        t = i + 1;
                    }
                }
                else
                {
                    break;
                }
            }

            return b;
        }
        /*/
        //FUNZIONE 8
        public bool Modifica()
        {
            bool trova = false;
            string[] linee = File.ReadAllLines();
            using (StreamWriter sw = new StreamWriter(nomefile))
            {

                int i = 1;
                sw.WriteLine(linee[0]);
                for (; i < linee.Length; i++)
                {
                    string[] campi = linee[i].Split(';');
                    if (campi[0].ToLower() == textBox13.Text.ToLower())
                    {
                        trova = true;
                        campi[0] = textBox12.Text;
                        linee[i] = String.Join(";", campi);
                        sw.WriteLine(linee[i]);
                        break;
                    }
                    else
                        if (campi[1].ToLower() == textBox12.Text.ToLower())
                    {
                        trova = true;
                        campi[1] = textBox12.Text;
                        linee[i] = String.Join(";", campi);
                        sw.WriteLine(linee[i]);
                        break;
                    }
                    else
                        if (campi[2].ToLower() == textBox13.Text.ToLower())
                    {
                        trova = true;
                        campi[2] = textBox13.Text;
                        linee[i] = String.Join(";", campi);
                        sw.WriteLine(linee[i]);
                        break;
                    }
                    i++;
                    for (; i < linee.Length; i++)
                    {
                        sw.WriteLine(linee[i]);
                    }

                }
                return trova;

            }

        }
        /*/

        //FUNZIONE 9
        public void CancellazioneLogica(string a1)
        {
            bool[] a = new bool[1000];

            string[] a2 = new string[1000];

            string c = a1;

            int dim = 0;

            using (StreamReader sw = new StreamReader(nomefile))
            {
                string b = sw.ReadLine();

                while (b != null)
                {
                    a2[dim] = b;

                    string[] campi = b.Split(';');

                    if (campi[0] == c)
                    {
                        a[dim] = false;
                    }
                    else
                    {
                        a[dim] = true;
                    }
                    dim++;

                    b = sw.ReadLine();
                }
            }

            using (StreamWriter sw = new StreamWriter(nomefile))
            {
                dim = 0;

                while (a2[dim] != null)
                {

                    if (a[dim] == true)
                    {
                        sw.WriteLine(a2[dim]);
                    }
                    dim++;
                }
            }


        }
    }
}

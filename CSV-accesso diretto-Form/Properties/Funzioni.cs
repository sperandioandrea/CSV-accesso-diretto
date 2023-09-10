using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}

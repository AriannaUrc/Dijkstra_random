using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_random
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int MAX = 2147483647;


            Random rnd = new Random();
            int nNodi = rnd.Next(1, 15);

            int Arrivo = rnd.Next(0, 14);

            Console.WriteLine("nNodi: " + nNodi);

            int pesoMax = rnd.Next(1, 20);
            Console.WriteLine("pesoMax: " + pesoMax);

            int[,] adiacenza = new int[nNodi, nNodi];

            for (int i = 0; i < nNodi; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                        adiacenza[i, j] = MAX;
                    else
                    {
                        adiacenza[i, j] = rnd.Next(0, pesoMax);
                        adiacenza[j, i] = adiacenza[i, j];

                        if (adiacenza[i, j] == 0)
                        {
                            adiacenza[i, j] = MAX;
                            adiacenza[j, i] = MAX;
                        }
                    }


                }
            }


            for (int i = 0; i < nNodi; i++)
            {
                for (int j = 0; j < nNodi; j++)
                {
                    Console.Write(adiacenza[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int[] pred = new int[nNodi];
            int[] distanza = new int[nNodi];
            distanza[0] = 0;//iniziamo da A

            int[] stato = new int[nNodi]; //0 non visitato, 1 frontiera, -1 già visitato

            Queue<int> Q = new Queue<int>();

            Q.Enqueue(0);

            for (int i = 0; i<nNodi; i++)
            {
                pred[i] = -1;
                distanza[i] = MAX;
                stato[i] = 0;
            }


            while (Q.Count != 0)
            {
                for(int i = 0; i<nNodi; i++)
                {
                    if (adiacenza[Q.First(),i] != MAX)
                    {
                        //quarda solo gli archi collegati
                        if( ( adiacenza[Q.First(), i] + distanza[Q.First()] ) < distanza[i]) //se la somma del peso precedente e l'arco è minore della distanza del vertice aggiorna
                        {
                            pred[i] = Q.First();
                            distanza[i] = adiacenza[Q.First(), i] + distanza[Q.First()];
                            Q.Enqueue(i);

                        }
                    }
                }

                stato[Q.First()] = -1;
            }

            Console.WriteLine("Partenza: " + "0");
            Console.WriteLine("Arrivo: " + Arrivo);

        }
        
    
    }
}

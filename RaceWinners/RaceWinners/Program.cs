using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceWinners
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService ds = new DataService();
 
            // Asynchronously retrieve the group (class) data
            var data = await ds.GetGroupRanksAsync();

            for (int i = 0; i < data.Count; i++)
            {
                // Combine the ranks to print as a list
                var ranks = String.Join(", ", data[i].Ranks);

                Console.WriteLine($"{data[i].Name} - [{ranks}]");
            }

            double[] z = new double[4];
            for (int i = 0; i < data.Count; i++)
            {
                double k = data[i].Ranks.Take(7).Sum();
                k /= 7;
                z[i] = k;
                Console.WriteLine(k);
            }

            int[] ranked = new int[4];
            for (int i = 0; i < 4; i++) {
                int curRank = 1;

                for (int o = 0; o < i; o++) {
                    if (z[i] > z[o]) {
                        curRank++;
                    } else {
                        ranked[o]++;
                    }
                }

                ranked[i] = curRank;
            }
            Console.WriteLine("class A rank:" + ranked[0]);
            Console.WriteLine("class B rank:" + ranked[1]);
            Console.WriteLine("class C rank:" + ranked[2]);
            Console.WriteLine("class D rank:" + ranked[3]);
        }
    }
}
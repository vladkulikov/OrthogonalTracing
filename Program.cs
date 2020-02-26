using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;
using algorithm;


namespace OrthogonalTracing
{
    class Program
    {
		

        static void Main(string[] args)
        {


            //Net test = Parser.getData("/media/vldad/708A70F28A70B5E6/test2.txt");
            //Solution decision = Parser.getSolution("/media/vldad/708A70F28A70B5E6/test2.txt");

            Net  test = Parser.getData("C:/Users/vadya/OneDrive/Рабочий стол/Учеба/Диплом/Код/OrthogonalTracing-WaveMethod/test2.txt");
            Solution decision = Parser.getSolution("C:/Users/vadya/OneDrive/Рабочий стол/Учеба/Диплом/Код/OrthogonalTracing-WaveMethod/test2.txt");
            LevelAlgorithm alg = new LevelAlgorithm();
			Solution sol = alg.trace(test);


            for (int i = 0; i < sol.Pins.Length; i++)
            {
                Console.WriteLine($"Трасса {i + 1}:");
                for (int j = 0; j < sol.Tracks[i].Length; j++)
                {
                    Console.WriteLine(sol.Tracks[i][j]);
                }
            }

			Console.ReadKey();
        }
    }
}

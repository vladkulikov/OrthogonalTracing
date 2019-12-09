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
			


            Net  test = Parser.getData("C:/Users/USER/Desktop/OrthogonalTracing-WaveMethod/OrthogonalTracing/testproject.txt");

            Solution decision = Parser.getSolution("C:/Users/USER/Desktop/OrthogonalTracing-WaveMethod/OrthogonalTracing/testproject.txt");
			LevelAlgorithm alg = new LevelAlgorithm();
			Solution sol = alg.trace(test);
			for (int i = 0; i < sol.Tracks[0].Length; i++)
			{
				Console.WriteLine(sol.Tracks[0][i]);
			}
            

			Console.ReadKey();
        }
    }
}

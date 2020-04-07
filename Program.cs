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


      

            Net  test = Parser.getData("C:/Users/vadya/OneDrive/Рабочий стол/OrthogonalTracing-wavemethodopt/DataForTest1Pin.txt");
            LevelAlgorithm alg = new LevelAlgorithm();
			Solution sol = alg.trace(test);


            for (int i = 1; i <= sol.Tracks[0].Max() + 1; i++)
            {
              Console.WriteLine($"Сегмент {i }");
                for (int j = 0; j < sol.Tracks[0].Length; j++)
                {
                    if ((sol.Tracks[0][j] == i) || (sol.Tracks[0][j] == -i))
                    {
                      Console.WriteLine(j);
                    }
                }    
            }




            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;

namespace algorithm
{
    public class LevelAlgorithm : ITraceAlgorithm
    {
        public Solution trace(Net net)
        {
            int[][] tracks = new int[net.Pins.Length][];

            return new Solution(net.Pins, tracks);
        }

        public bool checkSolution(Net net, Solution solution)
        {
            int[][] tracks = solution.Tracks;
            int[][] pins = solution.Pins;
            int[][] graph = net.Graph;
            bool result = true;

            if (tracks.Length != pins.Length)
            {
                Console.WriteLine("tracks.Length != pins.Length");
                return false;
            }


            //TODO: add num of not traced pins
            for (int i = 0; i < tracks.Length; i++)
            {
                if (tracks[i] != null)
                {
                    List<int> cur = new List<int>(graph[ pins[i][0] ]);
                    if (cur.IndexOf(tracks[i][0]) < 0)
                    {
                        Console.WriteLine("Error in track {0}, on benween pos 0 and 1. Edge doesn't exist", i);
                        result = false;
                    }

                    int len = tracks[i].Length;
                    for (int j = 0; j < len - 1; j++)
                    {
                        cur = new List<int>(graph[tracks[i][j]]);
                        if (cur.IndexOf(tracks[i][j + 1]) < 0)
                        {
                            Console.WriteLine("Error in track {0}, on pos {1}, benween {2} and {3}. Edge doesn't exist", i, j, tracks[i][j], tracks[i][j + 1]);
                            result = false;
                        }
                    }
                    cur = new List<int>(graph[ tracks[i][len - 1] ]);
                    if (cur.IndexOf(pins[i][1]) < 0)
                    {
                        Console.WriteLine("Error in track {0}, on pos {1}, benween {2} and {3}. Edge doesn't exist", i, len, tracks[i][len - 1], pins[i][1]);
                        result = false;
                    }
                }
                else
                {
                    Console.WriteLine("Track {0} is not traced", i);
                    //result = ?
                }
            }
            return result;
        }
    }
}

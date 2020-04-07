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


            //List<int> test = new List<int>();
            int[][] tracks = new int[1][];
            int[][] pins = net.Pins;
            int[][] graph = net.Graph;
            int a = graph.Length;
            int[] vers = new int[a];
            int[] metal = new int[a];
            for (int i = 0; i < a; i++)
            {
                metal[i] = 0;
            }
            metal[pins[0][0]] = -1;
            metal[pins[0][1]] = -1;

           
            for (int k = 0; k < net.Pins.Length; k++)
            {

                int node1 = pins[k][0];
                int node2 = pins[k][1];


                List<int> track = new List<int>();
                List<int> top = new List<int>();
                top.Add(node1);
                List<int> previoustop = new List<int>();
               
                previoustop.Add(-1);

                for (int i = 0; i < a; i++)
                {
                    vers[i] = -1;
                }

                vers[node1] = 0;


                //распространение волны
                for (int i = 0; i < top.Count; i++)
                {
                    if ((metal[top[i]] != 0) && (i !=0) )
                    {
                        node2 = top[i];
                        break;
                    }
                    for (int j = 0; j < graph[top[i]].Length; j++)
                    {
                        if (vers[graph[top[i]][j]] == -1)
                        {
                            vers[graph[top[i]][j]] = 0;
                            top.Add(graph[top[i]][j]);
                            previoustop.Add(top[i]);
                        }

                    }
                }
                //

                //обратный ход
                track.Add(node2);
                for (int i = 0; i < top.Count; i++)
                {

                    int pos = top.IndexOf(track[i]);
                    track.Add(previoustop[pos]);
                    if (previoustop[pos] == node1)
                    {
                        break;
                    }

                }
                //


                track.Reverse();
                
                for (int i = 0; i < track.Count; i++)
                {
                    //test.Add(track[i]);
                    if (metal[track[i]] == 0)
                    {
                        metal[track[i]] = k + 1;
                    }
                    
              
                }
                
            }
            for (int i = 0; i < pins.Length; i++)
            {
                for (int j = 0; j < pins[i].Length; j++)
                {
                    metal[pins[i][j]] = -i - 1;
                }
            }
            tracks[0] = new int[a];
            for (int i = 0; i < a; i++)
            {
                tracks[0][i] = metal[i];
            }
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

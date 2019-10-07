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
            throw new NotImplementedException();
        }
    }
}

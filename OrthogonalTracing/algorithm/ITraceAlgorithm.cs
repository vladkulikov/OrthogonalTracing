using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;

namespace algorithm
{
    public interface ITraceAlgorithm
    {
        Solution trace(Net net);

        bool checkSolution(Net net, Solution solution);
    }
}

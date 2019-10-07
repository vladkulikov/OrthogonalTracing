using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;

namespace algorithm
{
    public interface ITuningAlgorithm
    {
        Solution tune(Net net, Solution solution);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class Net
    {
        private int[][] graph; //adjacency list
        private int[][] pins; //index pairs. shape = (n_tracks, 2)
        private float[][] ewgts; //edge weigths

        public Net(int[][] graph, int[][] pins, float[][] ewgts = null)
        {
            this.graph = graph;
            this.pins = pins;
            this.ewgts = ewgts;
        }

        //TODO: accurate copy?
        public int[][] Graph { get { return graph; } }
        public int[][] Pins  { get { return pins;  } }
        public float[][] Ewgts { get { return ewgts; } }
    }
}
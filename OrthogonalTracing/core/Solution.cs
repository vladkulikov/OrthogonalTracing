using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class Solution
    {
        private int[][] pins; //?
        private int[][] tracks; // shape - (n_tracks, len_of_track)

        public Solution(int[][] pins, int[][] tracks)
        {
            this.pins = pins;
            this.tracks = tracks;
        }

        public int[][] Pins { get { return pins; } }
        public int[][] Tracks { get { return tracks; } }
    }
}

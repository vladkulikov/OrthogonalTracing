using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;
using algorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace tests
{
    public class Test
    {
        public void test(string data, string sol)
        {
            Net net = Parser.getData(data);
            int[][] gt_sol = Parser.getSolution(sol).Tracks;

            LevelAlgorithm lAlg = new LevelAlgorithm();

            int[][] solution = lAlg.trace(net).Tracks;

            Assert.AreEqual(gt_sol.Length, solution.Length);

            for (int i = 0; i < solution.Length; i++)
            {
                Assert.AreEqual(gt_sol[i], solution.Length);
            }
        }
    }
}

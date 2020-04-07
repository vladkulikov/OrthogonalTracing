﻿
using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithm;
using core;

namespace TestTrace
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestTrace4pins()
        {
            Net test = Parser.getData("C:/Users/vadya/OneDrive/Рабочий стол/OrthogonalTracing-wavemethodopt/DataForTest4Pins.txt");
            Solution decision = Parser.getSolution("C:/Users/vadya/OneDrive/Рабочий стол/OrthogonalTracing-wavemethodopt/Эталон 4.txt");
            LevelAlgorithm alg = new LevelAlgorithm();
            Solution sol = alg.trace(test);
            bool trace = true;

                for (int i = 0; i < sol.Tracks[0].Length; i++)
                {
                    if (decision.Tracks[0][i] != sol.Tracks[0][i])
                    {
                        trace = false;
                        break;
                    }
                }
 
           
            Assert.AreEqual(true, trace);

        }

        [TestMethod]
        public void TestTrace2pins()
        {
            Net test = Parser.getData("C:/Users/vadya/OneDrive/Рабочий стол/OrthogonalTracing-wavemethodopt/DataForTest1Pin.txt");
            Solution decision = Parser.getSolution("C:/Users/vadya/OneDrive/Рабочий стол/OrthogonalTracing-wavemethodopt/Эталон 1.txt");
            LevelAlgorithm alg = new LevelAlgorithm();
            Solution sol = alg.trace(test);
            bool trace = true;
              for (int i = 0; i < sol.Tracks[0].Length; i++)
                {
                    if (decision.Tracks[0][i] != sol.Tracks[0][i])
                    {
                        trace = false;
                        break;
                    }
                }
            

            Assert.AreEqual(true, trace);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace LinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializationArray()
        {
            const int n = 5;
            double[] coeff = new double[n] { 1, 2, 3, 4, 5 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(2, a1[1]);
        }

        [TestMethod]
        public void InitializationList()
        {
            List<double> coeff = new List<double>() { 1, 2, 3, 4, 5, 6 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(4, a1[3]);
        }

        [TestMethod]
        public void InitializationString()
        {
            string coeff = "5,6,7,8,9,16.5,45.9";
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(16.5, a1[5]);
        }

        [TestMethod]
        public void InitializationZero()
        {
            int n = 5;
            LinearEquation a = new LinearEquation(n);
            Assert.AreEqual("0x1+0x2+0x3+0x4+0x5=0", a.ToString());
        }

        [TestMethod]
        public void CorrectSum()
        {
            string coeff1 = "5,6,7,8,9,16.5,45.9";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "3,6,7,0,10,-16.7,45.9";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "8,12,14,8,19,-0.2,91.8";
            Assert.AreEqual(new LinearEquation(res), a1 + a2);
        }

        [TestMethod]
        public void CorrectSub()
        {
            string coeff1 = "4,6,2,78.9,23";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "15.2,45,1,2,6";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "-11.2,-39,1,76.9,17";
            Assert.AreEqual(new LinearEquation(res), a1 - a2);
        }

        [TestMethod]
        public void CorrectUnaryMinus()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            string res = "-4,-6,-2,-78.9,-23";
            Assert.AreEqual(new LinearEquation(res), -a);
        }

        [TestMethod]
        public void CorrectMult1()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            string res = "12,18,6,236.7,69";
            Assert.AreEqual(new LinearEquation(res), a * 3);
        }

        [TestMethod]
        public void CorrectMult2()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            string res = "12,18,6,236.7,69";
            Assert.AreEqual(new LinearEquation(res), 3 * a);
        }

        [TestMethod]
        public void CorrectIndexing()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            Assert.AreEqual(78.9, a[3]);
        }

        [TestMethod]
        public void CorrectSameInitialization()
        {
            LinearEquation a = new LinearEquation(4);
            a.SameInitialization(15.2);
            string res = "15.2,15.2,15.2,15.2,15.2";
            Assert.AreEqual(new LinearEquation(res), a);
        }

        [TestMethod]
        public void ContradictoryEquation()
        {
            string res = "0,0,0,15.2";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true: false;
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void SolvableEquation()
        {
            string res = "0,2,0,15.2";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true : false;
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex1()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[10]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex2()
        {
            string coeff = "4,6,2,78.9,23";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[-2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailArgument()
        {
            Assert.Equals(typeof(ArgumentException), new LinearEquation(-133));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace SystemOfLinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectIndexing()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,2,3,15"));
            s.Add(new LinearEquation("2,4,3,20"));
            s.Add(new LinearEquation("5,6,7,33"));
            Assert.AreEqual(new LinearEquation("2,4,3,20"), s[1]);
        }
        [TestMethod]
        public void CorrectAnswer()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("3.0, 2.0,-4.0, 3.0"));
            s.Add(new LinearEquation("2.0, 3.0, 3.0, 15.0"));
            s.Add(new LinearEquation("5.0, -3, 1.0, 14.0"));
            s.SteppingUp();
            double[] solve1 = new double[] { 3, 1, 2 };
            double[] solve2 = s.SolveSystem();
            bool check = true;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(solve1[i] - solve2[i]) > 1e-9) check = false;
            }
            Assert.AreEqual(true,check);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing1()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,2,3,15"));
            s.Add(new LinearEquation("2,4,3,20"));
            s.Add(new LinearEquation("5,6,7,33"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[-1]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing2()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1,2,3,15"));
            s.Add(new LinearEquation("2,4,3,20"));
            s.Add(new LinearEquation("5,6,7,33"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[12]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNoSolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("3.0, 2.0,-4.0, 3.0"));
            s.Add(new LinearEquation("6.0, 4.0, -8.0, 15.0"));
            s.Add(new LinearEquation("6.0, 4.0, -8.0, 15.0"));
            s.SteppingUp();
            Assert.Equals(typeof(ArgumentException), s.SolveSystem());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InfinitelyManySolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("3.0, 2.0,-4.0, 7.5"));
            s.Add(new LinearEquation("6.0, 4.0, -8.0, 15.0"));
            s.Add(new LinearEquation("6.0, 4.0, -8.0, 15.0"));
            s.SteppingUp();
            Assert.Equals(typeof(ArgumentException), s.SolveSystem());
        }
    }
}

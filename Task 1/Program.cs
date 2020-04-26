using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
          const  int n = 2;
            double[] tested = new double[n] { 30, 35 };
            Indexer ind1= new Indexer(tested, 0, 1);
           Console.WriteLine( ind1[0]);
            Console.WriteLine(ind1[1]);
        }
    }
}

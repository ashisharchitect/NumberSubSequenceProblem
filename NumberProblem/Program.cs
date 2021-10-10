using System;
using System.Linq;

namespace NumberProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string of numbers.");
            string strNumbers = Console.ReadLine();

            var result = LogicLayer.GetIncreasingSubsequenceValue(strNumbers);

            Console.WriteLine("Result is: " + result);
        }       
    }
}

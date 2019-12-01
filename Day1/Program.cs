using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = CalculateFuel(1969);

            var totalWeight = 0;
            using (var sr = new StreamReader($"{Directory.GetCurrentDirectory()}\\input.txt"))
            {
                while (!sr.EndOfStream)
                {
                    totalWeight += CalculateFuel(Convert.ToInt32(sr.ReadLine()));
                }
            }

            Console.WriteLine(totalWeight);
            Console.ReadLine();
        }

        private static int CalculateFuel(int mass)
        {
            var totalFuel = 0;

            var output = Convert.ToInt32(Math.Floor(Convert.ToDouble(mass) / 3) - 2);
            if (output > 0)
            {
                totalFuel += output;
                return totalFuel += CalculateFuel(output);
            }

            return totalFuel;
        }
    }
}
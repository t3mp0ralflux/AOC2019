using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var startNumber = 254032;
            var endNumber = 789860;

            //var startNumber = 123444;
            //var endNumber = 123444;
            var totalPasswords = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (Regex.IsMatch(i.ToString(), @"((^)|(.))((?(3)(?!\1).|.))\4(?!\4)"))
                {
                    if (IsIncreasing(i)) { totalPasswords.Add(i); }
                }
            }

            Console.WriteLine(totalPasswords.Count);
            Console.ReadKey();
        }

        private static bool IsIncreasing(int input)
        {
            var digits = input.ToString().Select(t => int.Parse(t.ToString())).ToArray();
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] > digits[i + 1]) return false;
            }

            return true;
        }
    }
}
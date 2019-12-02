using System;
using System.ComponentModel;
using System.IO;

namespace Day2

{
    internal class Program

    {
        private static void Main(string[] args)
        {
            var fileInput = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\input.txt");
            var intCode = Array.ConvertAll(fileInput.Split(','), int.Parse);

            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    intCode[1] = i;
                    intCode[2] = j;

                    var output = RunAlgorithm(intCode);
                    if (output != 19690720)
                    {
                        intCode = Array.ConvertAll(fileInput.Split(','), int.Parse);
                        continue;
                    }

                    Console.WriteLine($"1: {i}, 2:{j}");
                    Console.ReadKey();
                    break;
                }
            }
        }

        private static int RunAlgorithm(int[] intCode)
        {
            var pointer = 0;
            var NinetyNine = false;

            while (pointer != intCode.Length)
            {
                if (NinetyNine) break;
                switch (intCode[pointer])
                {
                    case 1:
                        intCode[intCode[pointer + 3]] = intCode[intCode[pointer + 1]] + intCode[intCode[pointer + 2]];
                        pointer += 4;
                        break;

                    case 2:
                        intCode[intCode[pointer + 3]] = intCode[intCode[pointer + 1]] * intCode[intCode[pointer + 2]];
                        pointer += 4;
                        break;

                    case 99:
                        NinetyNine = true;
                        break;

                    default:
                        pointer++;
                        break;
                }
            }

            return intCode[0];
        }
    }
}
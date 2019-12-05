using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileInput = File.ReadAllLines($"{Directory.GetCurrentDirectory()}\\input.txt");
            var lineA = fileInput[0].Split(',');
            var lineB = fileInput[1].Split(',');

            //var lineA = new[] { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" };
            //var lineB = new[] { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" };

            //var lineA = new[] { "R8", "U5", "L5", "D3" };
            //var lineB = new[] { "U7", "R6", "D4", "L4" };

            var dictA = PartOne(lineA);
            var dictB = PartOne(lineB);

            var intersections = dictA.Where(x => dictB.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            Tuple<int, int> minIntersection = new Tuple<int, int>(9999, 9999);
            var minValue = 0;
            foreach (var intersection in intersections)
            {
                var minManhatten = Math.Abs(minIntersection.Item1) + Math.Abs(minIntersection.Item2);
                var intersectionManhatten = Math.Abs(intersection.Key.Item1) + Math.Abs(intersection.Key.Item2);
                if (intersectionManhatten < minManhatten && minManhatten != 0)
                {
                    minIntersection = intersection.Key;
                    minValue = intersectionManhatten;
                }
            }

            Console.WriteLine($"Part One: {minValue}");

            intersections = dictA.Where(x => dictB.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            var bintersections = dictB.Where(x => dictA.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            minValue = 999999;
            foreach (var intersection in intersections)
            {
                var dictAVal = dictA[intersection.Key];
                var dictBVal = dictB[intersection.Key];
                var valueToTake = dictAVal + dictBVal;

                if (valueToTake < minValue)
                {
                    minValue = valueToTake;
                }
            }
            Console.WriteLine($"Part Two: {minValue}");
            Console.ReadKey();
        }

        private static Dictionary<Tuple<int, int>, int> PartOne(string[] lineInput)
        {
            var output = new Dictionary<Tuple<int, int>, int>();
            var x = 0;
            var y = 0;
            var pointDistance = 0; //distance on the wire from the start

            foreach (var instruction in lineInput)
            {
                var re = new Regex(@"([a-zA-Z]+)(\d+)");
                var result = re.Match(instruction);
                var movement = result.Groups[1].Value;
                var travelDistance = Convert.ToInt32(result.Groups[2].Value);

                for (var i = 1; i <= travelDistance; i++)
                {
                    switch (movement)
                    {
                        case "U":
                            y++;
                            break;

                        case "R":
                            x++;
                            break;

                        case "D":
                            y--;
                            break;

                        case "L":
                            x--;
                            break;
                    }

                    pointDistance++;
                    var newPoint = new Tuple<int, int>(x, y);

                    if (!output.ContainsKey(newPoint))
                    {
                        output.Add(newPoint, pointDistance);
                    }
                }
            }

            return output;
        }
    }
}
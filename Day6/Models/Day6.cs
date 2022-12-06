using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Models
{
    public class Day6 : IAOC2022
    {
        public string[] TestInput = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day6\testinput.txt");
        public string[] Input = File.ReadAllLines(@"C:\Users\conta\source\repos\AOC2022\Day6\input.txt");
       

        public void Part1()
        {
            var stringToCheck = Input[0];
            var foundIndex = 0;
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                var testPart = stringToCheck.Substring(i, 4);
                if (testPart.Distinct().Count() == 4)
                {
                    foundIndex = i + 4;
                    break;
                }
            }

            Console.WriteLine($"Part 1: {foundIndex}");
        }

        public void Part2()
        {
            var stringToCheck = Input[0];
            var foundIndex = 0;
            for (int i = 0; i < stringToCheck.Length; i++)
            {
                var testPart = stringToCheck.Substring(i, 14);
                if (testPart.Distinct().Count() == 14)
                {
                    foundIndex = i + 14;
                    break;
                }
            }

            Console.WriteLine($"Part 2: {foundIndex}");
        }

        public void Setup()
        {
        }
    }
}

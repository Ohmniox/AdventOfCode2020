using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day1
{
  public static class Solution
  {
    public static void Puzzle1()
    {
      var inputs = System.IO.File.ReadAllLines($"Puzzles/Day1/Input_Final.txt");
      foreach (var input1 in inputs)
      {
        foreach (var input2 in inputs)
        {
          foreach (var input3 in inputs)
          {
            var i1 = Convert.ToInt32(input1);
            var i2 = Convert.ToInt32(input2);
            var i3 = Convert.ToInt32(input3);

            if (i1 + i2 + i3 == 2020)
            {
              Console.WriteLine($"\t{input1} + \t{input2} + \t{input3}= \t2020 , ANS = \t{i1 * i2 * i3}");
            }
          }
        }
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day3
{
  public class Solution
  {
    public static void Puzzle1()
    {
      TreesEncountered(1, 1);
      TreesEncountered(3, 1);
      TreesEncountered(5, 1);
      TreesEncountered(7, 1);
      TreesEncountered(1, 2);
    }

    public static void Puzzle2()
    {
      var a = (long)TreesEncountered(1, 1);
      var b = (long)TreesEncountered(3, 1);
      var c = (long)TreesEncountered(5, 1);
      var d = (long)TreesEncountered(7, 1);
      var e = (long)TreesEncountered(1, 2);
      long s = a * b * c * d * e;
      Console.WriteLine($"MUL: {s}");
    }

    private static int TreesEncountered(int right, int down)
    {
      var inputs = System.IO.File.ReadAllLines("Puzzles/Day3/Input_Final.txt");
      var trees = 0;
      var currentIndex = 0;
      for (int i = down; i < inputs.Length;)
      {
        var foreverMap = inputs[i];
        currentIndex += right;
        while (foreverMap.Length - 1 < currentIndex)
        {
          foreverMap += inputs[i];
        }

        var c = foreverMap[currentIndex];
        if (c == '#')
        {
          trees++;
        }
        i += down;
      }
      Console.WriteLine($"Tress: {trees}");
      return trees;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day2
{
  internal static class Solution
  {
    public static void Puzzle1()
    {
      var inputs = System.IO.File.ReadAllLines("Puzzles/Day2/Input_Final.txt");
      var validPass = 0;
      foreach (var input in inputs)
      {
        var inputArray = input.Split(' ');

        var minLength = Convert.ToInt32(inputArray[0].Split('-')[0]);
        var maxLength = Convert.ToInt32(inputArray[0].Split('-')[1]);

        var letter = inputArray[1].Split(':')[0].ToCharArray()[0];
        var password = inputArray[2];

        var count = password.Count(x => x == letter);
        if (count >= minLength && count <= maxLength)
        {
          validPass++;
        }
      }
      Console.WriteLine($"Valid passwords: {validPass}");
    }

    public static void Puzzle2()
    {
      var inputs = System.IO.File.ReadAllLines("Puzzles/Day2/Input_Final.txt");
      var validPass = 0;
      foreach (var input in inputs)
      {
        var inputArray = input.Split(' ');

        var index1 = Convert.ToInt32(inputArray[0].Split('-')[0]) - 1;
        var index2 = Convert.ToInt32(inputArray[0].Split('-')[1]) - 1;

        var letter = inputArray[1].Split(':')[0].ToCharArray()[0];
        var password = inputArray[2];

        if (password[index1] == letter && password[index2] != letter)
        {
          validPass++;
        }
        else if (password[index1] != letter && password[index2] == letter)
        {
          validPass++;
        }
      }
      Console.WriteLine($"Valid passwords: {validPass}");
    }
  }
}

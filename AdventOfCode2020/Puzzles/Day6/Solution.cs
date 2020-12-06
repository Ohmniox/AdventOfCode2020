using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day6
{
  public class Solution
  {

    public static void Puzzle1()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var inputsLength = inputs.Length;
      var sum = 0;
      for (int i = 0; i < inputsLength;)
      {
        var grouppedAns = string.Empty;
        while (i < inputsLength && inputs[i] != "")
        {
          grouppedAns += inputs[i];
          i++;
        }
        var uniqueAns = grouppedAns.Distinct().Count();
        sum += uniqueAns;
        Console.WriteLine($"UniqueAns = {uniqueAns}");
        i++;
      }
      Console.WriteLine($"Sum: {sum}");
    }

    public static void Puzzle2()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var inputsLength = inputs.Length;
      var sum = 0;
      
      for (int i = 0; i < inputsLength;)
      {
        var firsInput = inputs[i];
        i++;
        while (i < inputsLength && inputs[i] != "")
        {
          var secondInput = inputs[i];
          firsInput = new string(firsInput.Where(x => secondInput.Any(s => s == x)).ToArray());
          i++;
        }
        var uniqueAns = firsInput.Distinct().Count();
        sum += uniqueAns;
        Console.WriteLine($"UniqueAns = {uniqueAns}");
        i++;
      }
      Console.WriteLine($"Sum: {sum}");
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day8
{
  public class Solution
  {
    public static void Puzzle1()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var data = GetProgramData(inputs);
      Console.WriteLine($"{data.accumulator}");
    }

    public static void Puzzle2()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      for (int i = 0; i < inputs.Length; i++)
      {
        var changedInputs = new string[inputs.Length];
        inputs.CopyTo(changedInputs, 0);
        var instruction = inputs[i].Split(' ')[0];
        if (instruction == "jmp" || instruction == "nop")
        {
          changedInputs[i] = changedInputs[i].Replace(instruction == "jmp" ? "jmp" : "nop", instruction == "jmp" ? "nop" : "jmp");
          if (ProgramLoopCompleted(changedInputs))
          {
            Console.WriteLine("Loop completed.");
            break;
          }
        }
      }
    }

    private static (int accumulator, int lastIndex) GetProgramData(string[] inputs)
    {
      var accumulator = 0;
      var lines = new List<int>();
      var i = 0;
      while(i < inputs.Length)
      {
        var instructionSplit = inputs[i].Split(' ');
        var instruction = instructionSplit[0];
        var value = Convert.ToInt32(instructionSplit[1]);
        if (lines.Contains(i))
        {
          break;
        }
        lines.Add(i);

        if (instruction == "nop")
        {
          i++;
        }
        else if (instruction == "acc")
        {
          accumulator += value;
          i++;
        }
        else if (instruction == "jmp")
        {
          i += value;
        }
      }
      return (accumulator, i);
    }

    private static bool ProgramLoopCompleted(string[] inputs)
    {
      var data = GetProgramData(inputs);
      if (data.lastIndex == inputs.Length)
      {
        Console.WriteLine($"Acc: {data.accumulator}");
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}

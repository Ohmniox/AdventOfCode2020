using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day9
{
  public class Solution
  {
    public static void Puzzle1()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      GetWeakNumber(inputs, 25);
    }
    
    public static void Puzzle2()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var weakNumber = GetWeakNumber(inputs, 25);
      FindEncryptionWeakness(inputs, weakNumber);
    }

    private static int GetWeakNumber(string[] inputs, int preamble)
    {
      var numberList = new List<int>();
      var weakNumber = 0;
      for (int i = 0; i < preamble; i++)
      {
        numberList.Add(Convert.ToInt32(inputs[i]));
      }

      for (int i = preamble; i < inputs.Length; i++)
      {
        var currentNumber = Convert.ToInt32(inputs[i]);
        if (!DoesPairExist(numberList.ToArray(), currentNumber))
        {
          weakNumber = currentNumber;
          Console.WriteLine($"Num: {weakNumber}");
          break;
        }
        numberList.Remove(numberList.First());
        numberList.Add(currentNumber);
      }
      return weakNumber;
    }

    private static bool DoesPairExist(int[] numberArray, int sum)
    {
      HashSet<int> hashset = new HashSet<int>();
      for (int i = 0; i < numberArray.Length; ++i)
      {
        var temp = sum - numberArray[i];
        if (hashset.Contains(temp))
        {
          return true;
        }
        hashset.Add(numberArray[i]);
      }
      return false;
    }

    private static void FindEncryptionWeakness(string[] inputs, long weakNumber)
    {
      var arr = inputs.Select(long.Parse).ToArray();
      for (int i = 0; i < arr.Length; i++)
      {
        long sum = 0;
        for (int j = i; j < arr.Length; j++)
        {
          sum += arr[j];
          if (sum == weakNumber)
          {
            var contiguousNumbers = arr[i..(j + 1)];
            Console.WriteLine($"Contiguous Numbers : {string.Join(',', contiguousNumbers)}");
            Console.WriteLine($"Min Max Sum: {contiguousNumbers.Min() + contiguousNumbers.Max()}");
            return;
          }
        }
      }
    }
  }
}
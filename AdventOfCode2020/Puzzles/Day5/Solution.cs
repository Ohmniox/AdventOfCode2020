using System;
using System.Linq;

namespace AdventOfCode2020.Puzzles.Day5
{
  public class Solution
  {
    public static void Puzzle1()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var highestSeatID = 1;
      var highestSeatCode = inputs[0];
      foreach (var input in inputs)
      {
        var rowCode = input.Substring(0, 7);
        var columnCode = input.Substring(7);

        var rowCodeInBinary = rowCode.Replace('F', '0').Replace('B', '1');
        var rowNumber = Convert.ToInt32(rowCodeInBinary, 2);

        var columnCodeInBinary = columnCode.Replace('R', '1').Replace('L', '0');
        var columnNumber = Convert.ToInt32(columnCodeInBinary, 2);

        var seatID = (rowNumber * 8) + columnNumber;
        Console.WriteLine($"input: {input} SeatID: {seatID}");
        if (seatID > highestSeatID)
        {
          highestSeatID = seatID;
          highestSeatCode = input;
        }
      }
      Console.WriteLine($"Highest seatCode: {highestSeatCode} seatID: {highestSeatID}");
    }

    public static void Puzzle2()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);
      var AllSeats = Enumerable.Range(11, 840).ToList();

      foreach (var input in inputs)
      {
        var rowCode = input.Substring(0, 7);
        var columnCode = input.Substring(7);

        var rowCodeInBinary = rowCode.Replace('F', '0').Replace('B', '1');
        var rowNumber = Convert.ToInt32(rowCodeInBinary, 2);

        var columnCodeInBinary = columnCode.Replace('R', '1').Replace('L', '0');
        var columnNumber = Convert.ToInt32(columnCodeInBinary, 2);

        var seatID = (rowNumber * 8) + columnNumber;
        AllSeats.Remove(seatID);
      }
      Console.WriteLine($"SeatID: {AllSeats.First()}");
    }
  }
}

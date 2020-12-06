using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Puzzles
{
  public class InputHelper
  {
    //Some Hard-coded Stuff.
    public static string[] ReadAllLines(InputFileType inputFileType)
    {
      var day = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod().ReflectedType.FullName.Split('.')[2];
      var fileName= $"Puzzles/{day}/Input_{inputFileType}.txt";
      return File.ReadAllLines(fileName);
    }
  }
}

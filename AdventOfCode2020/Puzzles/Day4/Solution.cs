using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day4
{
  public class Solution
  {
    public static void Puzzle1()
    {
      var validPass = 0;
      foreach (var passport in ReadAllPassportDetails())
      {
        if (IsPassportValid(passport))
        {
          validPass++;
        }
      }
      Console.WriteLine($"Valid passports: {validPass}");
    }

    public static void Puzzle2()
    {
      var validPass = 0;
      foreach (var passport in ReadAllPassportDetails())
      {
        if (IsPassportValid2(passport))
        {
          validPass++;
        }
      }
      Console.WriteLine($"Valid passports: {validPass}");
    }

    private static List<Dictionary<string, string>> ReadAllPassportDetails()
    {
      var inputs = System.IO.File.ReadAllLines("Puzzles/Day4/Input_Final.txt");
      var allPassportDetails = new List<Dictionary<string, string>>();
      for (int i = 0; i < inputs.Length;)
      {
        Dictionary<string, string> passDetails = new Dictionary<string, string>();
        while (i < inputs.Length && inputs[i] != "")
        {
          var inputArray = inputs[i].Split(' ');
          foreach (var inputItem in inputArray)
          {
            var keyValuePair = inputItem.Split(':');
            passDetails.Add(keyValuePair[0], keyValuePair[1]);
          }
          i++;
        }
        allPassportDetails.Add(passDetails);
        i++;
      }
      return allPassportDetails;
    }

    private static bool IsPassportValid(Dictionary<string, string> passportDetails)
    {
      if (passportDetails.ContainsKey("byr") &&
         passportDetails.ContainsKey("iyr") &&
         passportDetails.ContainsKey("eyr") &&
         passportDetails.ContainsKey("hgt") &&
         passportDetails.ContainsKey("hcl") &&
         passportDetails.ContainsKey("ecl") &&
         passportDetails.ContainsKey("pid")
         )
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    private static bool IsPassportValid2(Dictionary<string, string> passportDetails)
    {
      if (!passportDetails.ContainsKey("byr") ||
          !passportDetails.ContainsKey("iyr") ||
          !passportDetails.ContainsKey("eyr") ||
          !passportDetails.ContainsKey("hgt") ||
          !passportDetails.ContainsKey("hcl") ||
          !passportDetails.ContainsKey("ecl") ||
          !passportDetails.ContainsKey("pid")
         )
      {
        return false;
      }

      var byr = Convert.ToInt32(passportDetails["byr"]);
      if (byr < 1920 || byr > 2002)
      {
        return false;
      }

      var iyr = Convert.ToInt32(passportDetails["iyr"]);
      if (iyr < 2010 || iyr > 2020)
      {
        return false;
      }

      var eyr = Convert.ToInt32(passportDetails["eyr"]);
      if (eyr < 2020 || eyr > 2030)
      {
        return false;
      }

      var hgt = passportDetails["hgt"];
      if (hgt.EndsWith("cm") || hgt.EndsWith("in"))
      {
        if (hgt.EndsWith("cm"))
        {
          var h = Convert.ToInt32(hgt.Replace("cm", string.Empty));
          if (h < 150 || h > 193)
          {
            return false;
          }
        }
        else if (hgt.EndsWith("in"))
        {
          var h = Convert.ToInt32(hgt.Replace("in", string.Empty));
          if (h < 59 || h > 76)
          {
            return false;
          }
        }
      }
      else
      {
        return false;
      }

      var hcl = passportDetails["hcl"];
      if (!System.Text.RegularExpressions.Regex.Match(hcl, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
      {
        return false;
      }

      var validEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
      var ecl = passportDetails["ecl"];
      if (!validEyeColors.Any(x => x == ecl))
      {
        return false;
      }

      var pid = passportDetails["pid"];
      if (pid.Length != 9)
      {
        return false;
      }
      if (!System.Text.RegularExpressions.Regex.Match(pid, @"^\d+$").Success)
      {
        return false;
      }

      return true;
    }
  }
}

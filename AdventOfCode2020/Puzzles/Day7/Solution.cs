using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Puzzles.Day7
{
  public class Solution
  {
    static Dictionary<string, List<Bag>> LuggageRules = new Dictionary<string, List<Bag>>();

    public static void Puzzle1()
    {
      MapLuggageRules();
      var count = LuggageRules.Where(x => ContainsBag(x.Value, "shiny gold")).Count();
      Console.WriteLine($"Count : {count}");
    }

    public static void Puzzle2()
    {
      MapLuggageRules();
      var count = GetCount("shiny gold");
      Console.WriteLine($"Count : {count}");
    }

    public static int GetCount(string bagName)
    {
      var subBags = LuggageRules[bagName];
      var sum = 0;
      foreach (var bag in subBags)
      {
        sum += bag.Count + (bag.Count * (GetCount(bag.Name)));
      }
      return sum;
    }


    public static bool ContainsBag(List<Bag> currentBags, string checkBagName)
    {
      if (currentBags.FirstOrDefault(x => x.Name == checkBagName) != null)
      {
        return true;
      }
      else
      {
        foreach (var bag in currentBags)
        {
          var subBags = LuggageRules[bag.Name];
          if (ContainsBag(subBags, checkBagName))
          {
            return true;
          }
        }
        return false;
      }
    }

    public static void MapLuggageRules()
    {
      var inputs = InputHelper.ReadAllLines(InputFileType.Final);

      foreach (var input in inputs)
      {
        var mainSplit = input.Split("bags contain");
        var currentBagName = mainSplit[0].Trim();
        var bags = mainSplit[1].Split(',');
        var bagList = new List<Bag>();
        foreach (var bag in bags)
        {
          if (bag.Contains("no other bags."))
          {
            continue;
          }
          var bagInformation = bag.Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
          var count = Convert.ToInt32(bagInformation[..1]);
          var bagName = bagInformation[1..].Trim();
          bagList.Add(new Bag
          {
            Count = count,
            Name = bagName
          });
        }
        LuggageRules.Add(currentBagName, bagList);
      }
    }

    public class Bag
    {
      public int Count { get; set; }
      public string Name { get; set; }
    }
  }
}

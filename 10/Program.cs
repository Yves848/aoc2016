using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/10/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

Dictionary<int, List<int>> bots = [];
Dictionary<int, List<int>> bins = [];

Regex re1 = new(@"value.*?(\d+).*?(\d+)");
Regex re2 = new(@"^bot (\d+) gives low to (\w+) (\d+).*?high to (\w+) (\d+)");

void part1()
{
  int ans = 0;
  int i = 0;
  while (file.Count > 0)
  {
    string instruction = file[i];
    if (re1.IsMatch(instruction))
    {
      var m = re1.Match(instruction);
      int value = int.Parse(m.Groups[1].Value);
      int bot = int.Parse(m.Groups[2].Value);
      if (!bots.ContainsKey(bot)) bots.Add(bot,[]);
      
        List<int> chips = bots[bot];
        if (chips.Count < 2) chips.Add(value);
        bots[bot] = chips;
        file.RemoveAt(i);
      
    }
    else
    {
      var m = re2.Match(instruction);
      int bot = int.Parse(m.Groups[1].Value);
      // check if bot has 2 chips
      if (bots.ContainsKey(bot))
      {
        List<int> chips = bots[bot];
        if (chips.Count == 2)
        {
          // dispatch
          string typeLow = m.Groups[2].Value;
          int toLow = int.Parse(m.Groups[3].Value);
          string typeHigh = m.Groups[4].Value;
          int toHigh = int.Parse(m.Groups[5].Value);
          chips.Sort();
          int low = chips[0];
          int high = chips[1];
          if (low == 17 && high == 61) {
            ans = bot;
            // break;
          }
          if (typeLow == "bot")
          {
            if (!bots.ContainsKey(toLow)) bots.Add(toLow, []);
            chips = bots[toLow];
            chips.Add(low);
            bots[toLow] = chips;
          }
          else
          {
            if (!bins.ContainsKey(toLow)) bins.Add(toLow,[]);
            chips = bins[toLow];
            chips.Add(low);
            bins[toLow] = chips;
          }
          if (typeHigh == "bot")
          {
            if (!bots.ContainsKey(toHigh)) bots.Add(toHigh, []);
            chips = bots[toHigh];
            chips.Add(high);
            bots[toHigh] = chips;
          }
          else
          {
            if (!bins.ContainsKey(toHigh)) bins.Add(toHigh,[]);
            chips = bins[toHigh];
            chips.Add(high);
            bins[toHigh] = chips;
          }
          file.RemoveAt(i);
        }
        else i++;
      }
      else i++;
    }
    if (i > file.Count -1) i = 0;
  }
  Console.WriteLine($"Part 1 - Answer : {ans}");
  ans = bins[0][0]*bins[1][0]*bins[2][0];
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

// part2();

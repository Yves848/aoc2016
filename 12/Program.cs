using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/12/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

Dictionary<string, int> registers = new Dictionary<string, int>() {
  {"a",0},
  {"b",0},
  {"c",1}, // 0 = part 1   - 1 = Part 2
  {"d",0}
};

List<(string i, string a, string b)> instructions = [];

Regex re = new(@"^(\w{3}) (\w*)\s?(-?\w*)");

void part1()
{
  int ans = 0;
  file.ForEach(line =>
  {
    var m = re.Match(line);
    string i = m.Groups[1].Value;
    string a = m.Groups[2].Value;
    string b = "";
    if (m.Groups.Count > 3)
    {
      b = m.Groups[3].Value;
    }
    instructions.Add((i, a, b));
  });
  int i = 0;
  int val = 0;
  while (i < instructions.Count)
  {
    var (inst, a, b) = instructions[i];
    switch (inst)
    {
      case "cpy":
        if (int.TryParse(a, out val))
        {
          registers[b] = val;
        }
        else
        {
          registers[b] = registers[a];
        }
        break;
      case "inc":
        registers[a]++;
        break;
      case "dec":
        registers[a]--;
        break;
      case "jnz":
        val = 0;
        if (int.TryParse(a, out val))
        {

        } else val = registers[a];
        if (val != 0) {
          i += int.Parse(b);
          continue;
        }
        break;
    }
    i++;
  }
  ans = registers["a"];
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

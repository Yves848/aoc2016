using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/09/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re = new(@"(\d+)x(\d+)");
string puzzle = file[0];

void part1()
{
  int ans = 0;
  string result = "";
  string temp = "";
  bool repeat = false;
  bool f = false;
  int nb = 0;
  int t = 0;
  int i = 0;
  while (i < puzzle.Length)
  {
    char c = puzzle[i];
    if (c == '(' && !repeat)
    {
      temp = "";
      repeat = true;
      f = true;
      i++;
      continue;
    }
    if (c == ')' && f)
    {
      var m = re.Match(temp);
      nb = int.Parse(m.Groups[1].Value);
      t = int.Parse(m.Groups[2].Value);
      temp = "";
      f = false;
      i++;
      continue;
    }

    if (repeat)
    {
      if (f)
      {
        temp += c.ToString();
        i++;
        continue;
      }
      if (!f && nb > 0)
      {
        temp += c.ToString();
        nb--;
        if (nb == 0)
        {
          result += string.Concat(Enumerable.Repeat(temp, t));
          repeat = false;
        }
        i++;
        continue;
      }
    }
    result += c.ToString();
    i++;
  }
  ans = result.Length;
  Console.WriteLine($"Part 1 - Answer : {ans}");
}
void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

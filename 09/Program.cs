using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/09/test2.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re = new(@"(\d+)x(\d+)");
string puzzle = file[3];

void part1()
{
  int ans = 0;
  string result = decompress(puzzle);
  ans = result.Length;
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

string decompress(string compressed)
{
  string result = "";
  string temp = "";
  bool repeat = false;
  bool f = false;
  int nb = 0;
  int t = 0;
  int i = 0;
  while (i < compressed.Length)
  {
    char c = compressed[i];
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
  return result;
}
string decompress2(string compressed)
{
  string result = "";
  string temp = "";
  bool repeat = false;
  bool f = false;
  int nb = 0;
  int t = 0;
  int i = 0;
  while (i < compressed.Length)
  {
    char c = compressed[i];
    compressed = compressed[1..];
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

  return result;
}
void part2()
{
  long ans = 0;
  string temp = "";
  bool repeat = false;
  string result = "";
  int nb = 0;
  int t = 1;
  int i = 0;
  string comp = puzzle;
  while (i < comp.Length)
  {
    char c = comp[i];
    comp = comp[1..];
    if (c == '(')
    {
      temp = "";
      repeat = true;
      continue;
    }
    if (c == ')')
    {
      var m = re.Match(temp);
      nb = int.Parse(m.Groups[1].Value);
      t *= int.Parse(m.Groups[2].Value);
      temp = comp.Substring(0,nb);
      if (comp[0] != '(') {
        var m2 = re.Matches(temp);
        temp = string.Concat(Enumerable.Repeat(temp, t));
        repeat = false;
        ans += temp.Length-1;
        t = 1;
      }
      continue;
    }
    if (repeat)
    {
      temp += c.ToString();
    }
    else ans++;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

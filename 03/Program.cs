using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/03/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex reNum = new(@"(\d+)");
List<(int a, int b, int c)> triangles = [];
void part1()
{
  int ans = 0;
  file.ForEach(line =>
  {
    var m = reNum.Matches(line);
    var (a, b, c) = (int.Parse(m[0].Value), int.Parse(m[1].Value), int.Parse(m[2].Value));
    if (a + b > c &&
        a + c > b &&
        b + c > a)
    {
      ans++;
    }
    triangles.Add((a, b, c));
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  List<int> ta = triangles.Select(t =>
  {
    return t.a;
  }).ToList();//.Where(p => p >= 100).ToList();
  ta.Sort();
  for (int i = 0; i < ta.Count ; i += 3)
  {
    var (a, b, c) = (ta[i], ta[i + 1], ta[i + 2]);
    // if (a / 100 == b / 100 && a / 100 == c / 100)
      if (a + b > c &&
          a + c > b &&
          b + c > a)
      {
        ans++;
      }
  }
  ta.Clear();
  ta = triangles.Select(t =>
  {
    return t.b;
  }).ToList();//.Where(p => p >= 100).ToList();
  ta.Sort();
  for (int i = 0; i < ta.Count; i += 3)
  {
    var (a, b, c) = (ta[i], ta[i + 1], ta[i + 2]);
    // if (a / 100 == b / 100 && a / 100 == c / 100)
      if (a + b > c &&
          a + c > b &&
          b + c > a)
      {
        ans++;
      }
  }
  ta.Clear();
  ta = triangles.Select(t =>
  {
    return t.c;
  }).ToList();//.Where(p => p >= 100).ToList();
  ta.Sort();
  for (int i = 0; i < ta.Count; i += 3)
  {
    var (a, b, c) = (ta[i], ta[i + 1], ta[i + 2]);
    // if (a / 100 == b / 100 && a / 100 == c / 100)
      if (a + b > c &&
          a + c > b &&
          b + c > a)
      {
        ans++;
      }
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

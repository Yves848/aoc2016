using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO.Pipelines;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string file = args.Length > 0 ? File.ReadAllText(args[0]) : File.ReadAllText($"{home}/git/aoc2016/01/test.txt");
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
var dirs = new List<(int, int)> {
  (1,0),// N
  (0,1), // E
  (-1,0), // S
  (0,-1) // W
};

int turn(string d, int facing)
{
  int result = 0;
  if (d == "L")
  {
    result = facing - 1;
  }
  else result = facing + 1;

  if (result > dirs.Count - 1) result = 0;
  if (result < 0) result = dirs.Count - 1;

  return result;
}

void part1()
{
  HashSet<(int, int)> visited = [];
  int ans = 0;
  (int y, int x) ans2 = (0, 0);
  (int y, int x) start = (0, 0);
  bool first = true;
  int facing = 0; // N
  file.Split(",").ToList().ForEach(d =>
  {
    string m = d.Trim().Substring(0, 1);
    int nb = int.Parse(d.Trim().Substring(1, d.Trim().Length - 1));
    facing = turn(m, facing);
    var (dy, dx) = dirs[facing];
    while (nb > 0)
    {
      start.y += dy;
      start.x += dx;
      if (!visited.Contains(start))
      {
        visited.Add(start);
      }
      else
      {
        if (first)
        {
          ans2.y = start.y;
          ans2.x = start.x;
          first = false;
        }
      }
      nb--;
    }
  });
  ans = Math.Abs(0 - start.x) + Math.Abs(0 - start.y);
  Console.WriteLine($"Part 1 - Answer : {ans}");
  ans = Math.Abs(0 - ans2.x) + Math.Abs(0 - ans2.y);
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

// part2();

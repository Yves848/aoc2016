using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Spectre.Console;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/08/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re = new(@"rect|(rotate) (\w+) |(\d+)");

int[,] grid = new int[6, 50];
int h = grid.GetLength(0);
int w = grid.GetLength(1);
for (int y = 0; y < h; y++)
{
  for (int x = 0; x < w; x++)
  {
    grid[y, x] = 0;
  }
}

int prindGrid(int[,] grid)
{
  Rule rule = new Rule();
  int result = 0;
  for (int y = 0; y < h; y++)
  {
    for (int x = 0; x < w; x++)
    {
      Console.Write(grid[y, x] == 0 ? "." : "#");
      if (grid[y, x] == 1) result++;
    }
    Console.WriteLine();
  }
  AnsiConsole.Write(rule);
  Console.WriteLine();
  return result;
}

void part1()
{
  int ans = 0;
  prindGrid(grid);
  file.ForEach(line =>
  {
    Console.WriteLine(line);
    var matches = re.Matches(line);
    if (matches[0].Value == "rect")
    {
      for (int y = 0; y < int.Parse(matches[2].Value); y++)
      {
        for (int x = 0; x < int.Parse(matches[1].Value); x++)
        {
          grid[y, x] = 1;
        }
      }
    }
    if (matches[0].Value.Trim().Contains("row"))
    {
      var y = int.Parse(matches[1].Value);
      var nb = int.Parse(matches[2].Value);
      int[] row = new int[w];
      int x = nb;
      for (int i = 0; i < w; i++)
      {
        if (x > w - 1) x = 0;
        row[x] = grid[y, i];
        x++;
      }
      for (int i = 0; i < w; i++)
      {
        grid[y, i] = row[i];
      }
    }
    if (matches[0].Value.Trim().Contains("column"))
    {
      var x = int.Parse(matches[1].Value);
      var nb = int.Parse(matches[2].Value);
      int[] col = new int[h];
      int y = nb;
      for (int i = 0; i < h; i++)
      {
        if (y > h - 1) y = 0;
        col[y] = grid[i, x];
        y++;
      }
      for (int i = 0; i < h; i++)
      {
        grid[i, x] = col[i];
      }
    }
    ans = prindGrid(grid);
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

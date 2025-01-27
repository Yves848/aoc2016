using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO.Pipelines;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string file = args.Length > 0 ? File.ReadAllText(args[0]) : File.ReadAllText($"{home}/git/aoc2016/01/test.txt");
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
var dirs = new List<(int,int)> {
  (-1,0),// N
  (0,1), // E
  (1,0), // S
  (0,-1) // W
};

int turn(string d, int facing) {
  int result = 0;
  result = facing + d == "L" ? -1 : 1;
  if (result > dirs.Count -1) result = 0;
  if (result < 0) result = dirs.Count -1;

  return result;
}

void part1()
{
  int ans = 0;
  (int,int) start = (0,0);
  int facing = 0; // N
  file.Split(",").ToList().ForEach(d => {
    Console.WriteLine(d.Trim());
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

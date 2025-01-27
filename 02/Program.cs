using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/02/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";



var dirs = new Dictionary<char, (int, int)> {
  {'D',(1,0)},// U
  {'R',(0,1)}, // R
  {'U',(-1,0)}, // L
  {'L',(0,-1)} // D
};

void part1()
{
  string[,] numpad = {
  {"1","2","3"},
  {"4","5","6"},
  {"7","8","9"},
};
  string ans = "";
  (int y, int x) pos = (1, 1);
  file.ForEach(line =>
  {
    line.ToList().ForEach(c =>
    {
      var (dy, dx) = dirs[c];
      if (pos.y + dy >= 0 && pos.y + dy <= 2) pos.y = pos.y + dy;
      if (pos.x + dx >= 0 && pos.x + dx <= 2) pos.x = pos.x + dx;
    });
    ans += numpad[pos.y, pos.x];
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  string[,] numpad = {
  {".",".","1",".","."},
  {".","2","3","4","."},
  {"5","6","7","8","9"},
  {".","A","B","C","."},
  {".",".","D",".","."},
};
  string ans = "";
  (int y, int x) pos = (2, 0);
  file.ForEach(line =>
  {
    line.ToList().ForEach(c =>
    {
      var (dy, dx) = dirs[c];
      if (pos.y + dy >= 0 && pos.y + dy <= 4 && pos.x + dx >= 0 && pos.x + dx <= 4)
      {
        if (numpad[pos.y + dy, pos.x + dx] != ".")
        {
          pos.y = pos.y + dy;
          pos.x = pos.x + dx;
        }
      }
    });
    ans += numpad[pos.y, pos.x];
  });
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

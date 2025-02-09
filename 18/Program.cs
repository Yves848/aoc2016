using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO.Pipelines;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string line = "";
int safe = 0;
if (args.Length > 0)
{
  line = "^^.^..^.....^..^..^^...^^.^....^^^.^.^^....^.^^^...^^^^.^^^^.^..^^^^.^^.^.^.^.^.^^...^^..^^^..^.^^^^";
}
else
{
  line = ".^^.^.^^^^";
}

List<string> puzzle = [line];

bool isTrap(string row, int pos)
{
  bool left = pos == 0 ? false : row[pos - 1] == '^';
  bool center = row[pos] == '^';
  bool right = pos < row.Length - 1 ? row[pos + 1] == '^' : false;
  /*
  Its left and center tiles are traps, but its right tile is not.
  Its center and right tiles are traps, but its left tile is not.
  Only its left tile is a trap.
  Only its right tile is a trap.
  */
  if (left && center && !right) return true;
  if (center && right && !left) return true;
  if (left && !center && !right) return true;
  if (right && !center && !left) return true;
  return false;
}

void part1()
{
  int ans = 0;
  int ans2 = 0;
  int i = 0;
  safe += line.Where(c => c == '.').Count();
  while (i < 399999)
  {
    line = puzzle[i];
    string newline = "";
    int j = 0;
    line.ToList().ForEach(c =>
    {
      newline += isTrap(line, j) ? "^" : ".";
      j++;
    });
    if (i==39) ans = safe;
    safe += newline.Where(c => c == '.').Count();
    puzzle.Add(newline);
    i++;
  }
  // puzzle.ForEach(l => {
  //   Console.WriteLine(l);
  // });
  ans2 = safe;
  Console.WriteLine($"Part 1 - Answer : {ans}");
  Console.WriteLine($"Part 1 - Answer : {ans2}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

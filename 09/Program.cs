using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Linq.Expressions;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/09/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re = new(@"\((\d+)x(\d+)\)");
string puzzle = file[0];

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


void part2()
{
  long ans = 0;
  Stack<(string puzzle, int t)> Q = [];
  Stack<int> tt = [];
  while (true)
  {
    string temp = "";
    var m = re.Match(puzzle);
    int index = m.Index;
    int len = m.Length;
    int nb = int.Parse(m.Groups[1].Value);
    int t = int.Parse(m.Groups[2].Value);
    temp += puzzle.Substring(0, index);
    string sub = puzzle.Substring(index + len, nb);
    Console.WriteLine($"({nb}x{t}) {sub}");
    puzzle = puzzle.Substring(index + len + nb);
    if (sub.Contains(")("))
    {
      Console.WriteLine($"push ({t}) {puzzle}");
      if (puzzle != "")
        Q.Push((puzzle, t));
      tt.Push(t);
      puzzle = sub;
    }
    else
    {
      var matches = re.Matches(sub);
      long subtotal = 0;
      if (matches.Count > 0)
      {
        matches.ToList().ForEach(ma =>
        {
          int nb1 = int.Parse(ma.Groups[1].Value);
          int t1 = int.Parse(ma.Groups[2].Value);
          subtotal += (nb1 * t1);
          Console.WriteLine($"   ({nb1}x{t1}) {sub.Substring(ma.Index + ma.Length, nb1)} subtotal {(nb1 * t1)}");
        });
      }
      else
      {
        subtotal = sub.Length;
      }
      if (tt.Count > 0) t = tt.Pop();
      Console.WriteLine($"subtotal {subtotal * t} {t}");
      ans += t * subtotal;
    }
    if (puzzle == "")
    {
      while (puzzle == "" && Q.Count > 0)
        (puzzle, t) = Q.Pop();
      Console.WriteLine($"pop {Q.Count}");
    }
    if (puzzle == "") break;
  }
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

long split(string piece)
{
  long ans = 0;
  while (piece != "")
  {
    string temp = "";
    var m = re.Match(piece);
    int index = m.Index;
    int len = m.Length;
    int nb = int.Parse(m.Groups[1].Value);
    int t = int.Parse(m.Groups[2].Value);
    temp += piece.Substring(0, index);
    string sub = piece.Substring(index + len, nb);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"({nb}x{t})");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"{sub}");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($" {sub.Length}");
    piece = piece.Substring(index + len + nb);
    ans += split(sub);
  }
  Console.WriteLine(ans);
  return ans;
}

//part1();

// part2();

split(puzzle);

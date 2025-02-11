using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/01/data.txt").ToList();
string puzzle = "abcde";

if (args.Length > 0) {
  puzzle = "abcdefgh";
}

var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re1 = new(@"rotate (right|left) \d+");
Regex re2 = new(@"rotate based on position of letter (\w)");
Regex re3 = new(@"swap position (\d+) with position (\d+)");
Regex re4 = new(@"reverse positions (\d+) through (\d+)");
Regex re5 = new(@"move position (\d+) to position (\d+)");

void part1()
{
  int ans = 0;
  Span<char> checksum = puzzle.ToCharArray(); // Still needed, but manageable
  file.ForEach(line => {

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

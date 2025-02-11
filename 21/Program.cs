using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/21/test.txt").ToList();
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
Regex re6 = new(@"swap letter (\w) with letter (\w)");

void part1()
{
  int ans = 0;
  Span<char> checksum = puzzle.ToCharArray(); // Still needed, but manageable
  int i = 0;
  while (i < file.Count) {
    string line = file[i];
    if (re1.IsMatch(line)) {
      // rotate left/right
      var m = re1.Match(line);
      string direction = m.Groups[1].Value;
      int nb = int.Parse(m.Groups[2].Value); 
    }
    if (re2.IsMatch(line)) {
      // rotate letter
    }
    if (re3.IsMatch(line)) {
      // swap position
      var m = re3.Match(line);
      int p1 = int.Parse(m.Groups[1].Value);
      int p2 = int.Parse(m.Groups[2].Value);
      char t = checksum[p1];
      checksum[p1] = checksum[p2];
      checksum[p2] = t; 
    }
    if (re4.IsMatch(line)) {

    }
    if (re5.IsMatch(line)) {

    }
    if (re6.IsMatch(line)) {
      // Swap letters
      var m = re3.Match(line);
      int p1 = checksum.IndexOf(m.Groups[1].Value[0]);
      int p2 = checksum.IndexOf(m.Groups[2].Value[0]);
      char t = checksum[p1];
      checksum[p1] = checksum[p2];
      checksum[p2] = t;
    }
    i++;
  };
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

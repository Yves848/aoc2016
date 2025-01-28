using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/07/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex tls = new(@"\[?\w*(\w)(\w)\2\1\w*\]?");

void part1()
{
  int ans = 0;
  file.ForEach(line => {
    var m = tls.Matches(line);
    int nb = 0;
    for(int i = 0; i < m.Count;i++) {
      var ok = true;
      ok = ok && (m[i].Groups[1].Value != m[i].Groups[2].Value);
      ok = ok && !m[i].Value.Contains("[");
      if (ok) nb++;
    }
    ans += nb > 0 ? 1 : 0;
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

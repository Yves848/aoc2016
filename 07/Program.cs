using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/07/test2.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex tls = new(@"(\w)(\w)\2\1");
Regex ssl = new(@"(\w)(\w)\1");
Regex brackets = new(@"\[\w+\]");

bool ContainsABBA(string segment)
{
  for (int i = 0; i < segment.Length - 3; i++)
  {
    if (segment[i] != segment[i + 1] && segment[i] == segment[i + 3] && segment[i + 1] == segment[i + 2])
    {
      return true;
    }
  }
  return false;
}
void part1()
{
  int ans = 0;
  file.ForEach(line =>
  {
    var hypernet = brackets.Matches(line).Cast<Match>().Select(m => m.Value).ToList();
    var net = brackets.Split(line).ToList();
    if (!hypernet.Any(ContainsABBA))
    {
      if (net.Any(ContainsABBA)) ans++;
    }
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  file.ForEach(line =>
  {
    var hypernet = brackets.Matches(line).Cast<Match>().Select(m => m.Value).ToList();
    var net = brackets.Split(line).ToList();
    List<string> bab = [];
    for (int i = 0; i < net.Count; i++)
    {
      string segment = net[i];
      for (int j = 0; j < segment.Length - 2; j++)
      {
        if (segment[j] != segment[j + 1] && segment[j] == segment[j + 2])
        {
          bab.Add(segment[j+1].ToString()+segment[j]+segment[j+1]);
        }
      }

    }
    bool isSSL = false;
    bab.ForEach(b =>
    {
      hypernet.ForEach(h =>
      {
        isSSL = isSSL || h.Contains(b);
      });
    });
    if (isSSL) ans++;
  });
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

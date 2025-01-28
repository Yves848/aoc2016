using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/06/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";


void part1()
{
  int ans = 0;
  Dictionary<int,Dictionary<char,int>> counter = [];
  file.ForEach(line => {
    int pos = 0;
    line.ToList().ForEach(c => {
      if (!counter.ContainsKey(pos)) counter.Add(pos,new Dictionary<char, int>());
        var cpt = counter[pos];
        if (!cpt.ContainsKey(c)) cpt.Add(c,0);
        cpt[c] += 1;
      pos++;
    });
  });
  string word = "";
  string word2 = "";
  
  counter.ToList().ForEach(c => {
    var (pos,cpt) = c;
    var max = cpt.Max(kvp => kvp.Value);
    var min = cpt.Min(kvp => kvp.Value);
    word += cpt.FirstOrDefault(kvp => kvp.Value == max).Key.ToString();
    word2 += cpt.FirstOrDefault(kvp => kvp.Value == min).Key.ToString();
  });
  Console.WriteLine($"Part 1 - Answer : {word}");
  Console.WriteLine($"Part 2 - Answer : {word2}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

// part2();

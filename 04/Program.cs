using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/04/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
List<(string name, int id)> valid = [];

void part1()
{
  int ans = 0;
  Dictionary<char, int> car = [];
  List<char> check = [];
  file.ForEach(line =>
  {
    var blocs = line.Split("[");
    string checksum = blocs[1].Replace(']', ' ').Trim();
    var elements = blocs[0].Split("-").ToList();
    int id = int.Parse(elements[elements.Count() - 1]);
    elements.RemoveAt(elements.Count - 1);
    car.Clear();
    elements.ForEach(e =>
    {
      e.ToList().ForEach(c =>
      {
        if (!car.ContainsKey(c)) { car.Add(c, 0); }
        car[c] += 1;
      });
    });
    string sCheck = "";
    var sorted = car.OrderByDescending(c => c.Value).ThenBy(c => c.Key).ToList();
    sorted.ForEach(c => sCheck += c.Key.ToString());
    if (sCheck.StartsWith(checksum))
    {
      ans += id;
      valid.Add((String.Join(" ", elements), id));
    }
  });
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  valid.ForEach(v =>
  {
    var (key, id) = v;
    string decrypt = "";
    key.ToList().ForEach(c =>
    {
      if (c == ' ') { decrypt += c.ToString(); }
      else {
        for(int i = 0; i < (id % 26); i++) {
          c++;
          if (c > 'z') c = 'a';
        }
        decrypt += c.ToString();
      }
    });
    if (decrypt.Contains("objects"))
    Console.WriteLine($"{decrypt}\t{id}");
  });
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

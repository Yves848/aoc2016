using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


string init = "";
int size = 0;

Regex re = MyRegex();

if (args.Length > 0)
{
  init = "10111100110001111";
  size = 35651584;
}
else
{
  init = "10000";
  size = 20;
}

init = "10111100110001111";
size = 35651584;

void part1()
{
  int ans = 0;

  while (init.Length < size)
  {
    Span<char> b = init.Replace('0','#').Replace('1','0').Replace('#','1').ToArray();
    b.Reverse();
    init = init + "0" + new string(b);
    Console.WriteLine($"Size : {init.Length}");
  }
  // a = a.Substring(0, size);
  Console.WriteLine("Beginning Checksum");
  Span<char> checksum = init.ToArray();
  Span<char> t = checksum.Slice(0,size);
  while (t.Length % 2 == 0)
  {
    string temp = "";
    for (int i = 0; i < t.Length; i += 2)
    {
      if (t[i] == t[i + 1])
      {
        temp += "1";
      }
      else
      {
        temp += "0";
      }
    }
    t = temp.ToArray();
  }
  Console.WriteLine(new string(checksum));
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
partial class Program
{
  [GeneratedRegex(@"([1|0])\1")]
  private static partial Regex MyRegex();
}
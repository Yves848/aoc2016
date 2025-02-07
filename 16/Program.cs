using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;

string init = "";
int size = 0;

Regex re = MyRegex();

if (args.Length > 0)
{
  init = "10111100110001111";
  size = 272;
}
else
{
  init = "10000";
  size = 20;
}



void part1()
{
  int ans = 0;
  while (init.Length < size)
  {
    string a = init;
    string b = "";
    for (int i = a.Length - 1; i >= 0; i--)
    {
      b += a[i];
    }
    init = a + "0" + b.Replace('0', 'x').Replace('1', 'y').Replace('x', '1').Replace('y', '0');
  }
  init = init.Substring(0,size);
  string cheksum = init;
  while (cheksum.Length % 2 == 0) {
    var m = re.Matches(cheksum);
    cheksum = "";
    m.ToList().ForEach(chk => {
      cheksum += chk.Value;
    });
  }
  Console.WriteLine(cheksum);
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
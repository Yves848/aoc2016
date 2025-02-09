using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string passcode = "";
MD5 md = MD5.Create();
Dictionary <char,(int x, int y)> directions = new Dictionary<char, (int x, int y)> {
  {'U',(0,-1)},
  {'D',(0,1)},
  {'L',(-1,0)},
  {'R',(1,0)}
};

int w = 4;
int h = 5;

(int x, int y) start = (0,0);

if (args.Length > 0)
{
  passcode = "rrrbmfta";
}
else
{
  passcode = "hijkl";
}

Dictionary<char, (int x, int y)> getDirs(string hash)
{
  Dictionary<char, (int x, int y)> dirs = [];
  dirs.Clear();
  char[] d = ['U','D','L','R'];
  for (int i = 0; i < 4; i++)
  {
    switch (hash[i])
    {
      case 'b':
      case 'c':
      case 'd':
      case 'e':
      case 'f':
        {
          dirs.Add(d[i],directions[d[i]]);
          break;
        }
      default:
        {
          break;
        }
    }
  }
  return dirs;
}

void part1()
{
  int ans = 0;
  byte[] hashcode = md.ComputeHash(Encoding.UTF8.GetBytes(passcode));
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

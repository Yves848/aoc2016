using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string passcode = "";
MD5 md = MD5.Create();
Dictionary<char, (int x, int y)> directions = new Dictionary<char, (int x, int y)> {
  {'U',(0,-1)},
  {'D',(0,1)},
  {'L',(-1,0)},
  {'R',(1,0)}
};

HashSet<string> paths = [];

int w = 4;
int h = 4;

(int x, int y) start = (0, 0);

if (args.Length > 0)
{
  passcode = "rrrbmfta";
}
else
{
  passcode = "ihgpwlah";
}

void findWay((int x, int y) pos, string hash, string path)
{
  byte[] hashcode = md.ComputeHash(Encoding.UTF8.GetBytes(hash));
  string newhash = BitConverter.ToString(hashcode).ToLower().Replace("-", "").Substring(0, 4);
  var possibles = getDirs(newhash).ToList();
  int i = 0;
  (int x, int y) = pos;
  while (i < possibles.Count)
  {
    (int dx, int dy) = possibles[i].Value;
    if (x + dx >= 0 && x + dx < w && y + dy >= 0 && y + dy < h)
    {
      if (x + dx == 3 && y + dy == 3)
      {
        paths.Add(path+ possibles[i].Key);
        return;
      }
      Console.WriteLine($"hash{possibles[i]}");
      findWay((x + dx, y + dy), hash + possibles[i].Key,path+possibles[i].Key);
    }
    i++;
  }
  return;
}

Dictionary<char, (int x, int y)> getDirs(string hash)
{
  Dictionary<char, (int x, int y)> dirs = [];
  char[] d = ['U', 'D', 'L', 'R'];
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
          dirs.Add(d[i], directions[d[i]]);
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
  int ans = int.MaxValue;
  findWay((0, 0), passcode,"");
  string shortest = "";
  int longest = int.MinValue;
  paths.ToList().ForEach(path => { 
    if (path.Length < ans) {
      ans = path.Length;
      shortest = path;
    }
    if (path.Length > longest) {
      longest = path.Length;
    }
  });
    Console.WriteLine(shortest); 
  Console.WriteLine($"Part 2 - Answer : {longest}");
}

void part2()
{
  int ans = 0;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

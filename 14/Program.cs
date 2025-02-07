using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;


string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string salt = args.Length > 0 ? "cuanljph" : "abc";
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

Dictionary<int, string> hashes = [];
HashSet<string> keys = [];
HashSet<int> seen = [];
Regex re = new(@"(.{1})\1\1");
void part1()
{
  int ans = 0;
  int i = 0;
  int savei = -1;
  string car = "";
  while (seen.Count < 64)
  {
    string newhash = "";
    if (hashes.ContainsKey(i))
    {
      newhash = hashes[i];
    }
    else
    {
      MD5 hash = MD5.Create();
      byte[] hashbytes = hash.ComputeHash(Encoding.UTF8.GetBytes(salt + i.ToString()));
      newhash = BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
      hashes.Add(i, newhash);
    }
    if (savei == -1)
    {
      var m = re.Match(newhash);
      if (m.Success)
      {
        if (!seen.Contains(i))
        {
          // Console.Clear();
          // Console.WriteLine($"index = {i}");
          car = m.Groups[1].Value.PadLeft(5, m.Groups[1].Value[0]);
          savei = i;
        }
      }
    }
    else
    {
      if (newhash.Contains(car))
      {
        // Console.WriteLine($"key found : {newhash} ({keys.Count})");
        keys.Add(newhash);
        seen.Add(savei);
        i = savei;
        savei = -1;
      }
      if (i - savei > 1000)
      {
        i = savei;
        savei = -1;
      }
    }
    i++;
  }
  ans = seen.Last();
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  hashes.Clear();
  seen.Clear();
  int ans = 0;
  int i = 0;
  int savei = -1;
  string car = "";
  while (seen.Count < 64)
  {
    string newhash = "";
    if (hashes.ContainsKey(i))
    {
      newhash = hashes[i];
    }
    else
    {
      MD5 hash = MD5.Create();
      byte[] hashbytes = hash.ComputeHash(Encoding.UTF8.GetBytes(salt + i.ToString()));
      newhash = BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
      for (int x = 0; x < 2016; x++){
        hashbytes = hash.ComputeHash(Encoding.UTF8.GetBytes(newhash));
        newhash = BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
      }
      hashes.Add(i, newhash);
    }
    if (savei == -1)
    {
      var m = re.Match(newhash);
      if (m.Success)
      {
        if (!seen.Contains(i))
        {
          // Console.Clear();
          // Console.WriteLine($"index = {i}");
          car = m.Groups[1].Value.PadLeft(5, m.Groups[1].Value[0]);
          savei = i;
        }
      }
    }
    else
    {
      if (newhash.Contains(car))
      {
        // Console.WriteLine($"key found : {newhash} ({keys.Count})");
        keys.Add(newhash);
        seen.Add(savei);
        i = savei;
        savei = -1;
      }
      if (i - savei > 1000)
      {
        i = savei;
        savei = -1;
      }
    }
    i++;
  }
  ans = seen.Last();
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

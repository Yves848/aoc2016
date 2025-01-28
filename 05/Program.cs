using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string puzzle = args.Length > 0 ? File.ReadAllText(args[0]) : File.ReadAllText($"{home}/git/aoc2016/05/test.txt");
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

string GenerateMD5Hash(string input)
{
  using (MD5 md5 = MD5.Create())
  {
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    byte[] hashBytes = md5.ComputeHash(inputBytes);
    StringBuilder sb = new StringBuilder();
    foreach (byte b in hashBytes)
    {
      sb.Append(b.ToString("x2"));
    }

    return sb.ToString();
  }
}

void part1()
{
  int i = 1;
  string password = "";
  while (password.Length < 8)
  {
    string md5 = GenerateMD5Hash(puzzle + i.ToString());
    if (md5.StartsWith("00000"))
    {
      password += md5.Substring(5, 1);
    }
    i++;
  }
  Console.WriteLine($"Part 1 - Answer : {password}");
}

void part2()
{
  int i = 1;
  string password = "        ";
  HashSet<int> seen = [];
  while (seen.Count < 8)
  {
    string md5 = GenerateMD5Hash(puzzle + i.ToString());
    if (md5.StartsWith("00000"))
    {
      int position = 0;
      if (int.TryParse(md5.Substring(5, 1),out position))
      if (position >= 0 && position < 8)
      {
        if (!seen.Contains(position))
        {
          seen.Add(position);
          string c = md5.Substring(6, 1).ToString();
          password = password.Remove(position,1).Insert(position,c);
        }
      }
    }
    i++;
  }
  Console.WriteLine($"Part 2 - Answer : {password}");
}

part1();

part2();

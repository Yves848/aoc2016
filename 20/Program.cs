using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/20/data.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";

List<(uint min, uint max)> bornes = [];

Regex re = new(@"\d+");

void part1()
{
    uint ans = 0;
    file.ForEach(line =>
    {
        var m = re.Matches(line);
        uint b1 = uint.Parse(m[0].Value);
        uint b2 = uint.Parse(m[1].Value);
        bornes.Add((b1, b2));
    });
    bornes.Sort();
    int i = 0;
    while (i < bornes.Count - 1)
    {
        var (min, max) = bornes[i];
        if (ans >= min && ans <= max)
        {
            i++;
            ans = max + 1;
            // if (i == bornes.Count) break;
            continue;
        }
        i++;
    }
    Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
    uint ans = 0;
    bornes.ForEach(b =>
    {
        Console.WriteLine($"{b.min}-{b.max}");
    });
    int i = 0;
    uint nb = 0;
    var (min, max) = bornes[i];
    while (i < bornes.Count - 1)
    {
        i++;
        var (m1, m2) = bornes[i];
        if (m1 > max && m2 > min)
        {
            nb += m1 - max;
            min = m1;
            max = m2;

        }
    }
    if (max < uint.MaxValue)
    {
        nb += uint.MaxValue - max;
    }
    Console.WriteLine($"Part 2 - Answer : {nb}");
}

part1();

part2();

﻿using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Reflection.Metadata.Ecma335;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
int puzzle = args.Length > 0 ? 1358 : 10;
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
List<(int dx, int dy)> dirs = new List<(int dx, int dy)> {
  (0,-1), // up
  (-1,0), //Left
  (1,0), // right
  (0,1)  // Down
};

List<List<(int x, int y)>> ways = [];
HashSet<(int x, int y)> seen = [];

Dictionary<(int x, int y), int> grid = [];
puzzle = 10;
int h = 7;
int w = 10;
bool isWall(int x, int y)
{
    bool result = false;
    int rep = (x * x) + (3 * x) + (2 * x * y) + y + (y * y) + puzzle;
    string s = Convert.ToString(rep, 2);
    result = s.ToList().Sum(c => c == '1' ? 1 : 0) % 2 == 1;
    return result;

}

void printGrid()
{
    Console.CursorVisible = false;
    Console.ForegroundColor = ConsoleColor.White;
    for (int y = 0; y < h; y++)
    {
        for (int x = 0; x < w; x++)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(grid[(x, y)] == 1 ? "#" : ".");
        }
    }
    Console.CursorVisible = true;
}

void printWay(List<(int x, int y)> ways)
{
    Console.CursorVisible = false;
    ways.ToList().ForEach(way =>
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(way.x + 1, way.y + 1);
        Console.Write('O');
    });
    Console.ForegroundColor = ConsoleColor.White;
    Console.CursorVisible = true;
}

List<(int x,int y)> parse(List<(int x, int y)> route)
{
    var (x, y) = route.Last();
    int d = 0;
    bool possible = false;
    while (d < dirs.Count)
    {
        var (dx, dy) = dirs[d];
        while (!route.Contains((x + dx, y + dy)) && x + dx >= 0 && x + dx < w && y + dy >= 0 && y + dy < h && grid[(x + dx, y + dy)] != 1)
        {
            //x += dx;
            //y += dy;
            possible = true;
            route.Add((x + dx, y + dy));
            parse([..route]);
        }
        d++;
    }
    Console.WriteLine(possible);
    return route.ToList();
}


void part1()
{
    Console.Clear();
    (int x, int y) start = (1, 1);
    int ans = 0;
    for (int y = 0; y < h; y++)
    {
        for (int x = 0; x < w; x++)
        {
            grid.Add((x, y), isWall(x, y) ? 1 : 0);
        }
    }
    printGrid();

    List<(int x, int y)> way = [start];
    parse([..way]);
    Console.WriteLine();
    ans = ways.Count;
    Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
    int ans = 0;
    Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
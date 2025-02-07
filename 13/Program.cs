using System.Text.RegularExpressions;
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
Dictionary<(int x, int y), int> grid2 = [];
HashSet<(int, int)> visited = new HashSet<(int, int)>();
puzzle = 1358;
int h = 45;
int w = 45;
(int x, int y) dest = (31, 39);
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
            Console.Write(grid2[(x, y)] == 1 ? "#" : ".");
        }
    }
    Console.CursorVisible = true;
}

void printWay(List<(int x, int y)> pways)
{
    Console.CursorVisible = false;
    pways.ToList().ForEach(way =>
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(way.x + 1, way.y + 1);
        Console.Write('O');
        Thread.Sleep(10);
    });
    Console.ForegroundColor = ConsoleColor.White;
    Thread.Sleep(100);
    Console.CursorVisible = true;
}

void parse((int x, int y) coord, Stack<(int x, int y)> stack)
{
    (int x, int y) = coord;
    if (x < 0 || x > w - 1 || y < 0 || y > h - 1 || grid[(x, y)] == 1) return;

    if (coord == dest)
    {
        stack.Push(coord);
        ways.Add([.. stack.ToList()]);
        //printGrid();
        //printWay(ways.Last());
        stack.Pop();
        return;
    }

    var temp = grid[(x, y)];
    grid[(x, y)] = 1;
    stack.Push(coord);
    if (stack.Count <= 51) visited.Add(coord);

    foreach (var dir in dirs.ToList())
    {
        var (dx, dy) = dir;
        parse((x + dx, y + dy), stack);
    }

    grid[(x, y)] = temp;
    stack.Pop();
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
            grid2.Add((x, y), isWall(x, y) ? 1 : 0);
        }
    }
    //printGrid();

    Stack<(int x, int y)> Q = [];

    //Q.Push(start);
    parse(start, Q);
    //ways.Sort();
    ans = int.MaxValue;
    
    foreach (var item in ways.ToList())
    {
        if (item.Count - 1 < ans)
        {
            ans = item.Count - 1;
        }
    }
    Console.SetCursorPosition(0, Console.BufferHeight - 4);
    Console.WriteLine($"Part 1 - Answer : {ans}");
    ans = visited.Count;
    Console.WriteLine($"Part 2 - Answer : {ans}");
}

void part2()
{
    int ans = 0;
    Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
List<string> file = args.Length > 0 ? File.ReadAllLines(args[0]).ToList() : File.ReadAllLines($"{home}/git/aoc2016/15/test.txt").ToList();
var lf = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "\r\n" : "\n";
Regex re = new(@"\d+");

List<Disk> Disks = [];

file.ForEach(line =>
{
  var m = re.Matches(line);
  Disks.Add(new Disk(int.Parse(m[1].Value), int.Parse(m[3].Value)));
});

void part1()
{
  int ans = 0;
  int time = 1;
  bool capsule = false;
  while (!capsule)
  {
    List<Disk> temp = new List<Disk>(Disks);
    // button pressed
    int pressed = time;
    capsule = true;
    // Console.WriteLine($"Time : {pressed}");
    for(int i = 0; i < temp.Count;i++){
      int position = Disks[i].Position;
      int positions = Disks[i].Positions;
      int res = (((i+1)+pressed)+position) % positions;
      if (res != 0) {
        capsule = false;
        time++;
        break;
      }
    }
    // Console.ReadKey();
  }
  ans = time;
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  int time = 1;
  bool capsule = false;
  Disks.Add(new Disk(11,0));
  while (!capsule)
  {
    List<Disk> temp = new List<Disk>(Disks);
    // button pressed
    int pressed = time;
    capsule = true;
    // Console.WriteLine($"Time : {pressed}");
    for(int i = 0; i < temp.Count;i++){
      int position = Disks[i].Position;
      int positions = Disks[i].Positions;
      int res = (((i+1)+pressed)+position) % positions;
      if (res != 0) {
        capsule = false;
        time++;
        break;
      }
    }
    // Console.ReadKey();
  }
  ans = time;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

class Disk
{
  public int Positions;
  public int Position { get; set; }

  public Disk(int positions, int position)
  {
    this.Positions = positions;
    this.Position = position;
  }

  public void Tick(int nb = 1)
  {
    this.Position += nb;
    if (this.Position >= this.Positions) this.Position = this.Position % this.Positions;
  }
}
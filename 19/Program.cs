using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
int size = 0;
if (args.Length > 0)
{
  size = 3001330;
}
else
{
  size = 5;
}

void part1()
{
  int ans = 0;
  (int index, int nb)[] puzzle = new (int, int)[size];
  for (int i = 0; i < size; i++)
  {
    puzzle[i] = (i + 1, 1);
  }
  while (puzzle.Length > 1)
  {
    int i = 0;
    int i2;
    while (i < puzzle.Length)
    {
      if (puzzle[i].nb != 0)
      {
        i2 = (i == puzzle.Length - 1) ? 0 : i + 1;
        puzzle[i].nb += puzzle[i2].nb;
        puzzle[i2].nb = 0;
      }
      i++;
    }
    puzzle = [.. puzzle.Where(i => i.nb != 0)];
  }
  ans = puzzle[0].index;
  Console.WriteLine($"Part 1 - Answer : {ans}");
}

void part2()
{
  int ans = 0;
  (int index, int nb)[] puzzle = new (int, int)[size];
  for (int i = 0; i < size; i++)
  {
    puzzle[i] = (i + 1, 1);
  }
  int index = 0;
  while (puzzle.Length > 1)
  {
    int i2;
    if (puzzle.Length % 2 == 0)
    {
      // nombre pair
      if (index > puzzle.Length)
      {
        i2 = (int)Math.Floor(Convert.ToDouble(puzzle.Length) / 2)+index;
      }
      else
      {
        i2 = (puzzle.Length / 2) + index;
      }
    }
    else
    {
      // nombre impair
      if (index >= puzzle.Length)
      {
        i2 = puzzle.Length % puzzle.Length / 2;
      }
      else
      {
        i2 = (int)Math.Floor(Convert.ToDouble(puzzle.Length) / 2)+index;
        if (i2 >= puzzle.Length) i2 = i2 % puzzle.Length;
      }
    }
    puzzle[index].nb += puzzle[i2].nb;
    puzzle[i2].nb = 0;
    index++;
    puzzle = [.. puzzle.Where(i => i.nb != 0)];
    if (index > puzzle.Length) index = 0;
  }
  ans = puzzle[0].index;
  Console.WriteLine($"Part 2 - Answer : {ans}");
}

part1();

part2();

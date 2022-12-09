using System.Diagnostics.Metrics;
using System.Reflection;

string assemblyPath = Assembly.GetExecutingAssembly().Location;
string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
#if DEBUG
string textPath = Path.Combine(assemblyDirectory, "input.debug.txt");
#else
string textPath = Path.Combine(assemblyDirectory, "input.txt");
#endif

char[] input = File.ReadAllText(textPath).ToCharArray();

// Part 1

Dictionary<(int x, int y), int> visitedHouses = new Dictionary<(int x, int y), int>();

int x = 0;
int y = 0;

if (visitedHouses.ContainsKey((x, y))) visitedHouses[(x, y)]++;
else visitedHouses[(x, y)] = 1;

foreach (char c in input)
{
    if (c == '^') y++;
    if (c == 'v') y--;
    if (c == '>') x++;
    if (c == '<') x--;

    if (visitedHouses.ContainsKey((x, y))) visitedHouses[(x, y)]++;
    else visitedHouses[(x, y)] = 1;
}

Console.WriteLine($"Teil 1: {visitedHouses.Count}");

visitedHouses.Clear();

int xSanta = 0;
int ySanta = 0;
int xRobo = 0;
int yRobo = 0;

visitedHouses[(xSanta, ySanta)] = 2;

for (int i = 0; i < input.Length; i++)
{
    char c = input[i];

    if (c == '^')
    {
        if (i % 2 == 0) ySanta++;
        else yRobo++;
    }
    if (c == 'v')
    {
        if (i % 2 == 0) ySanta--;
        else yRobo--;
    }
    if (c == '>')
    {
        if (i % 2 == 0) xSanta++;
        else xRobo++;
    }
    if (c == '<')
    {
        if (i % 2 == 0) xSanta--;
        else xRobo--;
    }

    if (i % 2 == 0)
    {
        if (visitedHouses.ContainsKey((xSanta, ySanta))) visitedHouses[(xSanta, ySanta)]++;
        else visitedHouses[(xSanta, ySanta)] = 1;
    }
    else
    {
        if (visitedHouses.ContainsKey((xRobo, yRobo))) visitedHouses[(xRobo, yRobo)]++;
        else visitedHouses[(xRobo, yRobo)] = 1;
    }

}

Console.WriteLine($"Teil 2: {visitedHouses.Count}");
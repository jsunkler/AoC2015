using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.RegularExpressions;

string assemblyPath = Assembly.GetExecutingAssembly().Location;
string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
#if DEBUG
string textPath = Path.Combine(assemblyDirectory, "input.debug.txt");
#else
string textPath = Path.Combine(assemblyDirectory, "input.txt");
#endif

string[] input = File.ReadAllLines(textPath);

// Part 1

int counter = 0;

foreach (string line in input)
{
    var match = Regex.Match(line, @"^(\d+)x(\d+)x(\d+)$");
    int x = int.Parse(match.Groups[1].Value);
    int y = int.Parse(match.Groups[2].Value);
    int z = int.Parse(match.Groups[3].Value);

    counter += 2 * x * y + 2 * x * z + 2 * y * z + (new[] { x * y, x * z, y * z }.Min());
}

Console.WriteLine($"Teil 1: {counter}");

// Part 2

counter = 0;

foreach (string line in input)
{
    var match = Regex.Match(line, @"^(\d+)x(\d+)x(\d+)$");
    int x = int.Parse(match.Groups[1].Value);
    int y = int.Parse(match.Groups[2].Value);
    int z = int.Parse(match.Groups[3].Value);

    var arr = new[] { x, y, z }.Order();

    counter += 2 * arr.First() + 2 * arr.Skip(1).First() + x * y * z;
}

Console.WriteLine($"Teil 2: {counter}");
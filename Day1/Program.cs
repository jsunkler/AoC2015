using System.Diagnostics.Metrics;
using System.Reflection;

string assemblyPath = Assembly.GetExecutingAssembly().Location;
string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
#if DEBUG
string textPath = Path.Combine(assemblyDirectory, "input.debug.txt");
#else
string textPath = Path.Combine(assemblyDirectory, "input.txt");
#endif

string input = File.ReadAllText(textPath);

// Part 1

int counter = 0;

foreach (char c in input)
{
    if (c == '(') counter++;
    if (c == ')') counter--;

}

Console.WriteLine($"Teil 1: {counter}");

// Part 2
counter = 0;

for (int i = 1; i <= input.Length; i++)
{
    char c = input[i-1];

    if (c == '(') counter++;
    if (c == ')')
    {
        counter--;
        if (counter < 0)
        {
            Console.WriteLine($"Teil 2: {i}");
            break;
        }
    }
}
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

string assemblyPath = Assembly.GetExecutingAssembly().Location;
string assemblyDirectory = Path.GetDirectoryName(assemblyPath);
#if DEBUG
string textPath = Path.Combine(assemblyDirectory, "input.debug.txt");
#else
string textPath = Path.Combine(assemblyDirectory, "input.txt");
#endif

string input = File.ReadAllText(textPath);

// Part 1
var crypt = System.Security.Cryptography.MD5.Create();

int counter = 1;

while (true)
{
    var bytes = ASCIIEncoding.ASCII.GetBytes(input + counter.ToString());
    byte[] hash = crypt.ComputeHash(bytes);
    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16) break;
    counter++;
}

Console.WriteLine($"Teil 1: {counter}");

counter = 1;

while (true)
{
    var bytes = ASCIIEncoding.ASCII.GetBytes(input + counter.ToString());
    byte[] hash = crypt.ComputeHash(bytes);
    if (hash[0] == 0 && hash[1] == 0 && hash[2] == 0) break;
    counter++;
}

Console.WriteLine($"Teil 2: {counter}");
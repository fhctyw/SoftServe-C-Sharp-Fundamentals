using System.Text.RegularExpressions;
using static _08_Abstract.Program;

namespace _09_LINQ
{
    internal static class Program
    {
        static string PathProject => Path.Combine(Environment.CurrentDirectory, "..", "..", "..");
        static void Main()
        {
            // Practice
            int[] ints = { 1, 2, -3, 111, -3, 6, 0, -8, 9, 10 };
            Console.WriteLine($"Numbers = {{ {string.Join(", ", ints)} }}");
            Console.WriteLine($"Negative numbers = {{ {string.Join(", ", ints.Where(i => i < 0))} }}");
            Console.WriteLine($"Positive numbers = {{ {string.Join(", ", ints.Where(i => i > 0))} }}");
            Console.WriteLine($"Max = {ints.Max()}");
            Console.WriteLine($"Min = {ints.Min()}");
            Console.WriteLine($"Sum = {ints.Sum()}");
            double avg = ints.Average();
            Console.WriteLine($"First largest number that > Average({avg}) = {ints.Where(i => i < avg).Max()}");
            Console.WriteLine($"Sorted by OrderBy = {{ {string.Join(", ", ints.OrderBy(i => i))} }}");

            // A
            // Task 1
            List <Shape> shapes = new()
            {
                new Circle(4.3),
                new Circle(2),
                new Square(4.6),
                new Circle(10.44),
                new Square(5),
                new Square(44.31)
            };

            // Task 2
            File.WriteAllText(Path.Combine(PathProject, "shapes-range.txt"), string.Join("\n", shapes.Where(s =>
            {
                var area = s.Area();
                return area >= 10 && area <= 100;
            })));

            // Task 3
            File.WriteAllText(Path.Combine(PathProject, "shapes-letter.txt"), string.Join("\n", shapes.Where(s => s.Name.Contains('a'))));

            // Task 4
            shapes.Where(s => s.Perimeter() <= 5).ToList().ForEach(s => Console.WriteLine(s));
            
            // B
            string[] lines = File.ReadAllLines(Path.Combine(PathProject, "..", "07_Files", "Program.cs"));

            // Task 1
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine($"line {i + 1} = {lines[i].Length}");
            }

            // Task 2
            Console.WriteLine($"Longest line = {lines.Max(s => s.Length)}");
            Console.WriteLine($"Shortest line = {lines.Min(s => s.Length)}");

            // Task 3
            Regex regex = new(@"\bvar\b");
            foreach (var line in lines.Where(s => regex.IsMatch(s)))
            {
                Console.WriteLine(line.Trim());
            }
        }
    }
}
class Program
{
    private static void Main(string[] args)
    {
        // Practice 1
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine($"Count intergers in range[{a}..{b}] divided by 3 without reminder = {CountWithoutReminderBy(a, b, 3)}");

        // Practice 3
        Console.Write("Enter some text: ");
        string text = Console.ReadLine();
        text?.Where((c, i) => i % 2 == 0).ToList().ForEach(c => Console.Write(c));
        Console.WriteLine();

        // Practice 4
        Console.Write("Enter arr(1, 2, 3, 4...n): ");
        int[] numbers = Console.ReadLine().Split(", ").Select(n => int.Parse(n)).ToArray();
        Console.WriteLine($"Average numbers to first negative number = {CalculateAverageToNegative(numbers)}");

        // Practice 5
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine($"{year} is{(year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) ? "" : " not")} leap year");

        // Practice 6
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Sum of number digits = {DigitSum(number)}");

        // Practice 7
        Console.Write("Enter number: ");
        number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Each digits are odd = {IsOnlyOddDigit(number)}");

        // Task 1
        Console.Write("Enter string: ");
        text = Console.ReadLine();
        string searchedChars = "aoie";
        Console.WriteLine($"Count of {searchedChars} symbols = {CountCharacter(text, searchedChars)}");

        // Task 2
        Console.Write("Enter the number of month: ");
        int month = int.Parse(Console.ReadLine());
        Console.WriteLine(month >= 1 && month <= 12 ? $"{DateTime.DaysInMonth(DateTime.Now.Year, month)} days" : "Incorrect number month");

        // Task 3
        Console.Write("Enter 10 numbers(1, 3, -4, 0...n): ");
        numbers = Console.ReadLine().Split(", ").Select(n => int.Parse(n)).ToArray();
        if (numbers.Length == 10)
        {
            Console.WriteLine(numbers.All(n => n >= 0)
                ? numbers.Where((n, i) => i < 5).Sum()
                : numbers.Where((n, i) => i >= 5).Aggregate(1, (acc, v) => acc * v));
        }
        else
        {
            Console.WriteLine("Incorrect numbers count");
        }
    }

    private static int CountWithoutReminderBy(int a, int b, int reminder)
    {
        return Enumerable.Range(a, b - a + 1).Where(i => i % reminder == 0).Count();
    }

    private static double CalculateAverageToNegative(int[] arr)
    {
        return arr.TakeWhile(i => i > 0).Average();
    }
    private static int DigitSum(int number)
    {
        number = Math.Abs(number);
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }
    private static bool IsOnlyOddDigit(int number)
    {
        number = Math.Abs(number);
        while (number > 0)
        {
            if ((number % 10) % 2 == 0)
                return false;
            number /= 10;
        }
        return true;
    }
    private static int CountCharacter(string text, string searchedChars)
    {
        return text.Count(c => searchedChars.Contains(c));
    }
}
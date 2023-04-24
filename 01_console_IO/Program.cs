using System.Globalization;
Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

// Task 1
double a;

Console.Write("Enter side of square: ");
bool isSideSquareParsed = double.TryParse(Console.ReadLine(), out a);

if (isSideSquareParsed && a > 0)
{
    Console.WriteLine($"Your length of the side of the square = {a}");
    Console.WriteLine($"Square area = {a * a}");
    Console.WriteLine($"Square perimeter = {4 * a}");
}
else if (isSideSquareParsed && a <= 0)
{
    Console.WriteLine("Your length cannot be less or equal zero");
}
else
{
    Console.WriteLine("You entered wrong number");
}

// Task 2
string? name;
int age;
Console.WriteLine("What is you name?");
name = Console.ReadLine();
Console.WriteLine("How old are you?");
bool isAgeParsed = int.TryParse(Console.ReadLine(), out age);
if (isAgeParsed && name != null && age >= 0)
{
    Console.WriteLine($"Hello {name}, you are {age}");
}
else
{
    Console.WriteLine("Incorrect age or name");
}

// Task 3
double r;
Console.Write("Enter circle radius: ");
bool isRadiusParsed = double.TryParse(Console.ReadLine(), out r);
if (isRadiusParsed && r > 0)
{
    Console.WriteLine($"Your radius = {r}");
    Console.WriteLine($"Circle length = {2.0 * Math.PI * r}");
    Console.WriteLine($"Circle area = {Math.PI * r * r}");
    Console.WriteLine($"Circle volume = {4.0 / 3.0 * Math.PI * r * r * r}");
}
else
{
    Console.WriteLine("Incorrect length, cannot be less than zero");
}
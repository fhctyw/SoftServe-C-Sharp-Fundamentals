using System.Drawing;
using System.Globalization;

namespace _04_Classes;
public static class Program
{
    // Practice 1
    [Serializable]
    public class Car
    {
        public const string CompanyName = "Toyota";
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public Car(string name, Color color, decimal price)
        {
            Name = name;
            Color = color;
            Price = price;
        }
        public Car()
        {

        }
        public void Input()
        {
            Console.Write("Enter car name: ");
            Name = Console.ReadLine();
            Console.Write("Enter car color(argb, hex format): ");
            string? numberColor = Console.ReadLine();
            Color = numberColor == null ? Color.White : Color.FromArgb(int.Parse(numberColor, NumberStyles.HexNumber));
            Console.Write("Enter price: ");
            Price = decimal.Parse(Console.ReadLine() ?? "10000");
        }
        public void Print()
        {
            Console.WriteLine($"Company Name = {CompanyName}");
            Console.WriteLine($"Car name: {Name}");
            Console.WriteLine($"Car color: {Color.Name}, #{Color.ToArgb():X}");
            Console.WriteLine($"Car price: {Price:N0}$");
        }
        public void ChangePrice(double x)
        {
            Price *= 1 + (decimal)x / 100;
        }
        public override bool Equals(object? obj) => obj is Car car
                                                    && Name == car.Name
                                                    && Price == car.Price
                                                    && Color.Equals(car.Color);
        public override int GetHashCode() => HashCode.Combine(Name, Price, Color);
        // Practice 5
        public static bool operator ==(Car left, Car right) => left.Equals(right);
        public static bool operator !=(Car left, Car right) => !(left == right);
        // Practice 6
        public override string? ToString() => $"{Name}, {Color.Name}, {Price:N0}$";
    }

    public class Person
    {
        private string? name;
        private DateTime birthYear;
        public string? Name => name;
        public DateTime BirthDate => birthYear;
        public Person(string name, DateTime birthYear)
        {
            this.name = name;
            this.birthYear = birthYear;
        }
        public Person()
        {
            name = string.Empty;
            birthYear = DateTime.MinValue;
        }
        public TimeSpan Age() => DateTime.Now - birthYear;
        public void ChangeName(string? name) => this.name = name ?? string.Empty;
        public void Input()
        {
            Console.Write("Enter person name: ");
            name = Console.ReadLine();
            Console.Write($"Enter {name}(format: {DateTime.MaxValue.ToString()}) date: ");
            birthYear = DateTime.Parse(Console.ReadLine() ?? DateTime.MinValue.ToString());
        }
        public void Output() => Console.WriteLine(ToString());
        public static bool operator ==(Person left, Person right) => left.Name == right.Name;
        public static bool operator !=(Person left, Person right) => !(left == right);
        public override bool Equals(object? obj) => obj is Person person
                                                    && name == person.name
                                                    && birthYear == person.birthYear;
        public override string? ToString() => $"{Name}, {BirthDate.ToShortDateString()} ({(int)Age().TotalDays / 365} years)";
        public override int GetHashCode() => HashCode.Combine(name, birthYear);
    }
    private static List<Person> GetPersonsWithSameName(Person[] persons)
    {
        List<Person> repeatedPersons = new List<Person>();
        for (int i = 0; i < persons.Length; i++)
        {
            for (int j = 0; j < persons.Length; j++)
            {
                if (i != j && persons[i] == persons[j] && !repeatedPersons.Contains(persons[i]))
                {
                    repeatedPersons.Add(persons[i]);
                }
            }
        }
        return repeatedPersons;
    }
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        // Practice 2 
        Car firstCar = new Car("Yaris", Color.BlueViolet, 16000M);
        Car secondCar = new Car("Supra", Color.White, 43000M);
        Car thirdCar = new Car("Corolla", Color.Silver, 20000M);

        // Practice 3
        firstCar.Print();
        firstCar.ChangePrice(-10);
        firstCar.Print();

        // Practice 4
        Console.Write($"Enter new color for ({secondCar}) car: ");
        string? newColor = Console.ReadLine();
        secondCar.Color = Color.FromName(newColor ?? "black");
        secondCar.Print();

        // Task 1
        Person[] persons =
        {
            new Person("Eva", new DateTime(2007, 1, 1, 0, 0, 0)),
            new Person("Bella", new DateTime(1995, 6, 12, 0, 0, 0)),
            new Person("Bella", new DateTime(1988, 9, 30, 0, 0, 0)),
            new Person("Danielle", new DateTime(2003, 10, 17, 0, 0, 0)),
            new Person("Eva", new DateTime(1990, 8, 24, 0, 0, 0)),
            new Person("Frank", new DateTime(2009, 12, 10, 0, 0, 0)),
        };

        // Task 2
        foreach (Person person in persons)
        {
            person.Output();
        }
        Console.WriteLine();

        // Task 3
        for (int i = 0; i < persons.Length; i++)
        {
            if (persons[i].Age() < new TimeSpan(16 * 365, 0, 0, 0))
            {
                persons[i].ChangeName("Very Young");
            }
        }

        // Task 4
        foreach (Person person in persons)
        {
            person.Output();
        }
        Console.WriteLine();

        // Task 5
        foreach (Person person in GetPersonsWithSameName(persons))
        {
            person.Output();
        }
    }
}
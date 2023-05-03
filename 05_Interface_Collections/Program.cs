using System.Collections;
using System.Globalization;

internal class Program
{
    // Practice 1
    interface IFlable
    {
        void Fly();
    }

    // Practice 2
    class Bird : IFlable
    {
        string name;
        bool canFly;

        public Bird(string name, bool canFly)
        {
            this.name = name;
            this.canFly = canFly;
        }

        public void Fly()
        {
            if (canFly)
            {
                Console.WriteLine($"Bird {name} is flying");
            }
        }
    }
    // Practice 2
    class Plane : IFlable
    {
        string mark;
        int highFly;

        public Plane(string mark, int highFly)
        {
            this.mark = mark;
            this.highFly = highFly;
        }

        public void Fly()
        {
            if (highFly > 0)
            {
                Console.WriteLine($"Place {mark} is flying on {highFly}m over the ground");
            }
        }
    }
    // Task 1
    interface IDeveloper : IComparable
    {
        public object Tool { get; set; }
        public void Create();
        public void Destory();
    }
    // Task 2
    class Programmer : IDeveloper
    {
        private string language;
        public object Tool { get => language; set => _ = language; }

        public Programmer(string language)
        {
            this.language = language;
        }

        public void Create()
        {
            Console.WriteLine($"Programmer write program in {language} language");
        }

        public void Destory()
        {
            Console.WriteLine($"Programmer remove program");
        }

        public int CompareTo(object? obj)
        {
            return string.Compare(Tool.ToString(), obj != null ? ((IDeveloper)obj).Tool.ToString() : string.Empty);
        }

        public override string? ToString()
        {
            return $"Programmer with {Tool}";
        }
    }
    // Task 2
    class Builder : IDeveloper
    {
        private string tool;
        public object Tool { get => tool; set => _ = tool; }

        public Builder(string tool)
        {
            this.tool = tool;
        }

        public void Create()
        {
            Console.WriteLine($"Builder built the building using {tool}");
        }

        public void Destory()
        {
            Console.WriteLine($"Builder destory the building");
        }
        public int CompareTo(object? obj)
        {
            return string.Compare(Tool.ToString(), obj != null ? ((IDeveloper)obj).Tool.ToString() : string.Empty);
        }
        public override string? ToString()
        {
            return $"Builder with {Tool}";
        }
    }

    private static void Main(string[] args)
    {
        // Practice 3
        /*List<IFlable> flables = new List<IFlable>
        {
            new Plane ("Boeing 747", 35000),
            new Plane ("Airbus A380", 43000),
            new Bird ("Eagle", true),
            new Bird ("Penguin", false),
            new Plane ("Cessna 172", 13500),
            new Bird ("Sparrow", true),
            new Plane ("Concorde", 60000),
            new Plane ("Boeing 737", 41000),
            new Bird ("Ostrich",false),
            new Bird ("Parrot", true)
        };

        foreach (IFlable flable in flables)
        {
            flable.Fly();
        }

        // Practice 4
        Console.Write("Enter arr(1, 2, 3, 4...n): ");
        List<int> myColl = Console.ReadLine().Split(", ").Select(n => int.Parse(n)).ToList();

        // Practice 5
        string indexs = string.Join(", ", myColl.Select((n, i) => new { value = n, index = i })
            .Where(e => e.value == -10).Select(e => e.index));
        Console.WriteLine($"indexs which nubmer is -10: [{indexs}]");

        // Practice 6
        string numbersGreaterThan20 = string.Join(", ", myColl.Where(n => n <= 20));
        Console.WriteLine($"numbers which are greater than 20: [{numbersGreaterThan20}]");

        // Practice 7
        if (myColl.Count > 8)
        {
            List<int> myCollWithNewValues = new List<int>(myColl);
            myCollWithNewValues[2] = 1;
            myCollWithNewValues[5] = -4;
            myCollWithNewValues[8] = -3;
            string numbersWithNewValues = string.Join(", ", myCollWithNewValues);
            Console.WriteLine($"numbers with new values: [{numbersWithNewValues}]");
        }
        else
        {
            Console.WriteLine("The number must be more than 5");
        }
        // Practice 8
        List<int> myCollSortedNumbers = new List<int>(myColl);
        myCollSortedNumbers.Sort();
        string sortedNumbers = string.Join(", ", myCollSortedNumbers);
        Console.WriteLine($"sorted numbers: [{sortedNumbers}]");*/


        // Task 3
        List<IDeveloper> developers = new List<IDeveloper>()
        {
            new Programmer("C#"),
            new Programmer("Java"),
            new Builder("Hammer"),
            new Builder("Saw"),
            new Programmer("Python"),
            new Programmer("JavaScript"),
            new Builder("Drill"),
            new Builder("Wrench"),
            new Programmer("Ruby"),
            new Builder("Screwdriver")
        };

        foreach (IDeveloper developer in developers)
        {
            developer.Create();
            developer.Destory();
        }
        Console.WriteLine();
        // Task 4
        developers.ForEach(d => Console.WriteLine(d));
        Console.WriteLine();
        developers.Sort();
        developers.ForEach(d => Console.WriteLine(d));

        // Task 5
        Dictionary<uint, string> persons = new Dictionary<uint, string>();
        for (int i = 0; i < 7; i++)
        {
            Console.Write($"Enter {i + 1} person id: ");
            uint tmpId = uint.Parse(Console.ReadLine());
            Console.Write($"Enter {i + 1} person name: ");
            persons[tmpId] = Console.ReadLine();
        }

        // Task 6
        Console.Write($"Enter person id: ");
        uint id = uint.Parse(Console.ReadLine());
        if (persons.ContainsKey(id))
        {
            Console.WriteLine($"Person name with {id}: {persons[id]}");
        }
        else
        {
            Console.WriteLine($"Invalid id, dictionary doesn't contain person with {id}");
        }
    }
}
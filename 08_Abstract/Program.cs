using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace _08_Abstract
{
    internal static class Program
    {
        // Practice 1
        class Person
        {
            protected string name;
            public string Name => name;
            public Person(string name)
            {
                this.name = name;
            }
            public virtual void Print()
            {
                Console.WriteLine($"Name: {Name}");
            }
            public override string ToString() => name;
        }
        class Staff : Person
        {
            private int salary;
            public int Salary => salary;
            public Staff(string name, int salary) : base(name)
            {
                this.salary = salary;
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Salary: {salary}$");
            }
        }
        class Student : Person
        {
            private string groupName;

            public Student(string name, string groupName) : base(name)
            {
                this.groupName = groupName;
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Student of group: {groupName}");
            }
        }
        // Practice 2 
        class Teacher : Staff
        {
            private string subject;

            public Teacher(string name, int salary, string subject) : base(name, salary)
            {
                this.subject = subject;
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Subject: {subject}");
            }
        }
        class Developer : Staff
        {
            private string level;

            public Developer(string name, int salary, string level) : base(name, salary)
            {
                this.level = level;
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"Level: {level}");
            }
        }
        // Practice 4
        static void PrintInforamtionFromPersonsByName(List<Person> persons, string name)
        {
            persons.Find(p => p.Name == name)?.Print();
        }
        // Practice 5
        static void SaveSortedPersons(List<Person> persons, string fileName)
        {
            using StreamWriter streamWriter = new StreamWriter(fileName);
            List<Person> copyPersons = new List<Person>(persons);
            copyPersons.Sort((p1, p2) => string.Compare(p1.Name, p2.Name));
            foreach (Person person in copyPersons)
            {
                streamWriter.WriteLine(person.Name);
            }
        }
        // Practice 6
        static List<Staff> GetEmployeesSortedBySalary(List<Person> persons)
        {
            var employees = persons.Where(p => p != null && (p is Teacher || p is Developer))
                                   .Select(p => (Staff)p).ToList();
            employees.Sort((e1, e2) => e1.Salary.CompareTo(e2.Salary));
            return employees;
        }
        // Task 1
        abstract class Shape : IComparable<Shape>
        {
            public string Name { get; }
            protected Shape(string name)
            {
                Name = name;
            }
            public abstract double Area();
            public abstract double Perimeter();
            public int CompareTo(Shape? other) 
            {
                return Area().CompareTo(other?.Area());
            }
        }
        class Circle : Shape
        {
            private double radius;
            public Circle(double radius) : base("Circle")
            {
                this.radius = radius;
            }
            public override double Area() => Math.PI * radius * radius;
            public override double Perimeter() => 2 * Math.PI * radius;
        }
        class Square : Shape
        {
            private double side;
            public Square(double side) : base("Square")
            {
                this.side = side;
            }
            public override double Area() => side * side;
            public override double Perimeter() => 4 * side;
        }

        static void Main()
        {
            // Practice 3
            List<Person> people = new List<Person>
            {
                new Person("Taras"),
                new Student("Vadim", "KN-22"),
                new Teacher("Jane", 600, "Math"),
                new Developer("Adam", 3300, "Senior"),
                new Developer("Maxim", 1800, "Middle"),
                new Teacher("Andrew", 640, "Computer Science"),
            };

            foreach (Person person in people)
            {
                person.Print();
                Console.WriteLine();
            }

            Console.Write("Enter person's name: ");
            string name = Console.ReadLine();
            PrintInforamtionFromPersonsByName(people, name);

            // Practice 5
            SaveSortedPersons(people, "sorted-persons-name.txt");

            List<Staff> employees = GetEmployeesSortedBySalary(people);
            foreach (Staff employee in employees)
            {
                employee.Print();
                Console.WriteLine();
            }

            // Task 2
            List<Shape> shapes = new List<Shape>();
            Console.Write("Enter if Auto-fill enable: ");
            bool isAutofill = bool.Parse(Console.ReadLine());
            if (isAutofill)
            {
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    if (random.Next(0, 2) == 0)
                    {
                        shapes.Add(new Circle(random.Next(0, 1000) + random.NextDouble()));
                    }
                    else
                    {
                        shapes.Add(new Square(random.Next(0, 1000) + random.NextDouble()));
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (; ; )
                    {
                        Console.Write($"Enter {i + 1} shape name(Circle, Square): ");
                        string nameShape = Console.ReadLine();
                        if (nameShape == "Circle")
                        {
                            Console.Write($"Enter {i + 1} circle radius: ");
                            double radius = double.Parse(Console.ReadLine());
                            if (radius < 0)
                            {
                                continue;
                            }
                            shapes.Add(new Circle(radius));
                            break;
                        }
                        else if (nameShape == "Square")
                        {
                            Console.Write($"Enter {i + 1} square side: ");
                            double side = double.Parse(Console.ReadLine());
                            if (side < 0)
                            {
                                continue;
                            }
                            shapes.Add(new Square(side));
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine($"{"Index",-7}{"Name",-8}{"Area",-12}{"Perimeter",-12}");
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                Console.WriteLine($"{i,-7}" +
                    $"{shape.Name,-8}" +
                    $"{shape.Area(),-12:0.##}" +
                    $"{shape.Perimeter(),-12:0.##}");
            }
            Console.WriteLine();
            // Task 3
            var maxPerimeterShape = shapes.MaxBy(s => s.Perimeter());
            Console.WriteLine($"{maxPerimeterShape.Name,-8}" +
                    $"{maxPerimeterShape.Area(),-12:0.##}" +
                    $"{maxPerimeterShape.Perimeter(),-12:0.##}");
            Console.WriteLine();
            // Task 4
            shapes.Sort();
            Console.WriteLine($"{"Index",-7}{"Name",-8}{"Area",-12}{"Perimeter",-12}");
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape shape = shapes[i];
                Console.WriteLine($"{i,-7}" +
                    $"{shape.Name,-8}" +
                    $"{shape.Area(),-12:0.##}" +
                    $"{shape.Perimeter(),-12:0.##}");
            }
        }
    }
}
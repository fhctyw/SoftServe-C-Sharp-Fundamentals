using _02_Console_TypeSystem;
using System.Globalization;

internal class Program
{
    enum HTTPError
    {
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
    }

    struct Dog
    {
        public string name;
        public int age;
        public int mark;

        public override string? ToString()
        {
            return $"Name: {name}, Age: {age}, Mark: {mark}";
        }
    }
    private static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        // Task 1
        float firstFloatNumber, secondFloatNumber, thirdFloatNumber;
        bool isNumbersParsed;
        Console.Write("Enter first number: ");
        isNumbersParsed = float.TryParse(Console.ReadLine(), out firstFloatNumber);
        Console.Write("Enter second number: ");
        isNumbersParsed &= float.TryParse(Console.ReadLine(), out secondFloatNumber);
        Console.Write("Enter third number: ");
        isNumbersParsed &= float.TryParse(Console.ReadLine(), out thirdFloatNumber);

        if (isNumbersParsed)
        {
            Console.WriteLine($"Numbers({firstFloatNumber}, {secondFloatNumber}, {thirdFloatNumber}) are{(firstFloatNumber >= -5 && firstFloatNumber <= 5 && secondFloatNumber >= -5 && secondFloatNumber <= 5 && thirdFloatNumber >= -5 && thirdFloatNumber <= 5 ? "" : " not")} all the range [-5;5]");
        }
        else
        {
            Console.WriteLine("Incorrect numbers");
        }

        // Task 2
        int firstIntegerNumber, secondIntegerNumber, thirdIntegerNumber;
        Console.Write("Enter first number: ");
        isNumbersParsed = int.TryParse(Console.ReadLine(), out firstIntegerNumber);
        Console.Write("Enter second number: ");
        isNumbersParsed &= int.TryParse(Console.ReadLine(), out secondIntegerNumber);
        Console.Write("Enter third number: ");
        isNumbersParsed &= int.TryParse(Console.ReadLine(), out thirdIntegerNumber);
        if (isNumbersParsed)
        {
            Console.WriteLine($"Max = {Math.Max(Math.Max(firstIntegerNumber, secondIntegerNumber), thirdIntegerNumber)}");
            Console.WriteLine($"Min = {Math.Min(Math.Min(firstIntegerNumber, secondIntegerNumber), thirdIntegerNumber)}");
        }
        else
        {
            Console.WriteLine("Incorrect numbers");
        }

        // Task 3
        HTTPError httpCode;
        Console.Write("Enter HTTP error code: ");
        bool isCodeParsed = Enum.TryParse<HTTPError>(Console.ReadLine(), true, out httpCode);
        if (isCodeParsed && Enum.IsDefined(httpCode))
        {
            Console.WriteLine($"Error: {httpCode}, Code: {(int)httpCode}");
        }
        else if (!Enum.IsDefined(httpCode))
        {
            Console.WriteLine("Unknown code");
        }
        else
        {
            Console.WriteLine("Incorrect number");
        }

        // Task 4

        Dog myDog;
        myDog.name = "Barney";
        myDog.age = 4;
        myDog.mark = 6;
        Console.WriteLine(myDog);

        // Additional Task 1

        Cat cat = new Cat(50);
        cat.Play();
        cat.Play();
        cat.Play();
        cat.Eat(Food.Meat);
        cat.Eat(Food.Feed);
        cat.Eat(Food.Fish);
        cat.Eat(Food.Meat);
        cat.Eat(Food.Mouse);

        // Additional Task 2

        char isEnterStudents;
        Console.Write("Do you want to enter student data yourself?(y/n): ");
        isEnterStudents = char.ToLower(Console.ReadLine()[0]);
        Student[] students;

        if (isEnterStudents == 'y')
        {
            int countStudents;
            Console.Write("Enter student count: ");
            countStudents = int.Parse(Console.ReadLine());

            students = new Student[countStudents];
            for (int i = 0; i < countStudents; i++)
            {
                Console.Write($"Enter {i + 1} student last name: ");
                students[i].lastName = Console.ReadLine();
                Console.Write($"Enter {i + 1} student group number: ");
                students[i].groupNumber = int.Parse(Console.ReadLine());
            }
        }
        else
        {
            students = new Student[]
            {
                new Student() { lastName = "Smith", groupNumber = 1 },
                new Student() { lastName = "Johnson", groupNumber = 2 },
                new Student() { lastName = "Williams", groupNumber = 1 },
                new Student() { lastName = "Jones", groupNumber = 3 },
                new Student() { lastName = "Brown", groupNumber = 2 },
                new Student() { lastName = "Davis", groupNumber = 3 },
                new Student() { lastName = "Miller", groupNumber = 1 },
                new Student() { lastName = "Wilson", groupNumber = 2 },
                new Student() { lastName = "Moore", groupNumber = 3 },
                new Student() { lastName = "Taylor", groupNumber = 1 }
            };
        }

        char firstLetterOfLastName;
        Console.Write("Enter the first letter of the students' name: ");
        firstLetterOfLastName = char.ToLower((char)Console.ReadLine()[0]);
        if (char.IsLetter(firstLetterOfLastName))
        {
            students
                .Select(s => s.lastName)
                .Where(s => s.StartsWith(new string(new char[] { firstLetterOfLastName }), true, null))
                .ToList().ForEach(n => Console.WriteLine(n));
        }
        else
        {
            Console.WriteLine("Incorrect chars");
        }
    }
}


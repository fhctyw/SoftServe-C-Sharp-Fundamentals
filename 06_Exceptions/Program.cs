using System.Runtime.Serialization;

namespace _06_Exceptions
{
    internal class Program
    {
        class OutOfRangeException : Exception
        {
            public OutOfRangeException()
            {
            }

            public OutOfRangeException(string? message) : base(message)
            {
            }

            public OutOfRangeException(string? message, Exception? innerException) : base(message, innerException)
            {
            }

            protected OutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        static void Div(int a, int b)
        {
            // Task 1
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            Console.WriteLine(a / (double)b);
        }
        static List<double> ReadNumbers(int start, int end)
        {
            List<double> numbers = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter {i} number = ");
                double inputNumber = double.Parse(Console.ReadLine());
                if (inputNumber < start || inputNumber > end)
                {
                    throw new OutOfRangeException($"Your number must be [{start};{end}]");
                }
                numbers.Add(inputNumber);
            }
            return numbers;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Enter b = ");
                int b = int.Parse(Console.ReadLine());
                Div(a, b);
            }
            // Task 2
            catch (FormatException)
            {
                Console.WriteLine("Your can't enter double numbers, only integer inputs");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You can't divide by zero");
            }

            try
            {
                Console.Write("Enter start = ");
                int start = int.Parse(Console.ReadLine());
                Console.Write("Enter end = ");
                int end = int.Parse(Console.ReadLine());

                List<double> numbers = ReadNumbers(start, end);
                Console.WriteLine(string.Join(", ", numbers));
            }
            catch (OutOfRangeException outOfRangeException)
            {
                Console.WriteLine($"Out of range. {outOfRangeException.Message}");
            }
        }
    }
}
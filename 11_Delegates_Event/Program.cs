namespace _11_Delegates_Event
{
    internal static class Program
    {
        // Task 1
        public delegate void MyDel(int m);
        // Task 2
        public class Student
        {
            public string Name { get; set; }
            public List<int> Marks { get; set; }
            public bool IsSubscribed { get; private set; }
            public event MyDel? MarkChange;
            public Student(string name, List<int> marks)
            {
                Name = name;
                Marks = marks;
            }
            public void AddMark(int mark)
            {
                Marks.Add(mark);
                MarkChange?.Invoke(mark);
            }
        }
        // Task 3
        public class Parent
        {
            public void OnMarkChange(int mark)
            {
                Console.WriteLine(mark);
            }
        }
        public class Accountancy
        {
            public void PayingFellowship(int mark)
            {
                if (mark == 5 || mark == 4)
                {
                    Console.WriteLine("The student will receive a scholarship.");
                }
                else
                {
                    Console.WriteLine("The student will not receive a scholarship.");
                }
            }
        }

        static void Main()
        {
            // Task 4
            var parent = new Parent();
            var accountancy = new Accountancy();
            var student = new Student("John", new());
            student.MarkChange += parent.OnMarkChange;
            student.MarkChange += accountancy.PayingFellowship;

            student.AddMark(5);
            student.AddMark(5);
            student.AddMark(4);
            student.AddMark(3);
        }
    }
}
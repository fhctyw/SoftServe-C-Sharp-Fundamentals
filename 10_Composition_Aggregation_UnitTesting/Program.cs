namespace _10_Composition_Aggregation_UnitTesting
{
    public class Program
    {
        // Homework
        public struct Point
        {
            public double x, y;

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
            public override string ToString() => $"({x:0.00},{y:0.00})";
        }
        public struct Distances
        {
            public double distance1, distance2, distance3;

            public Distances(double distance1, double distance2, double distance3)
            {
                this.distance1 = distance1;
                this.distance2 = distance2;
                this.distance3 = distance3;
            }
        }

        public class Triangle
        {
            public Point vertex1, vertex2, vertex3;

            public Triangle(Point vertex1, Point vertex2, Point vertex3)
            {
                this.vertex1 = vertex1;
                this.vertex2 = vertex2;
                this.vertex3 = vertex3;
            }
            Distances Distance()
            {
                return new(Math.Sqrt(Math.Pow(vertex1.x - vertex2.x, 2) + Math.Pow(vertex1.y - vertex2.y, 2)),
                    Math.Sqrt(Math.Pow(vertex2.x - vertex3.x, 2) + Math.Pow(vertex2.y - vertex3.y, 2)),
                    Math.Sqrt(Math.Pow(vertex3.x - vertex1.x, 2) + Math.Pow(vertex3.y - vertex1.y, 2)));
            }
            public double Perimeter()
            {
                Distances distances = Distance();
                return distances.distance1 + distances.distance2 + distances.distance3;
            }
            // No, it is a triangle
            public void Square() { }

            public void Print()
            {
                Console.WriteLine($"Vertex1: {vertex1}");
                Console.WriteLine($"Vertex2: {vertex2}");
                Console.WriteLine($"Vertex3: {vertex3}");
                Console.WriteLine($"Perimeter: {Perimeter()}");
            }
        }

        static void Main()
        {
            List<Triangle> triangles = new()
            {
                new Triangle(new Point(2.3, -4), new Point(3, 4), new Point(-10, 0)),
                new Triangle(new Point(1.5, -2), new Point(0, 0), new Point(10, 5)),
                new Triangle(new Point(0, -0.0004), new Point(0.003, 0.05), new Point(-0.4, 0.4)),
            };

            triangles.ForEach(t => t.Print());
        }
    }
}
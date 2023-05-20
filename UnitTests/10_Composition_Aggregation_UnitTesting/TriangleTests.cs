using static _10_Composition_Aggregation_UnitTesting.Program;

namespace _10_UnitTests._10_Composition_Aggregation_UnitTesting
{
    public class TriangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            Triangle triangle = new Triangle(new Point(4, 5),
                new Point(-4.3, 5.4), new Point(11.42, 0.04));
            Assert.That(triangle.vertex1.x, Is.EqualTo(4));
            Assert.That(triangle.vertex1.y, Is.EqualTo(5));

            Assert.That(triangle.vertex2.x, Is.EqualTo(-4.3));
            Assert.That(triangle.vertex2.y, Is.EqualTo(5.4));

            Assert.That(triangle.vertex3.x, Is.EqualTo(11.42));
            Assert.That(triangle.vertex3.y, Is.EqualTo(0.04));
        }

        [Test]
        public void PerimeterTest()
        {
            Triangle triangle = new Triangle(new Point(4, 5),
                new Point(-4.3, 5.4), new Point(11.42, 0.04));

            double perimeter = Math.Sqrt(Math.Pow(triangle.vertex1.x - triangle.vertex2.x, 2) + Math.Pow(triangle.vertex1.y - triangle.vertex2.y, 2))
                + Math.Sqrt(Math.Pow(triangle.vertex2.x - triangle.vertex3.x, 2) + Math.Pow(triangle.vertex2.y - triangle.vertex3.y, 2))
                + Math.Sqrt(Math.Pow(triangle.vertex3.x - triangle.vertex1.x, 2) + Math.Pow(triangle.vertex3.y - triangle.vertex1.y, 2));

            Assert.That(triangle.Perimeter(), Is.EqualTo(perimeter));
        }
    }
}

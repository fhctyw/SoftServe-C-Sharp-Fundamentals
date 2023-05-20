using static _10_Composition_Aggregation_UnitTesting.Program;
namespace _10_UnitTests._10_Composition_Aggregation_UnitTesting;
public class PointTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DefaultConstructorTest()
    {
        Point point = new Point();
        Assert.That(point.x, Is.EqualTo(0.0));
        Assert.That(point.y, Is.EqualTo(0.0));
    }

    [Test]
    public void ConstructorTest()
    {
        Point point = new Point(4.4, -2.314);
        double x = 4.4;
        double y = -2.314;
        Assert.That(x, Is.EqualTo(point.x).Within(0.0001));
        Assert.That(y, Is.EqualTo(point.y).Within(0.0001));
    }

    [Test]
    public void ToStringTest()
    {
        Point point = new Point();
        Assert.That(point.ToString(), Is.EqualTo($"({point.x:0.00},{point.y:0.00})"));

        Point point1 = new Point(311, -453);
        Assert.That(point1.ToString(), Is.EqualTo($"({point1.x:0.00},{point1.y:0.00})"));

        Point point2 = new Point(0.46724, -1436.4090531);
        Assert.That(point2.ToString(), Is.EqualTo($"({point2.x:0.00},{point2.y:0.00})"));
    }
}
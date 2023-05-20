using static _08_Abstract.Program;

namespace _10_UnitTests._08_Abstract
{
    public class StudentTests
    {
        [Test]
        public void ContructorAndNameTest()
        {
            string name = "John";
            string group = "KN-22";
            Student student = new(name, group);

            Assert.That(name, Is.EqualTo(student.Name));
        }
    }
}

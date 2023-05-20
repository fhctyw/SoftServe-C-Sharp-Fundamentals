using static _08_Abstract.Program;

namespace _10_UnitTests._08_Abstract
{
    public class TeacherTests
    {
        [Test]
        public void ConstructorAndNameSalary()
        {
            string name = "John";
            int salary = 4000;
            Teacher teacher = new(name, salary, "Math");

            Assert.That(name, Is.EqualTo(teacher.Name));
            Assert.That(salary, Is.EqualTo(teacher.Salary));
        }
    }
}

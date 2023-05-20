using static _08_Abstract.Program;

namespace _10_UnitTests._08_Abstract
{
    public class DeveloperTests
    {
        [Test]
        public void ConstructorAndNameSalary()
        {
            string name = "John";
            int salary = 4000;
            Developer developer = new(name, salary, "Math");

            Assert.That(name, Is.EqualTo(developer.Name));
            Assert.That(salary, Is.EqualTo(developer.Salary));
        }
    }
}

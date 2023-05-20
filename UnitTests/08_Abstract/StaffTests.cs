using static _08_Abstract.Program;

namespace _10_UnitTests._08_Abstract
{
    public class StaffTests
    {
        [Test]
        public void ConstructorAndNameSalaryTest()
        {
            string name = "John";
            int salary = 4000;
            Staff staff = new(name, salary);

            Assert.That(name, Is.EqualTo(staff.Name));
            Assert.That(salary, Is.EqualTo(staff.Salary));
        }
    }
}

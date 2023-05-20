using static _08_Abstract.Program;
namespace _10_UnitTests._08_Abstract
{
    public class PersonTests
    {
        [Test]
        public void ConstructorAndNameTest()
        {
            string name = "John";
            Person person = new Person(name);

            Assert.That(name, Is.EqualTo(person.Name));
        }
        [Test]
        public void ToStringTest()
        {
            string personName = "John";
            Person person = new Person(personName);

            Assert.That(personName, Is.EqualTo(person.ToString()));
        }
    }
}

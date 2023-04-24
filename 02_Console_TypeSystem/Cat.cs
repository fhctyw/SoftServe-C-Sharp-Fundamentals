
namespace _02_Console_TypeSystem
{
    public class Cat
    {
        public Cat(int fullnessLevel = 100)
        {
            FullnessLevel = fullnessLevel;
        }

        public int FullnessLevel { get; set; }
        public void Eat(Food food)
        {
            if (FullnessLevel < 100)
            {
                switch (food)
                {
                    case Food.Meat:
                        FullnessLevel += 50;
                        break;
                    case Food.Fish:
                        FullnessLevel += 35;
                        break;
                    case Food.Mouse:
                        FullnessLevel += 10;
                        break;
                    case Food.Feed:
                        FullnessLevel += 20;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Cat cannot eat, cat is satiated");
            }
        }
        public void Play()
        {
            if (FullnessLevel < 0)
            {
                Console.WriteLine("Cat cannot play, cat is hungry");
            }
            else
            {
                FullnessLevel -= 40;
            }
        }
    }
}

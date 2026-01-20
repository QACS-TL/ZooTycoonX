namespace ZooTycoonX
{
    internal class Program
    {
        static List<string> animals = new List<string>();

        static void Main(string[] args)
        {
            //Variable Fun
            int count = 0;
            // csv Name, Type, Color, Age
            string animal1 = "Leo,Lion,Brown,4";
            animals.Add(animal1);
            string animal2 = "Molly,Monkey,Gray,5";
            animals.Add(animal2);
            animals.Add("Zara,Zebra,Black and White,3");
            animals.Add("Ellie,Elephant,Gray,10");
            Console.WriteLine($"Total animals in the zoo: {animals.Count}");

            Console.WriteLine("Please enter the name of an animal to add: ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the type of the animal: ");
            string type = Console.ReadLine();
            Console.WriteLine("Please enter the colour of the animal: ");
            string colour = Console.ReadLine();
            Console.WriteLine("Please enter the number of limbs of the animal: ");
            string limbCount = Console.ReadLine();
            //animals.AddRange(name, type, colour,limbCount);
            string newAnimal = $"{name},{type},{colour},{limbCount}";
            animals.Add(newAnimal);

            Console.WriteLine(string.Join("\n", animals));
        }
    }
}

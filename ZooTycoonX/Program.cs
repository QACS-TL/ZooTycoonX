namespace ZooTycoonX
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<string> animals = new List<string>();
            //Variable Fun
            LoadAnimals(animals);
            animals.Add(GenerateNewAnimal());
            animals.Add(GenerateNewAnimal());
            PrintDetails(animals);
        }

        private static void PrintDetails(List<string> ani)
        {
            Console.WriteLine(string.Join("\n", ani));
            Console.WriteLine($"Total animals in the zoo: {ani.Count}");
        }

        private static void LoadAnimals(List<string> ani)
        {
            // csv Name, Type, Color, Age
            string animal1 = "Leo,Lion,Brown,4";
            ani.Add(animal1);
            string animal2 = "Molly,Monkey,Gray,5";
            ani.Add(animal2);
            ani.Add("Zara,Zebra,Black and White,3");
            ani.Add("Ellie,Elephant,Gray,10");
        }

        private static string GenerateNewAnimal()
        {
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
            return newAnimal;
        }
    }
}

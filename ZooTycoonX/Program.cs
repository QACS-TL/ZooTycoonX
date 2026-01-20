
namespace ZooTycoonX
{
    internal class Program
    {
        private static HashSet<string> validAnimalTypes = new HashSet<string>
        {
            "Dog",
            "Cat",
            "Bird",
            "Monkey",
            "Unknown"
        };

        private static HashSet<string> validAnimalColours = new HashSet<string>
        {
            "Black",
            "White",
            "Balck and White",
            "Grey",
            "Pink"
        };

        //private static void PrintDetails(List<Dictionary<string, string>> animals)
        //{
        //    Console.WriteLine(string.Join("\n", animals));
        //    Console.WriteLine($"Total animals in the zoo: {animals.Count}");
        //}

        private static void PrintDetails(List<Dictionary<string, string>> animals)
        {
            Console.WriteLine($"You have {animals.Count} animals in your zoo.");

            //loop Through Dictionary and print details
            foreach (var animal in animals)
            {
                string name = animal["Name"];
                string type = animal["Type"];
                string colour = animal["Colour"];
                string limbs = animal["LimbCount"];

                Console.WriteLine($"{name}, {type}, {colour}, {limbs} ");

            }
        }

        private static List<Dictionary<string, string>> LoadAnimals(List<Dictionary<string, string>> animals)
        {
            animals = new List<Dictionary<string, string>>();

            animals.Add(new Dictionary<string, string>
            {
                {"Name", "Leo"},
                {"Type", "Lion"},
                {"Colour", "Brown"},
                {"LimbCount", "4"}
            });

            animals.Add(new Dictionary<string, string>
            {
                {"Name", "Molly"},
                {"Type", "Monkey"},
                {"Colour", "Grey"},
                {"LimbCount", "5"}
            });

            animals.Add(new Dictionary<string, string>
            {
                {"Name", "Zara"},
                {"Type", "Zebra"},
                {"Colour", "Black and White"},
                {"LimbCount", "3"}
            });

            animals.Add(new Dictionary<string, string>
            {
                {"Name", "Ellie"},
                {"Type", "Elephant"},
                {"Colour", "Grey"},
                {"LimbCount", "10"}
            });
            return animals;

        }

        private static void AddAnimal(List<Dictionary<string, string>> animals)
        {
            Console.WriteLine("Add a new animal.");

            Console.WriteLine("Name: ");
            string name = Console.ReadLine()?.Trim() ?? string.Empty;
            while(name.Length < 2) { 
                Console.WriteLine("Animal name must be at least 2 characters long. Try again");
                Console.WriteLine("Name: ");
                name = Console.ReadLine()?.Trim() ?? string.Empty;
            }

            Console.WriteLine("Type: ");
            string type = Console.ReadLine()?.Trim() ?? string.Empty;
            while (!validAnimalTypes.Contains(type))
            {
                Console.WriteLine($"Animal name must be a {string.Join(", ", validAnimalTypes)}. Try again");
                Console.WriteLine("Name: ");
                type = Console.ReadLine()?.Trim() ?? string.Empty;
            }

            Console.WriteLine("Colour: ");
            string colour = Console.ReadLine()?.Trim() ?? string.Empty;
            while (!validAnimalTypes.Contains(type))
            {
                Console.WriteLine($"Animal name must be a {string.Join(", ", validAnimalColours)}. Try again");
                Console.WriteLine("Colour: ");
                colour = Console.ReadLine()?.Trim() ?? string.Empty;
            }

            Console.Write("Limb Count: ");
            string limbCountInput = Console.ReadLine()?.Trim() ?? string.Empty;
            bool parsed = int.TryParse(limbCountInput, out int limbCount);
            while (!parsed || limbCount < 0)
            {
                Console.WriteLine("Invalid limb count, please try again.");
                Console.Write("Limb Count: ");
                limbCountInput = Console.ReadLine()?.Trim() ?? string.Empty;
                parsed = int.TryParse(limbCountInput, out limbCount);
            }

            animals.Add(new Dictionary<string, string>
            {
                {"Name", name},
                {"Type", type},
                {"Colour", colour},
                {"LimbCount", limbCount.ToString()}
            });


        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. View Animals");
            Console.WriteLine("3. Exit");
        }

        public static void MainMenu()
        {
            List<Dictionary<string, string>> animals = null;
            animals = LoadAnimals(animals);

            while (true)
            {
                PrintMenu();
                Console.WriteLine("Please select an option: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        AddAnimal(animals);
                        break;
                    case "2":
                        PrintDetails(animals);
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}

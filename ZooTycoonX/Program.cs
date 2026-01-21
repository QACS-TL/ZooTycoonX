
using System.Drawing;
using System.Globalization;
using ZooTycoonXLibrary;


namespace ZooTycoonX
{
    public class Program
    {


        //private static void PrintDetails(List<Animal> animals)
        //{
        //    Console.WriteLine(string.Join("\n", animals));
        //    Console.WriteLine($"Total animals in the zoo: {animals.Count}");
        //}

        public static void PrintDetails(List<Animal> animals)
        {
            //Console.WriteLine($"You have {animals.Count} animals in your zoo.");

            //loop Through Dictionary and print details
            //foreach (var animal in animals)
            //{
            //    string name = animal["Name"];
            //    string type = animal["Type"];
            //    string colour = animal["Colour"];
            //    string limbs = animal["LimbCount"];

            //    Console.WriteLine($"{name}, {type}, {colour}, {limbs} ");

            //}
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}) Name: {animals[i].Name}, Type: {animals[i].Type}, Colour: {animals[i].Colour}, LimbCount: {animals[i].LimbCount}");
            }

        }

        public static List<Animal> LoadAnimals(List<Animal> animals)
        {
            animals = new List<Animal>();

            animals.Add(new Animal()
            {
                Name= "Leo",
                Type = "Lion",
                Colour = "Brown",
                LimbCount = 4
            });

            animals.Add(new Animal( "Molly", "Monkey", "Grey",5));
            animals.Add(new Animal("Zara", "Zebra", "Black and White", 3));
            animals.Add(new Animal("Ellie", "Elephant", "Grey", 10));

            return animals;
        }

        private static void AddAnimal(List<Animal> animals)
        {
            Console.WriteLine("Add a new animal.");

            string name = GetAndValidateAttributeForAdding("Name");
            string type = GetAndValidateAttributeForAdding("Type").ToUpper();
            string colour = GetAndValidateAttributeForAdding("Colour").ToUpper();
            string limbCount = GetAndValidateAttributeForAdding("LimbCount");

            animals.Add(new Animal( name, type, colour, int.Parse(limbCount)));
        }

        private static bool AttributeChecker(string attribute, string value)
        {
            switch (attribute)
            {
                case "Name":
                    return value.Length < 2;
                case "Type":
                    return !Utilities.ValidAnimalTypes.Contains(value.ToUpper());
                case "Colour":
                    return !Utilities.ValidAnimalColours.Contains(value.ToUpper());
                case "LimbCount":
                    bool parsed = int.TryParse(value, out int limbCount);
                    return !parsed || limbCount < 0;
                default:
                    return true; 
            }
        }

        public static string GetAndValidateAttributeForAdding(string attribute)
        {
            Console.WriteLine($"{attribute}: ");
            string value = Console.ReadLine()?.Trim() ?? string.Empty;
            while (AttributeChecker(attribute, value))
            {
                Console.WriteLine($"Invalid {attribute}, please try again");
                Console.WriteLine($"{attribute}: ");
                value = Console.ReadLine()?.Trim() ?? string.Empty;
            }

            return value;
        }

        public static string InputDetail(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }


        public static int? ChooseIndex(int maxN)
        {
            string raw = InputDetail("Choose number (or blank to cancel)");
            if (string.IsNullOrWhiteSpace(raw))
            {
                Console.WriteLine("Cancelled.");
                return null;
            }

            if (!int.TryParse(raw, out int n))
            {
                Console.WriteLine("Invalid selection");
                return null;
            }

            if (n >= 1 && n <= maxN)
                return n - 1;

            Console.WriteLine("Invalid selection");
            return null;
        }

        public static (Animal? selected, bool Quit) AnimalSelector(List<Animal> animals, string messageMode, bool quitFlag)
        {
            var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(messageMode ?? string.Empty);
            Console.WriteLine($"{title} animals");

            if (animals == null || animals.Count == 0)
            {
                Console.WriteLine($"No animals to {messageMode}.");
                quitFlag = true;
            }

            PrintDetails(animals);

            int? idx = ChooseIndex(animals?.Count ?? 0);
            if (!idx.HasValue)
            {
                quitFlag = true;
                return (null, quitFlag);
            }

            return (animals[idx.Value], quitFlag);
        }


        private static string GetAndValidateAttributeForEditing(string attribute, string currentValue)
        {
            Console.WriteLine($"{attribute} [{currentValue}]: ");
            string value = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(value))
                return currentValue;

            while (AttributeChecker(attribute, value))
            {
                Console.WriteLine($"Invalid {attribute}, please try again");
                Console.WriteLine($"{attribute} [{currentValue}]: ");
                value = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(value))
                    return currentValue;
            }

            return value;
        }

        public static void EditAnimal(List<Animal> animals)
        {
            string messageMode = "edit";
            bool quitFlag = false;

            var (ani, qf) = AnimalSelector(animals, messageMode, quitFlag);
            if (qf || ani == null)
                return;

            ani.Name = GetAndValidateAttributeForEditing("Name", ani.Name);
            ani.Type = GetAndValidateAttributeForEditing("Type", ani.Type).ToUpper();
            ani.Colour = GetAndValidateAttributeForEditing("Colour", ani.Colour).ToUpper();
            ani.LimbCount = int.Parse(GetAndValidateAttributeForEditing("LimbCount", ani.LimbCount.ToString()));

            //SaveAnimals(animals);

        }

        public static void RemoveAnimal(List<Animal> animals)
        {
            string messageMode = "remove";
            bool quitFlag = false;

            var (ani, qf) = AnimalSelector(animals, messageMode, quitFlag);
            if (qf || ani == null)
                return;

            animals.Remove(ani);
            //SaveAnimals(animals);
            Console.WriteLine($"Removed {ani.Name}");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. View Animals");
            Console.WriteLine("3. Edit Animal");
            Console.WriteLine("4. Remove Animal");
            Console.WriteLine("5. Exit");
        }

        public static void MainMenu()
        {
            List<Animal> animals = null;
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
                        EditAnimal(animals);
                        break;
                    case "4":
                        RemoveAnimal(animals);
                        break;
                    case "5":
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

            //Animal myAnimal = new Animal("Fido", "Dog", "Green", 4);
            ////myAnimal.name = "Fido";
            ////myAnimal.type = "Dog";
            ////myAnimal.colour = "Black";
            ////myAnimal.limbCount = 4;

            //Animal myAnimal2 = new Animal();
            ////myAnimal2.Name = "Fifi";
            ////myAnimal2.type = "Cat";
            ////myAnimal2.colour = "White";
            ////myAnimal2.limbCount = 5;

            //myAnimal2.LimbCount = -1;
            //Console.WriteLine(myAnimal2.LimbCount);
            ////myAnimal2.SetLimbCount(-1);
            ////Console.WriteLine(myAnimal2.GetLimbCount());

            //Animal myAnimal3 = new Animal { Name = "", Type = "Camel", Colour = "Green", LimbCount=-10};

            //Console.WriteLine(myAnimal.Eat("Bone"));
            //Console.WriteLine(myAnimal2.Eat("Fish"));
            //Console.WriteLine(myAnimal3.Eat("Bananas"));
        }
    }
}

using System.Globalization;

namespace ZooTycoonXLibrary
{
    public class Animal
    {
        private string name; 
        private string type;
        private string colour;
        private int limbCount;
        private int x = 0;
        private int y = 0;
        TextInfo textInfo;

        private int health = 60;

        public Animal(string name="Anon", string type="UNKNOWN", string colour="BLACK", int limbCount=4)
        {
            this.Name = name;
            this.Type = type;
            this.Colour = colour;
            this.LimbCount = limbCount;
            textInfo = CultureInfo.CurrentCulture.TextInfo;
        }

        public string Name
        {
            get { return name; }
            set 
            { 
                while (value.Length < 2)
                {
                    value += "X";
                }
                name = value; 
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (!Utilities.ValidAnimalTypes.Contains(value.ToUpper()))
                {
                    value = "UNKNOWN";
                }
                type = value.ToUpper();
            }
        }

        public string Colour
        {
            get { return colour; }
            set { 
                if (!Utilities.ValidAnimalColours.Contains(value.ToUpper()))
                {
                    value = "BLACK";
                }
                colour = value.ToUpper(); 
            }
        }

        public int LimbCount
        {
            get { return limbCount; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                limbCount = value;
            }
        }

        //public int GetLimbCount()
        //{
        //    return limbCount;
        //}

        //public void SetLimbCount(int value)
        //{
        //    if (value < 0)
        //    {
        //        value = 0;
        //    }
        //    limbCount = value;
        //}

        public string Eat(string food)
        {
            health += 10;
            return $"{Name} the {textInfo.ToTitleCase(colour.ToLower())} {textInfo.ToTitleCase(type.ToLower())} is eating {food}.";
        }

        public string Move(string direction, int distance = 10)
        {
            // cHANGE x AND y COORDS To reflect new location
            return $"{Name} the {textInfo.ToTitleCase(colour)} {textInfo.ToTitleCase(type.ToLower())} is moving {direction} for a distance of {distance} metres.";
        }
    }
}

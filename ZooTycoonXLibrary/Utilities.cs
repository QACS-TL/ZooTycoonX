using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTycoonXLibrary
{
    public static class Utilities
    {
        public static HashSet<string> ValidAnimalTypes = new HashSet<string>
        {
            "DOG",
            "CAT",
            "BIRD",
            "MONKEY",
            "UNKNOWN"
        };

        public static HashSet<string> ValidAnimalColours = new HashSet<string>
        {
            "BLACK",
            "WHITE",
            "BLACK AND WHITE",
            "GREY",
            "PINK"
        };
    }
}

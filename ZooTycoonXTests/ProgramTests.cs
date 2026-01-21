using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTycoonX;
using ZooTycoonXLibrary;

namespace ZooTycoonXTests
{
    public class ProgramTests
    {
        [Fact]
        public void TestLoadAnimals()
        {
            //Arrange
            List<Animal> animals = null;

            //Act
            animals = Program.LoadAnimals(animals);

            //Assert
            Assert.Equal(4, animals.Count);
            Assert.Equal("Leo", animals[0].Name);
            Assert.Equal("BLACK AND WHITE", animals[2].Colour);
        }

        [Fact]
        public void TestGetAndValidateAttributeForAddingWithValidName()
        {
            //Arrange
            var input = new StringReader("Bob\n");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);
            //Act
            string name = Program.GetAndValidateAttributeForAdding("Name");
            //Assert
            Assert.Equal("Bob", name);
        }

    }
}

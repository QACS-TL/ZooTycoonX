using ZooTycoonXLibrary;

namespace ZooTycoonXTests
{
    public class AnimalTests
    {
        [Fact]
        public void TestAnimalNameDefaultPropertyValue()
        {
            //Arrange + Act
            Animal a = new Animal();

            //Assert
            Assert.Equal("Anon", a.Name);
        }

        [Fact]
        public void TestAnimalNamePropertySetValue()
        {
            //Arrange
            Animal a = new Animal();

            //Act
            a.Name = "Bob";

            //Assert
            Assert.Equal("Bob", a.Name);
        }

        [Theory]
        [InlineData("B", "BX")]
        [InlineData("", "XX")]
        public void TestAnimalNamePropertySetToIllegalValue(string name, string expectedName)
        {
            //Arrange
            Animal a = new Animal();

            //Act
            a.Name = name;

            //Assert
            Assert.Equal(expectedName, a.Name);
        }


    }
}

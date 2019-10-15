using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
         [Fact]

         public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange 
            var parserInt = new TacoParser();
            var str = " 32.92496,-85.961342,Taco Bell Alexander Cit...";
            // Act
            var actual = parserInt.Parse(str);

            //Assert
            Assert.NotNull(actual);



        }

     [Theory]
     [InlineData("33.635282, -86.684056, Taco Bell Birmingham..."," Taco Bell Birmingham...")]

        public void ShouldParse(string str, string expected)
        {
            //Arrange
            var parserInt = new TacoParser();

            //Act
            var actual = parserInt.Parse(str);

            //Assert
            Assert.Equal(expected, actual.Name);
        }

        [Theory]
        [InlineData("33.556383, -86.889051")]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            var parserInt = new TacoParser();

            //Act
            var actual = parserInt.Parse(str);

            //Assert
            Assert.Null(actual);
        }
    }
}

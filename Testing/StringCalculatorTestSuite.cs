using StringCalculatorLib;

namespace StringCalculatorLib.Tests
{
    public class StringCalculatorTestSuite
    {
        [Fact]
        public void Add_ForEmptyStringZeroExpected()
        {
            // Arrange
            string input = "";
            int expectedResult = 0;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_ForStringOfSingleNumberReturnsNumber()
        {
            // Arrange
            string input = "1";
            int expectedResult = 1;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_ForNegativeInputsExceptionThrown()
        {
            // Arrange
            string input = "-1,2";

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));

            // Assert
            Assert.Equal("Negatives not allowed: (-1)", exception.Message);
        }


        [Fact]
        public void Add_ForTwoNumbersSeparatedWithNewLineReturnsSum()
        {
            // Arrange
            string input = "1\n2";
            int expectedResult = 3;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Add_ForInvalidInputsThrowException()
        {
            // Arrange
            string input = "1,\n";

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));

            // Assert
            Assert.Contains("Invalid input: Trailing comma", exception.Message);
        }

        [Fact]
        public void Add_ForCustomDelimitersUsedReturnSum()
        {
            // Arrange
            string input = "//;\n1;2";
            int expectedResult = 3;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(3, result);
        }


        [Fact]
        public void Add_MultipleNegativeNumbersInInputThrowExceptionsWithAllNumbers()
        {
            // Arrange
            string input = "-1,-2,-3,4";

            // Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input));
            Assert.Equal("Negatives not allowed: (-1, -2, -3)", exception.Message);
        }

        [Fact]
        public void Add_ForNumbersGreaterThanThousandAreIgnored()
        {
            // Arrange 
            string input = "2,1001";
            int expectedResult = 2;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_ForCustomDelimiterWithAnyLengthReturnsSum()
        {
            // Arrange
            string input = "//[***]\n1***2***3";
            int expectedResult = 5;

            // Act
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_ForMultipleDelimitersReturnSum()
        {
            // Arrange
            string input = "//[*][%]\n1*2%3";
            int expectedResult = 6;

            // Act 
            int result = StringCalculator.Add(input);

            // Assert
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3", 6)]

        public void Add_ForCustomDelimiterWithAnyLengthReturnsSumUsingTheory(string testInput, int testOutput)
        {
            int result = StringCalculator.Add(testInput);
            Assert.Equal(testOutput, result);
        }

    }
}

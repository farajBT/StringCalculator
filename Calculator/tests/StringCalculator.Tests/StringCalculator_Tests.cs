using src;

namespace tests
{
  
    public class stringCalculator_Tests
    {
            [Theory]
            [InlineData("",0)]
            [InlineData("1",1)]
            [InlineData("1,2",3)]
            [InlineData("1,2,3,4,5",15)]
            [InlineData("1\n2,3",6)]
            [InlineData("5,10,1664",15)]
            [InlineData("//;\n1,2;3",6)]
            [InlineData(";2\n4,4",10)]
            public void canReturnTheSumofAllNumbersFromAnInputString(string input,int expected)
            {
                // When
                var StringCalculator = new StringCalculator();
                var actual = StringCalculator.Add(input);
                // Then
                Assert.Equal(expected,actual);
            }

            [Theory]
            [InlineData("-5,-2,-10,9",typeof(Exception))]
            [InlineData("A;2\n4,4",typeof(Exception))]
            [InlineData(";2\nB4,4",typeof(Exception))]
            public void canReturnAnExceptionWhenInputContainNegatifAndNoneIntegerChar(string input,Type exceptionType)
            {
                // When
                var StringCalculator = new StringCalculator();
                // Then
                Assert.Throws(exceptionType,() => StringCalculator.Add(input));
            }

        /******************************************************************/
            // [Fact]
            // public void canReturnAZeroWhenStringIsEmpty()
            // {
            //     // Given
            //     var expected = 0;
            //     var input = string.Empty;
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }

            // [Fact]
            // public void canReturnThenumberItslefWhenStringhasOneInput()
            // {
            //     // Given
            //     var expected = 1;
            //     var input = "1";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }

            // [Fact]
            // public void canReturnTheSumofTwoNumbers()
            // {
            //     // Given
            //     var expected = 3;
            //     var input = "1,2";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }

            // [Fact]
            // public void canReturnTheSumofallNumbersIntheInputString()
            // {
            //     // Given
            //     var expected = 15;
            //     var input = "1,2,3,4,5";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }

            // [Fact]
            // public void canReturnTheSumofallNumbersWithBackSlachNAndCommaAsDeliminator()
            // {
            //     // Given
            //     var expected = 6;
            //     var input = "1\n2,3";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }
        
            // [Fact]
            // public void canReturnTheSumofallNumbersWithAPerzonalisedDeliminator()
            // {
            //     // Given
            //     var expected = 6;
            //     var input = "//;\n1,2;3";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //     // Then
            //     Assert.Equal(expected,actual);
            // }

            // [Fact]
            // public void canThrowAnExceptionWhenANegativeNumberIsInsidetheInput()
            // {
            //     // Given
            //     var input = "-5,-2,-10,9";
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     // Then
            //     Assert.Throws<Exception>(() => StringCalculator.Add(input));
            // }

            // [Fact]
            // public void canIgnoreNumbersBiggerThanOneThousand()
            // {
            //     // Given
            //     var input = "5,10,1664";
            //     var expected = 15;
            //     // When
            //     var StringCalculator = new StringCalculator();
            //     var actual = StringCalculator.Add(input);
            //    // Then
            //     Assert.Equal(expected,actual);
            // }
    }
}
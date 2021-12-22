
using Xunit;
namespace calculator
{
    public class UnitTest1
    {
        [Fact]
        public void Test_addition()
        { 
            double a = 2;
            double b = 1;
            double expectedValue = 3;
            
             
            double sum = Program.Calculator.Addition(a, b);

            
            Assert.Equal(expectedValue, sum, 1);
        }
        [Fact]
        public void Test_addition_array()
        {
            double[] a = new double[] { 1,2,3};
           
            double expectedValue = 6;


            double sum = Program.Calculator.Addition(a);


            Assert.Equal(expectedValue, sum, 1);
        }
        [Fact]
        public void Test_subtraction()
        {
            double a = 2;
            double b = 1;
            double expectedValue = 1;


            double diff = Program.Calculator.Subtraction(a, b);


            Assert.Equal(expectedValue, diff, 1);
        }
        [Fact]
        public void Test_subtraction_array()
        {
            double[] a = new double[] { 1, 2, 3 };

            double expectedValue = -4;


            double diff = Program.Calculator.Subtraction(a);


            Assert.Equal(expectedValue, diff, 1);
        }
        [Fact]
        public void Test_multiplication()
        {
            double a = 2;
            double b = 2;
            double expectedValue = 4;


            double product = Program.Calculator.Multiplication(a, b);


            Assert.Equal(expectedValue, product, 1);
        }
        [Fact]
        public void Test_valid_division()
        {
            double a = 2;
            double b = 2;
            double expectedValue = 1;


            double quotient = Program.Calculator.Division(a, b);
            Assert.Equal(expectedValue, quotient, 1);
        }
        [Fact]
        public void Test_division_by_zero()
        {
            double a = 2;
            double b = 0;
            var ex = Assert.Throws<System.DivideByZeroException>(() => Program.Calculator.Division(a,b));
            Assert.Equal("Division by zero not allowed!", ex.Message);

            
        }
    }
}
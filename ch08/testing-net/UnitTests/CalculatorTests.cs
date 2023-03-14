using App;
using Xunit;

namespace UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void ShouldAdd2Numbers()
        {
            var calculator = new Calculator();
            Assert.Equal(4, calculator.Add(1,3));
        } 
    }
}

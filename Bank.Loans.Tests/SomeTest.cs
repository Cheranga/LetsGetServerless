using Xunit;

namespace Bank.Loans.Tests
{
    public class SomeTest
    {
        [Fact]
        public void TestIfNameIsEmpty()
        {
            var name = "cheranga";
            Assert.False(string.IsNullOrWhiteSpace(name));
        }
    }
}
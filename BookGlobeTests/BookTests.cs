using Xunit;

namespace BookGlobeTests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            var result = "Hi there";
            Assert.True(result == "Hi there");
        }
    }
}
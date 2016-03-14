using Shouldly;
using Xunit;

namespace MyFubuApp.Tests
{
    public class MyTestClass
    {
        [Fact]
        public void MyTestMethod()
        {
            var test = "my test string";

            test.ShouldBe("my test string");
        }
    }
}

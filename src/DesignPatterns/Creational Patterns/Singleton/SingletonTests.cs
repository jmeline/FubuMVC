
using Xunit;

namespace DesignPatterns.Creational_Patterns.Singleton
{
    public class SingletonTests
    {
        private class Test1 { }

        [Fact]
        public void Test1IsASingleton()
        {
            var s1 = Singleton<Test1>.Instance();
            var s2 = Singleton<Test1>.Instance();
            if (s1 != s2)
            {
                Assert.False(true);
            }
        }
    }
}

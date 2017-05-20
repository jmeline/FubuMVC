using Shouldly;
using Xunit;

namespace CSharp_Language
{
    public class BooleanLogic
    {
        [Fact]
        public void Logical_XOR_Examples()
        {
            (true ^ true).ShouldBe(false);
            (true ^ false).ShouldBe(true);
            (false ^ true).ShouldBe(true);
            (false ^ false).ShouldBe(false);

            (false ^ false ^ false ^ false).ShouldBeFalse();
            (false ^ true ^ true ^ false).ShouldBeFalse();
            (false ^ true ^ true ^ true).ShouldBeTrue();
        }
    }
}

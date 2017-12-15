
using AutoFixture;

namespace PanXPan.Api.Tests
{
    public class TestsBase
    {
        protected Fixture FakeBuilder { get; set; }

        public TestsBase()
        {
            FakeBuilder = new Fixture();
        }
    }
}

using MyUnit.CustomAttributes;

namespace Tests
{
    [TestFixture]
    public class PerformTest
    {
        [Test]
        public void Test_success()
        {
            int a = 2;
            int b = 2;
            if (a!=b)
            {
                Assert.IsFail("first test fails");
            }          
        }
        [Test]
        public void Test_fail()
        {
            int a = 2;
            int b = 3;
            if (a != b)
            {
                Assert.IsFail("Second test fails");
            }
        }
    }
}

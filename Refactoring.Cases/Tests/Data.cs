using Case1.Case1.V2;

namespace Tests
{
    [TestClass]
    public class Data
    {
        [TestMethod]
        public void DataV2Test()
        {
            var data = new DataV2();
            var d1 = data.LoadJson();

            bool expected = d1.Any();
            Assert.AreEqual(expected, true);
        }
    }
}
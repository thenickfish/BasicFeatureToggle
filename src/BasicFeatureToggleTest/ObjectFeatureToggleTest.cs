//using BasicFeatureToggle;
//using BasicFeatureToggle.Internal;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Threading.Tasks;

//namespace BasicFeatureToggleTest
//{
//    [TestClass]
//    public class ObjectFeatureToggleTest
//    {
//        [TestMethod]
//        public async Task TestObjectFeatureToggleValuesReturn()
//        {
//            var toggle = new ObjectFeatureToggle<int>(1);
//            Assert.AreEqual(1, toggle.FeatureValue);
//            Assert.AreEqual(1, await toggle.GetFeatureToggleValueAsync());

//            var toggle2 = new ObjectFeatureToggle<string>("yellow");
//            Assert.AreEqual("yellow", toggle2.FeatureValue);
//            Assert.AreEqual("yellow", await toggle2.GetFeatureToggleValueAsync());

//            var now = DateTime.Now;
//            var toggle3 = new ObjectFeatureToggle<DateTime>(now);
//            Assert.AreEqual(now, toggle3.FeatureValue);
//            Assert.AreEqual(now, await toggle3.GetFeatureToggleValueAsync());
//        }

//        [TestMethod]
//        public void TestObjectFeatureToggleRejectsNulls()
//        {
//            Assert.ThrowsException<BasicFeatureToggleConfigurationException>(() => new ObjectFeatureToggle<string>(null));
//        }
//    }
//}

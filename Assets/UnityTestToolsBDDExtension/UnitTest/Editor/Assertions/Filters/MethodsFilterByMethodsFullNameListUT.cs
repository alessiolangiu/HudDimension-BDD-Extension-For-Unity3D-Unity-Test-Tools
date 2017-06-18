using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodsFilterByMethodsFullNameListUT
    {
        [Test]
        public void FilterGivenMethodsFound()
        {
            MethodsFilterByMethodsFullNameListUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<MethodsFilterByMethodsFullNameListUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] methodsFullNamesList = new string[2] { "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.GivenMethod", "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.ThirdGivenMethod" };
            MethodsFilterByMethodsFullNameList methodsFilterByMethodsFullNameList = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            bool result = methodsFilterByMethodsFullNameList.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByMethodsFullNameList.Filter does not return the right answer");
        }

        [Test]
        public void FilterGivenMethodsNotFound()
        {
            MethodsFilterByMethodsFullNameListUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<MethodsFilterByMethodsFullNameListUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("SecondGivenMethod");
            string[] methodsFullNamesList = new string[2] { "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.GivenMethod", "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.ThirdGivenMethod" };
            MethodsFilterByMethodsFullNameList methodsFilterByMethodsFullNameList = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            bool result = methodsFilterByMethodsFullNameList.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByMethodsFullNameList.Filter does not return the right answer");
        }
    }
}

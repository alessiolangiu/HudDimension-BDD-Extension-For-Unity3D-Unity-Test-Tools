using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodFilterByStepTypeUT
    {
        [Test]
        public void FilterGivenMethodsForGivenStepType()
        {
            MethodFilterByStepTypeUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<MethodFilterByStepTypeUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            bool result = methodsFilterByStepType.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        public void FilterGivenMethodsForWhenStepType()
        {
            MethodFilterByStepTypeUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<MethodFilterByStepTypeUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            bool result = methodsFilterByStepType.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }
    }
}

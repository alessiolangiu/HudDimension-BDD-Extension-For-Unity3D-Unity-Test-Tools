using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodFilterByExecutionOrderUT
    {
        [Test]
        public void FilterGivenMethodForGivenStepType()
        {
            MethodFilterByExecutionOrderUTStaticBDDComponentForTest component = UnitTestUtility.CreateComponent<MethodFilterByExecutionOrderUTStaticBDDComponentForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        public void FilterGivenMethodForWhenStepType()
        {
            MethodFilterByExecutionOrderUTStaticBDDComponentForTest component = UnitTestUtility.CreateComponent<MethodFilterByExecutionOrderUTStaticBDDComponentForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        public void FilterWhenMethodForWhenStepTypeWithoutExecutionOrder()
        {
            MethodFilterByExecutionOrderUTStaticBDDComponentForTest component = UnitTestUtility.CreateComponent<MethodFilterByExecutionOrderUTStaticBDDComponentForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("SecondWhenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        public void FilterGivenMethodForGivenStepTypeInDynamicBDDComponent()
        {
            MethodFilterByExecutionOrderUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<MethodFilterByExecutionOrderUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }
    }
}
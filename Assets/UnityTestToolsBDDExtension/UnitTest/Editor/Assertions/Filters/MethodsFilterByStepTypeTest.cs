﻿using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodsFilterByStepTypeTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should return true given a Dynamic component for a Given method filtering Given methods")]
        public void Filter_Should_ReturnTrue_Given_ADynamicComponentForAGivenMethodFilteringGivenMethods()
        {
            MethodsFilterByStepTypeTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByStepTypeTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            bool result = methodsFilterByStepType.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should return false given a Dynamic component for a Given method filtering When methods")]
        public void Filter_Should_ReturnFalse_Given_ADynamicComponentForAGivenMethodFilteringWhenMethods()
        {
            MethodsFilterByStepTypeTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByStepTypeTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            bool result = methodsFilterByStepType.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }
    }
}

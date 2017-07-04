//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByStepTypeTest.cs" company="Hud Dimension">
//     Copyright (c) Hud Dimension. All rights reserved.
//     http://www.HudDimension.co.uk
// </copyright>
//
// <disclaimer>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </disclaimer>
//
// <author>Alessio Langiu</author>
// <email>alessio.langiu@huddimension.co.uk</email>
//-----------------------------------------------------------------------
using System.Reflection;
using NUnit.Framework;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class MethodsFilterByStepTypeTest
    {
        [Test]
        [Description("Filter method should return true given a Dynamic component for a Given method filtering Given methods")]
        public void Filter_Should_ReturnTrue_Given_ADynamicComponentForAGivenMethodFilteringGivenMethods()
        {
            MethodsFilterByStepTypeTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByStepTypeTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            bool result = methodsFilterByStepType.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
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

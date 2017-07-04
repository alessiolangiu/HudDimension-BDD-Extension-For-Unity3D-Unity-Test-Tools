//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByExecutionOrderTest.cs" company="Hud Dimension">
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
    public class MethodsFilterByExecutionOrderTest
    {
        [Test]
        [Description("Filter method should return true given a Static component for a Given method filtering Given methods")]
        public void Filter_Should_ReturnTrue_Given_AStaticComponentForAGivenMethodFilteringGivenMethods()
        {
            MethodsFilterByExecutionOrderTestStaticComponent component = UnitTestUtility.CreateComponent<MethodsFilterByExecutionOrderTestStaticComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        [Description("Filter method should return false given a Static component for a Given method filtering When methods")]
        public void Filter_Should_ReturnTrue_Given_AStaticComponentForAGivenMethodFilteringWhenMethods()
        {
            MethodsFilterByExecutionOrderTestStaticComponent component = UnitTestUtility.CreateComponent<MethodsFilterByExecutionOrderTestStaticComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        [Description("Filter method should return false given a Static component for a Generic method filtering When methods")]
        public void Filter_Should_ReturnTrue_Given_AStaticComponentForAGenericMethodFilteringWhenMethods()
        {
            MethodsFilterByExecutionOrderTestStaticComponent component = UnitTestUtility.CreateComponent<MethodsFilterByExecutionOrderTestStaticComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("SecondWhenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<WhenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }

        [Test]
        [Description("Filter method should return false given a Dynamic component for a Given method filtering Given methods")]
        public void Filter_Should_ReturnTrue_Given_ADynamicComponentForAGivenMethodFilteringGivenMethods()
        {
            MethodsFilterByExecutionOrderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByExecutionOrderTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            bool result = methodsFilterByExecutionOrder.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByStepType.Filter does not return the right answer");
        }
    }
}
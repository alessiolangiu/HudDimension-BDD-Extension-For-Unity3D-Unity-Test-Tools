//-----------------------------------------------------------------------
// <copyright file="MethodFilterByExecutionOrderUT.cs" company="Hud Dimesion">
//     Copyright (c) Hud Dimension. All rights reserved.
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
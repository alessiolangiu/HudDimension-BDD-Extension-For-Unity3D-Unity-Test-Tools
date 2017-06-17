//-----------------------------------------------------------------------
// <copyright file="MethodFilterByStepTypeUT.cs" company="Hud Dimesion">
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

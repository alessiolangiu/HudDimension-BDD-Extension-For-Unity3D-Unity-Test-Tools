//-----------------------------------------------------------------------
// <copyright file="BaseMethodDescriptionBuilderUT.cs" company="Hud Dimesion">
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
    public class BaseMethodDescriptionBuilderUT
    {
        [Test]
        public void BuildBaseMethodDescriptionWithoutExecutionOrder()
        {
            BaseMethodDescriptionBuilderUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            BaseMethodDescription expectedBaseMethodDescription = new BaseMethodDescription();
            expectedBaseMethodDescription.ComponentObject = component;
            expectedBaseMethodDescription.Method = methodInfo;
            expectedBaseMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedBaseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedBaseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription builderResult = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);

            Assert.IsTrue(expectedBaseMethodDescription.Equals(builderResult), "The method BaseMethodDescriptionBuilder.Build does not return the expected object");
            Assert.AreEqual(expectedBaseMethodDescription.Text, builderResult.Text, "The method BaseMethodDescriptionBuilder.Build does not return the expected Text");
        }

        [Test]
        public void BuildBaseMethodDescriptionWithExecutionOrder()
        {
            BaseMethodDescriptionBuilderUTStaticBDDForTest component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderUTStaticBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            BaseMethodDescription expectedBaseMethodDescription = new BaseMethodDescription();
            expectedBaseMethodDescription.ComponentObject = component;
            expectedBaseMethodDescription.Method = methodInfo;
            expectedBaseMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedBaseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedBaseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription builderResult = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);

            Assert.IsTrue(expectedBaseMethodDescription.Equals(builderResult), "The method BaseMethodDescriptionBuilder.Build does not return the expected object");
            Assert.AreEqual(expectedBaseMethodDescription.Text, builderResult.Text, "The method BaseMethodDescriptionBuilder.Build does not return the expected Text");
            Assert.AreEqual(expectedBaseMethodDescription.ExecutionOrder, builderResult.ExecutionOrder, "The method BaseMethodDescriptionBuilder.Build does not return the expected ExecutionOrder");
        }
    }
}

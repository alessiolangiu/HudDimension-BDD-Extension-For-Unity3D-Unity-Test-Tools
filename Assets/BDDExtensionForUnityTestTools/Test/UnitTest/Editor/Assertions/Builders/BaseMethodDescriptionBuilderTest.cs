//-----------------------------------------------------------------------
// <copyright file="BaseMethodDescriptionBuilderTest.cs" company="Hud Dimension">
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
    public class BaseMethodDescriptionBuilderTest
    {
        [Test]
        [Description("Build method should return the expected BaseMethodDescription object given a Dynamic component and a simple Given method")]
        public void Build_Should_ReturnTheExpectedBaseMethodDescriptionObject_Given_ADynamicComponentAndASimpleGivenMethod()
        {
            BaseMethodDescriptionBuilderTestDynamicComponent component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderTestDynamicComponent>();
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
        [Description("Build method should return the expected BaseMethodDescription object given a Static component on a Given method")]
        public void Build_Should_ReturnTheExpectedBaseMethodDescriptionObject_Given_AStaticComponentOnAGivenMethod()
        {
            BaseMethodDescriptionBuilderTestStaticComponent component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderTestStaticComponent>();
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

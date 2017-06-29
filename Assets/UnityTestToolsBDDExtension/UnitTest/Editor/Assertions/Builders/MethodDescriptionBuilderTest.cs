//-----------------------------------------------------------------------
// <copyright file="MethodDescriptionBuilderTest.cs" company="Hud Dimension">
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
using NSubstitute;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodDescriptionBuilderTest
    {
        [Test]
        [Description("Build method should return the expected MethodDescription object given a Dynamic component for a Given method with a string parameter and without ParametersIndexes")]
        public void Build_Should_ReturnTheExpectedMethodDescriptionObject_Given_ADynamicComponentForAGivenMethodWithAStringParameterAndWithoutParametersIndexes()
        {
            MethodDescriptionBuilderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodDescriptionBuilderTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string parametersIndex = null;

            MethodDescription expectedMethodDescription = new MethodDescription();
            expectedMethodDescription.ComponentObject = component;
            expectedMethodDescription.Method = methodInfo;
            expectedMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            arrayStorage.SetValue(component, new string[0]);

            MethodParameter expectedParameter = new MethodParameter();
            expectedParameter.ParameterInfoObject = methodInfo.GetParameters()[0];

            ParameterLocation parameterLocation = new ParameterLocation();
            parameterLocation.ParameterClassLocation = new ParameterLocation.ClassLocation();
            parameterLocation.ParameterClassLocation.ComponentObject = component;
            parameterLocation.ParameterClassLocation.ComponentType = component.GetType();
            parameterLocation.ParameterArrayLocation = new ParameterLocation.ArrayLocation();
            parameterLocation.ParameterArrayLocation.ArrayFieldInfo = component.GetType().GetField("StringsArrayStorage");
            parameterLocation.ParameterArrayLocation.ArrayName = "StringsArrayStorage";
            parameterLocation.ParameterArrayLocation.ArrayIndex = 0;

            expectedParameter.ParameterLocation = null;

            expectedParameter.Value = null;
            MethodParameters methodParameters = new MethodParameters();
            methodParameters.Parameters = new MethodParameter[1] { expectedParameter };
            expectedMethodDescription.Parameters = methodParameters;
            expectedMethodDescription.ParametersIndex = parametersIndex;

            MethodParametersLoader methodParametersLoader = Substitute.For<MethodParametersLoader>();
            methodParametersLoader.LoadMethodParameters(component, methodInfo, string.Empty, parametersIndex).Returns(expectedMethodDescription.Parameters);

            BaseMethodDescription baseMethodDescription = new BaseMethodDescription();
            baseMethodDescription.ComponentObject = component;
            baseMethodDescription.Method = methodInfo;
            baseMethodDescription.StepType = typeof(GivenBaseAttribute);
            baseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            baseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodDescription builderResult = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);

            Assert.IsTrue(expectedMethodDescription.Equals(builderResult), "The method MethodDescriptionBuilder.Build does not return the expected object");
        }

        [Test]
        [Description("Build method should return the expected MethodDescription object given a Dynamic component for a Given method with a string parameter with its ParameterIndex")]
        public void Build_Should_ReturnTheExpectedMethodDescriptionObject_Given_ADynamicComponentForAGivenMethodWithAStringParameterWithItsParameterIndex()
        {
            MethodDescriptionBuilderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodDescriptionBuilderTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string parametersIndex = ";string,DynamicBDDForTest.GivenMethod.stringParam.,StringsArrayStorage.Array.data[0];";

            MethodDescription expectedMethodDescription = new MethodDescription();
            expectedMethodDescription.ComponentObject = component;
            expectedMethodDescription.Method = methodInfo;
            expectedMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            arrayStorage.SetValue(component, new string[1] { "Parameter Value" });

            MethodParameter expectedParameter = new MethodParameter();
            expectedParameter.ParameterInfoObject = methodInfo.GetParameters()[0];

            ParameterLocation parameterLocation = new ParameterLocation();
            parameterLocation.ParameterClassLocation = new ParameterLocation.ClassLocation();
            parameterLocation.ParameterClassLocation.ComponentObject = component;
            parameterLocation.ParameterClassLocation.ComponentType = component.GetType();
            parameterLocation.ParameterArrayLocation = new ParameterLocation.ArrayLocation();
            parameterLocation.ParameterArrayLocation.ArrayFieldInfo = component.GetType().GetField("StringsArrayStorage");
            parameterLocation.ParameterArrayLocation.ArrayName = "StringsArrayStorage";
            parameterLocation.ParameterArrayLocation.ArrayIndex = 0;

            expectedParameter.ParameterLocation = parameterLocation;

            expectedParameter.Value = "Parameter Value";
            MethodParameters methodParameters = new MethodParameters();
            methodParameters.Parameters = new MethodParameter[1] { expectedParameter };
            expectedMethodDescription.Parameters = methodParameters;

            expectedMethodDescription.ParametersIndex = parametersIndex;

            MethodParametersLoader methodParametersLoader = Substitute.For<MethodParametersLoader>();
            methodParametersLoader.LoadMethodParameters(component, methodInfo, string.Empty, parametersIndex).Returns(expectedMethodDescription.Parameters);

            BaseMethodDescription baseMethodDescription = new BaseMethodDescription();
            baseMethodDescription.ComponentObject = component;
            baseMethodDescription.Method = methodInfo;
            baseMethodDescription.StepType = typeof(GivenBaseAttribute);
            baseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            baseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodDescription builderResult = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);

            Assert.IsTrue(expectedMethodDescription.Equals(builderResult), "The method MethodDescriptionBuilder.Build does not return the expected object");
        }

        [Test]
        [Description("Build method should return the expected MethodDescription object given a Dynamic component for a Then method without parameters")]
        public void Build_Should_ReturnTheExpectedMethodDescriptionObject_Given_ADynamicComponentForAThenMethodWithoutParameters()
        {
            MethodDescriptionBuilderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodDescriptionBuilderTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("ThenMethod");
            string parametersIndex = null;

            MethodDescription expectedMethodDescription = new MethodDescription();
            expectedMethodDescription.ComponentObject = component;
            expectedMethodDescription.Method = methodInfo;
            expectedMethodDescription.StepType = typeof(ThenBaseAttribute);
            expectedMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            arrayStorage.SetValue(component, new string[0]);

            MethodParameters methodParameters = new MethodParameters();
            methodParameters.Parameters = new MethodParameter[0];
            expectedMethodDescription.Parameters = methodParameters;
            expectedMethodDescription.ParametersIndex = parametersIndex;

            MethodParametersLoader methodParametersLoader = Substitute.For<MethodParametersLoader>();
            methodParametersLoader.LoadMethodParameters(component, methodInfo, string.Empty, parametersIndex).Returns(expectedMethodDescription.Parameters);

            BaseMethodDescription baseMethodDescription = new BaseMethodDescription();
            baseMethodDescription.ComponentObject = component;
            baseMethodDescription.Method = methodInfo;
            baseMethodDescription.StepType = typeof(ThenBaseAttribute);
            baseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            baseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodDescription builderResult = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);

            Assert.IsTrue(expectedMethodDescription.Equals(builderResult), "The method MethodDescriptionBuilder.Build does not return the expected object");
        }
    }
}

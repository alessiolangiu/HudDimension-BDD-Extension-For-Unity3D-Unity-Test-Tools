//-----------------------------------------------------------------------
// <copyright file="FullMethodDescriptionBuilderTest.cs" company="Hud Dimension">
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
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class FullMethodDescriptionBuilderTest
    {
        [Test]
        [Description("Build method should return the expected FullMethodDescription object given a Dynamic component for a Given method without CallBefore attributes")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObject_Given_ADynamicComponentForAGivenMethodWithoutCallBeforeAttributes()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestFirstDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);
            string parametersIndex = string.Empty;
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedFullMethodDescription = new FullMethodDescription();
            expectedFullMethodDescription.ComponentObject = methodDescription.ComponentObject;
            expectedFullMethodDescription.Method = methodDescription.Method;
            expectedFullMethodDescription.StepType = methodDescription.StepType;
            expectedFullMethodDescription.Text = methodDescription.Text;
            expectedFullMethodDescription.ExecutionOrder = methodDescription.ExecutionOrder;
            expectedFullMethodDescription.Parameters = methodDescription.Parameters;
            expectedFullMethodDescription.ParametersIndex = methodDescription.ParametersIndex;
            expectedFullMethodDescription.Delay = 0;
            expectedFullMethodDescription.TimeOut = 3000;
            expectedFullMethodDescription.SuccessionOrder = 1;
            expectedFullMethodDescription.MainMethod = null;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(methodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(1, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription object given a Dynamic component for a When method with Delay and Timeout properties")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObject_Given_ADynamicComponentForAWhenMethodWithDelayAndTimeoutProperties()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestFirstDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("WhenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            string parametersIndex = string.Empty;
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedFullMethodDescription = new FullMethodDescription();
            expectedFullMethodDescription.ComponentObject = methodDescription.ComponentObject;
            expectedFullMethodDescription.Method = methodDescription.Method;
            expectedFullMethodDescription.StepType = methodDescription.StepType;
            expectedFullMethodDescription.Text = methodDescription.Text;
            expectedFullMethodDescription.ExecutionOrder = methodDescription.ExecutionOrder;
            expectedFullMethodDescription.Parameters = methodDescription.Parameters;
            expectedFullMethodDescription.ParametersIndex = methodDescription.ParametersIndex;
            expectedFullMethodDescription.Delay = 21;
            expectedFullMethodDescription.TimeOut = 34;
            expectedFullMethodDescription.SuccessionOrder = 1;
            expectedFullMethodDescription.MainMethod = null;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(methodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(1, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a Then method with a single CallBefore attribute")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAThenMethodWithASingleCallBeforeAttribute()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestFirstDynamicComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("ThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = string.Empty;
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 0;
            expectedMainFullMethodDescription.TimeOut = 3000;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo callBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription callBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, callBeforeMethodInfo);
            MethodDescription callBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, callBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedCallBeforeFullMethodDescription.ComponentObject = callBeforeMethodDescription.ComponentObject;
            expectedCallBeforeFullMethodDescription.Method = callBeforeMethodDescription.Method;
            expectedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedCallBeforeFullMethodDescription.ExecutionOrder = callBeforeMethodDescription.ExecutionOrder;
            expectedCallBeforeFullMethodDescription.Parameters = callBeforeMethodDescription.Parameters;
            expectedCallBeforeFullMethodDescription.ParametersIndex = callBeforeMethodDescription.ParametersIndex;
            expectedCallBeforeFullMethodDescription.Delay = 32;
            expectedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(2, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a When method with a single CallBefore attribute calling a GenericBDDMethod")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAWhenMethodWithASingleCallBeforeAttributeCallingAGenericBDDMethod()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderUTStaticBDDForTestCallBeforeOnGenericBDDMethod component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderUTStaticBDDForTestCallBeforeOnGenericBDDMethod>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("WhenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = string.Empty;
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 21;
            expectedMainFullMethodDescription.TimeOut = 34;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo firstCallBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription firstCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GenericBDDMethod>(component, firstCallBeforeMethodInfo);
            MethodDescription firstCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedFirstCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstCallBeforeFullMethodDescription.ComponentObject = firstCallBeforeMethodDescription.ComponentObject;
            expectedFirstCallBeforeFullMethodDescription.Method = firstCallBeforeMethodDescription.Method;
            expectedFirstCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstCallBeforeFullMethodDescription.ExecutionOrder = 0;
            expectedFirstCallBeforeFullMethodDescription.Parameters = firstCallBeforeMethodDescription.Parameters;
            expectedFirstCallBeforeFullMethodDescription.ParametersIndex = firstCallBeforeMethodDescription.ParametersIndex;
            expectedFirstCallBeforeFullMethodDescription.Delay = 0;
            expectedFirstCallBeforeFullMethodDescription.TimeOut = 3000;
            expectedFirstCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            MethodInfo secondCallBeforeMethodInfo = component.GetType().GetMethod("GivenMethod");
            BaseMethodDescription secondCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, secondCallBeforeMethodInfo);
            MethodDescription secondCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, secondCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedSecondCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedSecondCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedSecondCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedSecondCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedSecondCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedSecondCallBeforeFullMethodDescription.ExecutionOrder = 0;
            expectedSecondCallBeforeFullMethodDescription.Parameters = secondCallBeforeMethodDescription.Parameters;
            expectedSecondCallBeforeFullMethodDescription.ParametersIndex = secondCallBeforeMethodDescription.ParametersIndex;
            expectedSecondCallBeforeFullMethodDescription.Delay = 32;
            expectedSecondCallBeforeFullMethodDescription.TimeOut = 54;
            expectedSecondCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedSecondCallBeforeFullMethodDescription.MainMethod = expectedFirstCallBeforeFullMethodDescription;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(3, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedSecondCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFirstCallBeforeFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[2], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a Then method with a complex CallBefore attributes cascade")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAWhenMethodWithAComplexCallBeforeAttributesCascade()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestFirstDynamicComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("SecondThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = string.Empty;
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 11;
            expectedMainFullMethodDescription.TimeOut = 33;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo secondCallBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription secondCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, secondCallBeforeMethodInfo);
            MethodDescription secondCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, secondCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedSecondCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedSecondCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedSecondCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedSecondCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedSecondCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedSecondCallBeforeFullMethodDescription.ExecutionOrder = secondCallBeforeMethodDescription.ExecutionOrder;
            expectedSecondCallBeforeFullMethodDescription.Parameters = secondCallBeforeMethodDescription.Parameters;
            expectedSecondCallBeforeFullMethodDescription.ParametersIndex = secondCallBeforeMethodDescription.ParametersIndex;
            expectedSecondCallBeforeFullMethodDescription.Delay = 65;
            expectedSecondCallBeforeFullMethodDescription.TimeOut = 64;
            expectedSecondCallBeforeFullMethodDescription.SuccessionOrder = 2;
            expectedSecondCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            MethodInfo firstCallBeforeMethodInfo = component.GetType().GetMethod("ThenMethod");
            BaseMethodDescription firstCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, firstCallBeforeMethodInfo);
            MethodDescription firstCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedFirstCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstCallBeforeFullMethodDescription.ComponentObject = firstCallBeforeMethodDescription.ComponentObject;
            expectedFirstCallBeforeFullMethodDescription.Method = firstCallBeforeMethodDescription.Method;
            expectedFirstCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstCallBeforeFullMethodDescription.ExecutionOrder = firstCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstCallBeforeFullMethodDescription.Parameters = firstCallBeforeMethodDescription.Parameters;
            expectedFirstCallBeforeFullMethodDescription.ParametersIndex = firstCallBeforeMethodDescription.ParametersIndex;
            expectedFirstCallBeforeFullMethodDescription.Delay = 56;
            expectedFirstCallBeforeFullMethodDescription.TimeOut = 65;
            expectedFirstCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            FullMethodDescription expectedFirstNestedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstNestedCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedFirstNestedCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedFirstNestedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstNestedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstNestedCallBeforeFullMethodDescription.ExecutionOrder = secondCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstNestedCallBeforeFullMethodDescription.Parameters = secondCallBeforeMethodDescription.Parameters;
            expectedFirstNestedCallBeforeFullMethodDescription.ParametersIndex = secondCallBeforeMethodDescription.ParametersIndex;
            expectedFirstNestedCallBeforeFullMethodDescription.Delay = 32;
            expectedFirstNestedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedFirstNestedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstNestedCallBeforeFullMethodDescription.MainMethod = expectedFirstCallBeforeFullMethodDescription;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(4, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFirstNestedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFirstCallBeforeFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedSecondCallBeforeFullMethodDescription, result[2], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[3], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Static component for a Then method with a complex CallBefore attributes cascade")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_AStaticComponentForAWhenMethodWithAComplexCallBeforeAttributesCascade()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestStaticComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestStaticComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("SecondThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = string.Empty;
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 11;
            expectedMainFullMethodDescription.TimeOut = 33;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo secondCallBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription secondCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GenericBDDMethod>(component, secondCallBeforeMethodInfo);
            MethodDescription secondCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, secondCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedSecondCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedSecondCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedSecondCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedSecondCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedSecondCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedSecondCallBeforeFullMethodDescription.ExecutionOrder = secondCallBeforeMethodDescription.ExecutionOrder;
            expectedSecondCallBeforeFullMethodDescription.Parameters = secondCallBeforeMethodDescription.Parameters;
            expectedSecondCallBeforeFullMethodDescription.ParametersIndex = secondCallBeforeMethodDescription.ParametersIndex;
            expectedSecondCallBeforeFullMethodDescription.Delay = 65;
            expectedSecondCallBeforeFullMethodDescription.TimeOut = 64;
            expectedSecondCallBeforeFullMethodDescription.SuccessionOrder = 2;
            expectedSecondCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            MethodInfo firstCallBeforeMethodInfo = component.GetType().GetMethod("ThenMethod");
            BaseMethodDescription firstCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GenericBDDMethod>(component, firstCallBeforeMethodInfo);
            MethodDescription firstCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstCallBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedFirstCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstCallBeforeFullMethodDescription.ComponentObject = firstCallBeforeMethodDescription.ComponentObject;
            expectedFirstCallBeforeFullMethodDescription.Method = firstCallBeforeMethodDescription.Method;
            expectedFirstCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstCallBeforeFullMethodDescription.ExecutionOrder = firstCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstCallBeforeFullMethodDescription.Parameters = firstCallBeforeMethodDescription.Parameters;
            expectedFirstCallBeforeFullMethodDescription.ParametersIndex = firstCallBeforeMethodDescription.ParametersIndex;
            expectedFirstCallBeforeFullMethodDescription.Delay = 56;
            expectedFirstCallBeforeFullMethodDescription.TimeOut = 65;
            expectedFirstCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            FullMethodDescription expectedFirstNestedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstNestedCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedFirstNestedCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedFirstNestedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstNestedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstNestedCallBeforeFullMethodDescription.ExecutionOrder = secondCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstNestedCallBeforeFullMethodDescription.Parameters = secondCallBeforeMethodDescription.Parameters;
            expectedFirstNestedCallBeforeFullMethodDescription.ParametersIndex = secondCallBeforeMethodDescription.ParametersIndex;
            expectedFirstNestedCallBeforeFullMethodDescription.Delay = 32;
            expectedFirstNestedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedFirstNestedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstNestedCallBeforeFullMethodDescription.MainMethod = expectedFirstCallBeforeFullMethodDescription;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(4, result.Count, "The method build doesn't return the right number of element in the list");

            Assert.AreEqual(expectedFirstNestedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFirstCallBeforeFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedSecondCallBeforeFullMethodDescription, result[2], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[3], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a Then method with a CallBefore attribute calling a method with parameters")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAThenMethodWithACallBeforeAttributeCallingAMethodWIthParameters()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestFirstDynamicComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("ThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = ";System.String,FullMethodDescriptionBuilderUTDynamicBDDForTest.ThenMethod.stringParam.,stringPVS.Array.data[0]" +
                                     ";System.String,FullMethodDescriptionBuilderUTDynamicBDDForTest.SecondGivenMethod.stringParam.,stringPVS.Array.data[1]";
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo stringPVS = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            string[] stringArray = new string[2] { "FirstElementForTheMainMethod", "SecondElementForTheCallBeforeMethod" };
            stringPVS.SetValue(component, stringArray);
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 0;
            expectedMainFullMethodDescription.TimeOut = 3000;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo callBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription callBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, callBeforeMethodInfo);
            MethodDescription callBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, callBeforeBaseMethodDescription, parametersIndex);

            FullMethodDescription expectedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedCallBeforeFullMethodDescription.ComponentObject = callBeforeMethodDescription.ComponentObject;
            expectedCallBeforeFullMethodDescription.Method = callBeforeMethodDescription.Method;
            expectedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedCallBeforeFullMethodDescription.ExecutionOrder = callBeforeMethodDescription.ExecutionOrder;
            expectedCallBeforeFullMethodDescription.Parameters = callBeforeMethodDescription.Parameters;
            expectedCallBeforeFullMethodDescription.ParametersIndex = string.Empty;
            expectedCallBeforeFullMethodDescription.Delay = 32;
            expectedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(2, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a Then method with a CallBefore attribute with Id property calling a method with parameters")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAThenMethodWithACallBeforeAttributeWithIdPropertyCallingAMethodWithParameters()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestSecondDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestSecondDynamicComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("ThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.ThenMethod.stringParam.,stringPVS.Array.data[0]" +
                                     ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.SecondGivenMethod.stringParam.ThenMethod,stringPVS.Array.data[1]";
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo stringPVS = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            string[] stringArray = new string[2] { "FirstElementForTheMainMethod", "SecondElementForTheCallBeforeMethod" };
            stringPVS.SetValue(component, stringArray);
            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 0;
            expectedMainFullMethodDescription.TimeOut = 3000;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo callBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription callBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, callBeforeMethodInfo);
            MethodDescription callBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, callBeforeBaseMethodDescription, parametersIndex);

            string callBeforeId = "ThenMethod";
            MethodParameters callBeforeParameters = methodParametersLoader.LoadMethodParameters(component, callBeforeMethodInfo, callBeforeId, parametersIndex);

            FullMethodDescription expectedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedCallBeforeFullMethodDescription.ComponentObject = callBeforeMethodDescription.ComponentObject;
            expectedCallBeforeFullMethodDescription.Method = callBeforeMethodDescription.Method;
            expectedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedCallBeforeFullMethodDescription.ExecutionOrder = callBeforeMethodDescription.ExecutionOrder;

            expectedCallBeforeFullMethodDescription.Parameters = callBeforeParameters;
            expectedCallBeforeFullMethodDescription.ParametersIndex = string.Empty;
            expectedCallBeforeFullMethodDescription.Delay = 32;
            expectedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;
            expectedCallBeforeFullMethodDescription.Id = "ThenMethod";

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(expectedMainFullMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(2, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
        }

        [Test]
        [Description("Build method should return the expected FullMethodDescription objects list given a Dynamic component for a Then method with a complex CallBefore attributes cascade with Id properties calling methods with parameters")]
        public void Build_Should_ReturnTheExpectedFullMethodDescriptionObjectsList_Given_ADynamicComponentForAThenMethodWithAComplexCallBeforeAttributeCascadeWithIdPropertiesCallingMethodsWithParameters()
        {
            // Create the MethodDescription
            FullMethodDescriptionBuilderTestSecondDynamicComponent component = UnitTestUtility.CreateComponent<FullMethodDescriptionBuilderTestSecondDynamicComponent>();
            MethodInfo mainMethodInfo = component.GetType().GetMethod("SecondThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.SecondGivenMethod.stringParam.SecondThenMethod_ThenMethod,stringPVS.Array.data[0]" +
                ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.ThenMethod.stringParam.SecondThenMethod,stringPVS.Array.data[1]" +
                ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.SecondGivenMethod.stringParam.SecondThenMethod,stringPVS.Array.data[2]" +
                ";System.Int32,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.SecondThenMethod.intParam.,intPVS.Array.data[0]" +
                ";System.String,FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID.SecondThenMethod.stringParam.,stringPVS.Array.data[3]";
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo stringPVS = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            string[] stringArray = new string[4] { "1", "2", "3", "4" };
            stringPVS.SetValue(component, stringArray);

            FieldInfo intPVS = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            int[] intArray = new int[1] { 1 };
            intPVS.SetValue(component, intArray);

            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            FullMethodDescription expectedMainFullMethodDescription = new FullMethodDescription();
            expectedMainFullMethodDescription.ComponentObject = mainMethodDescription.ComponentObject;
            expectedMainFullMethodDescription.Method = mainMethodDescription.Method;
            expectedMainFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedMainFullMethodDescription.Text = mainMethodDescription.Text;
            expectedMainFullMethodDescription.ExecutionOrder = mainMethodDescription.ExecutionOrder;
            expectedMainFullMethodDescription.Parameters = mainMethodDescription.Parameters;
            expectedMainFullMethodDescription.ParametersIndex = mainMethodDescription.ParametersIndex;
            expectedMainFullMethodDescription.Delay = 11;
            expectedMainFullMethodDescription.TimeOut = 33;
            expectedMainFullMethodDescription.SuccessionOrder = 1;
            expectedMainFullMethodDescription.MainMethod = null;

            MethodInfo secondCallBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription secondCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, secondCallBeforeMethodInfo);
            MethodDescription secondCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, secondCallBeforeBaseMethodDescription, parametersIndex);

            string secondCallBeforeId = "SecondThenMethod";
            MethodParameters secondCallBeforeParameters = methodParametersLoader.LoadMethodParameters(component, secondCallBeforeMethodInfo, secondCallBeforeId, parametersIndex);

            FullMethodDescription expectedSecondCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedSecondCallBeforeFullMethodDescription.ComponentObject = secondCallBeforeMethodDescription.ComponentObject;
            expectedSecondCallBeforeFullMethodDescription.Method = secondCallBeforeMethodDescription.Method;
            expectedSecondCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedSecondCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedSecondCallBeforeFullMethodDescription.ExecutionOrder = secondCallBeforeMethodDescription.ExecutionOrder;
            expectedSecondCallBeforeFullMethodDescription.Parameters = secondCallBeforeParameters;
            expectedSecondCallBeforeFullMethodDescription.ParametersIndex = string.Empty;
            expectedSecondCallBeforeFullMethodDescription.Delay = 65;
            expectedSecondCallBeforeFullMethodDescription.TimeOut = 64;
            expectedSecondCallBeforeFullMethodDescription.SuccessionOrder = 2;
            expectedSecondCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;
            expectedSecondCallBeforeFullMethodDescription.Id = "SecondThenMethod";

            MethodInfo firstCallBeforeMethodInfo = component.GetType().GetMethod("ThenMethod");
            BaseMethodDescription firstCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, firstCallBeforeMethodInfo);
            MethodDescription firstCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstCallBeforeBaseMethodDescription, parametersIndex);

            string firstCallBeforeId = "SecondThenMethod";
            MethodParameters firstCallBeforeParameters = methodParametersLoader.LoadMethodParameters(component, firstCallBeforeMethodInfo, firstCallBeforeId, parametersIndex);

            FullMethodDescription expectedFirstCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstCallBeforeFullMethodDescription.ComponentObject = firstCallBeforeMethodDescription.ComponentObject;
            expectedFirstCallBeforeFullMethodDescription.Method = firstCallBeforeMethodDescription.Method;
            expectedFirstCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstCallBeforeFullMethodDescription.ExecutionOrder = firstCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstCallBeforeFullMethodDescription.Parameters = firstCallBeforeParameters;
            expectedFirstCallBeforeFullMethodDescription.ParametersIndex = string.Empty;
            expectedFirstCallBeforeFullMethodDescription.Delay = 56;
            expectedFirstCallBeforeFullMethodDescription.TimeOut = 65;
            expectedFirstCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstCallBeforeFullMethodDescription.MainMethod = expectedMainFullMethodDescription;
            expectedFirstCallBeforeFullMethodDescription.Id = "SecondThenMethod";

            MethodInfo firstNestedCallBeforeMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            BaseMethodDescription firstNestedCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, firstNestedCallBeforeMethodInfo);
            MethodDescription firstNestedCallBeforeMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstNestedCallBeforeBaseMethodDescription, parametersIndex);

            string firstNestedCallBeforeId = "SecondThenMethod_ThenMethod";
            MethodParameters firstNestedCallBeforeParameters = methodParametersLoader.LoadMethodParameters(component, firstNestedCallBeforeMethodInfo, firstNestedCallBeforeId, parametersIndex);

            FullMethodDescription expectedFirstNestedCallBeforeFullMethodDescription = new FullMethodDescription();
            expectedFirstNestedCallBeforeFullMethodDescription.ComponentObject = firstNestedCallBeforeMethodDescription.ComponentObject;
            expectedFirstNestedCallBeforeFullMethodDescription.Method = firstNestedCallBeforeMethodDescription.Method;
            expectedFirstNestedCallBeforeFullMethodDescription.StepType = mainMethodDescription.StepType;
            expectedFirstNestedCallBeforeFullMethodDescription.Text = mainMethodDescription.Text;
            expectedFirstNestedCallBeforeFullMethodDescription.ExecutionOrder = firstNestedCallBeforeMethodDescription.ExecutionOrder;
            expectedFirstNestedCallBeforeFullMethodDescription.Parameters = firstNestedCallBeforeParameters;
            expectedFirstNestedCallBeforeFullMethodDescription.ParametersIndex = string.Empty;
            expectedFirstNestedCallBeforeFullMethodDescription.Delay = 32;
            expectedFirstNestedCallBeforeFullMethodDescription.TimeOut = 54;
            expectedFirstNestedCallBeforeFullMethodDescription.SuccessionOrder = 1;
            expectedFirstNestedCallBeforeFullMethodDescription.MainMethod = expectedFirstCallBeforeFullMethodDescription;
            expectedFirstNestedCallBeforeFullMethodDescription.Id = "ThenMethod";

            // Build the fullMethodDescription
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> result = fullMethodDescriptionBuilder.Build(expectedMainFullMethodDescription, 1);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(4, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFirstNestedCallBeforeFullMethodDescription, result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFirstCallBeforeFullMethodDescription, result[1], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedSecondCallBeforeFullMethodDescription, result[2], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedMainFullMethodDescription, result[3], "The method build doesn't return the right fullMethodDescription");
        }
    }
}

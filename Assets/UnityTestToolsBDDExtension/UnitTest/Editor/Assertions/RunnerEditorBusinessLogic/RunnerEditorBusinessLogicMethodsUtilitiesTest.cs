//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicMethodsUtilitiesTest.cs" company="Hud Dimension">
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
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class RunnerEditorBusinessLogicMethodsUtilitiesTest
    {
        [Test]
        [Description("AddMissedMethodNameToMethodsNames method should add at the the end of the string array another element with the passed string")]
        public void AddMissedMethodNameToMethodsNames_Should_AddAtTheEndOfTheStringArrayAnotherElementWithThePassedString()
        {
            string[] methodsNames = new string[3] { "FirstMethodName", "SecondMethodName", "ThirdMethodName" };
            string methodName = "MissedMethodName";
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();
            string[] result = methodsUtilities.AddMissedMethodNameToMethodsNames(methodName, methodsNames);
            Assert.AreEqual(4, result.Length, "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.AddMissedMethodNameToMethodsNames doesn't return the right amount of elements.");
            Assert.AreEqual(methodsNames[0], result[0], "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.AddMissedMethodNameToMethodsNames doesn't return the right elements.");
            Assert.AreEqual(methodsNames[1], result[1], "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.AddMissedMethodNameToMethodsNames doesn't return the right elements.");
            Assert.AreEqual(methodsNames[2], result[2], "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.AddMissedMethodNameToMethodsNames doesn't return the right elements.");
            Assert.AreEqual(methodName, result[3], "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.AddMissedMethodNameToMethodsNames doesn't add the new method name at the end of the array.");
        }

        [Test]
        [Description("GetMethodDescriptionForTheChosenMethod method should return the expected MethodDescription object given a Dynamic component and the method full name and the parametersIndexes")]
        public void GetMethodDescriptionForTheChosenMethod_Should_ReturnTheExpectedMethodDescriptionObject_Given_ADynamicComponentAndTheMethodFullNameAndTheParametersIndexes()
        {
            MethodDescriptionBuilder methodDescriptionBuilder = Substitute.For<MethodDescriptionBuilder>();

            MethodParametersLoader parametersLoader = Substitute.For<MethodParametersLoader>();

            RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[2] { "FirstValue", "SecondValue" });

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            firstIntArrayStorage.SetValue(component, new int[2] { 33, 14 });

            MethodInfo method = component.GetType().GetMethod("WhenMethod");
            string parametersIndex = ";string,RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            MethodParameters methodParameters = methodParametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex);
            parametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex).Returns(methodParameters);

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, method);

            MethodDescriptionBuilder methodDescriptionBuilderInstance = new MethodDescriptionBuilder();
            MethodDescription methodDescription = methodDescriptionBuilderInstance.Build(parametersLoader, baseMethodDescription, parametersIndex);
            methodDescriptionBuilder.Build(parametersLoader, baseMethodDescription, parametersIndex).Returns(methodDescription);

            string chosenMethodName = "RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent.WhenMethod";
            string chosenMethodParametersIndex = parametersIndex;
            List<BaseMethodDescription> methodList = new List<BaseMethodDescription>();
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("SecondWhenMethod")));
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("WhenMethod")));
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("ThirdWhenMethod")));

            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();
            MethodDescription result = methodsUtilities.GetMethodDescriptionForTheChosenMethod(methodDescriptionBuilder, parametersLoader, chosenMethodName, chosenMethodParametersIndex, methodList);

            Assert.IsTrue(methodDescription.Equals(result), "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.GetMethodDescriptionForTheChosenMethod doesn't return the right object");
        }

        [Test]
        [Description("GetMethodDescriptionForTheChosenMethod method should return null given a Dynamic component and an empty string as method full name")]
        public void GetMethodDescriptionForTheChosenMethod_Should_ReturnNull_Given_ADynamicComponentAdnAnEmptyStringAsMethodFullName()
        {
            MethodDescriptionBuilder methodDescriptionBuilder = Substitute.For<MethodDescriptionBuilder>();

            MethodParametersLoader parametersLoader = Substitute.For<MethodParametersLoader>();

            RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[2] { "FirstValue", "SecondValue" });

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            firstIntArrayStorage.SetValue(component, new int[2] { 33, 14 });

            MethodInfo method = component.GetType().GetMethod("WhenMethod");
            string parametersIndex = ";string,RunnerEditorBusinessLogicMethodsUtilitiesUTDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicMethodsUtilitiesUTDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            MethodParameters methodParameters = methodParametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex);
            parametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex).Returns(methodParameters);

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, method);

            MethodDescriptionBuilder methodDescriptionBuilderInstance = new MethodDescriptionBuilder();
            MethodDescription methodDescription = methodDescriptionBuilderInstance.Build(parametersLoader, baseMethodDescription, parametersIndex);
            methodDescriptionBuilder.Build(parametersLoader, baseMethodDescription, parametersIndex).Returns(methodDescription);

            string chosenMethodName = string.Empty;
            string chosenMethodParametersIndex = string.Empty;
            List<BaseMethodDescription> methodList = new List<BaseMethodDescription>();
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("SecondWhenMethod")));
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("WhenMethod")));
            methodList.Add(baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, component.GetType().GetMethod("ThirdWhenMethod")));

            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();
            MethodDescription result = methodsUtilities.GetMethodDescriptionForTheChosenMethod(methodDescriptionBuilder, parametersLoader, chosenMethodName, chosenMethodParametersIndex, methodList);

            Assert.IsNull(result, "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.GetMethodDescriptionForTheChosenMethod doesn't return the right object");
        }

        [Test]
        [Description("UpdateDataIfNewMethodIsChosen method should update the expected data and return true given the current chosen method is different to the previous that was empty")]
        public void UpdateDataIfNewMethodIsChosen_Should_UpdateTheExpectedDataAndReturnTrue_Given_TheCurrentChosenMethodIsDifferenToThePreviousThatWasEmpty()
        {
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();

            string[] expectedChosenMethodsNames = new string[3] { "DynamicBDDForTest.SecondWhenMethod", "DynamicBDDForTest.SecondWhenMethod", string.Empty };

            string[] expectedChosenMethodsParametersIndex = new string[3] { string.Empty, "SecondParametersIndex", string.Empty };

            bool[] expectedFoldouts = new bool[10] { false, true, true, true, true, true, true, true, true, true };

            bool expectedRebuild = true;

            string newChosenMethod = "DynamicBDDForTest.SecondWhenMethod";
            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { string.Empty, "DynamicBDDForTest.SecondWhenMethod", string.Empty };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { string.Empty, "SecondParametersIndex", string.Empty };
            bool[] foldouts = new bool[10] { false, true, true, true, true, true, true, true, true, true };
            int index = 0;
            bool rebuild = false;
            rebuild = methodsUtilities.UpdateDataIfNewMethodIsChosen(newChosenMethod, chosenMethods, foldouts, index, rebuild);

            Assert.AreEqual(expectedChosenMethodsNames, chosenMethods.ChosenMethodsNames, "The method UpdateDataIfNewMethodIsChosen does not return the right ChosenMethods object");

            Assert.AreEqual(expectedChosenMethodsParametersIndex, chosenMethods.ChosenMethodsParametersIndex, "The method UpdateDataIfNewMethodIsChosen does not return the right ChosenMethods object");

            Assert.AreEqual(expectedFoldouts, foldouts, "The method UpdateDataIfNewMethodIsChosen does not return the right foldout state");

            Assert.AreEqual(expectedRebuild, rebuild, "The method UpdateDataIfNewMethodIsChosen does not return the right rebuild state");
        }

        [Test]
        [Description("UpdateDataIfNewMethodIsChosen method should update the expected data and return true given the current chosen method is different to the previous")]
        public void UpdateDataIfNewMethodIsChosen_Should_UpdateTheExpectedDataAndReturnTrue_Given_TheCurrentChosenMethodIsDifferenToThePrevious()
        {
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();

            string[] expectedChosenMethodsNames = new string[3] { "DynamicBDDForTest.SecondWhenMethod", "DynamicBDDForTest.SecondWhenMethod", string.Empty };

            string[] expectedChosenMethodsParametersIndex = new string[3] { "FirstParametersIndex", "SecondParametersIndex", string.Empty };

            bool[] expectedFoldouts = new bool[10] { false, true, true, true, true, true, true, true, true, true };

            bool expectedRebuild = true;

            string newChosenMethod = "DynamicBDDForTest.SecondWhenMethod";
            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { "DynamicBDDForTest.WhenMethod", "DynamicBDDForTest.SecondWhenMethod", string.Empty };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "FirstParametersIndex", "SecondParametersIndex", string.Empty };
            bool[] foldouts = new bool[10] { true, true, true, true, true, true, true, true, true, true };
            int index = 0;
            bool rebuild = false;
            rebuild = methodsUtilities.UpdateDataIfNewMethodIsChosen(newChosenMethod, chosenMethods, foldouts, index, rebuild);

            Assert.AreEqual(expectedChosenMethodsNames, chosenMethods.ChosenMethodsNames, "The method UpdateDataIfNewMethodIsChosen does not return the right ChosenMethods object");

            Assert.AreEqual(expectedChosenMethodsParametersIndex, chosenMethods.ChosenMethodsParametersIndex, "The method UpdateDataIfNewMethodIsChosen does not return the right ChosenMethods object");

            Assert.AreEqual(expectedFoldouts, foldouts, "The method UpdateDataIfNewMethodIsChosen does not return the right foldout state");

            Assert.AreEqual(expectedRebuild, rebuild, "The method UpdateDataIfNewMethodIsChosen does not return the right rebuild state");
        }

        [Test]
        [Description("GetMethodsNames method should return the expected array of strings containing the full names of the methods given a list of BaseMethodDescription objects")]
        public void GetMethodsNames_Should_ReturnTheExpectedArrayOfStringsContainingTheFullNamesOfTheMethods_Given_ALIstOfBaseMethodDescriptionObjects()
        {
            string[] expectedResult = new string[3];
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicMethodsUtilitiesTestDynamicComponent>() };
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methodsList = bddStepMethodsLoader.LoadStepMethods<WhenBaseAttribute>(components);
            expectedResult[0] = methodsList[0].GetFullName();
            expectedResult[1] = methodsList[1].GetFullName();
            expectedResult[2] = methodsList[2].GetFullName();
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();
            string[] result = methodsUtilities.GetMethodsNames(methodsList);
            Assert.AreEqual(expectedResult, result, "The method UnityTestToolsBDDExtensionRunnerEditorBusinessLogic.GetMethodsNames doesn't return the right list of methods names.");
        }
    }
}
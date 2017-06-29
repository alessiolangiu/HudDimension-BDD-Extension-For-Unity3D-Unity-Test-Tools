//-----------------------------------------------------------------------
// <copyright file="ChosenMethodsCheckerTest.cs" company="Hud Dimension">
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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ChosenMethodsCheckerTest
    {
        [Test]
        [Description("CheckForBlankMethods method should return the expected list of UnityTestBDDError objects given a chosen methods list without empty elements")]
        public void CheckForBlankMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AChosenMethodsListWithoutEmptyElements()
        {
            string[] chosenMethods = new string[5] { "class.method", "class.method", "class.method", "class.method", "class.method" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForBlankMethods<GivenBaseAttribute>(chosenMethods);
            Assert.AreEqual(0, result.Count, "The method CheckForBlankMethods doesn't check properly");
        }

        [Test]
        [Description("CheckForBlankMethods method should return the expected list of UnityTestBDDError objects given a chosen methods list with an empty element")]
        public void CheckForBlankMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AChosenMethodsListWithAnEmptyElement()
        {
            string[] chosenMethods = new string[5] { "class.method", "class.method", string.Empty, "class.method", "class.method" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForBlankMethods<GivenBaseAttribute>(chosenMethods);
            Assert.AreEqual(1, result.Count, "The method CheckForBlankMethods doesn't check properly");
            string expectedMessage = "Incomplete settings detected on Given methods at position 3";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForBlankMethods doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckForBlankMethods doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckForBlankMethods doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForBlankMethods doesn't resturn the right StepType");
            Assert.AreEqual(2, result[0].Index, "The method CheckForBlankMethods doesn't resturn the right method index");
        }

        [Test]
        [Description("CheckForMethodNotFound method should return the expected list of UnityTestBDDError objects given a list of chosen methods and a Dynamic component with all the methods in the list")]
        public void CheckForMethodNotFound_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AListOfChosenMethodsAndADynamicComponentWithAllMethodsInTheList()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "ChosenMethodsCheckerTestFirstDynamicComponent.ThenMethod", "ChosenMethodsCheckerTestFirstDynamicComponent.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForMethodNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(0, result.Count, "The method CheckForMethodNotFound doesn't check properly");
        }

        [Test]
        [Description("CheckForMethodNotFound method should return the expected list of UnityTestBDDError objects given a list of chosen methods and a Dynamic component without a method in the list")]
        public void CheckForMethodNotFound_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AListOfChosenMethodsAndADynamicComponentWithoutAMethodInTheList()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "ChosenMethodsCheckerTestFirstDynamicComponent.ThenMethod", "ChosenMethodsCheckerTestFirstDynamicComponent.FakeSecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForMethodNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(1, result.Count, "The method CheckForMethodNotFound doesn't check properly");
            string expectedMessage = "Method ChosenMethodsCheckerTestFirstDynamicComponent.FakeSecondThenMethod not found on Then methods at position 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForMethodNotFound doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckForMethodNotFound doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckForMethodNotFound doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(ThenBaseAttribute), result[0].StepType, "The method CheckForMethodNotFound doesn't resturn the right StepType");
            Assert.AreEqual(1, result[0].Index, "The method CheckForMethodNotFound doesn't resturn the right method index");
        }

        [Test]
        [Description("CheckForComponentNotFound method should return the expected list of UnityTestBDDError objects given a list of chosen methods and the corresponding Dynamic components")]
        public void CheckForComponentNotFound_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AListOfChosenMethodsAndTheCorrespondingDynamicComponents()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "ChosenMethodsCheckerTestFirstDynamicComponent.ThenMethod", "ChosenMethodsCheckerTestFirstDynamicComponent.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForComponentNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(0, result.Count, "The method CheckForMethodNotFound doesn't check properly");
        }

        [Test]
        [Description("CheckForComponentNotFound method should return the expected list of UnityTestBDDError objects given a list of chosen methods without a corresponding Dynamic component")]
        public void CheckForComponentNotFound_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AListOfChosenMethodsWithoutACorrespondingDynamicComponent()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "ChosenMethodsCheckerTestFirstDynamicComponentFake.ThenMethod", "ChosenMethodsCheckerTestFirstDynamicComponent.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForComponentNotFound<ThenBaseAttribute>(chosenMethods, components);
            string expectedMessage = "The component for the method ChosenMethodsCheckerTestFirstDynamicComponentFake.ThenMethod is not found  in Then methods at position 1";

            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForComponentNotFound doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckForComponentNotFound doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckForComponentNotFound doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(ThenBaseAttribute), result[0].StepType, "The method CheckForComponentNotFound doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForComponentNotFound doesn't resturn the right method index");
        }

        [Test]
        [Description("CheckForNotMatchingParametersIndex method should return the expected list of UnityTestBDDError objects given the parametersIndexes and the Dynamic component with the corresponding methods and parameters")]
        public void CheckForNotMatchingParametersIndex_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TheParametersIndexesAndTheDynamicComponentWithTheCorrespondingMethodsAndParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[1] { "ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod" };
            string[] parametersIndex = new string[1] { ";System.String,ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParam.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndex, components);
            Assert.AreEqual(0, result.Count, "The method CheckForNotMatchingParametersIndex doesn't check properly");
        }

        [Test]
        [Description("CheckForNotMatchingParametersIndex method should return the expected list of UnityTestBDDError objects given the parametersIndexes and the Dynamic component with the corresponding methods but without a corresponding parameter")]
        public void CheckForNotMatchingParametersIndex_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TheParametersIndexesAndTheDynamicComponentWithTheCorrespondingMethodsButWithoutACorrespondingParameter()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParamWrongName.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            string expectedMessage = "The parameter ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParamWrongName is not found in Given methods at position 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingParametersIndex doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingParametersIndex doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingParametersIndex doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingParametersIndex doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingParametersIndex doesn't resturn the right method index");
        }

        [Test]
        [Description("CheckForNotMatchingParametersIndex method should return the expected list of UnityTestBDDError objects given the parametersIndexes and the Dynamic component with the corresponding methods but with a parameter with different type")]
        public void CheckForNotMatchingParametersIndex_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TheParametersIndexesAndTheDynamicComponentWithTheCorrespondingMethodsButWithAParameterWithDifferentType()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            string[] chosenMethods = new string[1] { "ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.Int32,ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParam.,intPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            string expectedMessage = "The parameter ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParam has a wrong type in Given methods at position 1.\n Previous type: System.Int32\n Current type System.String";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingParametersIndex doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingParametersIndex doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingParametersIndex doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingParametersIndex doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingParametersIndex doesn't resturn the right method index");
        }

        [Test]
        [Description("CheckForNotMatchingPVS method should return the expected list of UnityTestBDDError objects given a parametersIndexes and a Dynamic component with the corresponding ParametersValuesStorages")]
        public void CheckForNotMatchingPVS_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TheParametersIndexesAndADynamicComponentWithTheCorrespondingParametersValuesStorages()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[1] { "ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParamWrongName.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingPVS<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            Assert.AreEqual(0, result.Count, "The method CheckForNotMatchingPVS doesn't check properly");
        }

        [Test]
        [Description("CheckForNotMatchingPVS method should return the expected list of UnityTestBDDError objects given a parametersIndexes and a Dynamic component without a corresponding ParametersValuesStorages")]
        public void CheckForNotMatchingPVS_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TheParametersIndexesAndADynamicComponentWithoutACorrespondingParametersValuesStorages()
        {
            Component component = UnitTestUtility.CreateComponent<ChosenMethodsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] chosenMethods = new string[1] { "ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParam.,otherPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingPVS<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);

            string expectedMessage = "The ParametersValuesStorage field otherPVS for the parameter ChosenMethodsCheckerTestFirstDynamicComponent.GivenMethod.stringParam. is not found in Given methods at position 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingPVS doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingPVS doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingPVS doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingPVS doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingPVS doesn't resturn the right method index");
        }
    }
}
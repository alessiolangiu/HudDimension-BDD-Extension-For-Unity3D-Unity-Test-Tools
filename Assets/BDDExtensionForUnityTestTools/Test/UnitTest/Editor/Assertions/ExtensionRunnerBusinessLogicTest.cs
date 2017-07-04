//-----------------------------------------------------------------------
// <copyright file="ExtensionRunnerBusinessLogicTest.cs" company="Hud Dimension">
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
using System;
using System.Collections.Generic;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class ExtensionRunnerBusinessLogicTest
    {
        [TearDown]
        public void Cleanup()
        {
            UnitTestUtility.DestroyTemporaryTestGameObjects();
        }

        [Test]
        [Description("GetAllMethodsDescriptions method should return the expected list of FullMethodDescription objects given a the complete list of Given When Then chosen methods with nested CallBefore attributes for Dynamic components")]
        public void GetAllMethodsDescriptions_Should_ReturnTheExpectedListOfFullMethodDescriptionObjects_Given_ACompleteListOfGivenWhenThenChosenMethodsWithNestedCallBeforeAttributesForDynamicComponents()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> resultList = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            string expecetdMethod1 = "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod";
            string expecetdMethod2 = "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod";
            string expecetdMethod3 = "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod";
            string expecetdMethod4 = "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod";
            string expecetdMethod5 = "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod";

            string expecetdMethod6 = "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod";
            string expecetdMethod7 = "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.ThenMethod";
            string expecetdMethod8 = "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod";
            string expecetdMethod9 = "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod";

            string expecetdMethod10 = "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.SecondGivenMethod";
            string expecetdMethod11 = "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod";

            Assert.AreEqual(11, resultList.Count, "The method GetAllMethodsDescriptions doesn't return the right number of methods.");
            Assert.AreEqual(expecetdMethod1, resultList[0].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod2, resultList[1].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod3, resultList[2].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod4, resultList[3].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod5, resultList[4].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod6, resultList[5].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod7, resultList[6].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod8, resultList[7].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod9, resultList[8].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod10, resultList[9].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod11, resultList[10].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
        }

        [Test]
        [Description("GetAllMethodsDescriptions method should return the expected list of FullMethodDescription objects given a Static component with nested CallBefore attributes")]
        public void GetAllMethodsDescriptions_Should_ReturnTheExpectedListOfFullMethodDescriptionObjects_Given_AStaticComponentWithNestedCallBeforeAttributes()
        {
            ExtensionRunnerBusinessLogicTestFirstStaticComponent component = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstStaticComponent>();
            Component[] components = new Component[1] { component };

            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> resultList = businessLogic.GetAllMethodsDescriptions(components, null, null, null, null, null, null);

            string expecetdMethod1 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.GivenMethod";
            string expecetdMethod5 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.WhenMethod";

            string expecetdMethod6 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.SecondGivenMethod";
            string expecetdMethod7 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.ThenMethod";
            string expecetdMethod8 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.SecondGivenMethod";
            string expecetdMethod9 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.SecondThenMethod";

            string expecetdMethod10 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.SecondGivenMethod";
            string expecetdMethod11 = "ExtensionRunnerBusinessLogicTestFirstStaticComponent.ThenMethod";

            Assert.AreEqual(8, resultList.Count, "The method GetAllMethodsDescriptions doesn't return the right number of methods.");
            Assert.AreEqual(expecetdMethod1, resultList[0].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod5, resultList[1].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod6, resultList[2].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod7, resultList[3].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod8, resultList[4].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod9, resultList[5].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod10, resultList[6].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
            Assert.AreEqual(expecetdMethod11, resultList[7].GetFullName(), "The method GetAllMethodsDescriptions doesn't return the right methods order.");
        }

        [Test]
        [Description("RunCycle method should perform the expected calls for the first method in the list and return the index for the next method given the method has not a configured delay")]
        public void RunCycle_Should_PerformTheExpectedCallsForTheFirstMethodInTheListAndReturnTheIndexForTheNextMethod_Given_TheMethodHasNotAConfiguredDelay()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);
            mockedBusinessLogic.RunnerGameObject = gameObject;

            List<FullMethodDescription> methodsDescription = new List<FullMethodDescription>();
            methodsDescription.Add(methodDescription);
            methodsDescription.Add(Substitute.For<FullMethodDescription>());

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(firstNowDatetime);
            mockedBusinessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject).Returns<bool>(true);

            int indexToRun = -1;
            int newIndexToRun = businessLogic.RunCycle(mockedBusinessLogic, methodsDescription, indexToRun);
            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);
                mockedBusinessLogic.DateTimeNow();
            });
            Assert.AreEqual(1, newIndexToRun, "The method RunCycle doesn't return the right value");
        }

        [Test]
        [Description("RunCycle method should perform the expected calls for the first method in the list and return the same index given the method has not a delay configured and the method returns an AssertionResultRetry object")]
        public void RunCycle_Should_PerformTheExpectedCallsForTheFirstMethodInTheListAndReturnTheSameIndex_Given_TheMethodHasNotAConfiguredDelayAndTheMethodReturnsAnAssertionResultRetryObject()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultRetry("message");
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);
            mockedBusinessLogic.RunnerGameObject = gameObject;
            List<FullMethodDescription> methodsDescription = new List<FullMethodDescription>();
            methodsDescription.Add(methodDescription);
            methodsDescription.Add(Substitute.For<FullMethodDescription>());

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(firstNowDatetime);
            mockedBusinessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject).Returns<bool>(false);

            int indexToRun = -1;
            int newIndexToRun = businessLogic.RunCycle(mockedBusinessLogic, methodsDescription, indexToRun);
            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);
            });
            Assert.AreEqual(0, newIndexToRun, "The method RunCycle doesn't return the right value");
        }

        [Test]
        [Description("RunCycle method should perform the expected calls given it is invoked after the last method in the list")]
        public void RunCycle_ShouldPerFormTheExpectedCalls_Given_ItIsInvokedAfterTheLastMethodInTheList()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            ExtensionRunnerBusinessLogicTestFirstStaticComponent component = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstStaticComponent>();
            Component[] components = new Component[1] { component };

            List<FullMethodDescription> methodsDescription = businessLogic.GetAllMethodsDescriptions(components, null, null, null, null, null, null);

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            mockedBusinessLogic.InvokeMethod(businessLogic, methodsDescription[0], gameObject).Returns<bool>(true);

            int indexToRun = 8;
            businessLogic.RunCycle(mockedBusinessLogic, methodsDescription, indexToRun);
            Received.InOrder(() =>
            {
                businessLogic.InvokeAssertionSuccess(gameObject);
            });
        }

        [Test]
        [Description("InvokeMethod method should return true given the invoked method returns a AssertionResultSuccessful object")]
        public void InvokeMethod_Should_ReturnTrue_Given_TheInvokedMethodReturnsAAssertionResultSuccessfulObject()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.StartDelayTime = firstNowDatetime;
            DateTime secondNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(secondNowDatetime);
            mockedBusinessLogic.GetParametersValues(methodDescription).Returns<object[]>(parameters);
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            methodDescription.Method = mockedMethodInfo;
            bool result = businessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);

            Assert.IsTrue(result, "The method InvokeMethod doesn't return the right state");
        }

        [Test]
        [Description("InvokeMethod method should perform the expected calls and return false given the invoked method returns a AssertionResultRetry object")]
        public void InvokeMethod_Should_PerformTheExpectedCallsAndReturnFalse_Given_TheInvokedMethodReturnsAAssertionResultRetryObject()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            string errorText = "message";
            IAssertionResult methodInvokeAssertionResult = new AssertionResultRetry(errorText);
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.StartDelayTime = firstNowDatetime;
            DateTime secondNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(secondNowDatetime);

            mockedBusinessLogic.GetParametersValues(methodDescription).Returns<object[]>(parameters);
            string scenarioText = "scenarioText";
            string bddMethodLocation = "bddMethodLocation";
            List<FullMethodDescription> methods = new List<FullMethodDescription>();
            methods.Add(methodDescription);

            mockedBusinessLogic.MethodsDescription = methods;
            mockedBusinessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription).Returns(scenarioText);
            mockedBusinessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription).Returns(bddMethodLocation);

            bool result = businessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);

            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.GetParametersValues(methodDescription);
                mockedMethodInfo.Invoke(component, parameters);
                mockedBusinessLogic.DateTimeNow();

                mockedBusinessLogic.InvokeAssertionFailed(errorText, scenarioText, bddMethodLocation, gameObject);
            });
            Assert.IsFalse(result, "The method InvokeMethod doesn't return the right state");
        }

        [Test]
        [Description("InvokeMethod method should perform the expected calls and return false given the invoked method has a not reached delay")]
        public void InvokeMethod_Should_PerformTheExpectedCallsAndReturnFalse_GivenTheInvokedMethodHasANotReachedDelay()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.Delay = 1000;

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.StartDelayTime = firstNowDatetime;
            DateTime secondNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 990);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(secondNowDatetime);
            mockedBusinessLogic.GetParametersValues(methodDescription).Returns<object[]>(parameters);
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            methodDescription.Method = mockedMethodInfo;
            bool result = businessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);

            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
            });

            Assert.IsFalse(result, "The method InvokeMethod doesn't return the right state");
        }

        [Test]
        [Description("InvokeMethod method should perform the expected calls and return true given the invoked method has a reached delay and returns a AssertionResultSuccessful object")]
        public void InvokeMethod_Should_PerformTheExpectedCallsAndReturnTrue_Given_TheInvokedMethodHasAReachedDelayAndReturnsAAssertionResultSuccessfulObject()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.Delay = 1000;

            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.StartDelayTime = firstNowDatetime;
            DateTime secondNowDatetime = new DateTime(2017, 05, 01, 00, 00, 01, 001);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(secondNowDatetime);
            mockedBusinessLogic.GetParametersValues(methodDescription).Returns<object[]>(parameters);
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            methodDescription.Method = mockedMethodInfo;
            bool result = businessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);

            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.GetParametersValues(methodDescription);
                mockedMethodInfo.Invoke(component, parameters);
            });

            Assert.IsTrue(result, "The method InvokeMethod doesn't return the right state");
        }

        [Test]
        [Description("InvokeMethod method should perform the expected calls and return false given the invoked method has a reached delay and returns a AssertionResultRetry object")]
        public void InvokeMethod_Should_PerformTheExpectedCallsAndReturnFalse_Given_TheInvokedMethodHasAReachedDelayAndReturnsAAssertionResultRetryObject()
        {
            GameObject gameObject = UnitTestUtility.CreateGameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultRetry("message");
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.TimeOut = 1000;
            ExtensionRunnerBusinessLogic mockedBusinessLogic = Substitute.For<ExtensionRunnerBusinessLogic>(gameObject);

            DateTime firstNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.StartDelayTime = firstNowDatetime;
            DateTime secondNowDatetime = new DateTime(2017, 05, 01, 00, 00, 00, 000);
            mockedBusinessLogic.DateTimeNow().Returns<DateTime>(secondNowDatetime);

            mockedBusinessLogic.GetParametersValues(methodDescription).Returns<object[]>(parameters);

            bool result = businessLogic.InvokeMethod(mockedBusinessLogic, methodDescription, gameObject);

            Received.InOrder(() =>
            {
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.DateTimeNow();
                mockedBusinessLogic.GetParametersValues(methodDescription);
                mockedMethodInfo.Invoke(component, parameters);
                mockedBusinessLogic.DateTimeNow();
            });
            Assert.IsFalse(result, "The method InvokeMethod doesn't return the right state");
        }

        [Test]
        [Description("GetScenarioTextForErrorInSpecificMethod method should return the expected string given the list of the FullMethodDescription objects and without a specific method in error")]
        public void GetScenarioTextForError_Should_ReturnTheExpectedString_GivenTheListOfTheFullMethodDescriptionObjectsAndWithoutASPecificMethodInError()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = null;

            string expectedString = "\n            Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n              and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        [Description("GetScenarioTextForErrorInSpecificMethod method should return the expected string given the list of the FullMethodDescription objects between three Dynamic components and with the first given main method in error")]
        public void GetScenarioTextForError_Should_ReturnTheExpectedString_Given_TheListOfTheFullMethodDescriptionObjectsBeteweenThreeDynamicComponentsAndWithTheFirstGivenMainMethodInError()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[0];

            string expectedString = "\n----------> Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n              and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        [Description("GetScenarioTextForErrorInSpecificMethod method should return the expected string given the list of the FullMethodDescription objects between three Dynamic components and the error in a CallBefore method")]
        public void GetScenarioTextForError_Should_ReturnTheExpectedString_Given_TheListOfTheFullMethodDescriptionObjectsBeteweenThreeDynamicComponentsAndAndTheErrorInACallBeforeMethod()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[9];

            string expectedString = "\n            Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n---------->   and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        [Description("GetbddMethodLocationForSpecificMethod method should return the expected string given a list of FullMethodDescription objects and without a specific method in error")]
        public void GetbddMethodLocationForSpecificMethod_Should_ReturnTheExpectedString_Given_AListOfFullMethodDescriptionObjectsAndWithoutASpecificMethodInError()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = null;

            string expectedString = "\n           [Given]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [ When]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ Then]        ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     ExtensionRunnerBusinessLogicTestSecondDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod [Delay= 0 Timeout= 3000]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }

        [Test]
        [Description("GetbddMethodLocationForSpecificMethod method should return the expected string given a list of FullMethodDescription objects and with the first method in error")]
        public void GetbddMethodLocationForSpecificMethod_Should_ReturnTheExpectedString_Given_AListOfFullMethodDescriptionObjectsAndTheFirstMethodInError()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[0];

            string expectedString = "\n---------->[Given]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [ When]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ Then]        ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     ExtensionRunnerBusinessLogicTestSecondDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod [Delay= 0 Timeout= 3000]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }

        [Test]
        [Description("GetbddMethodLocationForSpecificMethod method should return the expected string given a list of FullMethodDescription objects and with a nested method in error")]
        public void GetbddMethodLocationForSpecificMethod_Should_ReturnTheExpectedString_Given_AListOfFullMethodDescriptionObjectsAndANestedMethodInError()
        {
            ExtensionRunnerBusinessLogicTestFirstDynamicComponent firstComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestFirstDynamicComponent>();
            ExtensionRunnerBusinessLogicTestSecondDynamicComponent secondComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestSecondDynamicComponent>();
            ExtensionRunnerBusinessLogicTestThirdDynamicComponent thirdComponent = UnitTestUtility.CreateComponent<ExtensionRunnerBusinessLogicTestThirdDynamicComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod", "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod", "ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = UnitTestUtility.CreateGameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[5];

            string expectedString = "\n           [Given]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 0 Timeout= 3000]\n           [Given]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.GivenMethod [Delay= 0 Timeout= 3000]\n           [ When]  ExtensionRunnerBusinessLogicTestFirstDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.WhenMethod [Delay= 21 Timeout= 34]\n---------->[ Then]        ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  ExtensionRunnerBusinessLogicTestThirdDynamicComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     ExtensionRunnerBusinessLogicTestSecondDynamicComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  ExtensionRunnerBusinessLogicTestSecondDynamicComponent.ThenMethod [Delay= 0 Timeout= 3000]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="RunnerBusinessLogicUT.cs" company="Hud Dimesion">
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
using System;
using System.Collections.Generic;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class RunnerBusinessLogicUT
    {
        [Test]
        public void GetAllMethodsDescriptionsWithThreeBDDDynamicComponentsAndMethodsWithNestedCallBefore()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> resultList = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            string expecetdMethod1 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod";
            string expecetdMethod2 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod";
            string expecetdMethod3 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod";
            string expecetdMethod4 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod";
            string expecetdMethod5 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod";

            string expecetdMethod6 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod";
            string expecetdMethod7 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.ThenMethod";
            string expecetdMethod8 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod";
            string expecetdMethod9 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod";

            string expecetdMethod10 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.SecondGivenMethod";
            string expecetdMethod11 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod";

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
        public void GetAllMethodsDescriptionsWithBDDStaticomponentAndMethodsWithNestedCallBefore()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList component = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList>();
            Component[] components = new Component[1] { component };

            GameObject gameObject = new GameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> resultList = businessLogic.GetAllMethodsDescriptions(components, null, null, null, null, null, null);

            string expecetdMethod1 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.GivenMethod";
            string expecetdMethod5 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.WhenMethod";

            string expecetdMethod6 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.SecondGivenMethod";
            string expecetdMethod7 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.ThenMethod";
            string expecetdMethod8 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.SecondGivenMethod";
            string expecetdMethod9 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.SecondThenMethod";

            string expecetdMethod10 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.SecondGivenMethod";
            string expecetdMethod11 = "UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList.ThenMethod";

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
        public void RunCycleForFirstMethodSucceedWithoutDelay()
        {
            GameObject gameObject = new GameObject();

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
        public void RunCycleForFirstMethodRetryWithoutDelay()
        {
            GameObject gameObject = new GameObject();

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
        public void RunCycleAfterLastMethod()
        {
            GameObject gameObject = new GameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList component = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTStaticBDDForTestForCallBeforeMethodsList>();
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
        public void InvokeMethodNoDelayReturnsSucceed()
        {
            GameObject gameObject = new GameObject();

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
        public void InvokeMethodNoDelayReturnsRetry()
        {
            GameObject gameObject = new GameObject();

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
        public void InvokeMethodWithDelayReturnsSucceed()
        {
            GameObject gameObject = new GameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.Delay = 1000F;

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
        public void InvokeMethodWithElapsedDelayReturnsSucceed()
        {
            GameObject gameObject = new GameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultSuccessful();
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.Delay = 1000F;

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
        public void InvokeMethodNoDelayReturnsRetryWithGreaterTimeout()
        {
            GameObject gameObject = new GameObject();

            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);

            Component component = Substitute.For<Component>();
            MethodInfo mockedMethodInfo = Substitute.For<MethodInfo>();
            object methodInvokeAssertionResult = new AssertionResultRetry("message");
            object[] parameters = new object[0];
            mockedMethodInfo.Invoke(component, parameters).Returns(methodInvokeAssertionResult);
            FullMethodDescription methodDescription = Substitute.For<FullMethodDescription>();
            methodDescription.Method = mockedMethodInfo;
            methodDescription.GetFullName().Returns<string>("component.method");
            methodDescription.TimeOut = 1000F;
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
        public void GetScenarioTextForErrorInSpecificMethodForDynamicClassesWithoutError()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = null;

            string expectedString = "\n            Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n              and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        public void GetScenarioTextForErrorInSpecificMethodForDynamicClassesAndFirstGivenMainMethod()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[0];

            string expectedString = "\n----------> Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n              and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        public void GetScenarioTextForErrorInSpecificMethodForDynamicClassesAndErrorMethodInCallBefore()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[9];

            string expectedString = "\n            Given Given method\n              and Second Given method\n              and Given method\n             when When method\n              and When method\n             then Second Then method\n---------->   and Then method";

            string result = businessLogic.GetScenarioTextForErrorInSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetScenarioTextForErrorInSpecificMethod doesn't return the right scenario text");
        }

        [Test]
        public void GetbddMethodLocation()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = null;

            string expectedString = "\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ Then]        UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod [Delay= 0 Timeout= 0]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }

        [Test]
        public void GetbddMethodLocationForSpecificMethodForFirstMainMethod()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[0];

            string expectedString = "\n---------->[Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ Then]        UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod [Delay= 0 Timeout= 0]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }

        [Test]
        public void GetbddMethodLocationForSpecificMethodForNestedMethod()
        {
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent firstComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent secondComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent>();
            UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent thirdComponent = UnitTestUtility.CreateComponent<UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent>();
            Component[] components = new Component[3] { firstComponent, secondComponent, thirdComponent };

            string[] givenMethods = new string[3] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod" };
            string[] givenParameters = new string[3] { string.Empty, string.Empty, string.Empty };

            string[] whenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod" };
            string[] whenParameters = new string[2] { string.Empty, string.Empty };

            string[] thenMethods = new string[2] { "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod", "UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod" };
            string[] thenParameters = new string[2] { string.Empty, string.Empty };

            GameObject gameObject = new GameObject();
            ExtensionRunnerBusinessLogic businessLogic = new ExtensionRunnerBusinessLogic(gameObject);
            List<FullMethodDescription> methods = businessLogic.GetAllMethodsDescriptions(components, givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters);

            FullMethodDescription methodDescription = methods[5];

            string expectedString = "\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 0 Timeout= 0]\n           [Given]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.GivenMethod [Delay= 0 Timeout= 0]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent.WhenMethod [Delay= 21 Timeout= 34]\n           [ When]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.WhenMethod [Delay= 21 Timeout= 34]\n---------->[ Then]        UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.ThenMethod [Delay= 56 Timeout= 65]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondGivenMethod [Delay= 65 Timeout= 64]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListThirdComponent.SecondThenMethod [Delay= 11 Timeout= 33]\n           [ Then]     UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.SecondGivenMethod [Delay= 32 Timeout= 54]\n           [ Then]  UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListSecondComponent.ThenMethod [Delay= 0 Timeout= 0]";

            string result = businessLogic.GetbddMethodLocationForSpecificMethod(methods, methodDescription);

            Assert.AreEqual(expectedString, result, "The method GetbddMethodLocationForSpecificMethod doesn't return the right location text");
        }
    }
}

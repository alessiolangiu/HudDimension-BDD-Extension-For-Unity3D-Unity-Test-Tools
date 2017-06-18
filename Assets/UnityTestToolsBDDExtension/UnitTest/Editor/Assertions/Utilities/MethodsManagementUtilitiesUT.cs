using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodsManagementUtilitiesUT
    {
        [Test]
        public void GetParametersIndexForMethodName()
        {
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            int expectedIndex = 1;
            string[] chosenMethods = new string[4] { "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string[] chosenMethodsParametersIndexes = new string[4] { "FirstIndex", "SecondIndex", "ThirdIndex", "FourthIndex" };
            string methodFullName = chosenMethods[expectedIndex];
            string parametersIndex = methodsManagementUtilities.GetParametersIndexForMethod(methodFullName, chosenMethods, chosenMethodsParametersIndexes);
            Assert.AreEqual(chosenMethodsParametersIndexes[expectedIndex], parametersIndex, "The method GetParametersIndexForMethod doesn't return the expected parametersIndex");
        }

        [Test]
        public void GetParametersIndexForMethodNameWithNoMethodChosen()
        {
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            string[] chosenMethods = new string[0];
            string[] chosenMethodsParametersIndexes = new string[0];
            string methodFullName = string.Empty;
            string parametersIndex = methodsManagementUtilities.GetParametersIndexForMethod(methodFullName, chosenMethods, chosenMethodsParametersIndexes);
            Assert.IsNull(parametersIndex, "The method GetParametersIndexForMethod doesn't return the expected parametersIndex");
        }

        [Test]
        public void LoadMethodsDescriptionsFromChosenMethods()
        {
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodsManagementUtilitiesUTFirstDynamicBDDForTest bddComponent1 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTFirstDynamicBDDForTest>();
            MethodsManagementUtilitiesUTSecondDynamicBDDForTest bddComponent2 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTSecondDynamicBDDForTest>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(bddComponent1, typeof(string));
            firstStringArrayStorage.SetValue(bddComponent1, new string[1] { "Parameter For The MethodsManagementUtilitiesUTFirstDynamicBDDForTest.GivenMethod" });

            FieldInfo secondStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(bddComponent2, typeof(string));
            secondStringArrayStorage.SetValue(bddComponent2, new string[1] { "Parameter For The MethodsManagementUtilitiesUTSecondDynamicBDDForTest.GivenMethod" });

            Component[] dynamicBDDComponents = new Component[2] { bddComponent1, bddComponent2 };

            BaseMethodDescriptionBuilder methodBuilder = new BaseMethodDescriptionBuilder();
            string[] chosenMethods = new string[2] { "MethodsManagementUtilitiesUTSecondDynamicBDDForTest.GivenMethod", "MethodsManagementUtilitiesUTFirstDynamicBDDForTest.GivenMethod" };
            IMethodsFilter methodFilter = new MethodsFilterByMethodsFullNameList(chosenMethods);
            MethodsLoader methodsLoader = new MethodsLoader(methodBuilder, methodFilter);
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();

            string[] chosenMethodsParametersIndexes = new string[2] { ";string,MethodsManagementUtilitiesUTSecondDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0];", ";string,MethodsManagementUtilitiesUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0];" };

            List<MethodDescription> methodDescriptionList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<GivenBaseAttribute>(dynamicBDDComponents, methodsLoader, methodDescriptionBuilder, methodParametersLoader, chosenMethods, chosenMethodsParametersIndexes);
            Assert.AreEqual(2, methodDescriptionList.Count, "The method LoadMethodsDescriptionsFromChosenMethods doesn't return the expected amount of Method Descriptions");
            MethodDescription expectedMethodDescription1 = null;
            MethodDescription expectedMethodDescription2 = null;
            if (chosenMethods[0].Equals(methodDescriptionList[0].Method.DeclaringType.Name + "." + methodDescriptionList[0].Method.Name))
            {
                expectedMethodDescription1 = methodDescriptionList[0];
                expectedMethodDescription2 = methodDescriptionList[1];
            }
            else
            {
                expectedMethodDescription1 = methodDescriptionList[1];
                expectedMethodDescription2 = methodDescriptionList[0];
            }

            Assert.AreEqual(chosenMethods[0], expectedMethodDescription1.GetFullName(), "The method LoadMethodsDescriptionsFromChosenMethods doesn't return the expected methods");
            Assert.AreEqual(chosenMethods[1], expectedMethodDescription2.GetFullName(), "The method LoadMethodsDescriptionsFromChosenMethods doesn't return the expected methods");
        }

        [Test]
        public void IsStaticBDDScenarioTrue()
        {
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodsManagementUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent1 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTFirstDynamicBDDForTest>();
            MethodsManagementUtilitiesUTStaticBDDForTest staticComponent = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTStaticBDDForTest>();
            MethodsManagementUtilitiesUTSecondDynamicBDDForTest dynamicBDDComponent2 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTSecondDynamicBDDForTest>();
            Component[] components = new Component[3] { dynamicBDDComponent1, staticComponent, dynamicBDDComponent2 };
            bool result = methodsManagementUtilities.IsStaticBDDScenario(components);
            Assert.IsTrue(result, "THe method IsStaticBDDScenario does not return the right state");
        }

        [Test]
        public void IsStaticBDDScenarioFalse()
        {
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodsManagementUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent1 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTFirstDynamicBDDForTest>();
            MethodsManagementUtilitiesUTSecondDynamicBDDForTest dynamicBDDComponent2 = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTSecondDynamicBDDForTest>();
            Component[] components = new Component[2] { dynamicBDDComponent1, dynamicBDDComponent2 };
            bool result = methodsManagementUtilities.IsStaticBDDScenario(components);
            Assert.IsFalse(result, "THe method IsStaticBDDScenario does not return the right state");
        }

        [Test]
        public void LoadFullMethodsDescriptionsFromChosenMethodsWithEmptyCallBeforeAndOtherCallBeforeForDynamicScenario()
        {
            // Create the MethodDescription
            MethodsManagementUtilitiesUTDynamicBDDForTestForCallBeforeMethodsList component = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTDynamicBDDForTestForCallBeforeMethodsList>();

            MethodInfo mainMethodInfo = component.GetType().GetMethod("SecondThenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = string.Empty;
            MethodDescription firstChosenMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Create the expected FullMethodDescription
            MethodInfo firstCallBeforeMethodInfo = component.GetType().GetMethod("ThenMethod");
            BaseMethodDescription firstCallBeforeBaseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, firstCallBeforeMethodInfo);
            MethodDescription secondChosenMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, firstCallBeforeBaseMethodDescription, parametersIndex);
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> firstChosenFullMethodDescriptionsList = fullMethodDescriptionBuilder.BuildFromBaseMethodDescription(firstChosenMethodDescription, 1);
            List<FullMethodDescription> seconChosenFullMethodDescriptionsList = fullMethodDescriptionBuilder.BuildFromBaseMethodDescription(secondChosenMethodDescription, 2);
            List<FullMethodDescription> expectedFullMethodDescriptionsList = new List<FullMethodDescription>();
            expectedFullMethodDescriptionsList.AddRange(firstChosenFullMethodDescriptionsList);
            expectedFullMethodDescriptionsList.AddRange(seconChosenFullMethodDescriptionsList);

            // Build the fullMethodDescription
            List<MethodDescription> methodsDescriptionsList = new List<MethodDescription>();
            methodsDescriptionsList.Add(firstChosenMethodDescription);
            methodsDescriptionsList.Add(secondChosenMethodDescription);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            List<FullMethodDescription> result = methodsManagementUtilities.LoadFullMethodsDescriptions<ThenBaseAttribute>(methodsDescriptionsList, fullMethodDescriptionBuilder);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(6, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFullMethodDescriptionsList[0], result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[1], result[1], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[2], result[2], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[3], result[3], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[4], result[4], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[5], result[5], "The method build doesn't return the right fullMethodDescription");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("LoadFullMethodsDescriptions should load the parameters for the CallBefore method when the parameter index of the main MethodDescription is properly set.")]
        public void LoadFullMethodsDescriptions_Should_LoadParametersForTheCallBeforeMethod_When_TheParameterIndexOfTheMainMethodDescriptionIsProperlySet()
        {
            // Create the MethodDescription
            MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad component = UnitTestUtility.CreateComponent<MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad>();

            MethodInfo mainMethodInfo = component.GetType().GetMethod("SecondGivenMethod");
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();

            BaseMethodDescription mainBaseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, mainMethodInfo);
            string parametersIndex = ";System.String,MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad.SecondGivenMethod.stringParam.,stringPVS.Array.data[0]" +
                ";System.String,MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad.GivenMethod.stringParam.,stringPVS.Array.data[1]";
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo stringPVS = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            string[] stringArray = new string[2] { "FirstElementForTheMainMethod", "SecondElementForTheCallBeforeMethod" };
            stringPVS.SetValue(component, stringArray);

            MethodDescription mainMethodDescription = methodDescriptionBuilder.Build(methodParametersLoader, mainBaseMethodDescription, parametersIndex);

            // Creating the expected FullMethodDescription list
            MethodInfo callBeforeMethodInfo = component.GetType().GetMethod("GivenMethod");
            List<FullMethodDescription> expectedFullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(mainMethodDescription, 1);
            expectedFullMethodDescriptionsList[0].Parameters = methodParametersLoader.LoadMethodParameters(component, callBeforeMethodInfo, string.Empty, parametersIndex);

            // Executing LoadFullMethodsDescriptions
            List<MethodDescription> methodsDescriptionsList = new List<MethodDescription>();
            methodsDescriptionsList.Add(mainMethodDescription);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            List<FullMethodDescription> result = methodsManagementUtilities.LoadFullMethodsDescriptions<GivenBaseAttribute>(methodsDescriptionsList, fullMethodDescriptionBuilder);

            // Compare the FullMethodDescriptions
            Assert.AreEqual(2, result.Count, "The method build doesn't return the right number of element in the list");
            Assert.AreEqual(expectedFullMethodDescriptionsList[0], result[0], "The method build doesn't return the right fullMethodDescription");
            Assert.AreEqual(expectedFullMethodDescriptionsList[1], result[1], "The method build doesn't return the right fullMethodDescription");
        }
    }
}
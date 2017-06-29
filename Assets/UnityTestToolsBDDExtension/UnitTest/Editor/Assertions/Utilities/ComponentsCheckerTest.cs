//-----------------------------------------------------------------------
// <copyright file="ComponentsCheckerTest.cs" company="Hud Dimension">
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
    public class ComponentsCheckerTest
    {
        [Test]
        [Description("CheckDuplicateStepMethods method should return the expected list of UnityTestBDDError objects given a Dynamic component without methods with the same full method name")]
        public void CheckDuplicateStepMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithoutMethodsWithTheSameFullMethodName()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStepMethods(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateStepMethods doesn't check properly");
        }

        [Test]
        [Description("CheckDuplicateStepMethods method should return the expected list of UnityTestBDDError objects given a Dynamic component with methods with the same full method name for the same step type")]
        public void CheckDuplicateStepMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithMethodsWithTheSameFullMethodNameForTheSameStepType()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSecondDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            MethodInfo methodInfo1 = null;
            MethodInfo methodInfo2 = null;
            foreach (MethodInfo method in methodsInfo)
            {
                if (method.Name.Equals("WhenMethod"))
                {
                    if (methodInfo1 == null)
                    {
                        methodInfo1 = method;
                    }
                    else
                    {
                        methodInfo2 = method;
                    }
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStepMethods(components);
            Assert.AreEqual(1, result.Count, "The method CheckForBlankMethods doesn't check properly");
            string expectedMessage = "There are more than one BDD Methods with the name ComponentsCheckerTestSecondDynamicComponent.WhenMethod You can have only one method with the same name.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateStepMethods doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckDuplicateStepMethods doesn't resturn the right Component");
            Assert.That(methodInfo1.Equals(result[0].MethodMethodInfo) || methodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckDuplicateStepMethods doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckDuplicateStepMethods method should return the expected list of UnityTestBDDError objects given a Dynamic component with methods with the same full method name for different step types")]
        public void CheckDuplicateStepMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithMethodsWithTheSameFullMethodNameForDifferentStepTypes()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestThirdDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            MethodInfo methodInfo1 = null;
            MethodInfo methodInfo2 = null;
            foreach (MethodInfo method in methodsInfo)
            {
                if (method.Name.Equals("GivenMethod"))
                {
                    if (methodInfo1 == null)
                    {
                        methodInfo1 = method;
                    }
                    else
                    {
                        methodInfo2 = method;
                    }
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStepMethods(components);
            Assert.AreEqual(1, result.Count, "The method CheckForBlankMethods doesn't check properly");
            string expectedMessage = "There are more than one BDD Methods with the name ComponentsCheckerTestThirdDynamicComponent.GivenMethod You can have only one method with the same name.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateStepMethods doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckDuplicateStepMethods doesn't resturn the right Component");
            Assert.That(methodInfo1.Equals(result[0].MethodMethodInfo) || methodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckDuplicateStepMethods doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckDuplicateComponents method should return the expected list of UnityTestBDDError objects given only a Dynamic component")]
        public void CheckDuplicateComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_OnlyADynamicComponent()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateComponents(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateComponents doesn't check properly");
        }

        [Test]
        [Description("CheckDuplicateComponents method should return the expected list of UnityTestBDDError objects given a list with duplicated Dynamic component")]
        public void CheckDuplicateComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AListWithADuplicatedDynamicComponent()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component secondComponent = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[2] { component, secondComponent };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateComponents(components);

            Assert.AreEqual(1, result.Count, "The method CheckDuplicateComponents doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestFirstDynamicComponent is duplicated.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateComponents doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component) || secondComponent.Equals(result[0].Component), "The method CheckDuplicateComponents doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckDuplicateComponents doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckValuesParametersStorage method should return the expected list of UnityTestBDDError objects given a Dynamic component without errors")]
        public void CheckValuesParametersStorage_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithoutErrors()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);
            Assert.AreEqual(0, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
        }

        [Test]
        [Description("CheckValuesParametersStorage method should return the expected list of UnityTestBDDError objects given a Dynamic component with a field marked as ValuesParametersStorage that is not an array")]
        public void CheckValuesParametersStorage_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAFieldMarkedAsValuesParametersStorageThatIsNotAnArray()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFourthDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The field ComponentsCheckerTestFourthDynamicComponent.ButtonPVS is not an array.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckValuesParametersStorage method should return the expected list of UnityTestBDDError objects given a Dynamic component with a field marked as ValuesParametersStorage for a type already present")]
        public void CheckValuesParametersStorage_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAFieldMarkedAsValuesParametersStorageForATypeAlreadyPresent()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFiftDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestFiftDynamicComponent has more than one ParametersValuesStorage for the type System.String";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckValuesParametersStorage method should return the expected list of UnityTestBDDError objects given a Dynamic component with a field marked as ValuesParametersStorage without SerializedField attribute")]
        public void CheckValuesParametersStorage_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAFieldMarkedAsValuesParametersStorageWithoutSerializedFieldAttribute()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSixthDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The field ComponentsCheckerTestSixthDynamicComponent.buttonPVS is private but it hasn't the [SerializedField] attribute. The inspector is not going to manage it.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckValuesParametersStorage method should return the expected list of UnityTestBDDError objects given a Dynamic component with a method with a parameter of a type not found in the list of the available ValuesParametersStorages")]
        public void CheckValuesParametersStorage_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAMethodWithAParameterOfATypeNotFoundInTheListOfTheAvailableValuesParametersStorages()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSeventhDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "There is not ParametersValuesStorage for the type Button for the parameter stringParam for the method ComponentsCheckerTestSeventhDynamicComponent.GivenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodReturnValue method should return the expected list of UnityTestBDDError objects given a step method that returns a IAssertionResult object")]
        public void CheckStepMethodReturnValue_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStepMethodThatReturnsAIAssertionResultObject()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodReturnValue(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodReturnValue doesn't check properly");
        }

        [Test]
        [Description("CheckStepMethodReturnValue method should return the expected list of UnityTestBDDError objects given a step method that does not return a IAssertionResult object")]
        public void CheckStepMethodReturnValue_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStepMethodThatDoesNotReturnAIAssertionResultObject()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestEighthDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodReturnValue(components);
            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestEighthDynamicComponent.WhenMethod does not return an IAssertionResult value.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeMethods method  should return the expected list of UnityTestBDDError objects given a Dynamic component without errors")]
        public void CheckCallBeforeMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithoutErrors()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeMethods(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeMethods doesn't check properly");
        }

        [Test]
        [Description("CheckCallBeforeMethods method  should return the expected list of UnityTestBDDError objects given a CallBefore attribute with a empty Method property")]
        public void CheckCCheckCallBeforeMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ACallBeforeAttributeWithAEmptyMethodProperty()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestNinthDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("SecondWhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeMethods(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "Method ComponentsCheckerTestNinthDynamicComponent. not found. It is referenced in a CallBefore attribute for the method ComponentsCheckerTestNinthDynamicComponent.SecondWhenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeMethods method should return the expected list of UnityTestBDDError objects given a CallBefore attribute with a Method property pointing to a not found method")]
        public void CheckCCheckCallBeforeMethods_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ACallBeforeAttributeWithAMethodPropertyPointingToANotFoundMethod()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestTenthDynamicComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("SecondWhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeMethods(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "Method ComponentsCheckerTestTenthDynamicComponent.MethodNotPresent not found. It is referenced in a CallBefore attribute for the method ComponentsCheckerTestTenthDynamicComponent.SecondWhenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeOnStepDeclaration method should return the expected list of UnityTestBDDError objects given a CallBefore attribute on a step method")]
        public void CheckCallBeforeOnStepDeclaration_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ACallBeforeAttributeOnAStepMethod()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeOnStepDeclaration(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeOnStepDeclaration doesn't check properly");
        }

        [Test]
        [Description("CheckCallBeforeOnStepDeclaration method shuld return the expected list of UnityTestBDDError objects given a CallBefore attribute on an ordinary method")]
        public void CheckCallBeforeOnStepDeclaration_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ACallBeforeAttributeOnAOrdinaryMethod()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestEleventhDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("SecondWhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeOnStepDeclaration(components);

            Assert.AreEqual(1, result.Count, "The method CheckCallBeforeOnStepDeclaration doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestEleventhDynamicComponent.SecondWhenMethod has a CallBefore attribute but it is not a BDD Method.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeExecutionOrders method should return the expected list of UnityTestBDDError objects given a Dynamic component with all CallBefore attributes with right ExecutionOrder properties")]
        public void CheckCallBeforeExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAllCallBeforeAttributesWidhRightExecutionOrderProperties()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeExecutionOrders doesn't check properly");
        }

        [Test]
        [Description("CheckCallBeforeExecutionOrders method should return the expected list of UnityTestBDDError objects given a Dynamic component with a CallBefore attribute with an ExecutionOrder property value set to 0")]
        public void CheckCallBeforeExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAllCallBeforeAttributesWidhACallBeforeAttributeWithAnExecutionOrderPropertyValueSetToZero()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestTwelvethDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckCallBeforeExecutionOrders doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestTwelvethDynamicComponent.WhenMethod has a wrong value for CallBefore.ExecutionOrder: 0\n It must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeExecutionOrders method should return the expected list of UnityTestBDDError objects given a Dynamic component with two CallBefore attributes with the same ExecutionOrder property value")]
        public void CheckCallBeforeExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAllCallBeforeAttributesWidhTwoCallBeforeAttributesWithTheSameExecutionOrderPropertyValue()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestThirteenthDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckCallBeforeExecutionOrders doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestThirteenthDynamicComponent.WhenMethod has duplicated CallBefore.ExecutionOrder: 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckCallBeforeExecutionOrders method should return the expected list of UnityTestBDDError objects given a Dynamic component with a missing value of ExecutionOrder for CallBefore attributes")]
        public void CheckCallBeforeExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponentWithAllCallBeforeAttributesWidhAMissingValueOfExecutionOrderForCallBeforeAttributes()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFourteenthDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckCallBeforeExecutionOrders doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestFourteenthDynamicComponent.WhenMethod has a missing CallBefore.ExecutionOrder: 3";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Dynamic component")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ADynamicComponent()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with no errors")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithNoErrors()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a Given method with an ExecutionOrder set to 0")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAGivenMethodWithAnExecutionOrderSetToZero()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSecondStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("GivenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The Given declaration for the method ComponentsCheckerTestSecondStaticComponent.GivenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a When method with an ExecutionOrder set to 0")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAWhenMethodWithAnExecutionOrderSetToZero()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestThirdStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The When declaration for the method ComponentsCheckerTestThirdStaticComponent.WhenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a Then method with an ExecutionOrder set to 0")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAThenMethodWithAnExecutionOrderSetToZero()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFourthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("ThenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The Then declaration for the method ComponentsCheckerTestFourthStaticComponent.ThenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a Given methods with duplicated ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAGivenMethodWithDuplicatedExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFifthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo1 = null;
            MethodInfo expectedMethodInfo2 = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("GivenMethod"))
                {
                    expectedMethodInfo1 = methodInfo;
                }

                if (methodInfo.Name.Equals("SecondGivenMethod"))
                {
                    expectedMethodInfo2 = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage1 = "The Given declaration for the method ComponentsCheckerTestFifthStaticComponent.GivenMethod has a duplicate ExecutionOrder value: 1. Check the others Given methods.";
            string expectedMessage2 = "The Given declaration for the method ComponentsCheckerTestFifthStaticComponent.SecondGivenMethod has a duplicate ExecutionOrder value: 1. Check the others Given methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a When methods with duplicated ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAWhenMethodWithDuplicatedExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSixthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo1 = null;
            MethodInfo expectedMethodInfo2 = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo1 = methodInfo;
                }

                if (methodInfo.Name.Equals("ThirdWhenMethod"))
                {
                    expectedMethodInfo2 = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage1 = "The When declaration for the method ComponentsCheckerTestSixthStaticComponent.WhenMethod has a duplicate ExecutionOrder value. Check the others When methods.";
            string expectedMessage2 = "The When declaration for the method ComponentsCheckerTestSixthStaticComponent.ThirdWhenMethod has a duplicate ExecutionOrder value. Check the others When methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with a Then methods with duplicated ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithAThenMethodWithDuplicatedExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSeventhStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo1 = null;
            MethodInfo expectedMethodInfo2 = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("ThenMethod"))
                {
                    expectedMethodInfo1 = methodInfo;
                }

                if (methodInfo.Name.Equals("SecondThenMethod"))
                {
                    expectedMethodInfo2 = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage1 = "The Then declaration for the method ComponentsCheckerTestSeventhStaticComponent.ThenMethod has a duplicate ExecutionOrder value. Check the others Then methods.";
            string expectedMessage2 = "The Then declaration for the method ComponentsCheckerTestSeventhStaticComponent.SecondThenMethod has a duplicate ExecutionOrder value. Check the others Then methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with Given methods with missing ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithGivenMethodsWithMissingExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestEighthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestEighthStaticComponent has a missing Given.ExecutionOrder: 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with When methods with missing ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithWhenMethodsWithMissingExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestNinthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestNinthStaticComponent has a missing When.ExecutionOrder: 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with Then methods with missing ExecutionOrder")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithThenMethodsWithMissingExecutionOrder()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestTenthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestTenthStaticComponent has a missing Then.ExecutionOrder: 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with Given methods missing")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithGivenMethodsMissing()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestEleventhStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestEleventhStaticComponent has not Given components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with When methods missing")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithWhenMethodsMissing()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestTwelvethStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestTwelvethStaticComponent has not When components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStepMethodsExecutionOrders method should return the expected list of UnityTestBDDError objects given a Static component with Then methods missing")]
        public void CheckStepMethodsExecutionOrders_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithThenMethodsMissing()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestThirteenthStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component ComponentsCheckerTestThirteenthStaticComponent has not Then components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckStaticComponentsWithParameters method should return the expected list of UnityTestBDDError objects given a Static component without methods with parameters")]
        public void CheckStaticComponentsWithParameters_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithoutMethodsWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStaticComponentsWithParameters(components);
            Assert.AreEqual(0, result.Count, "The method CheckStaticComponentsWithParameters doesn't check properly");
        }

        [Test]
        [Description("CheckStaticComponentsWithParameters method should return the expected list of UnityTestBDDError objects given a Static component with methods with parameters")]
        public void CheckStaticComponentsWithParameters_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AStaticComponentWithMethodsWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFourteenthStaticComponent>();
            Component[] components = new Component[1] { component };
            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("SecondThenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStaticComponentsWithParameters(components);
            Assert.AreEqual(1, result.Count, "The method CheckStaticComponentsWithParameters doesn't check properly");
            string expectedMessage = "The method ComponentsCheckerTestFourteenthStaticComponent.SecondThenMethod is not allowed to have parameters";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStaticComponentsWithParameters doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStaticComponentsWithParameters doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStaticComponentsWithParameters doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckDuplicateStaticComponents method should return the expected list of UnityTestBDDError objects given only one Static component")]
        public void CheckDuplicateStaticComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_OnlyOneStaticComponent()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStaticComponents(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateStaticComponents doesn't check properly");
        }

        [Test]
        [Description("CheckDuplicateStaticComponents method should return the expected list of UnityTestBDDError objects given two Static components")]
        public void CheckDuplicateStaticComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_TwoStaticComponents()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            Component component2 = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            Component[] components = new Component[2] { component, component2 };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStaticComponents(components);
            Assert.AreEqual(1, result.Count, "The method CheckDuplicateStaticComponents doesn't check properly");
            string expectedMessage = "There are more than one Static BDD Component. Only one is allowed";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateStaticComponents doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckDuplicateStaticComponents doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckDuplicateStaticComponents doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckRecursiveCalls method should return the expected list of UnityTestBDDError objects given a component with a recursive call")]
        public void CheckRecursiveCalls_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithARecursiveCall()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFifteenthStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();
            MethodInfo expectedFirstMethodInfo = null;
            MethodInfo expectedSecondMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("GivenMethod"))
                {
                    expectedFirstMethodInfo = methodInfo;
                }

                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedSecondMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckRecursiveCalls(component);
            Assert.AreEqual(2, result.Count, "The method CheckRecursiveCalls doesn't check properly");
            string expectedMessage = "The method GivenMethod has a recursive call. Recursive calls are not allowed.\n Call chain:\n\nGivenMethod [CallBefore( 1 \"WhenMethod\" Timeout =3000)]\nWhenMethod [CallBefore( 1 \"GivenMethod\" Timeout =3000)]";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckRecursiveCalls doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckRecursiveCalls doesn't resturn the right Component");
            Assert.IsNull(result[1].Component, "The method CheckRecursiveCalls doesn't resturn the right Component");
            Assert.That(expectedFirstMethodInfo.Equals(result[0].MethodMethodInfo) || expectedFirstMethodInfo.Equals(result[1].MethodMethodInfo), "The method CheckRecursiveCalls doesn't resturn the right MethodInfo");
            Assert.That(expectedSecondMethodInfo.Equals(result[0].MethodMethodInfo) || expectedSecondMethodInfo.Equals(result[1].MethodMethodInfo), "The method CheckRecursiveCalls doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckRecursiveCalls method should return the expected list of UnityTestBDDError objects given a component without recursive calls")]
        public void CheckRecursiveCalls_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithoutRecursiveCalls()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckRecursiveCalls(component);
            Assert.AreEqual(0, result.Count, "The method CheckRecursiveCalls doesn't check properly");
        }

        [Test]
        [Description("CheckParametersUniqueness method should return the expected list of UnityTestBDDError objects given a component without methods with parameters")]
        public void CheckParametersUniqueness_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithoutMethodsWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        [Description("CheckParametersUniqueness method should return the expected list of UnityTestBDDError objects given a component with duplicated CallBefore without parameters")]
        public void CheckParametersUniqueness_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithDuplicatedCallBeforeWithoutParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSixteenthStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        [Description("CheckParametersUniqueness method should return the expected list of UnityTestBDDError objects given a component with simple duplicated CallBefore with parameters")]
        public void CheckParametersUniqueness_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithSimpleDuplicatedCallBeforeWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestSeventeenthStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            MethodInfo expectedMethodInfo = null;
            MethodInfo[] methodsInfo = component.GetType().GetMethods();
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                if (methodInfo.Name.Equals("WhenMethod"))
                {
                    expectedMethodInfo = methodInfo;
                }
            }

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(1, result.Count, "The method CheckParametersUniqueness doesn't check properly");
            string expectedMessage = "The CallBefore chains declared for the method WhenMethod have a non unique identifications for the parameters of the method identified by the key: \"ComponentsCheckerTestSeventeenthStaticComponent.GivenMethod.\"\n Please, use the Id property in the CallBefore attributes for making them unique.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckParametersUniqueness doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckParametersUniqueness doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckParametersUniqueness doesn't resturn the right MethodInfo");
        }

        [Test]
        [Description("CheckParametersUniqueness method should return the expected list of UnityTestBDDError objects given a component with nested duplicated CallBefore with parameters")]
        public void CheckParametersUniqueness_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithNestedDuplicatedCallBeforeWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestEighteenthStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        [Description("CheckParametersUniqueness method should return the expected list of UnityTestBDDError objects given a component with duplicated CallBefore with parameters and Ids")]
        public void CheckParametersUniqueness_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AComponentWithDuplicatedCallBeforeWithParametersAndIds()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestNineteenthStaticComponent>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        [Description("CheckEnoughAttachedComponents method should return the expected list of UnityTestBDDError objects given a non empty list of components")]
        public void CheckEnoughAttachedComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_ANonEmptyListOfComponents()
        {
            Component component = UnitTestUtility.CreateComponent<ComponentsCheckerTestFirstDynamicComponent>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckEnoughAttachedComponents(components);
            Assert.AreEqual(0, result.Count, "The method CheckEnoughAttachedComponents doesn't check properly");
        }

        [Test]
        [Description("CheckEnoughAttachedComponents method should return the expected list of UnityTestBDDError objects given an empty list of components")]
        public void CheckEnoughAttachedComponents_Should_ReturnTheExpectedListOfUnityTestBDDErrorObjects_Given_AnEmptyListOfComponents()
        {
            Component[] components = new Component[0];
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckEnoughAttachedComponents(components);
            Assert.AreEqual(1, result.Count, "The method CheckEnoughAttachedComponents doesn't check properly");
            string expectedMessage = "Please, add your BDD Components and enjoy BDD.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckEnoughAttachedComponents doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckEnoughAttachedComponents doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckParametersUniqueness doesn't resturn the right MethodInfo");
        }
    }
}

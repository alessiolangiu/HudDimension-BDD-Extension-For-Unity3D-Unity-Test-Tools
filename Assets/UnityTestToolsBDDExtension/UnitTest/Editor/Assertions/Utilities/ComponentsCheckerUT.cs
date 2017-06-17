//-----------------------------------------------------------------------
// <copyright file="ComponentsCheckerUT.cs" company="Hud Dimesion">
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
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ComponentsCheckerUT
    {
        [Test]
        public void CheckDuplicateStepMethodSignatureNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStepMethods(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateStepMethods doesn't check properly");
        }

        [Test]
        public void CheckDuplicateStepMethodSignatureWithDuplicates()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestWithDuplicate>();
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
            string expectedMessage = "There are more than one step method with the name CheckForErrorsUTDynamicBDDForTestWithDuplicate.WhenMethod and the same When BDD declaration.You can have only one method with the same name.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateStepMethods doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckDuplicateStepMethods doesn't resturn the right Component");
            Assert.That(methodInfo1.Equals(result[0].MethodMethodInfo) || methodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckDuplicateStepMethods doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckDuplicateComponentsNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateComponents(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateComponents doesn't check properly");
        }

        [Test]
        public void CheckDuplicateComponentsWithDuplicates()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component secondComponent = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[2] { component, secondComponent };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateComponents(components);

            Assert.AreEqual(1, result.Count, "The method CheckDuplicateComponents doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTDynamicBDDForTestNoErrors is duplicated.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckDuplicateComponents doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component) || secondComponent.Equals(result[0].Component), "The method CheckDuplicateComponents doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckDuplicateComponents doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckParametersWithValuesParametersStorageNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);
            Assert.AreEqual(0, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
        }

        [Test]
        public void CheckParametersWithValuesParametersStorageValuesStorageIsNotArray()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNotArrayForValuesArray>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The field CheckForErrorsUTDynamicBDDForTestNotArrayForValuesArray.ButtonPVS is not an array.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckParametersWithValuesParametersDoubleArrayStorageSameType()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestDoubleArrayStorageSameType>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTDynamicBDDForTestDoubleArrayStorageSameType has more than one ValuesArrayStorage for the type System.String";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckParametersWithValuesParametersPrivateArrayStorageWithoutSerializedField()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestPrivateArrayStorageWithoutSerializedField>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "The field CheckForErrorsUTDynamicBDDForTestPrivateArrayStorageWithoutSerializedField.buttonPVS is private but it hasn't the [SerializedField] attribute. The inspector will not see it.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckParametersWithValuesParametersNoValuesArrayStorageForParameter()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoValuesArrayStorageForParameter>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckValuesParametersStorage(components);

            Assert.AreEqual(1, result.Count, "The method CheckValuesParametersStorage doesn't check properly");
            string expectedMessage = "There is not ValuesArrayStorage for the type Button for the parameter stringParam for the method CheckForErrorsUTDynamicBDDForTestNoValuesArrayStorageForParameter.GivenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckValuesParametersStorage doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckValuesParametersStorage doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckValuesParametersStorage doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodReturnValueNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodReturnValue(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodReturnValue doesn't check properly");
        }

        [Test]
        public void CheckStepMethodReturnValue()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestReturnValueException>();
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
            string expectedMessage = "The method CheckForErrorsUTDynamicBDDForTestReturnValueException.WhenMethod doesn't return an IAssertionResult value.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeMethodNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeMethods(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeMethods doesn't check properly");
        }

        [Test]
        public void CheckCallBeforeMethodBlank()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestCallBeforeBlank>();
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
            string expectedMessage = "Method CheckForErrorsUTDynamicBDDForTestCallBeforeBlank. not found. It is referenced in a CallBefore attribute for the method CheckForErrorsUTDynamicBDDForTestCallBeforeBlank.SecondWhenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeMethodNotFound()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestCallBeforeNotFound>();
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
            string expectedMessage = "Method CheckForErrorsUTDynamicBDDForTestCallBeforeNotFound.MethodNotPresent not found. It is referenced in a CallBefore attribute for the method CheckForErrorsUTDynamicBDDForTestCallBeforeNotFound.SecondWhenMethod";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodReturnValue doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodReturnValue doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodReturnValue doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeOnStepMethodDeclarationNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeOnStepDeclaration(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeOnStepDeclaration doesn't check properly");
        }

        [Test]
        public void CheckCallBeforeOnStepMethodDeclaration()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestCallBeforeOnStepDeclaration>();
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
            string expectedMessage = "The method CheckForErrorsUTDynamicBDDForTestCallBeforeOnStepDeclaration.SecondWhenMethod has a CallBefore attribute but it is not a BDD Step Method.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeOnStepDeclaration doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeExecutionOrdersNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckCallBeforeExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckCallBeforeExecutionOrders doesn't check properly");
        }

        [Test]
        public void CheckCallBeforeExecutionOrdersZeroValue()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestZeroValue>();
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
            string expectedMessage = "The method CheckForErrorsUTDynamicBDDForTestZeroValue.WhenMethod has a wrong value for CallBefore.ExecutionOrder: 0\n It must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeExecutionOrdersDuplicateValue()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestDuplicateValue>();
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
            string expectedMessage = "The method CheckForErrorsUTDynamicBDDForTestDuplicateValue.WhenMethod has duplicate CallBefore.ExecutionOrder: 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCallBeforeExecutionOrdersMissingValue()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestMissingValue>();
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
            string expectedMessage = "The method CheckForErrorsUTDynamicBDDForTestMissingValue.WhenMethod has a missing CallBefore.ExecutionOrder: 3";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckCallBeforeExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckCallBeforeExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckCallBeforeExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersNoErrorExpectedForDynamicComponent()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTDynamicBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersNoErrorExpectedForStaticComponent()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);
            Assert.AreEqual(0, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersZeroValueForGivenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestZeroValueForGivenMethods>();
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
            string expectedMessage = "The Given declaration for the method CheckForErrorsUTStaticBDDForTestZeroValueForGivenMethods.GivenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersZeroValueForWhenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestZeroValueForWhenMethods>();
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
            string expectedMessage = "The When declaration for the method CheckForErrorsUTStaticBDDForTestZeroValueForWhenMethods.WhenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersZeroValueForThenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestZeroValueForThenMethods>();
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
            string expectedMessage = "The Then declaration for the method CheckForErrorsUTStaticBDDForTestZeroValueForThenMethods.ThenMethod has a wrong ExecutionOrder value: it must be >0";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersDuplicateValueForGivenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestDuplicateValueForGivenMethods>();
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
            string expectedMessage1 = "The Given declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForGivenMethods.GivenMethod has a duplicate ExecutionOrder value. Check the others Given methods.";
            string expectedMessage2 = "The Given declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForGivenMethods.SecondGivenMethod has a duplicate ExecutionOrder value. Check the others Given methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersDuplicateValueForWhenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestDuplicateValueForWhenMethods>();
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
            string expectedMessage1 = "The When declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForWhenMethods.WhenMethod has a duplicate ExecutionOrder value. Check the others When methods.";
            string expectedMessage2 = "The When declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForWhenMethods.ThirdWhenMethod has a duplicate ExecutionOrder value. Check the others When methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersDuplicateValueForThenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestDuplicateValueForThenMethods>();
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
            string expectedMessage1 = "The Then declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForThenMethods.ThenMethod has a duplicate ExecutionOrder value. Check the others Then methods.";
            string expectedMessage2 = "The Then declaration for the method CheckForErrorsUTStaticBDDForTestDuplicateValueForThenMethods.SecondThenMethod has a duplicate ExecutionOrder value. Check the others Then methods.";
            Assert.That(expectedMessage1.Equals(result[0].Message) || expectedMessage2.Equals(result[0].Message), "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.That(expectedMethodInfo1.Equals(result[0].MethodMethodInfo) || expectedMethodInfo2.Equals(result[0].MethodMethodInfo), "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingValueForGivenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingValueForGivenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingValueForGivenMethods has a missing Given.ExecutionOrder: 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingValueForWhenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingValueForWhenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingValueForWhenMethods has a missing When.ExecutionOrder: 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingValueForThenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingValueForThenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExecutionOrders(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExecutionOrders doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingValueForThenMethods has a missing Then.ExecutionOrder: 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExecutionOrders doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExecutionOrders doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExecutionOrders doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingGivenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingGivenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingGivenMethods has not Given components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingWhenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingWhenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingWhenMethods has not When components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStepMethodsExecutionOrdersMissingThenMethods()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestMissingThenMethods>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckStepMethodsExistance(components);

            Assert.AreEqual(1, result.Count, "The method CheckStepMethodsExistance doesn't check properly");
            string expectedMessage = "The component CheckForErrorsUTStaticBDDForTestMissingThenMethods has not Then components";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStepMethodsExistance doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckStepMethodsExistance doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckStepMethodsExistance doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckStaticComponentWithMethodsWithParametersNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckStaticComponentsWithParameters(components);
            Assert.AreEqual(0, result.Count, "The method CheckStaticComponentsWithParameters doesn't check properly");
        }

        [Test]
        public void CheckStaticComponentWithMethodsWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestWithParameter>();
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
            string expectedMessage = "The method CheckForErrorsUTStaticBDDForTestWithParameter.SecondThenMethod is not allowed to have parameters";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckStaticComponentsWithParameters doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckStaticComponentsWithParameters doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckStaticComponentsWithParameters doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckDuplicateStaticComponentsNoErrorExpected()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            Component[] components = new Component[1] { component };
            ComponentsChecker checkForErrors = new ComponentsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckDuplicateStaticComponents(components);
            Assert.AreEqual(0, result.Count, "The method CheckDuplicateStaticComponents doesn't check properly");
        }

        [Test]
        public void CheckDuplicateStaticComponents()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            Component component2 = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
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
        public void CheckRecursiveCalls()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestRecursiveCallError>();
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
            string expectedMessage = "The method GivenMethod has a recursive call. Recursive calls are not allowed.\n Call chain:\n\nGivenMethod [CallBefore( 1 \"WhenMethod\")]\nWhenMethod [CallBefore( 1 \"GivenMethod\")]";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckRecursiveCalls doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckRecursiveCalls doesn't resturn the right Component");
            Assert.IsNull(result[1].Component, "The method CheckRecursiveCalls doesn't resturn the right Component");
            Assert.That(expectedFirstMethodInfo.Equals(result[0].MethodMethodInfo) || expectedFirstMethodInfo.Equals(result[1].MethodMethodInfo), "The method CheckRecursiveCalls doesn't resturn the right MethodInfo");
            Assert.That(expectedSecondMethodInfo.Equals(result[0].MethodMethodInfo) || expectedSecondMethodInfo.Equals(result[1].MethodMethodInfo), "The method CheckRecursiveCalls doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckRecursiveCallsNoErrors()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            ComponentsChecker checkForErrors = new ComponentsChecker();
            
            List<UnityTestBDDError> result = checkForErrors.CheckRecursiveCalls(component);
            Assert.AreEqual(0, result.Count, "The method CheckRecursiveCalls doesn't check properly");
        }

        [Test]
        public void CheckCheckParametersUniquenessNoErrorsNoDuplicatedCallBefore()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrors>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        public void CheckCheckParametersUniquenessNoErrorsDuplicatedCallBeforeWithoutParameters()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrorsDuplicatedCallBeforeWithoutParameters>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        public void CheckCheckParametersUniquenessSimpleDuplicatedCallBeforeWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestSimpleDuplicatedCallBeforeWithParameters>();
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
            string expectedMessage = "The CallBefore chains declared for the method WhenMethod have a non unique identifications for the parameters of the method identified by the key: \"CheckForErrorsUTStaticBDDForTestSimpleDuplicatedCallBeforeWithParameters.GivenMethod.\"\n Please, use the Id property in the CallBefore attributes for making them unique.";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckParametersUniqueness doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckParametersUniqueness doesn't resturn the right Component");
            Assert.That(expectedMethodInfo.Equals(result[0].MethodMethodInfo), "The method CheckParametersUniqueness doesn't resturn the right MethodInfo");
        }

        [Test]
        public void CheckCheckParametersUniquenessNoErrorsNestedDuplicatedCallBeforeWithParameters()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestNoErrorsNestedDuplicatedCallBeforeWithParameters>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }

        [Test]
        public void CheckCheckParametersUniquenessNoErrorsDuplicatedCallBeforeWithParametersAndIds()
        {
            Component component = UnitTestUtility.CreateComponent<CheckForErrorsUTStaticBDDForTestDuplicatedCallBeforeWithParametersAndIds>();
            ComponentsChecker checkForErrors = new ComponentsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckParametersUniqueness(component);
            Assert.AreEqual(0, result.Count, "The method CheckParametersUniqueness doesn't check properly");
        }
    }
}

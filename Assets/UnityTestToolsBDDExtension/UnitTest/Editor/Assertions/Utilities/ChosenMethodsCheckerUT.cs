using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ChosenMethodsCheckerUT
    {
        [Test]
        public void CheckIfAMethodIsBlankNoError()
        {
            string[] chosenMethods = new string[5] { "class.method", "class.method", "class.method", "class.method", "class.method" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForBlankMethods<GivenBaseAttribute>(chosenMethods);
            Assert.AreEqual(0, result.Count, "The method CheckForBlankMethods doesn't check properly");
        }

        [Test]
        public void CheckIfAMethodIsBlank()
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
        public void CheckForMethodNotFoundNoError()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "BDDChosenMethodsCheckForErrorsUTNoErrors.ThenMethod", "BDDChosenMethodsCheckForErrorsUTNoErrors.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForMethodNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(0, result.Count, "The method CheckForMethodNotFound doesn't check properly");
        }

        [Test]
        public void CheckForMethodNotFound()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "BDDChosenMethodsCheckForErrorsUTNoErrors.ThenMethod", "BDDChosenMethodsCheckForErrorsUTNoErrors.FakeSecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForMethodNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(1, result.Count, "The method CheckForMethodNotFound doesn't check properly");
            string expectedMessage = "Method BDDChosenMethodsCheckForErrorsUTNoErrors.FakeSecondThenMethod not found on Then methods at position 2";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForMethodNotFound doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckForMethodNotFound doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckForMethodNotFound doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(ThenBaseAttribute), result[0].StepType, "The method CheckForMethodNotFound doesn't resturn the right StepType");
            Assert.AreEqual(1, result[0].Index, "The method CheckForMethodNotFound doesn't resturn the right method index");
        }

        [Test]
        public void CheckForComponentNotFoundNoError()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "BDDChosenMethodsCheckForErrorsUTNoErrors.ThenMethod", "BDDChosenMethodsCheckForErrorsUTNoErrors.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForComponentNotFound<ThenBaseAttribute>(chosenMethods, components);
            Assert.AreEqual(0, result.Count, "The method CheckForMethodNotFound doesn't check properly");
        }

        [Test]
        public void CheckForComponentNotFound()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[2] { "BDDChosenMethodsCheckForErrorsUTNoErrorsFake.ThenMethod", "BDDChosenMethodsCheckForErrorsUTNoErrors.SecondThenMethod" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForComponentNotFound<ThenBaseAttribute>(chosenMethods, components);
            string expectedMessage = "The component for the method BDDChosenMethodsCheckForErrorsUTNoErrorsFake.ThenMethod is not found  in Then methods at position 1";

            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForComponentNotFound doesn't resturn the right message");
            Assert.IsNull(result[0].Component, "The method CheckForComponentNotFound doesn't resturn the right Component");
            Assert.IsNull(result[0].MethodMethodInfo, "The method CheckForComponentNotFound doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(ThenBaseAttribute), result[0].StepType, "The method CheckForComponentNotFound doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForComponentNotFound doesn't resturn the right method index");
        }

        [Test]
        public void CheckForNotMatchingParametersIndexNoError()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndex = new string[1] { ";System.String,BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParam.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndex, components);
            Assert.AreEqual(0, result.Count, "The method CheckForNotMatchingParametersIndex doesn't check properly");
        }

        [Test]
        public void CheckForNotMatchingParametersIndexParamNotFound()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParamWrongName.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            string expectedMessage = "The parameter BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParamWrongName is not found in Given methods at position 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingParametersIndex doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingParametersIndex doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingParametersIndex doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingParametersIndex doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingParametersIndex doesn't resturn the right method index");
        }

        [Test]
        public void CheckForNotMatchingParametersIndexParamTypeChanged()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.Int32,BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParam.,intPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            string expectedMessage = "The parameter BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParam has a wrong type in Given methods at position 1.\n Previous type: System.Int32\n Current type System.String";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingParametersIndex doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingParametersIndex doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingParametersIndex doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingParametersIndex doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingParametersIndex doesn't resturn the right method index");
        }

        [Test]
        public void CheckForNotMatchingPVSNoErrors()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParamWrongName.,stringPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingPVS<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);
            Assert.AreEqual(0, result.Count, "The method CheckForNotMatchingPVS doesn't check properly");
        }

        [Test]
        public void CheckForNotMatchingPVS()
        {
            Component component = UnitTestUtility.CreateComponent<BDDChosenMethodsCheckForErrorsUTNoErrors>();
            Component[] components = new Component[1] { component };
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] chosenMethods = new string[1] { "BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParam.,otherPVS.Array.data[0];" };
            ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();

            List<UnityTestBDDError> result = checkForErrors.CheckForNotMatchingPVS<GivenBaseAttribute>(chosenMethods, parametersIndexes, components);

            string expectedMessage = "The ParametersValuesStorage array otherPVS for the parameter BDDChosenMethodsCheckForErrorsUTNoErrors.GivenMethod.stringParam. is not found in Given methods at position 1";
            Assert.AreEqual(expectedMessage, result[0].Message, "The method CheckForNotMatchingPVS doesn't resturn the right message");
            Assert.That(component.Equals(result[0].Component), "The method CheckForNotMatchingPVS doesn't resturn the right Component");
            Assert.That(methodInfo.Equals(result[0].MethodMethodInfo), "The method CheckForNotMatchingPVS doesn't resturn the right MethodInfo");
            Assert.AreEqual(typeof(GivenBaseAttribute), result[0].StepType, "The method CheckForNotMatchingPVS doesn't resturn the right StepType");
            Assert.AreEqual(0, result[0].Index, "The method CheckForNotMatchingPVS doesn't resturn the right method index");
        }
    }
}
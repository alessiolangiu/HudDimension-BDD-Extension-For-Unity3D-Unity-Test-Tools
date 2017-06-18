﻿namespace HudDimension.UnityTestBDD
{
    public class CheckForErrorsUTDynamicBDDForTestReturnValueException : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method")]
        public string WhenMethod(string whenStringParam, int whenIntParam)
        {
            return null;
        }

        [When("Second When method")]
        public IAssertionResult SecondWhenMethod(string whenStringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("Third When method")]
        public IAssertionResult ThirdWhenMethod(int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then("Second Then method")]
        public IAssertionResult SecondThenMethod(int intParam, float floatParam)
        {
            return new AssertionResultSuccessful();
        }
    }
}
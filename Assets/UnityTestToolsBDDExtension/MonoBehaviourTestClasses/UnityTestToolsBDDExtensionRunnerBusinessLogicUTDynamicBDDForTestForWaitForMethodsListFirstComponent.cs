namespace HudDimension.UnityTestBDD
{
    public class UnityTestToolsBDDExtensionRunnerBusinessLogicUTDynamicBDDForTestForCallBeforeMethodsListFirstComponent : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Given("Second Given method")]
        public IAssertionResult SecondGivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [When("When method", Delay = 21F, Timeout = 34)]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        [CallBefore(1, "SecondGivenMethod", Delay = 32F, Timeout = 54F)]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then("Second Then method", Delay = 11F, Timeout = 33F)]
        [CallBefore(1, "ThenMethod", Delay = 56F, Timeout = 65F)]
        [CallBefore(2, "SecondGivenMethod", Delay = 65F, Timeout = 64F)]
        public IAssertionResult SecondThenMethod(int intParam, float floatParam)
        {
            return new AssertionResultSuccessful();
        }
    }
}
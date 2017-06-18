namespace HudDimension.UnityTestBDD
{
    public class FullMethodDescriptionBuilderUTDynamicCallBeforeWithParameterAndID : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Given("Second Given method")]
        public IAssertionResult SecondGivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method", Delay = 21f, Timeout = 34)]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        [CallBefore(1, "SecondGivenMethod", Delay = 32F, Timeout = 54F, Id = "ThenMethod")]
        public IAssertionResult ThenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Second Then method", Delay = 11f, Timeout = 33f)]
        [CallBefore(1, "ThenMethod", Delay = 56F, Timeout = 65F, Id = "SecondThenMethod")]
        [CallBefore(2, "SecondGivenMethod", Delay = 65F, Timeout = 64F, Id = "SecondThenMethod")]
        public IAssertionResult SecondThenMethod(int intParam, string stringParam)
        {
            return new AssertionResultSuccessful();
        }
    }
}

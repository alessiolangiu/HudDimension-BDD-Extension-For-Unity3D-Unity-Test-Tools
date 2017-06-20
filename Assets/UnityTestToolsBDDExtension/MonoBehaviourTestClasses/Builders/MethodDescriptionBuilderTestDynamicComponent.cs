namespace HudDimension.UnityTestBDD
{
    public class MethodDescriptionBuilderTestDynamicComponent : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method")]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
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

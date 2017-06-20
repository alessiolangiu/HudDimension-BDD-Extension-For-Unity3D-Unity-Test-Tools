namespace HudDimension.UnityTestBDD
{
    public class ComponentsFilterTestFirstDynamicComponent : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method")]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}

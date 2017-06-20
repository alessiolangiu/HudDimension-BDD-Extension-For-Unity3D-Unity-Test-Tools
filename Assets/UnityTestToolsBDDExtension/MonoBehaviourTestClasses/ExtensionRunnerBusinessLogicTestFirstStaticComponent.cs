namespace HudDimension.UnityTestBDD
{
    public class ExtensionRunnerBusinessLogicTestFirstStaticComponent : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        public IAssertionResult SecondGivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [When(1, "When method", Delay = 21F, Timeout = 34F)]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(2, "Then method")]
        [CallBefore(1, "SecondGivenMethod", Delay = 32F, Timeout = 54F)]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(1, "Second Then method", Delay = 11F, Timeout = 33F)]
        [CallBefore(1, "ThenMethod", Delay = 56F, Timeout = 65F)]
        [CallBefore(2, "SecondGivenMethod", Delay = 65F, Timeout = 64F)]
        public IAssertionResult SecondThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}
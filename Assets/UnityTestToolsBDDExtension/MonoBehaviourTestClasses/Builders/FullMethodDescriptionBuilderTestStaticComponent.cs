namespace HudDimension.UnityTestBDD
{
    public class FullMethodDescriptionBuilderTestStaticComponent : StaticBDDComponent
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

        [When(1, "When method", Delay = 21f, Timeout = 34f)]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
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

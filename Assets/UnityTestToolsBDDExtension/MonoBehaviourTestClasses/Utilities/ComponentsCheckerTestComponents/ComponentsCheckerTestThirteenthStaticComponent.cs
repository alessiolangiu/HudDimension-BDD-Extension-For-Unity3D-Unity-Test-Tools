namespace HudDimension.UnityTestBDD
{
    public class ComponentsCheckerTestThirteenthStaticComponent : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [CallBefore(1, "GivenMethod")]
        [CallBefore(2, "SecondWhenMethod")]
        [CallBefore(3, "GivenMethod")]
        [When(1, "When method")]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        public IAssertionResult SecondWhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [When(2, "Third When method")]
        public IAssertionResult ThirdWhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult SecondThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}
namespace HudDimension.UnityTestBDD
{
    public class ComponentsCheckerTestTwelvethStaticComponent : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        public IAssertionResult SecondWhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult ThirdWhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(1, "Then method")]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(2, "Second Then method")]
        public IAssertionResult SecondThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}
namespace HudDimension.UnityTestBDD
{
    public class CheckForErrorsUTStaticBDDForTestDuplicatedCallBeforeWithParametersAndIds : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod(int intParam)
        {
            return new AssertionResultSuccessful();
        }

        [CallBefore(1, "GivenMethod", Id = "First")]
        [CallBefore(2, "SecondWhenMethod")]
        [CallBefore(3, "GivenMethod", Id = "Second")]
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
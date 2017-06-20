namespace HudDimension.UnityTestBDD
{
    public class MethodsLoaderTestThirdStaticComponent : StaticBDDComponent
    {
            [Given(1, "Given method")]
            public IAssertionResult GivenMethod()
            {
                return new AssertionResultSuccessful();
            }

            [Given(1, "Second Given method")]
            public IAssertionResult SecondGivenMethod()
            {
                return new AssertionResultSuccessful();
            }

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

            [Then(2, "Then method")]
            public IAssertionResult ThenMethod()
            {
                return new AssertionResultSuccessful();
            }

            [Then(1, "Second Then method")]
            public IAssertionResult SecondThenMethod()
            {
                return new AssertionResultSuccessful();
            }
        }
}

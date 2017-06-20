using System.Diagnostics.CodeAnalysis;

namespace HudDimension.UnityTestBDD
{
    public class MethodsManagementUtilitiesTestStaticComponent : StaticBDDComponent
    {
            [Given(1, "Given method")]
            public IAssertionResult GivenMethod()
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

            [GenericBDDMethod]
            public IAssertionResult ThirdWhenMethod()
            {
                return new AssertionResultSuccessful();
            }

            [Then(1, "Then method")]
            public IAssertionResult ThenMethod()
            {
                return new AssertionResultSuccessful();
            }

            [GenericBDDMethod]
            public IAssertionResult SecondThenMethod()
            {
                return new AssertionResultSuccessful();
            }
        }
}
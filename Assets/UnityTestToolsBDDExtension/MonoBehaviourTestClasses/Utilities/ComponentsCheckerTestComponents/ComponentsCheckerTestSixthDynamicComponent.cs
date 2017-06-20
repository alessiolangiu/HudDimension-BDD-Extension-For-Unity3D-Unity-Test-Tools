using System.Diagnostics.CodeAnalysis;
using UnityEngine.UI;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.UnityTestBDD
{
    public class ComponentsCheckerTestSixthDynamicComponent : DynamicBDDComponent
    {
#pragma warning disable 0169
        [ParametersValuesStorage]
        private Button[] buttonPVS;

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

        [When("Second When method")]
        public IAssertionResult SecondWhenMethod(string whenStringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("Third When method")]
        public IAssertionResult ThirdWhenMethod(int whenIntParam)
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
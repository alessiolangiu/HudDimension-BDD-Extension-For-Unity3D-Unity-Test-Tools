//-----------------------------------------------------------------------
// <copyright file="FullMethodDescriptionBuilderTestSecondDynamicComponent.cs" company="Hud Dimension">
//     Copyright (c) Hud Dimension. All rights reserved.
//     http://www.HudDimension.co.uk
// </copyright>
//
// <disclaimer>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </disclaimer>
//
// <author>Alessio Langiu</author>
// <email>alessio.langiu@huddimension.co.uk</email>
//-----------------------------------------------------------------------
namespace HudDimension.UnityTestBDD
{
    public class FullMethodDescriptionBuilderTestSecondDynamicComponent : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Given("Second Given method")]
        public IAssertionResult SecondGivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method", Delay = 21, Timeout = 34)]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        [CallBefore(1, "SecondGivenMethod", Delay = 32, Timeout = 54, Id = "ThenMethod")]
        public IAssertionResult ThenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Second Then method", Delay = 11, Timeout = 33)]
        [CallBefore(1, "ThenMethod", Delay = 56, Timeout = 65, Id = "SecondThenMethod")]
        [CallBefore(2, "SecondGivenMethod", Delay = 65, Timeout = 64, Id = "SecondThenMethod")]
        public IAssertionResult SecondThenMethod(int intParam, string stringParam)
        {
            return new AssertionResultSuccessful();
        }
    }
}

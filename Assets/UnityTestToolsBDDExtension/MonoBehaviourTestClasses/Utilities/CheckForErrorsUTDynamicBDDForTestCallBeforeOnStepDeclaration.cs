//-----------------------------------------------------------------------
// <copyright file="CheckForErrorsUTDynamicBDDForTestCallBeforeOnStepDeclaration.cs" company="Hud Dimesion">
//     Copyright (c) Hud Dimension. All rights reserved.
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
    public class CheckForErrorsUTDynamicBDDForTestCallBeforeOnStepDeclaration : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [CallBefore(1, "GivenMethod")]
        [CallBefore(2, "GivenMethod")]
        [CallBefore(3, "GivenMethod")]
        [When("When method")]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [CallBefore(1, "GivenMethod")]
        public IAssertionResult SecondWhenMethod(string whenStringParam)
        {
            return new AssertionResultSuccessful();
        }

        [CallBefore(1, "SecondWhenMethod")]
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
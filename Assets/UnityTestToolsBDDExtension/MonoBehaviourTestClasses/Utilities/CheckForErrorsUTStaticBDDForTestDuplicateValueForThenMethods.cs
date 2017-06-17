//-----------------------------------------------------------------------
// <copyright file="CheckForErrorsUTStaticBDDForTestDuplicateValueForThenMethods.cs" company="Hud Dimesion">
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
    public class CheckForErrorsUTStaticBDDForTestDuplicateValueForThenMethods : StaticBDDComponent
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

        [Then(1, "Then method")]
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
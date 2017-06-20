//-----------------------------------------------------------------------
// <copyright file="MethodsLoaderTestSecondStaticComponent.cs" company="Hud Dimension">
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
    public class MethodsLoaderTestSecondStaticComponent : StaticBDDComponent
    {
            [Given(1, "Given method")]
            public IAssertionResult GivenMethod()
            {
                return new AssertionResultSuccessful();
            }

            [Given(3, "Second Given method")]
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

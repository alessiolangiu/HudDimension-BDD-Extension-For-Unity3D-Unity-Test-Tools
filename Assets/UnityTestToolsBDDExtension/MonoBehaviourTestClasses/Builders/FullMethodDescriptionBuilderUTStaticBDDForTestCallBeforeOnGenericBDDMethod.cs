//-----------------------------------------------------------------------
// <copyright file="FullMethodDescriptionBuilderUTStaticBDDForTestCallBeforeOnGenericBDDMethod.cs" company="Hud Dimension">
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
    public class FullMethodDescriptionBuilderUTStaticBDDForTestCallBeforeOnGenericBDDMethod : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        [CallBefore(1, "GivenMethod", Delay = 32F, Timeout = 54F)]
        public IAssertionResult SecondGivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [When(1, "When method", Delay = 21f, Timeout = 34f)]
        [CallBefore(1, "SecondGivenMethod")]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        [CallBefore(1, "SecondGivenMethod", Delay = 32F, Timeout = 54F)]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(1, "Second Then method", Delay = 11F, Timeout = 33F)]
        [CallBefore(1, "ThenMethod", Delay = 56F, Timeout = 65F)]
        [CallBefore(2, "SecondGivenMethod", Delay = 65F, Timeout = 64F)]
        public IAssertionResult SecondThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}

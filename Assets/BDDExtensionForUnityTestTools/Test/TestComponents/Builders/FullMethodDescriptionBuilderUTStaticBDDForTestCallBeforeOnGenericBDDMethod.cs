﻿//-----------------------------------------------------------------------
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
namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class FullMethodDescriptionBuilderUTStaticBDDForTestCallBeforeOnGenericBDDMethod : StaticBDDComponent
    {
        [Given(1, "Given method")]
        public IAssertionResult GivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        [CallBefore(1, "GivenMethod", Delay = 32, Timeout = 54)]
        public IAssertionResult SecondGivenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [When(1, "When method", Delay = 21, Timeout = 34)]
        [CallBefore(1, "SecondGivenMethod")]
        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [GenericBDDMethod]
        [CallBefore(1, "SecondGivenMethod", Delay = 32, Timeout = 54)]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then(1, "Second Then method", Delay = 11, Timeout = 33)]
        [CallBefore(1, "ThenMethod", Delay = 56, Timeout = 65)]
        [CallBefore(2, "SecondGivenMethod", Delay = 65, Timeout = 64)]
        public IAssertionResult SecondThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}

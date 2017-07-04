//-----------------------------------------------------------------------
// <copyright file="MethodsManagementUtilitiesTestStaticComponent.cs" company="Hud Dimension">
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
using System.Diagnostics.CodeAnalysis;

namespace HudDimension.BDDExtensionForUnityTestTools
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
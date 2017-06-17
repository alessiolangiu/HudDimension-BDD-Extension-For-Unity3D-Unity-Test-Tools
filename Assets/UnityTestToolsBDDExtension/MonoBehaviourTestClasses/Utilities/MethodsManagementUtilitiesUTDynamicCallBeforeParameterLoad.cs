//-----------------------------------------------------------------------
// <copyright file="MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad.cs" company="Hud Dimesion">
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
    public class MethodsManagementUtilitiesUTDynamicCallBeforeParameterLoad : DynamicBDDComponent
    {
        [Given("Given method")]
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [Given("Second Given method")]
        [CallBefore(1, "GivenMethod")]
        public IAssertionResult SecondGivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        [When("When method", Delay = 21F, Timeout = 34)]
        public IAssertionResult WhenMethod(string whenStringParam, int whenIntParam)
        {
            return new AssertionResultSuccessful();
        }

        [Then("Then method")]
        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }

        [Then("Second Then method", Delay = 11F, Timeout = 33F)]
        public IAssertionResult SecondThenMethod(int intParam, float floatParam)
        {
            return new AssertionResultSuccessful();
        }
    }
}
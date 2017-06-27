//-----------------------------------------------------------------------
// <copyright file="TemplateDynamicBDDComponent.cs" company="Hud Dimension">
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
using HudDimension.UnityTestBDD;

public class TemplateDynamicBDDComponent : DynamicBDDComponent
{
    [Given("given text", Delay = 1000)]
    public IAssertionResult GivenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }

    [When("when text")]
    public IAssertionResult WhenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }

    [Then("then text")]
    public IAssertionResult ThenMethod()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        return result;
    }
}
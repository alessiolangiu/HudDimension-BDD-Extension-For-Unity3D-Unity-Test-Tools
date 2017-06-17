﻿//-----------------------------------------------------------------------
// <copyright file="TemplateDynamicBDD.cs" company="Hud Dimesion">
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
using HudDimension.UnityTestBDD;

public class TemplateDynamicBDDComponent : DynamicBDDComponent
{
    [Given("given text", Delay = 1000f)]
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
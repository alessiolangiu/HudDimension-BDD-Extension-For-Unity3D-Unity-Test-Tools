//-----------------------------------------------------------------------
// <copyright file="CreationOfGameObjectBDDStaticFirstScenario.cs" company="Hud Dimension">
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
using UnityEngine;
using UnityEngine.UI;

public class CreationOfGameObjectBDDStaticFirstScenario : StaticBDDComponent
{
    private const string ButtonCreateTag = "BUTTON CREATE";

    private const string CubeTag = "CUBE";

    [Given(1, "the program is just started and waiting for an input", Delay = 1000f)]
    public IAssertionResult StartedAndWaitingForInput()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(CubeTag);
        GameObject buttonCreate = GameObject.FindWithTag(ButtonCreateTag);
        if (buttonCreate == null)
        {
            result = new AssertionResultRetry("Button Create not found");
        }
        else if (cube != null)
        {
            result = new AssertionResultFailed("There is an unexpected cube in the scene.");
        }
        else if (buttonCreate != null && buttonCreate.activeSelf)
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }

    [When(1, "I press the button \"Create\"")]
    public IAssertionResult PressTheButtonCreate()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        GameObject buttonCreate = GameObject.FindWithTag(ButtonCreateTag);
        Button button = buttonCreate.GetComponent<Button>();
        button.onClick.Invoke();
        return result;
    }

    [Then(1, "an object named \"object for test\" has to appear on the scene")]
    public IAssertionResult TheNewObjectAppears()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(CubeTag);
        if (cube == null)
        {
            result = new AssertionResultRetry("\"object for test\" not found");
        }
        else if (cube != null && cube.activeSelf)
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }
}
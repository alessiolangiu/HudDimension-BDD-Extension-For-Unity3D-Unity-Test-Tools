//-----------------------------------------------------------------------
// <copyright file="CreationOfGameObjectBDDStaticThirdScenario.cs" company="Hud Dimension">
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

public class CreationOfGameObjectBDDStaticThirdScenario : StaticBDDComponent
{
    private const string ButtonCreateTag = "BUTTON CREATE";

    private const string Cube = "CUBE";

    [GenericBDDMethod]
    public IAssertionResult StartedAndWaitingForInput()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(Cube);
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

    [GenericBDDMethod]
    public IAssertionResult TheNewObjectAppears()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(Cube);
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

    [Given(1, "There is a cube in the scene")]
    [CallBefore(1, "StartedAndWaitingForInput", Delay = 1000f)]
    [CallBefore(2, "PressTheButtonCreate")]
    [CallBefore(3, "TheNewObjectAppears")]
    public IAssertionResult ThereIsACubeInTheScene()
    {
        return new AssertionResultSuccessful();
    }

    [Then(1, "only one object named \"object for test\" has to be in the scene", Delay = 1000f)]
    public IAssertionResult OnlyACubeInTheScene()
    {
        IAssertionResult result = null;
        GameObject[] cubes = GameObject.FindGameObjectsWithTag(Cube);
        if (cubes == null || cubes.Length == 0)
        {
            result = new AssertionResultRetry("No \"object for test\" not found");
        }
        else if (cubes.Length > 1)
        {
            result = new AssertionResultFailed("More than one \"object for test\" objects are in the scene");
        }
        else
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }
}
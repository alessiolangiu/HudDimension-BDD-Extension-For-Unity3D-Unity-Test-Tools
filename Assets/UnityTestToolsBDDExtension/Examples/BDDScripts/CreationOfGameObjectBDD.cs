//-----------------------------------------------------------------------
// <copyright file="CreationOfGameObjectBDD.cs" company="Hud Dimension">
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

public class CreationOfGameObjectBDD : DynamicBDDComponent
{
    private const string ButtonCreateTag = "BUTTON CREATE";

    private const string ButtonDeleteTag = "BUTTON DELETE";

    private const string CubeTag = "CUBE";

    [SerializeField]
    private GameObject warningTextObject;

    public GameObject WarningTextObject
    {
        get
        {
            return this.warningTextObject;
        }

        set
        {
            this.warningTextObject = value;
        }
    }

    [Given("the program is just started and waiting for an input", Delay = 100f)]
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

    [When("I press the button \"Create\"")]
    public IAssertionResult PressTheButtonCreate()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        GameObject buttonCreate = GameObject.FindWithTag(ButtonCreateTag);
        Button button = buttonCreate.GetComponent<Button>();
        button.onClick.Invoke();
        return result;
    }

    [Then("an object named \"object for test\" has to appear on the scene")]
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

    [Given("There is a cube in the scene")]
    [CallBefore(1, "StartedAndWaitingForInput")]
    [CallBefore(2, "PressTheButtonCreate")]
    [CallBefore(3, "TheNewObjectAppears")]
    public IAssertionResult ThereIsACubeInTheScene()
    {
        return new AssertionResultSuccessful();
    }

    [When("I press the button \"Delete\"")]
    public IAssertionResult PressTheButtonDelete()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        GameObject buttonDelete = GameObject.FindWithTag(ButtonDeleteTag);
        Button button = buttonDelete.GetComponent<Button>();
        button.onClick.Invoke();
        return result;
    }

    [Then("the object named \"object for test\" has to be deleted from the scene")]
    public IAssertionResult TheCubeDisappears()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(CubeTag);
        if (cube != null && cube.activeSelf)
        {
            result = new AssertionResultRetry("\"object for test\" found and Active");
        }
        else if (cube != null)
        {
            result = new AssertionResultRetry("\"object for test\" found inactive");
        }
        else
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }

    [Then("only one object named \"object for test\" has to be in the scene", Delay = 1000f)]
    public IAssertionResult OnlyACubeInTheScene()
    {
        IAssertionResult result = null;
        GameObject[] cubes = GameObject.FindGameObjectsWithTag(CubeTag);
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

    [Then("the warning message \"%expectedWarningText%\" appears in the scene", Delay = 1000f)]
    public IAssertionResult WarningInTheScene(string expectedWarningText)
    {
        IAssertionResult result = null;

        if (this.WarningTextObject == null)
        {
            result = new AssertionResultRetry("No warning on the scene");
        }
        else if (!this.WarningTextObject.activeSelf)
        {
            result = new AssertionResultRetry("No visible warning on the scene");
        }
        else
        {
            Text text = this.WarningTextObject.GetComponent<Text>();
            if (text.text.Equals(expectedWarningText))
            {
                result = new AssertionResultSuccessful();
            }
            else
            {
                result = new AssertionResultFailed("The warning message has not the expected text: \"" + text.text + "\" instead of \"" + expectedWarningText);
            }
        }

        return result;
    }
}
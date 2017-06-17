//-----------------------------------------------------------------------
// <copyright file="CreationOfGameObjectBDDStaticFourthScenario.cs" company="Hud Dimesion">
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
using UnityEngine;
using UnityEngine.UI;

public class CreationOfGameObjectBDDStaticFourthScenario : StaticBDDComponent
{
    private const string ButtonCreateTag = "BUTTON CREATE";

    private const string ButtonDeleteTag = "BUTTON DELETE";

    private const string CubeTag = "CUBE";

    private string expectedWarningText = "Warning! No Object to delete!";

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

    public string ExpectedWarningText
    {
        get
        {
            return this.expectedWarningText;
        }

        set
        {
            this.expectedWarningText = value;
        }
    }

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

    [When(1, "I press the button \"Delete\"")]
    public IAssertionResult PressTheButtonDelete()
    {
        IAssertionResult result = new AssertionResultSuccessful();
        GameObject buttonDelete = GameObject.FindWithTag(ButtonDeleteTag);
        Button button = buttonDelete.GetComponent<Button>();
        button.onClick.Invoke();
        return result;
    }

    [Then(1, "the warning message \"Warning! No Object to delete!\" appears in the scene", Delay = 1000f)]
    public IAssertionResult WarningInTheScene()
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
            if (text.text.Equals(this.ExpectedWarningText))
            {
                result = new AssertionResultSuccessful();
            }
            else
            {
                result = new AssertionResultFailed("The warning message has not the expected text: \"" + text.text + "\" instead of \"" + this.ExpectedWarningText);
            }
        }

        return result;
    }
}
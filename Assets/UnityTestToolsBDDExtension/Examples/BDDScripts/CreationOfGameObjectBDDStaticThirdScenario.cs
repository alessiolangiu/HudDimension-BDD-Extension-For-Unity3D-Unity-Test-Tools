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
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreationOfGameObjectBDDStaticThirdScenario : StaticBDDComponent
{
    private const string ButtonCreateTag = "BUTTON CREATE";

    private const string CubeTag = "CUBE";

    private const string CubeName = "object for test";

    private GameObject[] listOfCubesInTheScene = null;

    [GenericBDDMethod]
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

    [GenericBDDMethod]
    public IAssertionResult TheNewObjectAppears()
    {
        IAssertionResult result = null;
        GameObject cube = GameObject.FindWithTag(CubeTag);
        if (cube == null || !cube.name.Equals(CubeName))
        {
            result = new AssertionResultRetry("\"" + CubeName + "\" not found");
        }
        else if (cube != null && cube.activeSelf)
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }

    [GenericBDDMethod]
    public IAssertionResult StoreTheListOfCubesInTheScene()
    {
        this.listOfCubesInTheScene = GameObject.FindGameObjectsWithTag(CubeTag);
        return new AssertionResultSuccessful(); ;
    }

    [Given(1, "there is a cube in the scene called \"object for test\"")]
    [CallBefore(1, "StartedAndWaitingForInput")]
    [CallBefore(2, "PressTheButtonCreate")]
    [CallBefore(3, "TheNewObjectAppears")]
    [CallBefore(4, "StoreTheListOfCubesInTheScene")]
    public IAssertionResult ThereIsACubeInTheSceneAndStoreItForAFollowingUse()
    {
        return new AssertionResultSuccessful();
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

    [Then(1, "nothing is going to change in the scene.", Delay = 1000)]
    public IAssertionResult OnlyACubeInTheScene()
    {
        IAssertionResult result = null;
        GameObject[] cubes = GameObject.FindGameObjectsWithTag(CubeTag);
        if (this.listOfCubesInTheScene.SequenceEqual(cubes) == false)
        {
            result = new AssertionResultFailed("The objects in the scene are changed!");
        }
        else
        {
            result = new AssertionResultSuccessful();
        }

        return result;
    }
}
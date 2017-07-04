//-----------------------------------------------------------------------
// <copyright file="UnitTestUtility.cs" company="Hud Dimension">
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
using System.Collections.Generic;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public static class UnitTestUtility
    {
        private static List<GameObject> gameObjects = new List<GameObject>();

        public static T CreateComponent<T>() where T : MonoBehaviour
        {
            GameObject gameObject = new GameObject();
            T component = gameObject.AddComponent<T>();
            gameObjects.Add(gameObject);
            return component;
        }

        public static GameObject CreateGameObject()
        {
            GameObject gameObject = new GameObject();
            gameObjects.Add(gameObject);
            return gameObject;
        }

        public static void DestroyTemporaryTestGameObjects()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                GameObject.DestroyImmediate(gameObject);
            }
            gameObjects = new List<GameObject>();
        }
    }
}
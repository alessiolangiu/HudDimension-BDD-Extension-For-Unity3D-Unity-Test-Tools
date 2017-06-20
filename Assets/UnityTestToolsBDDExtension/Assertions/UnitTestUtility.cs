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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public static class UnitTestUtility
    {
        public static T CreateComponent<T>() where T : MonoBehaviour
        {
            GameObject gameObject = new GameObject();
            T component = gameObject.AddComponent<T>();
            return component;
        }
    }
}
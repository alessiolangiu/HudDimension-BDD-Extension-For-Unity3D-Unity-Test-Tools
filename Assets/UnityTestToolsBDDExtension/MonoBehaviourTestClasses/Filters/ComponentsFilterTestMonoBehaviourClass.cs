//-----------------------------------------------------------------------
// <copyright file="ComponentsFilterTestMonoBehaviourClass.cs" company="Hud Dimension">
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
    public class ComponentsFilterTestMonoBehaviourClass : MonoBehaviour
    {
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}

﻿//-----------------------------------------------------------------------
// <copyright file="BDDComponentsFilterUTNoBDDComponentForTest.cs" company="Hud Dimesion">
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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class BDDComponentsFilterUTNoBDDComponentForTest : MonoBehaviour
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
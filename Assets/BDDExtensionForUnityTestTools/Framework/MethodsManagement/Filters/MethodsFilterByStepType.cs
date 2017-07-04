﻿//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByStepType.cs" company="Hud Dimension">
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
using System.Reflection;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class MethodsFilterByStepType : IMethodsFilter
    {
        public bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration
        {
            if (method.GetCustomAttributes(typeof(T), true).Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}

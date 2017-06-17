//-----------------------------------------------------------------------
// <copyright file="StepMethodUtilities.cs" company="Hud Dimesion">
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
using System;

namespace HudDimension.UnityTestBDD
{
    public static class StepMethodUtilities
    {
        public static string GetStepMethodName<T>() where T : IGivenWhenThenDeclaration
        {
            IGivenWhenThenDeclaration declaration = Activator.CreateInstance(typeof(T), string.Empty) as IGivenWhenThenDeclaration;
            string result = declaration.GetStepName();
            return result;
        }
    }
}

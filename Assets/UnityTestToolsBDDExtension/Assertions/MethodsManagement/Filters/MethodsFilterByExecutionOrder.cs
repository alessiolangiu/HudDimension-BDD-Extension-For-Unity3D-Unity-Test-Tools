//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByExecutionOrder.cs" company="Hud Dimesion">
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
using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodsFilterByExecutionOrder : IMethodsFilter
    {
        public bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration
        {
            if (!typeof(StaticBDDComponent).IsAssignableFrom(method.DeclaringType))
            {
                return false;
            }

            object[] attributes = method.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}

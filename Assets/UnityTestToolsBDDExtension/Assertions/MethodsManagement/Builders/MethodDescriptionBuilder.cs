//-----------------------------------------------------------------------
// <copyright file="MethodDescriptionBuilder.cs" company="Hud Dimesion">
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
using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodDescriptionBuilder
    {
        public virtual MethodDescription Build(MethodParametersLoader methodParametersLoader, BaseMethodDescription baseMethodDescription, string parametersIndex)
        {
            if (baseMethodDescription != null)
            {
                MethodDescription result = new MethodDescription();
                result.ComponentObject = baseMethodDescription.ComponentObject;
                result.Method = baseMethodDescription.Method;
                result.StepType = baseMethodDescription.StepType;
                result.Text = baseMethodDescription.Text;
                result.ExecutionOrder = baseMethodDescription.ExecutionOrder;
                result.ParametersIndex = parametersIndex;
                result.Parameters = methodParametersLoader.LoadMethodParameters(result.ComponentObject, result.Method, string.Empty, result.ParametersIndex);
                return result;
            }

            return null;             
        }
    }
}

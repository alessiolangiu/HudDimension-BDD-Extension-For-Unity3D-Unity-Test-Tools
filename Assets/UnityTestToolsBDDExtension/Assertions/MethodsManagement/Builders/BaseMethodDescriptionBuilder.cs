//-----------------------------------------------------------------------
// <copyright file="BaseMethodDescriptionBuilder.cs" company="Hud Dimension">
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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class BaseMethodDescriptionBuilder
    {
        public virtual BaseMethodDescription Build<T>(Component component, MethodInfo methodInfo) where T : IGivenWhenThenDeclaration
        {
            BaseMethodDescription result = new BaseMethodDescription();
            result.ComponentObject = component;
            result.Method = methodInfo;
            result.StepType = typeof(T);
            object[] attributes = methodInfo.GetCustomAttributes(typeof(T), true);
            IGivenWhenThenDeclaration gwtBaseAttribute = (IGivenWhenThenDeclaration)attributes[0];
            result.Text = gwtBaseAttribute.GetStepScenarioText();
            result.ExecutionOrder = gwtBaseAttribute.GetExecutionOrder();
            return result;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="BDDMethodBaseAttribute.cs" company="Hud Dimension">
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
using System;

namespace HudDimension.UnityTestBDD
{
    [AttributeUsage(System.AttributeTargets.Method)]
    public abstract class BDDMethodBaseAttribute : Attribute, IGivenWhenThenDeclaration
    {
        public abstract float GetDelay();

        public abstract uint GetExecutionOrder();

        public abstract string GetStepName();

        public abstract string GetStepScenarioText();

        public abstract float GetTimeout();
    }
}

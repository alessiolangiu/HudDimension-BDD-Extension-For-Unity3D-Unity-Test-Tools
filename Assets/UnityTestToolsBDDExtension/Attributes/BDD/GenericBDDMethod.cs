//-----------------------------------------------------------------------
// <copyright file="GenericBDDMethod.cs" company="Hud Dimension">
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
    public class GenericBDDMethod : BDDMethodBaseAttribute
    {
        public override string GetStepName()
        {
            return "Generic";
        }

        public override string GetStepScenarioText()
        {
            return null;
        }

        public override uint GetExecutionOrder()
        {
            return 0;
        }

        public override float GetDelay()
        {
            return 0f;
        }

        public override float GetTimeout()
        {
            return 0f;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="GivenBaseAttribute.cs" company="Hud Dimesion">
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
    [AttributeUsage(System.AttributeTargets.Method)]
    public class GivenBaseAttribute : BDDMethodBaseAttribute
    {
        public GivenBaseAttribute(string text)
        {
            this.Text = text;
        }

        public float Delay { get; set; }

        public float Timeout { get; set; }

        public string Text { get; set; }

        public override string GetStepName()
        {
            return "Given";
        }

        public override string GetStepScenarioText()
        {
            return this.Text;
        }

        public override uint GetExecutionOrder()
        {
            return 0;
        }

        public override float GetDelay()
        {
            return this.Delay;
        }

        public override float GetTimeout()
        {
            return this.Timeout;
        }
    }
}

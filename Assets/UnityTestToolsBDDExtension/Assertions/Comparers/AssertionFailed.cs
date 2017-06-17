//-----------------------------------------------------------------------
// <copyright file="AssertionFailed.cs" company="Hud Dimesion">
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
using UnityTest;

namespace HudDimension.UnityTestBDD
{
    internal class AssertionFailed : ActionBase
    {
        public string ErrorText { get; set; }

        public string ScenarioText { get; set; }

        public string BDDMethodLocation { get; set; }

        public override string GetFailureMessage()
        {
            string text = "Test Failed!\nReason: " + this.ErrorText;
            if (this.ScenarioText != null)
            {
                text += "\n For the scenario:\n" + this.ScenarioText;
            }

            if (this.BDDMethodLocation != null)
            {
                text += "\n BDD Method: \n" + this.BDDMethodLocation;
            }

            return text;
        }

        protected override bool Compare(object objVal)
        {
            return false;
        }
    }
}

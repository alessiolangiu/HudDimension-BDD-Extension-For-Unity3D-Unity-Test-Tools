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

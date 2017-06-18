using System;

namespace HudDimension.UnityTestBDD
{
    [AttributeUsage(System.AttributeTargets.Method)]
    public class WhenBaseAttribute : BDDMethodBaseAttribute
    {
        public WhenBaseAttribute(string text)
        {
            this.Text = text;
        }

        public float Delay { get; set; }

        public float Timeout { get; set; }

        public string Text { get; set; }

        public override string GetStepName()
        {
            return "When";
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

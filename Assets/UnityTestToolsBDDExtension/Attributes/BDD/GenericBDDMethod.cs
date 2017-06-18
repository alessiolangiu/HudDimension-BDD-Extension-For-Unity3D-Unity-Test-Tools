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

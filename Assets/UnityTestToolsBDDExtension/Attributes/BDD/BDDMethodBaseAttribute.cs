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

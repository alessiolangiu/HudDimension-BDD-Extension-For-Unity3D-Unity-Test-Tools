using System;

namespace HudDimension.UnityTestBDD
{
    public interface IGivenWhenThenDeclaration
    {
        string GetStepName();

        string GetStepScenarioText();

        uint GetExecutionOrder();

        float GetDelay();

        float GetTimeout();
    }
}

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

using System;
using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodDescriptionBuilder
    {
        public virtual MethodDescription Build(MethodParametersLoader methodParametersLoader, BaseMethodDescription baseMethodDescription, string parametersIndex)
        {
            if (baseMethodDescription != null)
            {
                MethodDescription result = new MethodDescription();
                result.ComponentObject = baseMethodDescription.ComponentObject;
                result.Method = baseMethodDescription.Method;
                result.StepType = baseMethodDescription.StepType;
                result.Text = baseMethodDescription.Text;
                result.ExecutionOrder = baseMethodDescription.ExecutionOrder;
                result.ParametersIndex = parametersIndex;
                result.Parameters = methodParametersLoader.LoadMethodParameters(result.ComponentObject, result.Method, string.Empty, result.ParametersIndex);
                return result;
            }

            return null;             
        }
    }
}

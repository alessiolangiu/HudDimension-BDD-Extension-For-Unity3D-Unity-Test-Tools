using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class FullMethodDescriptionBuilder
    {
        public virtual List<FullMethodDescription> BuildFromBaseMethodDescription(BaseMethodDescription baseMethodDescription, uint stepNumber)
        {
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            string parametersIndex = string.Empty;
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            return this.Build(methodDescription, stepNumber);
        }

        public virtual List<FullMethodDescription> Build(MethodDescription methodDescription, uint stepNumber)
        {
            List<FullMethodDescription> result = new List<FullMethodDescription>();
            if (methodDescription != null)
            {
                FullMethodDescription mainFullMethodDescription = this.GetFullMethodDescription(methodDescription.ComponentObject, methodDescription.Method, methodDescription.StepType, methodDescription.Text, methodDescription.Parameters, methodDescription.ParametersIndex, methodDescription.ExecutionOrder, 0, 0, stepNumber, string.Empty, null);
                this.AddDelayAndTimeoutToMainFullMethodDescription(mainFullMethodDescription);
                result = this.GetCallBeforeListFullMethodsDescriptions(mainFullMethodDescription, mainFullMethodDescription.ParametersIndex);
                result.Add(mainFullMethodDescription);
            }

            return result;
        }

        private void AddDelayAndTimeoutToMainFullMethodDescription(FullMethodDescription mainFullMethodDescription)
        {
            object[] customCallBeforeAttributes = mainFullMethodDescription.Method.GetCustomAttributes(mainFullMethodDescription.StepType, true);
            IGivenWhenThenDeclaration bddBethodBaseAttribute = (IGivenWhenThenDeclaration)customCallBeforeAttributes[0];
            mainFullMethodDescription.Delay = bddBethodBaseAttribute.GetDelay();
            mainFullMethodDescription.TimeOut = bddBethodBaseAttribute.GetTimeout();
        }

        private List<FullMethodDescription> GetCallBeforeListFullMethodsDescriptions(FullMethodDescription mainMethodDescription, string parametersIndex)
        {
            List<FullMethodDescription> result = new List<FullMethodDescription>();
            object[] customCallBeforeAttributes = mainMethodDescription.Method.GetCustomAttributes(typeof(CallBefore), true);
            foreach (object callBeforeAttribute in customCallBeforeAttributes)
            {
                CallBefore callBefore = (CallBefore)callBeforeAttribute;
                if (callBefore.Method != null && !callBefore.Method.Equals(string.Empty))
                {
                    FullMethodDescription callBeforeFullMethodDescription = this.GetCallBeforeFullMethodDescription(callBefore, mainMethodDescription, parametersIndex);
                    List<FullMethodDescription> listOfCallBeforeFullMethodDescriptions = this.GetCallBeforeListFullMethodsDescriptions(callBeforeFullMethodDescription, parametersIndex);
                    result.AddRange(listOfCallBeforeFullMethodDescriptions);
                    result.Add(callBeforeFullMethodDescription);
                }
            }

            result.Sort();
            return result;
        }

        private FullMethodDescription GetCallBeforeFullMethodDescription(CallBefore callBefore, FullMethodDescription mainMethod, string parametersIndex)
        {
            MethodInfo methodInfo = mainMethod.ComponentObject.GetType().GetMethod(callBefore.Method);
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            string fullId = methodsManagementUtilities.GetMainFullId(mainMethod) + callBefore.Id;
            MethodParameters methodParameters = methodParametersLoader.LoadMethodParameters(mainMethod.ComponentObject, methodInfo, fullId, parametersIndex);

            FullMethodDescription result = this.GetFullMethodDescription(mainMethod.ComponentObject, methodInfo, mainMethod.StepType, mainMethod.Text, methodParameters, string.Empty, 0, callBefore.Delay, callBefore.Timeout, callBefore.ExecutionOrder, callBefore.Id, mainMethod);
            return result;
        }

        private FullMethodDescription GetFullMethodDescription(Component componentObject, MethodInfo method, Type stepType, string text, MethodParameters parameters, string parametersIndex, uint executionOrder, float delay, float timeOut, uint callBeforeExecutionOrder, string id, FullMethodDescription mainMethod)
        {
            FullMethodDescription result = new FullMethodDescription();
            result.ComponentObject = componentObject;
            result.Method = method;
            result.StepType = stepType;
            result.Text = text;
            result.Parameters = parameters;
            result.ParametersIndex = parametersIndex;
            result.ExecutionOrder = executionOrder;
            result.Delay = delay;
            result.TimeOut = timeOut;
            result.SuccessionOrder = callBeforeExecutionOrder;
            result.MainMethod = mainMethod;
            result.Id = id;

            return result;
        }
    }
}

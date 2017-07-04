//-----------------------------------------------------------------------
// <copyright file="ExtensionRunnerBusinessLogic.cs" company="Hud Dimension">
//     Copyright (c) Hud Dimension. All rights reserved.
//     http://www.HudDimension.co.uk
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
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityTest;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class ExtensionRunnerBusinessLogic
    {
        public ExtensionRunnerBusinessLogic(GameObject gameObject)
        {
            this.RunnerGameObject = gameObject;
        }

        public List<FullMethodDescription> MethodsDescription { get; set; }

        public DateTime StartDelayTime { get; set; }

        public DateTime? StartTimoutTime { get; set; }

        public int IndexToRun { get; set; }

        public GameObject RunnerGameObject { get; set; }

        public bool AreThereErrors { get; internal set; }

        public List<FullMethodDescription> GetAllMethodsDescriptions(
            Component[] allComponents,
            string[] givenMethods,
            string[] givenParameters,
            string[] whenMethods,
            string[] whenParameters,
            string[] thenMethods,
            string[] thenParameters)
        {
            List<FullMethodDescription> result = new List<FullMethodDescription>();
            ComponentsFilter componentsFilter = new ComponentsFilter();
            Component[] components = componentsFilter.Filter(allComponents);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            if (methodsManagementUtilities.IsStaticBDDScenario(components))
            {
                result.AddRange(this.GetAllStaticFullMethodsDescriptions<GivenBaseAttribute>(components, methodsManagementUtilities));
                result.AddRange(this.GetAllStaticFullMethodsDescriptions<WhenBaseAttribute>(components, methodsManagementUtilities));
                result.AddRange(this.GetAllStaticFullMethodsDescriptions<ThenBaseAttribute>(components, methodsManagementUtilities));
            }
            else
            {
                result.AddRange(this.GetAllDynamicFullMethodsDescriptions<GivenBaseAttribute>(components, methodsManagementUtilities, givenMethods, givenParameters));
                result.AddRange(this.GetAllDynamicFullMethodsDescriptions<WhenBaseAttribute>(components, methodsManagementUtilities, whenMethods, whenParameters));
                result.AddRange(this.GetAllDynamicFullMethodsDescriptions<ThenBaseAttribute>(components, methodsManagementUtilities, thenMethods, thenParameters));
            }

            return result;
        }

        public List<FullMethodDescription> GetAllStaticFullMethodsDescriptions<T>(Component[] bddComponents, MethodsManagementUtilities methodsManagementUtilities) where T : IGivenWhenThenDeclaration
        {
            List<FullMethodDescription> result = null;
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByExecutionOrder);
            List<BaseMethodDescription> methodsList = bddStepMethodsLoader.LoadStepMethods<T>(bddComponents);
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            result = methodsManagementUtilities.LoadFullMethodsDescriptions<T>(methodsList, fullMethodDescriptionBuilder);

            return result;
        }

        public int RunCycle(ExtensionRunnerBusinessLogic businessLogic, List<FullMethodDescription> methodsDescription, int indexToRun)
        {
            int runningIndex = indexToRun;
            if (runningIndex == -1)
            {
                runningIndex++;
                businessLogic.StartDelayTime = businessLogic.DateTimeNow();
            }

            if (runningIndex < methodsDescription.Count)
            {
                bool performed = businessLogic.InvokeMethod(businessLogic, methodsDescription[runningIndex], businessLogic.RunnerGameObject);
                if (performed)
                {
                    runningIndex++;
                    businessLogic.StartDelayTime = businessLogic.DateTimeNow();
                }
            }
            else
            {
                businessLogic.InvokeAssertionSuccess(businessLogic.RunnerGameObject);
            }

            return runningIndex;
        }

        public virtual DateTime DateTimeNow()
        {
            return DateTime.Now;
        }

        public virtual bool InvokeMethod(ExtensionRunnerBusinessLogic businessLogic, FullMethodDescription methodDescription, GameObject gameObject)
        {
            bool performed = false;
            if (businessLogic.DateTimeNow().Subtract(businessLogic.StartDelayTime).TotalMilliseconds >= methodDescription.Delay)
            {
                if (businessLogic.StartTimoutTime == null)
                {
                    businessLogic.StartTimoutTime = businessLogic.DateTimeNow();
                }

                if (methodDescription.Method != null && !methodDescription.Method.Equals(string.Empty))
                {
                    MethodInfo method = methodDescription.Method;
                    Component component = methodDescription.ComponentObject;
                    object[] parameters = businessLogic.GetParametersValues(methodDescription);
                    IAssertionResult executionResult = null;

                    object executionResultObject = method.Invoke(component, parameters);
                    if (executionResultObject == null)
                    {
                        string errorText = "The Step Method return null.";
                        string scenarioText = businessLogic.GetScenarioTextForErrorInSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                        string bddMethodLocation = businessLogic.GetbddMethodLocationForSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                        businessLogic.InvokeAssertionFailed(errorText, scenarioText, bddMethodLocation, gameObject);
                        return true;
                    }
                    if(typeof(AssertionResultSuccessful).IsAssignableFrom(executionResultObject.GetType()) ||
                        typeof(AssertionResultFailed).IsAssignableFrom(executionResultObject.GetType()) ||
                        typeof(AssertionResultRetry).IsAssignableFrom(executionResultObject.GetType()))
                    
                    {
                        executionResult = (IAssertionResult)executionResultObject;
                    }
                    else
                    {
                        string errorText = "The return value of the Step Method is not a valid IAssertionResult implementation.";
                        string scenarioText = businessLogic.GetScenarioTextForErrorInSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                        string bddMethodLocation = businessLogic.GetbddMethodLocationForSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                        businessLogic.InvokeAssertionFailed(errorText, scenarioText, bddMethodLocation, gameObject);
                        return true;
                    }

                    if (executionResult is AssertionResultSuccessful)
                    {
                        performed = true;
                    }
                    else if (executionResult is AssertionResultFailed)
                    {
                        string errorText = ((AssertionResultFailed)executionResult).Text;

                        string scenarioText = businessLogic.GetScenarioTextForErrorInSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                        string bddMethodLocation = businessLogic.GetbddMethodLocationForSpecificMethod(businessLogic.MethodsDescription, methodDescription);

                        businessLogic.InvokeAssertionFailed(errorText, scenarioText, bddMethodLocation, gameObject);
                        performed = true;
                    }
                    else if (executionResult is AssertionResultRetry)
                    {
                        if (businessLogic.DateTimeNow().Subtract(businessLogic.StartTimoutTime ?? DateTime.MaxValue).TotalMilliseconds >= methodDescription.TimeOut)
                        {
                            string errorText = ((AssertionResultRetry)executionResult).Text;

                            string scenarioText = businessLogic.GetScenarioTextForErrorInSpecificMethod(businessLogic.MethodsDescription, methodDescription);
                            string bddMethodLocation = businessLogic.GetbddMethodLocationForSpecificMethod(businessLogic.MethodsDescription, methodDescription);

                            businessLogic.InvokeAssertionFailed(errorText, scenarioText, bddMethodLocation, gameObject);

                            performed = true;
                        }

                        performed = false;
                    }
                }
                else
                {
                    performed = true;
                    businessLogic.StartTimoutTime = null;
                }
            }

            return performed;
        }

        public virtual object[] GetParametersValues(FullMethodDescription methodDescription)
        {
            List<object> parameters = new List<object>();
            foreach (MethodParameter parameter in methodDescription.Parameters.Parameters)
            {
                parameters.Add(parameter.Value);
            }

            return parameters.ToArray();
        }

        public void InvokeAssertionSuccess(GameObject gameObject)
        {
            AssertionComponent.Create<AssertionSuccessful>(CheckMethod.Start, gameObject, "TestComponent.enabled");
        }

        public virtual void InvokeAssertionFailed(string errorText, string scenarioText, string bddMethodLocation, GameObject gameObject)
        {
            AssertionFailed assertion = AssertionComponent.Create<AssertionFailed>(CheckMethod.Start, gameObject, "TestComponent.enabled");
            assertion.ErrorText = errorText;
            assertion.ScenarioText = scenarioText;
            assertion.BDDMethodLocation = bddMethodLocation;
        }

        public virtual string GetScenarioTextForErrorInSpecificMethod(List<FullMethodDescription> methods, FullMethodDescription methodDescription)
        {
            string result = string.Empty;
            Type previousStepType = null;
            bool nextMainMethodHasError = false;
            for (int index = 0; index < methods.Count; index++)
            {
                FullMethodDescription method = methods[index];
                if (method.MainMethod == null)
                {
                    Type currentStepType = method.StepType;
                    string label = this.GetLabel(previousStepType, currentStepType);
                    string partialString = string.Empty;
                    if (method.Equals(methodDescription) || nextMainMethodHasError)
                    {
                        partialString = "\n----------> &&&&& %%%";
                    }
                    else
                    {
                        partialString = "\n            &&&&& %%%";
                    }

                    result += partialString.Replace("&&&&&", label).Replace("%%%", method.GetDecodifiedText());
                    previousStepType = method.StepType;
                    nextMainMethodHasError = false;
                }
                else
                {
                    if (method.Equals(methodDescription))
                    {
                        nextMainMethodHasError = true;
                    }
                }
            }

            return result;
        }

        public virtual string GetbddMethodLocationForSpecificMethod(List<FullMethodDescription> methods, FullMethodDescription methodDescription)
        {
            string result = string.Empty;
            for (int index = 0; index < methods.Count; index++)
            {
                FullMethodDescription method = methods[index];
                string partialString = string.Empty;
                if (method.Equals(methodDescription))
                {
                    partialString = "\n---------->$ & %%%";
                }
                else
                {
                    partialString = "\n           $ & %%%";
                }

                string indenting = this.GetIndentingForMethod(method);
                string methodText = this.GetMethodText(method);
                string stepTypeText = this.GetStepTypeText(method);
                result += partialString.Replace("$", stepTypeText).Replace("&", indenting).Replace("%%%", methodText);
            }

            return result;
        }

        public void SetSucceedOnAssertions()
        {
            TestComponent testComponent = this.RunnerGameObject.GetComponent<TestComponent>();
            testComponent.succeedAfterAllAssertionsAreExecuted = true;
        }

        internal bool CheckForErrors(
            Component[] allComponents,
            string[] givenMethods,
            string[] givenParameters,
            string[] whenMethods,
            string[] whenParameters,
            string[] thenMethods,
            string[] thenParameters)
        {
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] bddComponents = bddComponentsFilter.Filter(allComponents);
            ComponentsChecker checkForComponentsErrors = new ComponentsChecker();
            errors.AddRange(checkForComponentsErrors.Check(bddComponents));

            if (bddComponents.Length > 0)
            {
                bool isStaticScenario = false;
                foreach (Component component in bddComponents)
                {
                    if (typeof(StaticBDDComponent).IsAssignableFrom(component.GetType()))
                    {
                        isStaticScenario = true;
                    }
                }

                if (!isStaticScenario)
                {
                    ChosenMethodsChecker checkForChosenMethodsErrors = new ChosenMethodsChecker();
                    errors.AddRange(checkForChosenMethodsErrors.Check(givenMethods, givenParameters, whenMethods, whenParameters, thenMethods, thenParameters, bddComponents));
                }
            }

            if (errors.Count > 0)
            {
                string message = string.Empty;
                foreach (UnityTestBDDError error in errors)
                {
                    message += error.Message + "\n";
                }

                this.InvokeAssertionFailed("Errors detected in configuration. Please, fix them before run the test.\n" + message, null, null, this.RunnerGameObject);
                return true;
            }

            return false;
        }

        private List<FullMethodDescription> GetAllDynamicFullMethodsDescriptions<T>(Component[] components, MethodsManagementUtilities methodsManagementUtilities, string[] methodsFullNamesList, string[] methodsParametersList) where T : IGivenWhenThenDeclaration
        {
            List<FullMethodDescription> result = null;
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByMethodsFullNameList methodsFilterByMethodsFullNameList = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByMethodsFullNameList);

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> methodsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<T>(components, bddStepMethodsLoader, methodDescriptionBuilder, methodParametersLoader, methodsFullNamesList, methodsParametersList);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            result = methodsManagementUtilities.LoadFullMethodsDescriptions<T>(methodsList, fullMethodDescriptionBuilder);

            return result;
        }

        private string GetLabel(Type previousStepType, Type currentStepType)
        {
            string result = null;
            if (previousStepType == null)
            {
                result = "Given";
            }
            else if (previousStepType.Equals(currentStepType))
            {
                result = "  and";
            }
            else if (previousStepType.Equals(typeof(GivenBaseAttribute)))
            {
                result = " when";
            }
            else
            {
                result = " then";
            }

            return result;
        }

        private string GetStepTypeText(FullMethodDescription method)
        {
            string result = null;
            if (method.StepType.Equals(typeof(GivenBaseAttribute)))
            {
                result = "[Given]";
            }
            else if (method.StepType.Equals(typeof(WhenBaseAttribute)))
            {
                result = "[ When]";
            }
            else
            {
                result = "[ Then]";
            }

            return result;
        }

        private string GetMethodText(FullMethodDescription method)
        {
            string result = method.GetFullName();
            result += " [Delay= " + method.Delay + " Timeout= " + method.TimeOut + "]";
            return result;
        }

        private string GetIndentingForMethod(FullMethodDescription method)
        {
            string result = string.Empty;
            int numberOfIndents = 0;
            FullMethodDescription mainMethod = method.MainMethod;
            while (mainMethod != null)
            {
                numberOfIndents++;
                mainMethod = mainMethod.MainMethod;
            }

            result = string.Empty.PadRight(numberOfIndents * 3, ' ');
            return result;
        }
    }
}
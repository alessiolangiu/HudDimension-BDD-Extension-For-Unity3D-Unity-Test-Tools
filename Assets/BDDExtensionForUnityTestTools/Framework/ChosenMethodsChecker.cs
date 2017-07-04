//-----------------------------------------------------------------------
// <copyright file="ChosenMethodsChecker.cs" company="Hud Dimension">
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

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class ChosenMethodsChecker
    {
        public List<UnityTestBDDError> Check(string[] givenChosenMethods, string[] givenParametersIndexes, string[] whenChosenMethods, string[] whenParametersIndexes, string[] thenChosenMethods, string[] thenParametersIndexes, Component[] components)
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();

            List<UnityTestBDDError> partialResult = this.CheckForBlankMethods<GivenBaseAttribute>(givenChosenMethods);
            result.AddRange(partialResult);

            partialResult = this.CheckForBlankMethods<WhenBaseAttribute>(whenChosenMethods);
            result.AddRange(partialResult);

            partialResult = this.CheckForBlankMethods<ThenBaseAttribute>(thenChosenMethods);
            result.AddRange(partialResult);

            partialResult = this.CheckForMethodNotFound<GivenBaseAttribute>(givenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForMethodNotFound<WhenBaseAttribute>(whenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForMethodNotFound<ThenBaseAttribute>(thenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingParametersIndex<GivenBaseAttribute>(givenChosenMethods, givenParametersIndexes, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingParametersIndex<WhenBaseAttribute>(whenChosenMethods, whenParametersIndexes, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingParametersIndex<ThenBaseAttribute>(thenChosenMethods, thenParametersIndexes, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForComponentNotFound<GivenBaseAttribute>(givenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForComponentNotFound<WhenBaseAttribute>(whenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForComponentNotFound<ThenBaseAttribute>(thenChosenMethods, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingPVS<GivenBaseAttribute>(givenChosenMethods, givenParametersIndexes, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingPVS<WhenBaseAttribute>(whenChosenMethods, whenParametersIndexes, components);
            result.AddRange(partialResult);

            partialResult = this.CheckForNotMatchingPVS<ThenBaseAttribute>(thenChosenMethods, thenParametersIndexes, components);
            result.AddRange(partialResult);

            return result;
        }

        public List<UnityTestBDDError> CheckForBlankMethods<T>(string[] chosenMethods) where T : IGivenWhenThenDeclaration
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                if (chosenMethods[index].Equals(string.Empty))
                {
                    IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                    UnityTestBDDError error = new UnityTestBDDError();
                    error.Message = "Incomplete settings detected on " + genericComponentInteface.GetStepName() + " methods at position " + (index + 1);
                    error.StepType = typeof(T);
                    error.Index = index;
                    error.LockRunnerInspectorOnErrors = false;
                    error.ShowButton = false;
                    error.LockBuildParameters = false;
                    error.LockParametersRows = false;
                    result.Add(error);
                }
            }

            return result;
        }

        public List<UnityTestBDDError> CheckForMethodNotFound<T>(string[] chosenMethods, Component[] components)
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();

            for (int index = 0; index < chosenMethods.Length; index++)
            {
                if (this.IsMethodNotFound(chosenMethods[index], components))
                {
                    IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                    UnityTestBDDError error = new UnityTestBDDError();
                    error.Message = "Method " + chosenMethods[index] + " not found on " + genericComponentInteface.GetStepName() + " methods at position " + (index + 1);
                    error.StepType = typeof(T);
                    error.Index = index;
                    error.LockRunnerInspectorOnErrors = false;
                    error.ShowButton = false;
                    error.LockBuildParameters = true;
                    error.LockParametersRows = false;

                    result.Add(error);
                }
            }

            return result;
        }

        public List<UnityTestBDDError> CheckForNotMatchingParametersIndex<T>(string[] chosenMethods, string[] parametersIndexes, Component[] components) where T : IGivenWhenThenDeclaration
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                string[] parametersIndexList = parametersIndexUtilities.GetParametersIndexList(parametersIndexes[index]);
                foreach (string parametersIndex in parametersIndexList)
                {
                    string parameterType = parametersIndexUtilities.GetParameterType(parametersIndex);
                    string parameterName = parametersIndexUtilities.GetParameterName(parametersIndex);
                    string methodFullName = parametersIndexUtilities.GetMethodFullName(parametersIndex);
                    Component component = this.GetComponent(methodFullName, components);
                    MethodInfo methodInfo = this.GetMethodInfo(methodFullName, component);
                    List<UnityTestBDDError> partialResult = this.CheckForNotMatchingParametersIndex<T>(component, methodInfo, parameterType, parameterName, index);
                    result.AddRange(partialResult);
                }
            }

            return result;
        }

        public List<UnityTestBDDError> CheckForNotMatchingParametersIndex<T>(Component component, MethodInfo methodInfo, string parameterType, string parameterName, int chosenMethodIndex) where T : IGivenWhenThenDeclaration
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();
            bool isParameterFound = false;
            bool isParameterTypeMatching = false;
            ParameterInfo[] parameters = methodInfo.GetParameters();

            Type currentParameterType = null;
            foreach (ParameterInfo parameter in parameters)
            {
                if (parameter.Name.Equals(parameterName))
                {
                    isParameterFound = true;
                    currentParameterType = parameter.ParameterType;
                    if (currentParameterType.FullName.Equals(parameterType))
                    {
                        isParameterTypeMatching = true;
                    }
                }
            }

            if (!isParameterFound)
            {
                IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                UnityTestBDDError error = new UnityTestBDDError();
                error.Message = "The parameter " + component.GetType().Name + "." + methodInfo.Name + "." + parameterName + " is not found in " + genericComponentInteface.GetStepName() + " methods at position " + (chosenMethodIndex + 1);
                error.Component = component;
                error.MethodMethodInfo = methodInfo;
                error.StepType = typeof(T);
                error.Index = chosenMethodIndex;
                error.LockRunnerInspectorOnErrors = false;
                error.ShowButton = true;
                error.LockBuildParameters = true;
                error.LockParametersRows = true;
                result.Add(error);
            }
            else if (!isParameterTypeMatching)
            {
                IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                UnityTestBDDError error = new UnityTestBDDError();
                error.Message = "The parameter " + component.GetType().Name + "." + methodInfo.Name + "." + parameterName + " has a wrong type in " + genericComponentInteface.GetStepName() + " methods at position " + (chosenMethodIndex + 1) + ".\n Previous type: " + parameterType + "\n Current type " + currentParameterType.FullName;
                error.Component = component;
                error.MethodMethodInfo = methodInfo;
                error.StepType = typeof(T);
                error.Index = chosenMethodIndex;
                error.LockRunnerInspectorOnErrors = false;
                error.ShowButton = true;
                error.LockBuildParameters = true;
                error.LockParametersRows = true;

                result.Add(error);
            }

            return result;
        }

        public List<UnityTestBDDError> CheckForComponentNotFound<T>(string[] chosenMethods, Component[] components)
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                if (this.GetComponent(chosenMethods[index], components) == null && chosenMethods[index] != null && !chosenMethods[index].Equals(string.Empty))
                {
                    IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                    UnityTestBDDError error = new UnityTestBDDError();
                    error.Message = "The component for the method " + chosenMethods[index] + " is not found  in " + genericComponentInteface.GetStepName() + " methods at position " + (index + 1);
                    error.StepType = typeof(T);
                    error.Index = index;
                    error.LockRunnerInspectorOnErrors = false;
                    error.ShowButton = false;
                    error.LockBuildParameters = true;
                    error.LockParametersRows = true;

                    result.Add(error);
                }
            }

            return result;
        }

        public List<UnityTestBDDError> CheckForNotMatchingPVS<T>(string[] chosenMethods, string[] parametersIndexes, Component[] components)
        {
            List<UnityTestBDDError> result = new List<UnityTestBDDError>();
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                Component component = this.GetComponent(chosenMethods[index], components);
                string[] parametersIndexList = parametersIndexUtilities.GetParametersIndexList(parametersIndexes[index]);
                foreach (string parameterIndex in parametersIndexList)
                {
                    string arrayPVSName = parametersIndexUtilities.GetParameterValueStorageName(parameterIndex);
                    FieldInfo arrayPVS = component.GetType().GetField(arrayPVSName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (arrayPVS == null)
                    {
                        IGivenWhenThenDeclaration genericComponentInteface = (IGivenWhenThenDeclaration)Activator.CreateInstance(typeof(T), string.Empty);
                        UnityTestBDDError error = new UnityTestBDDError();
                        error.Message = "The ParametersValuesStorage field " + arrayPVSName + " for the parameter " + parametersIndexUtilities.GetParameterFullName(parameterIndex) + " is not found in " + genericComponentInteface.GetStepName() + " methods at position " + (index + 1);
                        error.Component = component;
                        error.MethodMethodInfo = this.GetMethodInfo(chosenMethods[index], component);
                        error.StepType = typeof(T);
                        error.Index = index;
                        error.LockRunnerInspectorOnErrors = false;
                        error.ShowButton = true;
                        error.LockBuildParameters = true;
                        error.LockParametersRows = true;

                        result.Add(error);
                    }
                    else
                    {
                        Array array = arrayPVS.GetValue(component) as Array;
                        if (array == null || array.Length == 0)
                        {
                            UnityTestBDDError error = new UnityTestBDDError();
                            error.Message = "The component "+ component.GetType().Name+" seems to have been reset, so some parameter values are lost. Please, undo the reset operation or rebuild the settings to confirm the reset.";
                            error.Component = component;
                            error.MethodMethodInfo = this.GetMethodInfo(chosenMethods[index], component);
                            error.StepType = typeof(T);
                            error.Index = index;
                            error.LockRunnerInspectorOnErrors = false;
                            error.ShowButton = true;
                            error.LockBuildParameters = true;
                            error.LockParametersRows = true;

                            result.Add(error);
                        }
                    }
                }
            }

            return result;
        }

        private MethodInfo GetMethodInfo(string methodFullName, Component component)
        {
            if (!methodFullName.Equals(string.Empty))
            {
                string methodName = methodFullName.Split('.')[1];
                return component.GetType().GetMethod(methodName);
            }

            return null;
        }

        private Component GetComponent(string methodFullName, Component[] components)
        {
            if (!methodFullName.Equals(string.Empty))
            {
                string componentName = methodFullName.Split('.')[0];
                foreach (Component component in components)
                {
                    if (component.GetType().Name.Equals(componentName))
                    {
                        return component;
                    }
                }
            }

            return null;
        }

        private bool IsMethodNotFound(string methodFullName, Component[] components)
        {
            bool result = true;
            if (methodFullName.Equals(string.Empty))
            {
                result = false;
            }
            else
            {
                string componentName = methodFullName.Split('.')[0];
                string methodName = methodFullName.Split('.')[1];
                foreach (Component component in components)
                {
                    if (component.GetType().Name.Equals(componentName))
                    {
                        if (component.GetType().GetMethod(methodName) != null)
                        {
                            result = false;
                            return result;
                        }
                    }
                }
            }

            return result;
        }
    }
}
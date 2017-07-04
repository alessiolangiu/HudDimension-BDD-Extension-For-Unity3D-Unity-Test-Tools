//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicMethodsUtilities.cs" company="Hud Dimension">
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
using System.Collections.Generic;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class RunnerEditorBusinessLogicMethodsUtilities
    {
        public string[] CheckMissedMethod(ChosenMethods chosenMethods, string[] methodsNames, int index, MethodDescription methodDescription)
        {
            if (methodDescription == null)
            {
                methodsNames = this.AddMissedMethodNameToMethodsNames(chosenMethods.ChosenMethodsNames[index], methodsNames);
            }

            return methodsNames;
        }

        public MethodDescription GetMethodDescription(MethodDescriptionBuilder methodDescriptionBuilder, MethodParametersLoader parametersLoader, ChosenMethods chosenMethods, List<BaseMethodDescription> methodsList, int index)
        {
            MethodDescription methodDescription = null;
            if (!chosenMethods.ChosenMethodsNames[index].Equals(string.Empty))
            {
                methodDescription = this.GetMethodDescriptionForTheChosenMethod(methodDescriptionBuilder, parametersLoader, chosenMethods.ChosenMethodsNames[index], chosenMethods.ChosenMethodsParametersIndex[index], methodsList);
            }

            return methodDescription;
        }

        public bool UpdateDataIfNewMethodIsChosen(string newChosenMethod, ChosenMethods chosenMethods, bool[] foldouts, int index, bool rebuild, out string newUndoText)
        {
            newUndoText = string.Empty;
            if (!newChosenMethod.Equals(chosenMethods.ChosenMethodsNames[index]))
            {
                chosenMethods.ChosenMethodsNames[index] = newChosenMethod;
                newUndoText = "Change Step Method";
                foldouts[index] = false;
                rebuild = true;
            }

            return rebuild;
        }

        public MethodDescription GetMethodDescriptionForTheChosenMethod(MethodDescriptionBuilder methodDescriptionBuilder, MethodParametersLoader parametersLoader, string chosenMethodName, string chosenMethodParametersIndex, List<BaseMethodDescription> methodsList)
        {
            MethodDescription methodDescription = null;
            foreach (BaseMethodDescription baseMethodDescription in methodsList)
            {
                if (baseMethodDescription.GetFullName().Equals(chosenMethodName))
                {
                    methodDescription = methodDescriptionBuilder.Build(parametersLoader, baseMethodDescription, chosenMethodParametersIndex);
                }
            }

            return methodDescription;
        }

        public string[] GetMethodsNames(List<BaseMethodDescription> methodsList)
        {
            string[] methodsNames = new string[methodsList.Count];
            int methodsArrayindex = -1;
            foreach (BaseMethodDescription baseMethodDescription in methodsList)
            {
                methodsArrayindex++;
                methodsNames[methodsArrayindex] = baseMethodDescription.GetFullName();
            }

            return methodsNames;
        }

        internal string[] AddMissedMethodNameToMethodsNames(string methodName, string[] methodsNames)
        {
            string[] newMethodsArray = new string[methodsNames.Length + 1];
            for (int temporaryIndex = 0; temporaryIndex < methodsNames.Length; temporaryIndex++)
            {
                newMethodsArray[temporaryIndex] = methodsNames[temporaryIndex];
            }

            newMethodsArray[newMethodsArray.Length - 1] = methodName;
            return newMethodsArray;
        }
    }
}
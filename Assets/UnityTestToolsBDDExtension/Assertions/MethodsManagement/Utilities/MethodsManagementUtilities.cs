//-----------------------------------------------------------------------
// <copyright file="MethodsManagementUtilities.cs" company="Hud Dimesion">
//     Copyright (c) Hud Dimension. All rights reserved.
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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class MethodsManagementUtilities
    {
        public List<FullMethodDescription> LoadFullMethodsDescriptions<T>(List<BaseMethodDescription> methodsDescriptionsList, FullMethodDescriptionBuilder fullMethodDescriptionBuilder) where T : IGivenWhenThenDeclaration
        {
            List<FullMethodDescription> fullMethodsDescriptions = new List<FullMethodDescription>();

            for (int index = 0; index < methodsDescriptionsList.Count; index++)
            {
                BaseMethodDescription baseMethodDescription = methodsDescriptionsList[index];
                List<FullMethodDescription> fullmethodDescriptionsList = fullMethodDescriptionBuilder.BuildFromBaseMethodDescription(baseMethodDescription, (uint)index + 1);
                fullMethodsDescriptions.AddRange(fullmethodDescriptionsList);
            }

            return fullMethodsDescriptions;
        }

        public List<FullMethodDescription> LoadFullMethodsDescriptions<T>(List<MethodDescription> methodsDescriptionsList, FullMethodDescriptionBuilder fullMethodDescriptionBuilder) where T : IGivenWhenThenDeclaration
        {
            List<FullMethodDescription> fullMethodsDescriptions = new List<FullMethodDescription>();

            for (int index = 0; index < methodsDescriptionsList.Count; index++)
            {
                MethodDescription methodDescription = methodsDescriptionsList[index];
                List<FullMethodDescription> fullmethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, (uint)index + 1);
                fullMethodsDescriptions.AddRange(fullmethodDescriptionsList);
            }

            return fullMethodsDescriptions;
        }

        public List<MethodDescription> LoadMethodsDescriptionsFromChosenMethods<T>(Component[] dynamicBDDComponents, MethodsLoader methodsLoader, MethodDescriptionBuilder methodDescriptionBuilder, MethodParametersLoader methodParametersLoader, string[] chosenMethods, string[] chosenMethodsParametersIndexes) where T : IGivenWhenThenDeclaration
        {
            List<MethodDescription> methodsDescriptions = new List<MethodDescription>();
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadOrderedStepMethods<T>(dynamicBDDComponents, chosenMethods);
            for (int index = 0; index < baseMethodsDescriptions.Count; index++)
            {
                BaseMethodDescription baseMethodDescription = baseMethodsDescriptions[index];
                string parametersIndex = chosenMethodsParametersIndexes[index];
                MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
                methodsDescriptions.Add(methodDescription);
            }

            return methodsDescriptions;
        }

        public string GetParametersIndexForMethod(string methodFullName, string[] chosenMethods, string[] chosenMethodsParametersIndexes)
        {
            string result = null;
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                if (methodFullName.Equals(chosenMethods[index]))
                {
                    result = chosenMethodsParametersIndexes[index];
                }
            }

            return result;
        }

        public bool IsStaticBDDScenario(Component[] components)
        {
            bool result = false;
            foreach (Component component in components)
            {
                if (typeof(StaticBDDComponent).IsAssignableFrom(component.GetType()))
                {
                    result = true;
                }
            }

            return result;
        }

        public string GetFullId(FullMethodDescription method)
        {
            if (method == null)
            {
                return string.Empty;
            }

            string mainFullId = this.GetMainFullId(method.MainMethod);
            return mainFullId + method.Id;
        }

        public string GetMainFullId(FullMethodDescription method)
        {
            if (method == null || method.MainMethod == null)
            {
                return string.Empty;
            }

            return this.GetMainFullId(method.MainMethod) + method.Id + "_";
        }

        private List<BaseMethodDescription> GetOrderedListByMethodsNames(List<BaseMethodDescription> baseMethodsDescriptions, string[] chosenMethods)
        {
            List<BaseMethodDescription> result = new List<BaseMethodDescription>();
            for (int index = 0; index < chosenMethods.Length; index++)
            {
                foreach (BaseMethodDescription method in baseMethodsDescriptions)
                {
                    if (chosenMethods[index].Equals(method.GetFullName()))
                    {
                        result.Add(method);
                    }
                }
            }

            return result;
        }
    }
}

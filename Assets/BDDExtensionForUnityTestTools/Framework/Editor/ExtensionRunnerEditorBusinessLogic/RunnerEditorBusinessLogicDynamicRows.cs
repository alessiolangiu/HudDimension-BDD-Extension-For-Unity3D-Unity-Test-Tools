//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicDynamicRows.cs" company="Hud Dimension">
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
using UnityEditor;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class RunnerEditorBusinessLogicDynamicRows
    {
        public bool DrawDynamicRows<T>(
            IUnityInterfaceWrapper unityInterface,
            MethodsLoader methodsLoader,
            MethodDescriptionBuilder methodDescriptionBuilder,
            MethodParametersLoader parametersLoader,
            Component[] bddComponents,
            ChosenMethods chosenMethods,
            bool[] foldouts,
            Dictionary<Type, ISerializedObjectWrapper> serializedObjects,
            UnityEngine.Object target,
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities,
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements,
            bool lockParametersRows,
            bool rebuild,
            out ChosenMethods updatedChosenMethodsList,
            out bool[] updatedFoldouts,
            out bool dirtyStatus,
            out string undoText) where T : IGivenWhenThenDeclaration
        {
            updatedChosenMethodsList = (ChosenMethods)chosenMethods.Clone();
            updatedFoldouts = new bool[foldouts.Length];
            Array.Copy(foldouts, updatedFoldouts, foldouts.Length);
            undoText = string.Empty;
            dirtyStatus = false;

            List<BaseMethodDescription> methodsList = methodsLoader.LoadStepMethods<T>(bddComponents);
            string[] methodsNames = methodsUtilities.GetMethodsNames(methodsList);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                MethodDescription methodDescription = methodsUtilities.GetMethodDescription(methodDescriptionBuilder, parametersLoader, chosenMethods, methodsList, index);

                methodsNames = methodsUtilities.CheckMissedMethod(chosenMethods, methodsNames, index, methodDescription);

                List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, (uint)index + 1);

                unityInterface.EditorGUILayoutBeginHorizontal();
                dynamicRowsElements.DrawFoldoutSymbol(unityInterface, updatedFoldouts, index, fullMethodDescriptionsList);

                dynamicRowsElements.DrawLabel<T>(unityInterface, index);
                float textSize = (unityInterface.EditorGUIUtilityCurrentViewWidth() - RunnerEditorBusinessLogicData.LabelWidthAbsolute - RunnerEditorBusinessLogicData.ButtonsWidthAbsolute) * RunnerEditorBusinessLogicData.TextWidthPercent;
                dynamicRowsElements.DrawDescription(unityInterface, chosenMethods.ChosenMethodsNames[index], methodDescription, textSize);

                
                string newChosenMethod = dynamicRowsElements.DrawComboBox(unityInterface, chosenMethods.ChosenMethodsNames[index], methodsNames);
                rebuild = methodsUtilities.UpdateDataIfNewMethodIsChosen(newChosenMethod, updatedChosenMethodsList, updatedFoldouts, index, rebuild, out undoText);
                dirtyStatus = dirtyStatus || dynamicRowsElements.DrawAddRowButton(unityInterface, index, updatedChosenMethodsList, target, undoText, out updatedChosenMethodsList, out undoText);
                dirtyStatus = dirtyStatus || dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, updatedChosenMethodsList, target, undoText, out updatedChosenMethodsList, out undoText);
                if (dirtyStatus)
                {
                    break;
                }

                dynamicRowsElements.DrawCogButton(unityInterface, methodDescription);
                unityInterface.EditorGUILayoutEndHorizontal();

                dynamicRowsElements.DrawParametersRows(unityInterface, foldouts[index], fullMethodDescriptionsList, serializedObjects, lockParametersRows);
            }

            return rebuild;
        }


    }
}
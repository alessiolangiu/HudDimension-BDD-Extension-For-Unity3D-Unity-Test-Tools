//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicDynamicRowsElements.cs" company="Hud Dimension">
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
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class RunnerEditorBusinessLogicDynamicRowsElements
    {
        public const string ChoseMethodFromComboBox = "### Choose a method from the combo box ###";

        public void DrawFoldoutSymbol(IUnityInterfaceWrapper unityInterface, bool[] updatedFoldouts, int index, List<FullMethodDescription> fullMethodDescriptionList)
        {
            bool thereAreParameters = false;
            foreach (FullMethodDescription fullMethodDescription in fullMethodDescriptionList)
            {
                if (fullMethodDescription.Parameters.Parameters.Length > 0)
                {
                    thereAreParameters = true;
                }
            }

            if (thereAreParameters)
            {
                Rect rect = unityInterface.EditorGUILayoutGetControlRect();
                updatedFoldouts[index] = unityInterface.EditorGUIFoldout(rect, updatedFoldouts[index], string.Empty);
            }
            else
            {
                Rect rect = unityInterface.EditorGUILayoutGetControlRect();
                unityInterface.EditorGUIFoldout(rect, false, string.Empty, EditorStyles.label);
            }
        }

        public void DrawLabel<T>(IUnityInterfaceWrapper unityInterface, int index) where T : IGivenWhenThenDeclaration
        {
            string label = StepMethodUtilities.GetStepMethodName<T>();
            if (index > 0)
            {
                label = "and";
            }

            unityInterface.EditorGUILayoutLabelField(label, RunnerEditorBusinessLogicData.LabelWidthAbsolute);
        }

        public void DrawDescription(IUnityInterfaceWrapper unityInterface, string chosenMethod, MethodDescription methodDescription, float textSize)
        {
            string description = string.Empty;
            if (methodDescription != null)
            {
                description = methodDescription.GetDecodifiedText();
            }
            else if (chosenMethod.Equals(string.Empty))
            {
                description = ChoseMethodFromComboBox;
            }
            else
            {
                description = "### The method " + chosenMethod + " is missing ###";
            }

            unityInterface.EditorGUILayoutLabelField(description, textSize);
        }

        public string DrawComboBox(IUnityInterfaceWrapper unityInterface, string selectedMethod, string[] methodsArray)
        {
            string[] methods = null;
            if (methodsArray.Length == 0)
            {
                methods = new string[1] { string.Empty };
            }
            else if (!methodsArray[0].Equals(string.Empty))
            {
                methods = new string[methodsArray.Length + 1];
                methods[0] = string.Empty;
                Array.Copy(methodsArray, 0, methods, 1, methodsArray.Length);
            }
            else
            {
                methods = new string[methodsArray.Length];
                Array.Copy(methodsArray, methods, methodsArray.Length);
            }

            string result = string.Empty;

            int index = this.GetIndexByValue(selectedMethod, methods);
            index = unityInterface.EditorGUILayoutPopup(index, methods);
            result = methods[index];
            return result;
        }

        public int GetIndexByValue(string selectedMethod, string[] methodsArray)
        {
            int result = 0;
            for (int index = 0; index < methodsArray.Length; index++)
            {
                if (methodsArray[index].Equals(selectedMethod))
                {
                    result = index;
                    break;
                }
            }

            return result;
        }

        public void DrawParametersRows(IUnityInterfaceWrapper unityInterface, bool foldout, List<FullMethodDescription> fullMethodDescriptionsList, Dictionary<Type, ISerializedObjectWrapper> serializedObjects, bool lockParametersRows)
        {
            if (fullMethodDescriptionsList != null && fullMethodDescriptionsList.Count > 0 && foldout && !lockParametersRows)
            {
                bool theCallBeforeMethodsHaveParameters = false;
                foreach (FullMethodDescription fullMethodDescription in fullMethodDescriptionsList)
                {
                    if (fullMethodDescription.Parameters.Parameters.Length > 0)
                    {
                        if (fullMethodDescription.MainMethod != null)
                        {
                            theCallBeforeMethodsHaveParameters = true;
                        }

                        if (theCallBeforeMethodsHaveParameters)
                        {
                            unityInterface.EditorGUILayoutSeparator();
                            unityInterface.EditorGUILayoutBeginHorizontal();
                            float currentViewWidth = unityInterface.EditorGUIUtilityCurrentViewWidth();
                            string text = this.GetHeaderTextForFullMethodDescription(fullMethodDescription);
                            unityInterface.EditorGUILayoutLabelFieldTruncate(text, currentViewWidth);
                            unityInterface.EditorGUILayoutEndHorizontal();
                        }

                        this.DrawParametersRows(unityInterface, foldout, fullMethodDescription, serializedObjects, lockParametersRows);
                    }
                }

                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
            }
        }

        public void DrawParametersRows(IUnityInterfaceWrapper unityInterface, bool foldout, FullMethodDescription fullMethodDescription, Dictionary<Type, ISerializedObjectWrapper> serializedObjects, bool lockParametersRows)
        {
            if (fullMethodDescription != null && foldout && !lockParametersRows)
            {
                ISerializedObjectWrapper serializedObject = null;
                serializedObjects.TryGetValue(fullMethodDescription.ComponentObject.GetType(), out serializedObject);

                foreach (MethodParameter parameter in fullMethodDescription.Parameters.Parameters)
                {
                    string parameterName = parameter.ParameterInfoObject.Name;
                    ParameterLocation parameterLocation = parameter.ParameterLocation;

                    // "given.Array.data[0]"
                    string parameterLocationString = parameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + parameterLocation.ParameterArrayLocation.ArrayIndex + "]";
                    GUIContent label = unityInterface.GUIContent(parameterName);
                    ISerializedPropertyWrapper property = serializedObject.FindProperty(parameterLocationString);
                    unityInterface.EditorGUILayoutPropertyField(property, label);
                }
            }

            if (fullMethodDescription != null && foldout && lockParametersRows)
            {
                float labelWidth = unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.EditorGUILayoutLabelField("When there are some errors the parameters are protected to avoid data lost.", labelWidth);
            }
        }

        public bool DrawAddRowButton(IUnityInterfaceWrapper unityInterface, int currentIndex, ChosenMethods chosenMethods, UnityEngine.Object target, out ChosenMethods newChosenMethods)
        {
            bool dirty = false;
            newChosenMethods = new ChosenMethods();
            newChosenMethods.ChosenMethodsNames = chosenMethods.ChosenMethodsNames;
            newChosenMethods.ChosenMethodsParametersIndex = chosenMethods.ChosenMethodsParametersIndex;

            if (unityInterface.GUILayoutButton("+", EditorStyles.miniButton, unityInterface.GUILayoutWidth(20)))
            {
                string[] newArrayMethodsNames = new string[newChosenMethods.ChosenMethodsNames.Length + 1];
                string[] newArrayMethodsParametersIndex = new string[newChosenMethods.ChosenMethodsParametersIndex.Length + 1];
                int newIndex = 0;
                for (int tempIndex = 0; tempIndex < chosenMethods.ChosenMethodsNames.Length; tempIndex++)
                {
                    if (tempIndex == currentIndex + 1)
                    {
                        newArrayMethodsNames[newIndex] = string.Empty;
                        newArrayMethodsParametersIndex[newIndex] = string.Empty;
                        newIndex++;
                    }

                    newArrayMethodsNames[newIndex] = newChosenMethods.ChosenMethodsNames[tempIndex];
                    newArrayMethodsParametersIndex[newIndex] = newChosenMethods.ChosenMethodsParametersIndex[tempIndex];
                    newIndex++;
                }

                if (newArrayMethodsNames[newArrayMethodsNames.Length - 1] == null)
                {
                    newArrayMethodsNames[newArrayMethodsNames.Length - 1] = string.Empty;
                    newArrayMethodsParametersIndex[newArrayMethodsNames.Length - 1] = string.Empty;
                }

                newChosenMethods.ChosenMethodsNames = newArrayMethodsNames;
                newChosenMethods.ChosenMethodsParametersIndex = newArrayMethodsParametersIndex;
                unityInterface.EditorUtilitySetDirty(target);
                dirty = true;
            }

            return dirty;
        }

        public bool DrawRemoveRowButton(IUnityInterfaceWrapper unityInterface, int currentIndex, ChosenMethods chosenMethods, UnityEngine.Object target, out ChosenMethods newChosenMethods)
        {
            bool dirty = false;
            newChosenMethods = new ChosenMethods();
            newChosenMethods.ChosenMethodsNames = chosenMethods.ChosenMethodsNames;
            newChosenMethods.ChosenMethodsParametersIndex = chosenMethods.ChosenMethodsParametersIndex;
            if (unityInterface.GUILayoutButton("-", EditorStyles.miniButton, unityInterface.GUILayoutWidth(20)))
            {
                if (chosenMethods.ChosenMethodsNames.Length > 1)
                {
                    string[] newArrayMethodsNames = new string[newChosenMethods.ChosenMethodsNames.Length - 1];
                    string[] newArrayMethodsParametersIndex = new string[newChosenMethods.ChosenMethodsParametersIndex.Length - 1];
                    int newIndex = 0;
                    for (int tempIndex = 0; tempIndex < chosenMethods.ChosenMethodsNames.Length; tempIndex++)
                    {
                        if (tempIndex == currentIndex)
                        {
                            tempIndex++;
                        }

                        if (tempIndex < chosenMethods.ChosenMethodsNames.Length)
                        {
                            newArrayMethodsNames[newIndex] = chosenMethods.ChosenMethodsNames[tempIndex];
                            newArrayMethodsParametersIndex[newIndex] = chosenMethods.ChosenMethodsParametersIndex[tempIndex];
                            newIndex++;
                        }
                    }

                    newChosenMethods.ChosenMethodsNames = newArrayMethodsNames;
                    newChosenMethods.ChosenMethodsParametersIndex = newArrayMethodsParametersIndex;
                    unityInterface.EditorUtilitySetDirty(target);
                    dirty = true;
                }
            }

            return dirty;
        }

        internal void DrawCogButton(IUnityInterfaceWrapper unityInterface, MethodDescription methodDescription)
        {
            string texture = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\cog.png";
            Texture2D inputTexture = unityInterface.AssetDatabaseLoadAssetAtPath(texture, typeof(Texture2D));
            GUILayoutOption[] options = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(16), unityInterface.GUILayoutHeight(16) };

            if (unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, options))
            {
                GenericMenu menu = new GenericMenu();
                GUIContent content = new GUIContent("Open method source");
                bool on = false;
                MethodInfo method = null;
                if (methodDescription != null)
                {
                    on = true;
                    method = methodDescription.Method;
                    menu.AddItem(content, on, () => { SourcesManagement.OpenMethodSourceCode(method, unityInterface); });
                }
                else
                {
                    menu.AddDisabledItem(content);
                }

                menu.ShowAsContext();
            }
        }

        private string GetHeaderTextForFullMethodDescription(FullMethodDescription fullMethodDescription)
        {
            string result = "Method ";

            string methodName = fullMethodDescription.Method.Name;
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            string fullId = methodsManagementUtilities.GetMainFullId(fullMethodDescription.MainMethod) + fullMethodDescription.Id;
            result += methodName;
            if (!fullId.Equals(string.Empty))
            {
                result += " Id=" + fullId;
            }

            return result;
        }
    }
}

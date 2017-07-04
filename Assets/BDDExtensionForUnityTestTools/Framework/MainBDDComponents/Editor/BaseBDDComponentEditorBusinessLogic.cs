﻿//-----------------------------------------------------------------------
// <copyright file="BaseBDDComponentEditorBusinessLogic.cs" company="Hud Dimension">
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
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class BaseBDDComponentEditorBusinessLogic
    {
        private Component component;

        private string openComponentButtonTextureFileName = @"openComponentButton.png";

        private string errorTextureFileName = @"exclamation_red.png";

        public BaseBDDComponentEditorBusinessLogic(Component component)
        {
            this.component = component;
        }

        public string ErrorTextureFileName
        {
            get
            {
                return this.errorTextureFileName;
            }

            set
            {
                this.errorTextureFileName = value;
            }
        }

        public string OpenComponentButtonTextureFileName
        {
            get
            {
                return this.openComponentButtonTextureFileName;
            }

            set
            {
                this.openComponentButtonTextureFileName = value;
            }
        }

        public void Errors(List<UnityTestBDDError> errors, IUnityInterfaceWrapper unityInterface)
        {

            BDDExtensionRunner bddExtensionRunner = this.component.gameObject.GetComponent<BDDExtensionRunner>();
            string openComponentButtonTextureFullPath = Utilities.GetAssetFullPath(bddExtensionRunner, this.OpenComponentButtonTextureFileName);
            string errorTextureFullPath= Utilities.GetAssetFullPath(bddExtensionRunner, this.ErrorTextureFileName);
            foreach (UnityTestBDDError error in errors)
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                float currentViewWidth = unityInterface.EditorGUIUtilityCurrentViewWidth();
                Texture2D errorTexture = unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D));
                GUILayoutOption[] errorTextureOptions = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                unityInterface.EditorGUILayoutLabelField(errorTexture, errorTextureOptions);
                float labelWidth = currentViewWidth - 100;
                unityInterface.EditorGUILayoutLabelField(error.Message, labelWidth);

                Texture2D openComponentButtonTexture = unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D));
                GUILayoutOption[] options = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                if (unityInterface.GUILayoutButton(openComponentButtonTexture, EditorStyles.label, options))
                {
                    if (error.MethodMethodInfo != null)
                    {
                        SourcesManagement.OpenMethodSourceCode(error.MethodMethodInfo, unityInterface);
                    }
                    else if (error.Component != null)
                    {
                        SourcesManagement.OpenSourceCode(error.Component, unityInterface);
                    }
                    else{
                        MethodInfo[] methods = this.component.GetType().GetMethods();
                        foreach (MethodInfo method in methods)
                        {
                            if (method.DeclaringType.Name.Equals(this.component.GetType().Name))
                            {
                                SourcesManagement.OpenSourceCode(method, unityInterface);
                            }
                        }
                    }
                }

                unityInterface.EditorGUILayoutEndHorizontal();
            }
        }
    }
}

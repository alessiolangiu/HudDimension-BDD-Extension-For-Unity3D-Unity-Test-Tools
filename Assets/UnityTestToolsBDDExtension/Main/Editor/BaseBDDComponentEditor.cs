//-----------------------------------------------------------------------
// <copyright file="BaseBDDComponentEditor.cs" company="Hud Dimesion">
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
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [CustomEditor(typeof(BaseBDDComponent), true)]
    public class BaseBDDComponentEditor : Editor
    {
        private string texturePath = null;

        private IUnityInterfaceWrapper unityInterface = new UnityInterfaceWrapper();

        internal string TexturePath
        {
            get
            {
                return this.texturePath;
            }

            set
            {
                this.texturePath = value;
            }
        }

        public void Awake()
        {
            BaseBDDComponent script = (BaseBDDComponent)target;
            script.Checking = true;
        }

        public override void OnInspectorGUI()
        {
            BaseBDDComponent script = (BaseBDDComponent)target;
            if (EditorApplication.isCompiling)
            {
                script.Checking = true;
            }

            BDDExtensionRunner runner = script.gameObject.GetComponent<BDDExtensionRunner>();
            if (runner != null)
            {
                this.unityInterface.EditorGUILayoutBeginHorizontal();
                Texture2D texture = this.unityInterface.AssetDatabaseLoadAssetAtPath(this.TexturePath, typeof(Texture2D));
                GUILayoutOption[] options = new GUILayoutOption[1] { this.unityInterface.GUILayoutHeight(70) };
                GUIContent label = new GUIContent(texture);
                EditorGUILayout.LabelField(label, options);
                this.unityInterface.EditorGUILayoutEndHorizontal();
                if (script.Checking == true)
                {
                    ComponentsChecker checkForErrors = new ComponentsChecker();
                    script.Errors = checkForErrors.Check(script);
                }

                if (script.Errors.Count > 0)
                {
                    BaseBDDComponentEditorBusinessLogic businessLogic = new BaseBDDComponentEditorBusinessLogic(script);
                    businessLogic.Errors(script.Errors, this.unityInterface);
                }
                else
                {
                    this.DrawDefaultInspector();
                }

                script.Checking = false;
            }
            else
            {
                this.DrawDefaultInspector();
            }
        }
    }
}

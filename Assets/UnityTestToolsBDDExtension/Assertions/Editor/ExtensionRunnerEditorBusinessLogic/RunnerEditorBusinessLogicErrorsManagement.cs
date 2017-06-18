using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class RunnerEditorBusinessLogicErrorsManagement
    {
        private string texture = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\openComponentButton.png";
        private string errorTextureName = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\exclamation_red.png";

        public string ErrorTextureName
        {
            get
            {
                return this.errorTextureName;
            }

            set
            {
                this.errorTextureName = value;
            }
        }

        public string Texture
        {
            get
            {
                return this.texture;
            }

            set
            {
                this.texture = value;
            }
        }

        public void Errors(List<UnityTestBDDError> errors, IUnityInterfaceWrapper unityInterface)
        {
            foreach (UnityTestBDDError error in errors)
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                float currentViewWidth = unityInterface.EditorGUIUtilityCurrentViewWidth();
                if (error.ShowRedEsclamationMark)
                {
                    Texture2D errorTexture = unityInterface.AssetDatabaseLoadAssetAtPath(this.ErrorTextureName, typeof(Texture2D));
                    GUILayoutOption[] errorTextureOptions = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                    unityInterface.EditorGUILayoutLabelField(errorTexture, errorTextureOptions);
                }

                float labelWidth = currentViewWidth - 100;
                unityInterface.EditorGUILayoutLabelField(error.Message, labelWidth);

                Texture2D openComponentButtonTexture = unityInterface.AssetDatabaseLoadAssetAtPath(this.Texture, typeof(Texture2D));
                GUILayoutOption[] options = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                if (error.ShowButton)
                {
                    if (unityInterface.GUILayoutButton(openComponentButtonTexture, EditorStyles.label, options))
                    {
                        if (error.MethodMethodInfo != null)
                        {
                            SourcesManagement.OpenMethodSourceCode(error.MethodMethodInfo, unityInterface);
                        }
                        else if (error.Component != null)
                        {
                            MethodInfo[] methods = error.Component.GetType().GetMethods();
                            foreach (MethodInfo method in methods)
                            {
                                if (method.DeclaringType.Name.Equals(error.Component.GetType().Name))
                                {
                                    SourcesManagement.OpenSourceCode(method, unityInterface);
                                }
                            }
                        }
                    }
                }

                unityInterface.EditorGUILayoutEndHorizontal();
            }
        }
    }
}

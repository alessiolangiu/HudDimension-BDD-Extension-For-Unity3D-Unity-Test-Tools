using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class BaseBDDComponentEditorBusinessLogic
    {
        private Component component;

        private string texture = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\openComponentButton.png";

        private string errorTextureName = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\exclamation_red.png";

        public BaseBDDComponentEditorBusinessLogic(Component component)
        {
            this.component = component;
        }

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
                Texture2D errorTexture = unityInterface.AssetDatabaseLoadAssetAtPath(this.ErrorTextureName, typeof(Texture2D));
                GUILayoutOption[] errorTextureOptions = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                unityInterface.EditorGUILayoutLabelField(errorTexture, errorTextureOptions);
                float labelWidth = currentViewWidth - 100;
                unityInterface.EditorGUILayoutLabelField(error.Message, labelWidth);

                Texture2D openComponentButtonTexture = unityInterface.AssetDatabaseLoadAssetAtPath(this.Texture, typeof(Texture2D));
                GUILayoutOption[] options = new GUILayoutOption[2] { unityInterface.GUILayoutWidth(24), unityInterface.GUILayoutHeight(24) };
                if (unityInterface.GUILayoutButton(openComponentButtonTexture, EditorStyles.label, options))
                {
                    if (error.MethodMethodInfo != null)
                    {
                        SourcesManagement.OpenMethodSourceCode(error.MethodMethodInfo, unityInterface);
                    }
                    else
                    {
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

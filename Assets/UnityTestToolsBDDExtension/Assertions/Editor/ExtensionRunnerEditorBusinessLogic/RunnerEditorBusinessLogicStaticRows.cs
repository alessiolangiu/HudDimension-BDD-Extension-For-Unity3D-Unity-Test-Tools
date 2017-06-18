using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class RunnerEditorBusinessLogicStaticRows
    {
        public void DrawStaticRows<T>(IUnityInterfaceWrapper unityInterface, MethodsLoader stepMethodsLoader, Component[] bddComponents, float labelWidthAbsolute, float buttonsWidthAbsolute) where T : IGivenWhenThenDeclaration
        {
            List<BaseMethodDescription> methodsList = stepMethodsLoader.LoadStepMethods<T>(bddComponents);
            for (int index = 0; index < methodsList.Count; index++)
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                float rowWidth = unityInterface.EditorGUIUtilityCurrentViewWidth() - labelWidthAbsolute - buttonsWidthAbsolute;
                float textSize = rowWidth - 20;
                string label = StepMethodUtilities.GetStepMethodName<T>();
                if (index > 0)
                {
                    label = "and";
                }

                unityInterface.EditorGUILayoutLabelField(label, labelWidthAbsolute);
                string description = string.Empty;

                description = methodsList[index].Text;
                unityInterface.EditorGUILayoutLabelField(description, textSize);
                this.DrawCogButton(unityInterface, methodsList[index]);
                unityInterface.EditorGUILayoutEndHorizontal();
            }
        }

        internal void DrawCogButton(IUnityInterfaceWrapper unityInterface, BaseMethodDescription methodDescription)
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
    }
}

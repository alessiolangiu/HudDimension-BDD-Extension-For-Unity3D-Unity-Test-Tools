//-----------------------------------------------------------------------
// <copyright file="UnityInterfaceWrapper.cs" company="Hud Dimension">
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
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class UnityInterfaceWrapper : IUnityInterfaceWrapper
    {
        public Texture2D AssetDatabaseLoadAssetAtPath(string texture, Type type)
        {
            return AssetDatabase.LoadAssetAtPath(texture, type) as Texture2D;
        }

        public bool EditorApplicationIsCompiling()
        {
            return EditorApplication.isCompiling;
        }

        public bool EditorGUIFoldout(Rect rect, bool foldout, string content)
        {
            return EditorGUI.Foldout(rect, foldout, content);
        }

        public bool EditorGUIFoldout(Rect rect, bool foldout, string content, GUIStyle style)
        {
            return EditorGUI.Foldout(rect, foldout, content, style);
        }

        public void EditorGUILayoutBeginHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
        }

        public void EditorGUILayoutEndHorizontal()
        {
            EditorGUILayout.EndHorizontal();
        }

        public Rect EditorGUILayoutGetControlRect()
        {
            return EditorGUILayout.GetControlRect(false, GUILayout.Width(20));
        }

        public void EditorGUILayoutLabelField(Texture2D texture, GUILayoutOption[] options)
        {
            GUIContent label = new GUIContent(texture);
            EditorGUILayout.LabelField(label, options);
        }

        public void EditorGUILayoutLabelField(string text, float labelWidth)
        {
            EditorGUILayout.LabelField(text, EditorStyles.wordWrappedLabel, GUILayout.Width(labelWidth));
        }

        public void EditorGUILayoutLabelFieldTruncate(string text, float labelWidth)
        {
            EditorGUILayout.LabelField(text, EditorStyles.boldLabel, GUILayout.Width(labelWidth));
        }

        public int EditorGUILayoutPopup(int index, string[] itemsList)
        {
            return EditorGUILayout.Popup(index, itemsList);
        }

        public bool EditorGUILayoutPropertyField(ISerializedPropertyWrapper property, GUIContent label)
        {
            return EditorGUILayout.PropertyField(property.GetProperty(), label, GUILayout.ExpandWidth(true));
        }

        public bool EditorGUILayoutPropertyFieldCustomizable(ISerializedPropertyWrapper property, GUIContent label, GUILayoutOption[] options)
        {
            return EditorGUILayout.PropertyField(property.GetProperty(), label, options);
        }

        public void EditorGUILayoutSeparator()
        {
            EditorGUILayout.Separator();
        }

        public float EditorGUIUtilityCurrentViewWidth()
        {
            return EditorGUIUtility.currentViewWidth;
        }

        public void EditorUtilitySetDirty(UnityEngine.Object target)
        {
            EditorUtility.SetDirty(target);
        }

        public GUIContent GUIContent(string text)
        {
            return new GUIContent(text);
        }

        public bool GUILayoutButton(Texture2D inputTexture, GUIStyle style, GUILayoutOption[] options)
        {
            return GUILayout.Button(inputTexture, style, options);
        }

        public bool GUILayoutButton(string text, GUIStyle style, GUILayoutOption guiLayoutOption)
        {
            return GUILayout.Button(text, style, guiLayoutOption);
        }

        public GUILayoutOption GUILayoutHeight(int value)
        {
            return GUILayout.Height(value);
        }

        public GUILayoutOption GUILayoutWidth(int value)
        {
            return GUILayout.Width(value);
        }

        public void UnityEditorInternalInternalEditorUtilityOpenFileAtLineExternal(string documentUrl, int startLine)
        {
            UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(documentUrl, startLine);
        }
    }
}

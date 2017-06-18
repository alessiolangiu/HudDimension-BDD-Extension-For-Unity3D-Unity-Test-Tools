//-----------------------------------------------------------------------
// <copyright file="IUnityInterfaceWrapper.cs" company="Hud Dimesion">
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
using System;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public interface IUnityInterfaceWrapper
    {
        bool EditorApplicationIsCompiling();

        void EditorGUILayoutBeginHorizontal();

        void EditorGUILayoutEndHorizontal();

        bool EditorGUILayoutPropertyField(ISerializedPropertyWrapper property, GUIContent label);

        bool EditorGUILayoutPropertyFieldCustomizable(ISerializedPropertyWrapper property, GUIContent label, GUILayoutOption[] options);

        void EditorGUILayoutLabelField(string text, float labelWidth);

        void EditorGUILayoutLabelFieldTruncate(string text, float labelWidth);

        int EditorGUILayoutPopup(int index, string[] itemsList);

        bool EditorGUIFoldout(Rect rect, bool foldout, string content);

        bool EditorGUIFoldout(Rect rect, bool foldout, string content, GUIStyle style);

        float EditorGUIUtilityCurrentViewWidth();

        void EditorUtilitySetDirty(UnityEngine.Object target);

        bool GUILayoutButton(string v, GUIStyle style, GUILayoutOption guiLayoutOption);

        void EditorGUILayoutSeparator();

        Rect EditorGUILayoutGetControlRect();

        GUIContent GUIContent(string text);

        GUILayoutOption GUILayoutWidth(int v);

        void UnityEditorInternalInternalEditorUtilityOpenFileAtLineExternal(string documentUrl, int startLine);

        void EditorGUILayoutLabelField(Texture2D texture, GUILayoutOption[] options);

        GUILayoutOption GUILayoutHeight(int v);

        Texture2D AssetDatabaseLoadAssetAtPath(string texture, Type type);

        bool GUILayoutButton(Texture2D inputTexture, GUIStyle label, GUILayoutOption[] options);
    }
}
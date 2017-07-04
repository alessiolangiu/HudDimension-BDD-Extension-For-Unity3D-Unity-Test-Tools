//-----------------------------------------------------------------------
// <copyright file="unityTestBDDComponentBaseEditorBusinessLogicTest.cs" company="Hud Dimension">
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
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class UnityTestBDDComponentBaseEditorBusinessLogicTest
    {
        [TearDown]
        public void Cleanup()
        {
            UnitTestUtility.DestroyTemporaryTestGameObjects();
        }

        [Test]
        [Description("Errors method should call the expected Unity Editor statements given one error on a component")]
        public void Errors_Should_CallTheExpectedUnityEditorStatements_Given_OneErrorOnAComponent()
        {
            UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent>();
            BDDExtensionRunner runner = UnitTestUtility.CreateComponent<BDDExtensionRunner>(component.gameObject);

            BaseBDDComponentEditorBusinessLogic unityTestBDDComponentBaseEditorBusinessLogic = new BaseBDDComponentEditorBusinessLogic(component);
            string expectedMessage = "Message";
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            UnityTestBDDError error = new UnityTestBDDError();
            error.Message = expectedMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            errors.Add(error);

            string errorTextureFullPath = Utilities.GetAssetFullPath(runner, unityTestBDDComponentBaseEditorBusinessLogic.ErrorTextureFileName);
            string openComponentButtonTextureFullPath = Utilities.GetAssetFullPath(runner, unityTestBDDComponentBaseEditorBusinessLogic.OpenComponentButtonTextureFileName);

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns(600f);
            float labelWidth = 500f;
            Texture2D inputTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D)).Returns(inputTexture);
            Texture2D errorTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D)).Returns(errorTexture);

            GUILayoutOption buttonWidth = GUILayout.Width(16);
            unityInterface.GUILayoutWidth(24).Returns(buttonWidth);
            GUILayoutOption buttonHeight = GUILayout.Height(16);
            unityInterface.GUILayoutHeight(24).Returns(buttonHeight);
            GUILayoutOption[] options = new GUILayoutOption[2];
            options[0] = buttonWidth;
            options[1] = buttonHeight;
            unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, options).Returns(false);
            GUILayoutOption[] errorTextureOptions = new GUILayoutOption[2];
            errorTextureOptions[0] = buttonWidth;
            errorTextureOptions[1] = buttonHeight;
            unityTestBDDComponentBaseEditorBusinessLogic.Errors(errors, unityInterface);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.EditorGUILayoutLabelField(errorTexture, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(errorTextureOptions) == true));
                unityInterface.EditorGUILayoutLabelField(expectedMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(options) == true));
                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }

        [Test]
        [Description("Errors method should call the expected Unity Editor statements given two errors on a component")]
        public void Errors_Should_CallTheExpectedUnityEditorStatements_Given_TwoErrorsOnAComponent()
        {
            UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent>();
            BDDExtensionRunner runner = UnitTestUtility.CreateComponent<BDDExtensionRunner>(component.gameObject);

            BaseBDDComponentEditorBusinessLogic unityTestBDDComponentBaseEditorBusinessLogic = new BaseBDDComponentEditorBusinessLogic(component);
            string expectedFirstMessage = "FirstMessage";
            string expectedSecondMessage = "SecondMessage";
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            UnityTestBDDError error = new UnityTestBDDError();
            error.Message = expectedFirstMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            errors.Add(error);

            error = new UnityTestBDDError();
            error.Message = expectedSecondMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            errors.Add(error);

            string errorTextureFullPath = Utilities.GetAssetFullPath(runner, unityTestBDDComponentBaseEditorBusinessLogic.ErrorTextureFileName);
            string openComponentButtonTextureFullPath = Utilities.GetAssetFullPath(runner, unityTestBDDComponentBaseEditorBusinessLogic.OpenComponentButtonTextureFileName);

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns(600f);
            float labelWidth = 500f;
            Texture2D inputTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D)).Returns(inputTexture);
            Texture2D errorTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D)).Returns(errorTexture);

            GUILayoutOption buttonWidth = GUILayout.Width(16);
            unityInterface.GUILayoutWidth(24).Returns(buttonWidth);
            GUILayoutOption buttonHeight = GUILayout.Height(16);
            unityInterface.GUILayoutHeight(24).Returns(buttonHeight);
            GUILayoutOption[] options = new GUILayoutOption[2];
            options[0] = buttonWidth;
            options[1] = buttonHeight;
            unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, options).Returns(false);
            GUILayoutOption[] errorTextureOptions = new GUILayoutOption[2];
            errorTextureOptions[0] = buttonWidth;
            errorTextureOptions[1] = buttonHeight;

            unityTestBDDComponentBaseEditorBusinessLogic.Errors(errors, unityInterface);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.EditorGUILayoutLabelField(errorTexture, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(errorTextureOptions) == true));
                unityInterface.EditorGUILayoutLabelField(expectedFirstMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(options) == true));
                unityInterface.EditorGUILayoutEndHorizontal();

                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.AssetDatabaseLoadAssetAtPath(errorTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.EditorGUILayoutLabelField(errorTexture, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(errorTextureOptions) == true));
                unityInterface.EditorGUILayoutLabelField(expectedSecondMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(openComponentButtonTextureFullPath, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(options) == true));
                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }
    }
}
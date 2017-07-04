//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicErrorsManagementTest.cs" company="Hud Dimension">
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
    public class RunnerEditorBusinessLogicErrorsManagementTest
    {
        [Test]
        [Description("Errors method should call the expected Unity Editor statements given a list containing one UnityTestBDDError object")]
        public void Errors_Should_CallTheExpectedUnityEditoStatements_Given_AListContainingOneUnityTestBDDErrorObject()
        {
            UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent>();

            RunnerEditorBusinessLogicErrorsManagement runnerEditorBusinessLogicErrorsManagement = new RunnerEditorBusinessLogicErrorsManagement();
            string expectedMessage = "Message";
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            UnityTestBDDError error = new UnityTestBDDError();
            error.Message = expectedMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            error.ShowButton = true;
            error.ShowRedExclamationMark = true;
            errors.Add(error);

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns(600f);
            float labelWidth = 500f;
            Texture2D inputTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.OpenComponentButtonTextureFileName, typeof(Texture2D)).Returns(inputTexture);
            Texture2D errorTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.ErrorTextureFileName, typeof(Texture2D)).Returns(errorTexture);

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
            runnerEditorBusinessLogicErrorsManagement.Errors(errors, unityInterface, null);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.ErrorTextureFileName, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.EditorGUILayoutLabelField(errorTexture, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(errorTextureOptions) == true));
                unityInterface.EditorGUILayoutLabelField(expectedMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.OpenComponentButtonTextureFileName, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.GUILayoutButton(inputTexture, EditorStyles.label, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(options) == true));
                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }

        [Test]
        [Description("Errors method should call the expected Unity Editor statements given a list containing two UnityTestBDDError object")]
        public void Errors_Should_CallTheExpectedUnityEditoStatements_Given_AListContainingTwoUnityTestBDDErrorObject()
        {
            UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<UnityTestBDDComponentBaseEditorBusinessLogicTestFirstDynamicComponent>();
            RunnerEditorBusinessLogicErrorsManagement runnerEditorBusinessLogicErrorsManagement = new RunnerEditorBusinessLogicErrorsManagement();
            string expectedFirstMessage = "FirstMessage";
            string expectedSecondMessage = "SecondMessage";
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            UnityTestBDDError error = new UnityTestBDDError();
            error.Message = expectedFirstMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            error.ShowButton = true;
            error.ShowRedExclamationMark = true;

            errors.Add(error);

            error = new UnityTestBDDError();
            error.Message = expectedSecondMessage;
            error.Component = component;
            error.MethodMethodInfo = null;
            error.ShowButton = false;
            error.ShowRedExclamationMark = false;

            errors.Add(error);

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns(600f);
            float labelWidth = 500f;
            Texture2D inputTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.OpenComponentButtonTextureFileName, typeof(Texture2D)).Returns(inputTexture);
            Texture2D errorTexture = new Texture2D(10, 10);
            unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.ErrorTextureFileName, typeof(Texture2D)).Returns(errorTexture);

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

            runnerEditorBusinessLogicErrorsManagement.Errors(errors, unityInterface, null);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutSeparator();
                unityInterface.EditorGUILayoutEndHorizontal();
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.ErrorTextureFileName, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);
                unityInterface.EditorGUILayoutLabelField(errorTexture, Arg.Is<GUILayoutOption[]>(x => x.SequenceEqual(errorTextureOptions) == true));
                unityInterface.EditorGUILayoutLabelField(expectedFirstMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.OpenComponentButtonTextureFileName, typeof(Texture2D));
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

                unityInterface.EditorGUILayoutLabelField(expectedSecondMessage, labelWidth);
                unityInterface.AssetDatabaseLoadAssetAtPath(runnerEditorBusinessLogicErrorsManagement.OpenComponentButtonTextureFileName, typeof(Texture2D));
                unityInterface.GUILayoutWidth(24);
                unityInterface.GUILayoutHeight(24);

                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }
    }
}
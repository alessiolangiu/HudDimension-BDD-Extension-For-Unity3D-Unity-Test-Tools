//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicDynamicRowsElementsUT.cs" company="Hud Dimesion">
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class RunnerEditorBusinessLogicDynamicRowsElementsUT
    {
        [Test]
        public void DrwawFoldoutSymbolWithParametersWithoutInteractions()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[3] { "FirstValue", "SecondValue", "ThirdValue" });

            MethodInfo methodInfo = component.GetType().GetMethod("SecondWhenMethod");
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            bool[] foldouts = new bool[3] { false, false, false };
            bool[] expectedFoldouts = new bool[3] { false, false, false };
            int index = 0;
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            Rect rect = default(Rect);
            rect.width = 600F;
            rect.height = 300F;
            unityInterface.EditorGUILayoutGetControlRect().Returns(rect);
            unityInterface.EditorGUIFoldout(rect, foldouts[index], string.Empty).Returns(false);

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawFoldoutSymbol(unityInterface, foldouts, index, fullMethodDescriptionsList);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutGetControlRect();
                unityInterface.EditorGUIFoldout(rect, foldouts[index], string.Empty);
            });

            Assert.AreEqual(expectedFoldouts, foldouts, "Il metodo DrawFoldoutSymbol non restituisce il corretto valore di foldouts");
        }

        [Test]
        public void DrwawFoldoutSymbolWithParametersWithInteractions()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[3] { "FirstValue", "SecondValue", "ThirdValue" });

            MethodInfo methodInfo = component.GetType().GetMethod("SecondWhenMethod");
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            bool[] foldouts = new bool[3] { false, false, false };
            bool[] expectedFoldouts = new bool[3] { true, false, false };
            int index = 0;
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            Rect rect = default(Rect);
            rect.width = 600F;
            rect.height = 300F;
            unityInterface.EditorGUILayoutGetControlRect().Returns(rect);
            unityInterface.EditorGUIFoldout(rect, foldouts[index], string.Empty).Returns(true);

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawFoldoutSymbol(unityInterface, foldouts, index, fullMethodDescriptionsList);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutGetControlRect();
                unityInterface.EditorGUIFoldout(rect, false, string.Empty);
            });

            Assert.AreEqual(expectedFoldouts, foldouts, "Il metodo DrawFoldoutSymbol non restituisce il corretto valore di foldouts");
        }

        [Test]
        public void DrwawFoldoutSymbolWithoutParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[3] { "FirstValue", "SecondValue", "ThirdValue" });

            MethodInfo methodInfo = component.GetType().GetMethod("ThenMethod");
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            bool[] foldouts = new bool[3] { false, false, false };
            bool[] expectedFoldouts = new bool[3] { false, false, false };
            int index = 0;
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            Rect rect = default(Rect);
            rect.width = 600F;
            rect.height = 300F;
            unityInterface.EditorGUILayoutGetControlRect().Returns(rect);
            unityInterface.EditorGUIFoldout(rect, foldouts[index], string.Empty).Returns(true);

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, methodInfo);
            string parametersIndex = string.Empty;
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawFoldoutSymbol(unityInterface, foldouts, index, fullMethodDescriptionsList);

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutGetControlRect();
                unityInterface.EditorGUIFoldout(rect, false, string.Empty, EditorStyles.label);
            });

            Assert.AreEqual(expectedFoldouts, foldouts, "Il metodo DrawFoldoutSymbol non restituisce il corretto valore di foldouts");
        }

        [Test]
        public void DrawLabelGiven()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            for (int index = 0; index < 3; index++)
            {
                dynamicRowsElements.DrawLabel<GivenBaseAttribute>(unityInterface, index);
            }

            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutLabelField("Given", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
                unityInterface.EditorGUILayoutLabelField("and", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
                unityInterface.EditorGUILayoutLabelField("and", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
            });
        }

        [Test]
        public void DrawDescriptionWithChosenMethodBlank()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = string.Empty;
            MethodDescription methodDescription = null;
            dynamicRowsElements.DrawDescription(unityInterface, chosenMethod, methodDescription, 200F);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutLabelField(RunnerEditorBusinessLogicDynamicRowsElements.ChoseMethodFromComboBox, 200F);
            });
        }

        [Test]
        public void DrawDescriptionWithChosenMethodFoundWithoutParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = string.Empty;
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("ThenMethod");
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<ThenBaseAttribute>(component, methodInfo);
            string parametersIndex = string.Empty;
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            dynamicRowsElements.DrawDescription(unityInterface, chosenMethod, methodDescription, 200F);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutLabelField(methodDescription.Text, 200F);
            });
        }

        [Test]
        public void DrawDescriptionWithChosenMethodFoundWithParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = string.Empty;
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[1] { "StringParameterValue" });

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            firstIntArrayStorage.SetValue(component, new int[1] { 103 });

            MethodInfo methodInfo = component.GetType().GetMethod("WhenMethod");
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0];string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            dynamicRowsElements.DrawDescription(unityInterface, chosenMethod, methodDescription, 200F);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutLabelField(methodDescription.GetDecodifiedText(), 200F);
            });
        }

        [Test]
        public void DrawDescriptionWithChosenMethodNotFound()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = "DynamicBDDForTest.FakeMethodName";
            MethodDescription methodDescription = null;
            dynamicRowsElements.DrawDescription(unityInterface, chosenMethod, methodDescription, 200F);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutLabelField("### The method " + chosenMethod + " is missing ###", 200F);
            });
        }

        [Test]
        public void DrawComboBoxWithEmptySelectionAndNoAction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUILayoutPopup(Arg.Any<int>(), Arg.Any<string[]>()).Returns(0);
            string selectedMethod = string.Empty;
            string[] methodsArray = new string[4] { "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string[] modifiedMethodsArray = new string[5] { string.Empty, "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string result = dynamicRowsElements.DrawComboBox(unityInterface, selectedMethod, methodsArray);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutPopup(0, Arg.Is<string[]>(x => x.SequenceEqual(modifiedMethodsArray) == true));
            });
            Assert.AreEqual(string.Empty, result, "The method DrawComboBox doesn't return the right method");
        }

        [Test]
        public void DrawComboBoxWithEmptySelectionAndANewSelectionAction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUILayoutPopup(Arg.Any<int>(), Arg.Any<string[]>()).Returns(2);
            string selectedMethod = string.Empty;
            string[] methodsArray = new string[4] { "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string[] modifiedMethodsArray = new string[5] { string.Empty, "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string result = dynamicRowsElements.DrawComboBox(unityInterface, selectedMethod, methodsArray);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutPopup(0, Arg.Is<string[]>(x => x.SequenceEqual(modifiedMethodsArray) == true));
            });
            Assert.AreEqual("SecondMethod", result, "The method DrawComboBox doesn't return the right method");
        }

        [Test]
        public void DrawComboBoxWithASelectionAndNoAction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUILayoutPopup(Arg.Any<int>(), Arg.Any<string[]>()).Returns(2);
            string selectedMethod = "SecondMethod";
            string[] methodsArray = new string[4] { "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string[] modifiedMethodsArray = new string[5] { string.Empty, "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string result = dynamicRowsElements.DrawComboBox(unityInterface, selectedMethod, methodsArray);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutPopup(2, Arg.Is<string[]>(x => x.SequenceEqual(modifiedMethodsArray) == true));
            });
            Assert.AreEqual("SecondMethod", result, "The method DrawComboBox doesn't return the right method");
        }

        [Test]
        public void DrawComboBoxWithASelectionAndANewSelectionAction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUILayoutPopup(Arg.Any<int>(), Arg.Any<string[]>()).Returns(3);
            string selectedMethod = "SecondMethod";
            string[] methodsArray = new string[4] { "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string[] modifiedMethodsArray = new string[5] { string.Empty, "FirstMethod", "SecondMethod", "ThirdMethod", "FourthMethod" };
            string result = dynamicRowsElements.DrawComboBox(unityInterface, selectedMethod, methodsArray);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutPopup(2, Arg.Is<string[]>(x => x.SequenceEqual(modifiedMethodsArray) == true));
            });
            Assert.AreEqual("ThirdMethod", result, "The method DrawComboBox doesn't return the right method");
        }

        [Test]
        public void DrawComboBoxWithEmptySelectionAndEmptyList()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUILayoutPopup(Arg.Any<int>(), Arg.Any<string[]>()).Returns(0);
            string selectedMethod = string.Empty;
            string[] methodsArray = new string[0];
            string[] modifiedMethodsArray = new string[1] { string.Empty };
            string result = dynamicRowsElements.DrawComboBox(unityInterface, selectedMethod, methodsArray);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutPopup(0, Arg.Is<string[]>(x => x.SequenceEqual(modifiedMethodsArray) == true));
            });
            Assert.AreEqual(string.Empty, result, "The method DrawComboBox doesn't return the right method");
        }

        [Test]
        public void DrawParametersRowsWithJustAStringParameterAndFoldoutFalse()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[1] { "ValueForTheStringParameter" });

            GUIContent guiContent = new GUIContent("stringParam");
            unityInterface.GUIContent("stringParam").Returns(guiContent);

            ISerializedObjectWrapper serializedObjectWrapper = Substitute.For<ISerializedObjectWrapper>();
            ISerializedPropertyWrapper property = Substitute.For<ISerializedPropertyWrapper>();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            string parameterLocationString = methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            serializedObjectWrapper.FindProperty(parameterLocationString).Returns(property);
            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest), serializedObjectWrapper);
            bool foldout = false;

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
            });
        }

        [Test]
        public void DrawParametersRowsWithJustAStringParameter()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[1] { "ValueForTheStringParameter" });

            GUIContent guiContent = new GUIContent("stringParam");
            unityInterface.GUIContent("stringParam").Returns(guiContent);

            ISerializedObjectWrapper serializedObjectWrapper = Substitute.For<ISerializedObjectWrapper>();
            ISerializedPropertyWrapper property = Substitute.For<ISerializedPropertyWrapper>();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            string parameterLocationString = methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            serializedObjectWrapper.FindProperty(parameterLocationString).Returns(property);
            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest), serializedObjectWrapper);
            bool foldout = true;

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
                unityInterface.GUIContent("stringParam");
                serializedObjectWrapper.FindProperty(parameterLocationString);
                unityInterface.EditorGUILayoutPropertyField(property, guiContent);
            });
        }

        [Test]
        public void DrawParametersRowsWithTwoParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("WhenMethod");

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[1] { "ValueForTheStringParameter" });

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            firstIntArrayStorage.SetValue(component, new int[1] { 103 });

            GUIContent stringParamGuiContent = new GUIContent("whenStringParam");
            unityInterface.GUIContent("whenStringParam").Returns(stringParamGuiContent);
            GUIContent intParamGuiContent = new GUIContent("whenIntParam");
            unityInterface.GUIContent("whenIntParam").Returns(intParamGuiContent);

            ISerializedObjectWrapper serializedObjectWrapper = Substitute.For<ISerializedObjectWrapper>();
            ISerializedPropertyWrapper stringProperty = Substitute.For<ISerializedPropertyWrapper>();
            ISerializedPropertyWrapper intProperty = Substitute.For<ISerializedPropertyWrapper>();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            MethodParameter stringParameter = null;
            MethodParameter intParameter = null;
            if (methodDescription.Parameters.Parameters[0].ParameterInfoObject.Name.Equals("whenStringParam"))
            {
                stringParameter = methodDescription.Parameters.Parameters[0];
                intParameter = methodDescription.Parameters.Parameters[1];
            }
            else
            {
                stringParameter = methodDescription.Parameters.Parameters[1];
                intParameter = methodDescription.Parameters.Parameters[0];
            }

            string stringParameterLocationString = stringParameter.ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + stringParameter.ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            string intParameterLocationString = intParameter.ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + intParameter.ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";

            serializedObjectWrapper.FindProperty(stringParameterLocationString).Returns(stringProperty);
            serializedObjectWrapper.FindProperty(intParameterLocationString).Returns(intProperty);

            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest), serializedObjectWrapper);
            bool foldout = true;

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
                unityInterface.GUIContent("whenStringParam");
                serializedObjectWrapper.FindProperty(stringParameterLocationString);
                unityInterface.EditorGUILayoutPropertyField(stringProperty, stringParamGuiContent);

                unityInterface.GUIContent("whenIntParam");
                serializedObjectWrapper.FindProperty(intParameterLocationString);
                unityInterface.EditorGUILayoutPropertyField(intProperty, intParamGuiContent);
            });
        }

        [Test]
        public void DrawParametersRowsWithMethodDescriptionNull()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            MethodInfo methodInfo = component.GetType().GetMethod("WhenMethod");

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            firstStringArrayStorage.SetValue(component, new string[1] { "ValueForTheStringParameter" });

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            firstIntArrayStorage.SetValue(component, new int[1] { 103 });

            GUIContent stringParamGuiContent = new GUIContent("whenStringParam");
            unityInterface.GUIContent("whenStringParam").Returns(stringParamGuiContent);
            GUIContent intParamGuiContent = new GUIContent("whenIntParam");
            unityInterface.GUIContent("whenIntParam").Returns(intParamGuiContent);

            ISerializedObjectWrapper serializedObjectWrapper = Substitute.For<ISerializedObjectWrapper>();
            ISerializedPropertyWrapper stringProperty = Substitute.For<ISerializedPropertyWrapper>();
            ISerializedPropertyWrapper intProperty = Substitute.For<ISerializedPropertyWrapper>();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription baseMethodDescription = baseMethodDescriptionBuilder.Build<WhenBaseAttribute>(component, methodInfo);
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            MethodParameter stringParameter = null;
            MethodParameter intParameter = null;
            if (methodDescription.Parameters.Parameters[0].ParameterInfoObject.Name.Equals("whenStringParam"))
            {
                stringParameter = methodDescription.Parameters.Parameters[0];
                intParameter = methodDescription.Parameters.Parameters[1];
            }
            else
            {
                stringParameter = methodDescription.Parameters.Parameters[1];
                intParameter = methodDescription.Parameters.Parameters[0];
            }

            string stringParameterLocationString = stringParameter.ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + stringParameter.ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            string intParameterLocationString = intParameter.ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + intParameter.ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";

            serializedObjectWrapper.FindProperty(stringParameterLocationString).Returns(stringProperty);
            serializedObjectWrapper.FindProperty(intParameterLocationString).Returns(intProperty);

            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest), serializedObjectWrapper);
            bool foldout = true;

            methodDescription = null;
            List<FullMethodDescription> fullMethodDescriptionsList = new List<FullMethodDescription>();
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
            });
        }

        [Test]
        public void DrawAddRowButtonForThreeRowsWithoutInteraction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption).Returns(false, false, false);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
            });

            Assert.AreEqual(chosenMethods.ChosenMethodsNames, newChosenMethods.ChosenMethodsNames, "THe method DrawAddRowButton doesn't return the right ChoosenMethods object");
            Assert.AreEqual(chosenMethods.ChosenMethodsParametersIndex, newChosenMethods.ChosenMethodsParametersIndex, "THe method DrawAddRowButton doesn't return the right ChoosenMethods object");
        }

        [Test]
        public void DrawAddRowButtonForThreeRowsWithInteractionIntheFirstRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption).Returns(true, false, false);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.EditorUtilitySetDirty(target);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
            });

            Assert.AreEqual(4, newChosenMethods.ChosenMethodsNames.Length, "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[0].Method.Name, newChosenMethods.ChosenMethodsNames[0], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("1", newChosenMethods.ChosenMethodsParametersIndex[0], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(string.Empty, newChosenMethods.ChosenMethodsNames[1], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual(string.Empty, newChosenMethods.ChosenMethodsParametersIndex[1], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[1].Method.Name, newChosenMethods.ChosenMethodsNames[2], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("2", newChosenMethods.ChosenMethodsParametersIndex[2], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[2].Method.Name, newChosenMethods.ChosenMethodsNames[3], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("3", newChosenMethods.ChosenMethodsParametersIndex[3], "The method DrawAddRowButton doesn't add correctly the new row");
        }

        [Test]
        public void DrawAddRowButtonForThreeRowsWithInteractionIntheLastRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption).Returns(false, false, true);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("+", EditorStyles.miniButton, layoutOption);
                unityInterface.EditorUtilitySetDirty(target);
            });

            Assert.AreEqual(4, newChosenMethods.ChosenMethodsNames.Length, "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[0].Method.Name, newChosenMethods.ChosenMethodsNames[0], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("1", newChosenMethods.ChosenMethodsParametersIndex[0], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[1].Method.Name, newChosenMethods.ChosenMethodsNames[1], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("2", newChosenMethods.ChosenMethodsParametersIndex[1], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[2].Method.Name, newChosenMethods.ChosenMethodsNames[2], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("3", newChosenMethods.ChosenMethodsParametersIndex[2], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(string.Empty, newChosenMethods.ChosenMethodsNames[3], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual(string.Empty, newChosenMethods.ChosenMethodsParametersIndex[3], "The method DrawAddRowButton doesn't add correctly the new row");
        }

        [Test]
        public void DrawRemoveRowButtonForThreeRowsWithoutInteraction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption).Returns(false, false, false);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
            });

            Assert.AreEqual(chosenMethods.ChosenMethodsNames, newChosenMethods.ChosenMethodsNames, "THe method DrawAddRowButton doesn't return the right ChoosenMethods object");
            Assert.AreEqual(chosenMethods.ChosenMethodsParametersIndex, newChosenMethods.ChosenMethodsParametersIndex, "THe method DrawAddRowButton doesn't return the right ChoosenMethods object");
        }

        [Test]
        public void DrawRemoveRowButtonForThreeRowsWithInteractionIntheFirstRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption).Returns(true, false, false);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.EditorUtilitySetDirty(target);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
            });

            Assert.AreEqual(2, newChosenMethods.ChosenMethodsNames.Length, "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[1].Method.Name, newChosenMethods.ChosenMethodsNames[0], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("2", newChosenMethods.ChosenMethodsParametersIndex[0], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[2].Method.Name, newChosenMethods.ChosenMethodsNames[1], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("3", newChosenMethods.ChosenMethodsParametersIndex[1], "The method DrawAddRowButton doesn't add correctly the new row");
        }

        [Test]
        public void DrawRemoveRowButtonForThreeRowsWithInteractionIntheLastRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[3] { baseMethodsDescriptions[0].Method.Name, baseMethodsDescriptions[1].Method.Name, baseMethodsDescriptions[2].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[3] { "1", "2", "3" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption).Returns(false, false, true);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
                unityInterface.EditorUtilitySetDirty(target);
            });

            Assert.AreEqual(2, newChosenMethods.ChosenMethodsNames.Length, "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[0].Method.Name, newChosenMethods.ChosenMethodsNames[0], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("1", newChosenMethods.ChosenMethodsParametersIndex[0], "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[1].Method.Name, newChosenMethods.ChosenMethodsNames[1], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("2", newChosenMethods.ChosenMethodsParametersIndex[1], "The method DrawAddRowButton doesn't add correctly the new row");
        }

        [Test]
        public void DrawRemoveRowButtonForOneRowWithInteraction()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsUTDynamicBDDForTest>();
            Component[] components = new Component[1] { component };
            MethodsFilterByStepType methodFilter = new MethodsFilterByStepType();
            BaseMethodDescriptionBuilder baseMethodBuilder = new BaseMethodDescriptionBuilder();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodBuilder, methodFilter);
            List<BaseMethodDescription> baseMethodsDescriptions = methodsLoader.LoadStepMethods<WhenBaseAttribute>(components);

            ChosenMethods chosenMethods = new ChosenMethods();
            chosenMethods.ChosenMethodsNames = new string[1] { baseMethodsDescriptions[0].Method.Name };
            chosenMethods.ChosenMethodsParametersIndex = new string[1] { "1" };

            UnityEngine.Object target = Substitute.For<UnityEngine.Object>();
            ChosenMethods newChosenMethods = null;
            ChosenMethods currentChosenMethods = (ChosenMethods)chosenMethods.Clone();
            GUILayoutOption layoutOption = GUILayout.Width(20);
            unityInterface.GUILayoutWidth(20).Returns(layoutOption);
            unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption).Returns(true);

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, out newChosenMethods);
                currentChosenMethods = newChosenMethods;
            }

            Received.InOrder(() =>
            {
                unityInterface.GUILayoutButton("-", EditorStyles.miniButton, layoutOption);
            });

            Assert.AreEqual(1, newChosenMethods.ChosenMethodsNames.Length, "The method DrawAddRowButton doesn't add correctly the new row");

            Assert.AreEqual(baseMethodsDescriptions[0].Method.Name, newChosenMethods.ChosenMethodsNames[0], "The method DrawAddRowButton doesn't add correctly the new row");
            Assert.AreEqual("1", newChosenMethods.ChosenMethodsParametersIndex[0], "The method DrawAddRowButton doesn't add correctly the new row");
        }
    }
}
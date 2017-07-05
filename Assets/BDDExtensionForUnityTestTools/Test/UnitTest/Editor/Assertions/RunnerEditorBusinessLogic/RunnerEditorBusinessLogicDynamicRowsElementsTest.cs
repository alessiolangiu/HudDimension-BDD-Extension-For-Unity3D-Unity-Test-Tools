//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicDynamicRowsElementsTest.cs" company="Hud Dimension">
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class RunnerEditorBusinessLogicDynamicRowsElementsTest
    {
        [TearDown]
        public void Cleanup()
        {
            UnitTestUtility.DestroyTemporaryTestGameObjects();
        }

        [Test]
        [Description("DrawFoldoutSymbol method should call the expected Unity Editor statements given a method with parameters and without user interactions with the foldout symbol")]
        public void DrawFoldoutSymbol_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithParametersAndWithoutUserInteractionsWithTheFoldoutSymbol()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();

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
        [Description("DrawFoldoutSymbol method should call the expected Unity Editor statements given a method with parameters and with user interactions with the foldout symbol")]
        public void DrawFoldoutSymbol_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithParametersAndWithUserInteractionsWithTheFoldoutSymbol()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();

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
        [Description("DrawFoldoutSymbol method should call the expected Unity Editor statements given a method without parameters")]
        public void DrawFoldoutSymbol_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithoutParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();

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
        [Description("DrawLabel method should call the expected Unity Editor statements given being called three times for the Given methods with increasing indexes")]
        public void DrawLabel_Should_CallTheExpectedUnityEditorStatements_Given_BeingCalledThreeTimesForGivenMethodsWithIncreasingIndexes()
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
        [Description("DrawDescription method should call the expected Unity Editor statements given a blank chosen method")]
        public void DrawDescription_Should_CallTheExpectedUnityEditorStatements_Given_ABlankChosenMethod()
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
        [Description("DrawDescription method should call the expected Unity Editor statements given a MethodDescription object without parameters")]
        public void DrawDescription_Should_CallTheExpectedUnityEditorStatements_Given_AMethodDescriptionObjectWithoutParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = string.Empty;
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
        [Description("DrawDescription method should call the expected Unity Editor statements given a MethodDescription object with parameters")]
        public void DrawDescription_Should_CallTheExpectedUnityEditorStatements_Given_AMethodDescriptionObjectWithParameters()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            string chosenMethod = string.Empty;
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();

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
        [Description("DrawDescription method should call the expected Unity Editor statements given a null MethodDescription parameter")]
        public void DrawDescription_Should_CallTheExpectedUnityEditorStatements_Given_ANullMethodDescriptionParameter()
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
        [Description("DrawComboBox  method should call the expected Unity Editor statements given an empty selection and without user interaction")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AnEmptySelectionAndWithoutUserInteraction()
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
        [Description("DrawComboBox  method should call the expected Unity Editor statements given an empty selection and a new selection action")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AnEmptySelectionAndANewSelectionAction()
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
        [Description("DrawComboBox  method should call the expected Unity Editor statements given a selection and without a user interaction")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_ASelectionAndWithoutUserInteraction()
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
        [Description("DrawComboBox  method should call the expected Unity Editor statements given a selection and a new selection action")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_ASelectionAndANewSelectionAction()
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
        [Description("DrawComboBox method should call the expected Unity Editor statements given an empty selection and an empty list")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AnEmptySelectionAndAnEmptyList()
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
        [Description("DrawParametersRows method should call the expected Unity Editor statements given a method with one parameter and foldout false")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithOneParameterAndFoldoutFalse()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.GivenMethod.stringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            string parameterLocationString = methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            serializedObjectWrapper.FindProperty(parameterLocationString).Returns(property);
            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent), serializedObjectWrapper);
            bool foldout = false;

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodDescriptionsList = fullMethodDescriptionBuilder.Build(methodDescription, 1);
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
            });
        }

        [Test]
        [Description("DrawParametersRows method should call the expected Unity Editor statements given a method with one string parameter and foldout true")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithOneStringParameterAndFoldoutTrue()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.GivenMethod.stringParam.,stringPVS.Array.data[0];";
            MethodDescription methodDescription = methodDescriptionBuilder.Build(methodParametersLoader, baseMethodDescription, parametersIndex);
            string parameterLocationString = methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayName + ".Array.data[" + methodDescription.Parameters.Parameters[0].ParameterLocation.ParameterArrayLocation.ArrayIndex + "]";
            serializedObjectWrapper.FindProperty(parameterLocationString).Returns(property);
            Dictionary<Type, ISerializedObjectWrapper> serializedObjects = new Dictionary<Type, ISerializedObjectWrapper>();
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent), serializedObjectWrapper);
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
        [Description("DrawParametersRows method should call the expected Unity Editor statements given a method with two parameters and foldout true")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_AMethodWithTwoParametersAndFoldoutTrue()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
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
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent), serializedObjectWrapper);
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
        [Description("DrawParametersRows method should call the expected Unity Editor statements given a null MethodDescription")]
        public void DrawComboBox_Should_CallTheExpectedUnityEditorStatements_Given_ANullMethodDescription()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();

            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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

            string parametersIndex = ";string,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.WhenMethod.whenStringParam.,stringPVS.Array.data[0];int,RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
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
            serializedObjects.Add(typeof(RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent), serializedObjectWrapper);
            bool foldout = true;

            methodDescription = null;
            List<FullMethodDescription> fullMethodDescriptionsList = new List<FullMethodDescription>();
            dynamicRowsElements.DrawParametersRows(unityInterface, foldout, fullMethodDescriptionsList, serializedObjects, false);

            Received.InOrder(() =>
            {
            });
        }

        [Test]
        [Description("DrawAddRowButton method should call the expected Unity Editor statements given three methods without interactions")]
        public void DrawAddRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithoutInteractions()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;
            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawAddRowButton method should call the expected Unity Editor statements given three methods with interaction on the first row")]
        public void DrawAddRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithInteractionOnTheFirstRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawAddRowButton method should call the expected Unity Editor statements given three methods with interaction on the last row")]
        public void DrawAddRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithInteractionOnTheLastRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawAddRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawRemoveRowButton method should call the expected Unity Editor statements given three methods without interactions")]
        public void DrawRemoveRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithoutInteractions()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawRemoveRowButton method should call the expected Unity Editor statements given three methods with interaction on the first row")]
        public void DrawRemoveRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithInteractionOnTheFirstRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawRemoveRowButton method should call the expected Unity Editor statements given three methods with interaction on the last row")]
        public void DrawRemoveRowButton_Should_CallTheExpectedUnityEditorStatements_Given_ThreeMethodsWithInteractionOnTheLastRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
        [Description("DrawRemoveRowButton method should call the expected Unity Editor statements given one methods with interaction on the row")]
        public void DrawRemoveRowButton_Should_CallTheExpectedUnityEditorStatements_Given_OneMethodsWithInteractionOnTheRow()
        {
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent component = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicDynamicRowsElementsTestFirstDynamicComponent>();
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
            string undoText = string.Empty;

            for (int index = 0; index < chosenMethods.ChosenMethodsNames.Length; index++)
            {
                dynamicRowsElements.DrawRemoveRowButton(unityInterface, index, currentChosenMethods, target, undoText, out newChosenMethods, out undoText);
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
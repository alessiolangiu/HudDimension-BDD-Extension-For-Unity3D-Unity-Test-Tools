using System.Collections.Generic;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class RunnerEditorBusinessLogicStaticRowsUT
    {
        [Test]
        public void DrawStaticRowsOneGivenRow()
        {
            Component[] bddComponents = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicStaticRowsUTStaticBDDComponentForTest>() };

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns<float>(500F);

            BaseMethodDescriptionBuilder methodBuilder = Substitute.For<BaseMethodDescriptionBuilder>();
            MethodInfo methodInfo = typeof(RunnerEditorBusinessLogicStaticRowsUTStaticBDDComponentForTest).GetMethod("GivenMethod");
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByExecutionOrder);
            List<BaseMethodDescription> baseMethodDescriptionList = bddStepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(bddComponents);
            methodBuilder.Build<GivenBaseAttribute>(bddComponents[0], methodInfo).Returns<BaseMethodDescription>(baseMethodDescriptionList[0]);
            IMethodsFilter methodFilter = Substitute.For<IMethodsFilter>();
            methodFilter.Filter<GivenBaseAttribute>(methodInfo).Returns(true);

            object[] constructorArguments = new object[2] { new BaseMethodDescriptionBuilder(), new MethodsFilterByExecutionOrder() };
            MethodsLoader stepMethodsLoader = Substitute.For<MethodsLoader>(constructorArguments);
            stepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(bddComponents).Returns(baseMethodDescriptionList);
            RunnerEditorBusinessLogicStaticRows runnerEditorBusinessLogicStaticRows = new RunnerEditorBusinessLogicStaticRows();
            runnerEditorBusinessLogicStaticRows.DrawStaticRows<GivenBaseAttribute>(unityInterface, stepMethodsLoader, bddComponents, RunnerEditorBusinessLogicData.LabelWidthAbsolute, RunnerEditorBusinessLogicData.ButtonsWidthAbsolute);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.EditorGUILayoutLabelField("Given", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
                unityInterface.EditorGUILayoutLabelField("Given method", 368);
                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }

        [Test]
        public void DrawStaticRowsTwoWhenRows()
        {
            Component[] bddComponents = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicStaticRowsUTStaticBDDComponentForTest>() };

            IUnityInterfaceWrapper unityInterface = Substitute.For<IUnityInterfaceWrapper>();
            unityInterface.EditorGUIUtilityCurrentViewWidth().Returns<float>(500F);

            BaseMethodDescriptionBuilder methodBuilder = Substitute.For<BaseMethodDescriptionBuilder>();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByExecutionOrder);
            List<BaseMethodDescription> baseMethodDescriptionList = bddStepMethodsLoader.LoadStepMethods<WhenBaseAttribute>(bddComponents);
            MethodInfo whenMethodInfo = typeof(RunnerEditorBusinessLogicStaticRowsUTStaticBDDComponentForTest).GetMethod("WhenMethod");
            MethodInfo secondWhenMethodInfo = typeof(RunnerEditorBusinessLogicStaticRowsUTStaticBDDComponentForTest).GetMethod("SecondWhenMethod");

            methodBuilder.Build<WhenBaseAttribute>(bddComponents[0], whenMethodInfo).Returns<BaseMethodDescription>(baseMethodDescriptionList[0]);

            methodBuilder.Build<WhenBaseAttribute>(bddComponents[0], secondWhenMethodInfo).Returns<BaseMethodDescription>(baseMethodDescriptionList[1]);

            IMethodsFilter methodFilter = Substitute.For<IMethodsFilter>();
            methodFilter.Filter<WhenBaseAttribute>(whenMethodInfo).Returns(true);
            methodFilter.Filter<WhenBaseAttribute>(secondWhenMethodInfo).Returns(true);

            object[] constructorArguments = new object[2] { new BaseMethodDescriptionBuilder(), new MethodsFilterByExecutionOrder() };
            MethodsLoader stepMethodsLoader = Substitute.For<MethodsLoader>(constructorArguments);
            stepMethodsLoader.LoadStepMethods<WhenBaseAttribute>(bddComponents).Returns(baseMethodDescriptionList);
            RunnerEditorBusinessLogicStaticRows runnerEditorBusinessLogicStaticRows = new RunnerEditorBusinessLogicStaticRows();
            runnerEditorBusinessLogicStaticRows.DrawStaticRows<WhenBaseAttribute>(unityInterface, stepMethodsLoader, bddComponents, RunnerEditorBusinessLogicData.LabelWidthAbsolute, RunnerEditorBusinessLogicData.ButtonsWidthAbsolute);
            Received.InOrder(() =>
            {
                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.EditorGUILayoutLabelField("When", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
                unityInterface.EditorGUILayoutLabelField("When method", 368);
                unityInterface.EditorGUILayoutEndHorizontal();

                unityInterface.EditorGUILayoutBeginHorizontal();
                unityInterface.EditorGUIUtilityCurrentViewWidth();
                unityInterface.EditorGUILayoutLabelField("and", RunnerEditorBusinessLogicData.LabelWidthAbsolute);
                unityInterface.EditorGUILayoutLabelField("Second When method", 368);
                unityInterface.EditorGUILayoutEndHorizontal();
            });
        }
    }
}
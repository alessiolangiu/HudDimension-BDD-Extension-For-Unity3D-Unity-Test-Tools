//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicParametersRebuildUT.cs" company="Hud Dimesion">
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
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class RunnerEditorBusinessLogicParametersRebuildUT
    {
        [Test]
        public void IsBDDObjectsNullWithBDDObjectsNull()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = null;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsTrue(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        public void IsBDDObjectsNullWithBDDObjectsNotNullButEmpty()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = new object[0];
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        public void IsBDDObjectsNullWithBDDObjectsNotNullAndNotEmpty()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = new object[1];
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        public void IsEditorApplicationCompilingJustFinishedMethodTestWithEditorApplicationNotCompilingAndLastEditorCompilingStateFalse()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();

            IUnityInterfaceWrapper unityInterfaceWrapper = Substitute.For<IUnityInterfaceWrapper>();
            unityInterfaceWrapper.EditorApplicationIsCompiling().Returns(false);
            runnerBusinessLogicData.IsCompiling = false;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsEditorApplicationCompilingJustFinished(unityInterfaceWrapper, runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsEditorApplicationCompilingJustFinished doesn't return the right state of editor compilation just finished");
            Assert.IsFalse(runnerBusinessLogicData.IsCompiling, "The method IsEditorApplicationCompilingJustFinished doesn't return the right last state of editor compilation");
        }

        [Test]
        public void IsEditorApplicationCompilingJustFinishedMethodTestWithEditorApplicationNotCompilingAndJustFinished()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();

            IUnityInterfaceWrapper unityInterfaceWrapper = Substitute.For<IUnityInterfaceWrapper>();
            unityInterfaceWrapper.EditorApplicationIsCompiling().Returns(false);
            runnerBusinessLogicData.IsCompiling = true;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsEditorApplicationCompilingJustFinished(unityInterfaceWrapper, runnerBusinessLogicData);
            Assert.IsTrue(result, "The method IsEditorApplicationCompilingJustFinished doesn't return the right state of editor compilation just finished");
            Assert.IsFalse(runnerBusinessLogicData.IsCompiling, "The method IsEditorApplicationCompilingJustFinished doesn't return the right last state of editor compilation");
        }

        [Test]
        public void IsEditorApplicationCompilingJustFinishedMethodTestWithEditorApplicationCompilingAndLastCompilingStateOnNotCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();

            IUnityInterfaceWrapper unityInterfaceWrapper = Substitute.For<IUnityInterfaceWrapper>();
            unityInterfaceWrapper.EditorApplicationIsCompiling().Returns(true);
            runnerBusinessLogicData.IsCompiling = false;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsEditorApplicationCompilingJustFinished(unityInterfaceWrapper, runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsEditorApplicationCompilingJustFinished doesn't return the right state of editor compilation just finished");
            Assert.IsTrue(runnerBusinessLogicData.IsCompiling, "The method IsEditorApplicationCompilingJustFinished doesn't return the right last state of editor compilation");
        }

        [Test]
        public void IsEditorApplicationCompilingJustFinishedMethodTestWithEditorApplicationCompilingAndLastCompilingStateOnCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();

            IUnityInterfaceWrapper unityInterfaceWrapper = Substitute.For<IUnityInterfaceWrapper>();
            unityInterfaceWrapper.EditorApplicationIsCompiling().Returns(true);
            runnerBusinessLogicData.IsCompiling = true;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsEditorApplicationCompilingJustFinished(unityInterfaceWrapper, runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsEditorApplicationCompilingJustFinished doesn't return the right state of editor compilation just finished");
            Assert.IsTrue(runnerBusinessLogicData.IsCompiling, "The method IsEditorApplicationCompilingJustFinished doesn't return the right last state of editor compilation");
        }

        [Test]
        public void BddObjectsHaveChangedWithPreviousBDDComponentsNullAndCurrentBDDObjectsArrayEmpty()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = null;
            Component[] currentComponents = new Component[0];
            ComponentsFilter bddComponentsFilter = Substitute.For<ComponentsFilter>();
            Component[] bddComponentsFilterResult = new Component[0];
            bddComponentsFilter.Filter(currentComponents).Returns<Component[]>(bddComponentsFilterResult);

            bool result = runnerEditorBusinessLogicParametersRebuild.BddObjectsHaveChanged(currentComponents, runnerBusinessLogicData, bddComponentsFilter);
            Assert.IsFalse(result, "The method BddObjectsHaveChanged doesn't return the right state");
        }

        [Test]
        public void BddObjectsHaveChangedWithPreviousBDDComponentsNullAndCurrentBDDObjectsArrayWithOneComponent()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = null;
            Component[] currentComponents = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersRebuildUTDynamicBDDForTest>() };
            ComponentsFilter bddComponentsFilter = Substitute.For<ComponentsFilter>();
            Component[] bddComponentsFilterResult = new Component[1] { currentComponents[0] };
            bddComponentsFilter.Filter(currentComponents).Returns<Component[]>(bddComponentsFilterResult);

            bool result = runnerEditorBusinessLogicParametersRebuild.BddObjectsHaveChanged(currentComponents, runnerBusinessLogicData, bddComponentsFilter);
            Assert.IsTrue(result, "The method BddObjectsHaveChanged doesn't return the right state");
        }

        [Test]
        public void BddObjectsHaveChangedWithPreviousBDDComponentsWithOneComponentAndCurrentBDDObjectsArrayWithTheSameOneComponent()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            Component[] currentComponents = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersRebuildUTDynamicBDDForTest>() };
            runnerBusinessLogicData.BDDObjects = new object[1] { currentComponents[0] };
            ComponentsFilter bddComponentsFilter = Substitute.For<ComponentsFilter>();
            Component[] bddComponentsFilterResult = new Component[1] { currentComponents[0] };
            bddComponentsFilter.Filter(currentComponents).Returns<Component[]>(bddComponentsFilterResult);

            bool result = runnerEditorBusinessLogicParametersRebuild.BddObjectsHaveChanged(currentComponents, runnerBusinessLogicData, bddComponentsFilter);
            Assert.IsFalse(result, "The method BddObjectsHaveChanged doesn't return the right state");
        }

        [Test]
        public void BddObjectsHaveChangedWithPreviousBDDComponentsWithOneComponentAndCurrentBDDObjectsArrayWithoutComponents()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = new Component[1] { UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersRebuildUTDynamicBDDForTest>() };
            Component[] currentComponents = new Component[0];
            ComponentsFilter bddComponentsFilter = Substitute.For<ComponentsFilter>();
            Component[] bddComponentsFilterResult = new Component[0];
            bddComponentsFilter.Filter(currentComponents).Returns<Component[]>(bddComponentsFilterResult);

            bool result = runnerEditorBusinessLogicParametersRebuild.BddObjectsHaveChanged(currentComponents, runnerBusinessLogicData, bddComponentsFilter);
            Assert.IsTrue(result, "The method BddObjectsHaveChanged doesn't return the right state");
        }

        [Test]
        public void IsParametersRebuildNeededWithNoBDDObjectsAndEditorIsCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = true;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenatio = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        public void IsParametersRebuildNeededWithNoBDDObjectsAndEditorCompilingIsJustFinished()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = true;
            bool rebuild = false;
            bool isDynamicScenatio = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        public void IsParametersRebuildNeededWithNoBDDObjectsAndEditorCompilingIsNotJustFinished()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenatio = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        public void IsParametersRebuildNeededWithBDDObjectsAndEditorCompilingIsNotJustFinishedAndBDDObjectsNotChangedAndApplicationIsNotCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenatio = true;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        public void IsParametersRebuildNeededWithBDDObjectsAndEditorCompilingIsNotJustFinishedAndBDDObjectsAreChangedAndApplicationIsNotCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = true;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenatio = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        public void IsParametersRebuildNeededWithBDDObjectsAndEditorCompilingIsNotJustFinishedAndBDDObjectsAreChangedAndApplicationIsCompiling()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = true;
            bool isEditorApplicationCompiling = true;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenatio = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenatio);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }
    }
}
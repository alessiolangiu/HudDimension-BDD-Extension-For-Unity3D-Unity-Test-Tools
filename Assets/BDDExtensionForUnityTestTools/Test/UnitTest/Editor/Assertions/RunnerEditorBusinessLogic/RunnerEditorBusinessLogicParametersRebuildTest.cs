//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicParametersRebuildTest.cs" company="Hud Dimension">
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
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class RunnerEditorBusinessLogicParametersRebuildTest
    {
        [TearDown]
        public void Cleanup()
        {
            UnitTestUtility.DestroyTemporaryTestGameObjects();
        }

        [Test]
        [Description("IsBDDObjectsNull method should return true given a null BDDObjects array")]
        public void IsBDDObjectsNull_Should_ReturnTrue_Given_ANullBDDObjectsArray()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = null;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsTrue(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        [Description("IsBDDObjectsNull method should return false given an empty BDDObjects array")]
        public void IsBDDObjectsNull_Should_ReturnFalse_Given_AnEmptyBDDObjectsArray()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = new object[0];
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        [Description("IsBDDObjectsNull method should return false given a non empty BDDObjects array")]
        public void IsBDDObjectsNull_Should_ReturnFalse_Given_ANonEmptyBDDObjectsArray()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();
            runnerBusinessLogicData.BDDObjects = new object[1];
            bool result = runnerEditorBusinessLogicParametersRebuild.IsBDDObjectsNull(runnerBusinessLogicData);
            Assert.IsFalse(result, "The method IsBDDObjectsNull doesn't return the right state of the BDDObjects");
        }

        [Test]
        [Description("IsEditorApplicationCompilingJustFinished method should return false and set the value of IsCompiling property to false given the state of IsCompiling property is false and the state of the EditorApplication.IsCompiling property is false")]
        public void IsEditorApplicationCompilingJustFinished_Should_ReturnFalseAndSetTheValueOfIsCompilingPropertyToFalse_Given_TheStateOfIsCompilingPropertyIsFalseAndTheStateOfTHeEditorApplicationIsCompilingPropertyIsFalse()
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
        [Description("IsEditorApplicationCompilingJustFinished method should return true and set the value of IsCompiling property to false given the state of IsCompiling property is true and the state of the EditorApplication.IsCompiling property is false")]
        public void IsEditorApplicationCompilingJustFinished_Should_ReturnTrueAndSetTheValueOfIsCompilingPropertyToFalse_Given_TheStateOfIsCompilingPropertyIsTrueAndTheStateOfTheEditorApplicationIsCompilingPropertyIsFalse()
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
        [Description("IsEditorApplicationCompilingJustFinished method should return false and set the value of IsCompiling property to true given the state of IsCompiling property is false and the state of the EditorApplication.IsCompiling property is true")]
        public void IsEditorApplicationCompilingJustFinished_Should_ReturnFalseAndSetTheValueOfIsCompilingPropertyToTrue_Given_TheStateOfIsCompilingPropertyIsFalseAndTheStateOfTheEditorApplicationIsCompilingPropertyIsTrue()
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
        [Description("IsEditorApplicationCompilingJustFinished method should return false and set the value of IsCompiling property to true given the state of IsCompiling property is true and the state of the EditorApplication.IsCompiling property is true")]
        public void IsEditorApplicationCompilingJustFinished_Should_ReturnFalseAndSetTheValueOfIsCompilingPropertyToTrue_Given_TheStateOfIsCompilingPropertyIsTrueAndTheStateOfTheEditorApplicationIsCompilingPropertyIsTrue()
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
        [Description("BddObjectsHaveChanged method should return false given the BDDObjects array is null and the currentComponents array is empty")]
        public void BddObjectsHaveChanged_Should_ReturnFalse_GivenTheBDDObjectsArrayIsNullAndTheCurrentComponentsArrayIsEmpty()
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
        [Description("BddObjectsHaveChanged method should return true given the BDDObjects array is null and the currentComponents array is not empty")]
        public void BddObjectsHaveChanged_Should_ReturnTrue_GivenTheBDDObjectsArrayIsNullAndTheCurrentComponentsArrayIsNotEmpty()
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
        [Description("BddObjectsHaveChanged method should return false given the BDDObjects array is not empty and the currentComponents array has the same elements of the BDDObjects Array")]
        public void BddObjectsHaveChanged_Should_ReturnFalse_GivenTheBDDObjectsArrayIsNotEmptyAndTheCurrentComponentsArrayHasTheSameElementsOfTheBDDObjectsArray()
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
        [Description("BddObjectsHaveChanged method should return true given the BDDObjects array is not empty and the currentComponents array is empty")]
        public void BddObjectsHaveChanged_Should_ReturnFalse_GivenTheBDDObjectsArrayIsNotEmptyAndTheCurrentComponentsArrayIsEmpty()
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
        [Description("IsParametersRebuildNeeded method should return false given the BDDObjects is null and BDDObjects did not changed and EditorApplicationIsCompiling is true and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnFalse_Given_TheBDDObjectsIsNullAndBDDObjectsDidNotChangedAndEditorApplicationIsCompilingIsTrueAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = true;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenario = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        [Description("IsParametersRebuildNeeded method should return true given the BDDObjects is null and BDDObjects did not changed and EditorApplicationIsCompiling is false and CompilingIsJustFinished and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnTrue_Given_TheBDDObjectsIsNullAndBDDObjectsDidNotChangedAndEditorApplicationIsCompilingIsFalseAndCompilingIsJustFinishedAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = true;
            bool rebuild = false;
            bool isDynamicScenario = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        [Description("IsParametersRebuildNeeded method should return true given the BDDObjects is null and BDDObjects did not changed and EditorApplicationIsCompiling is false and CompilingJustFinished is false and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnTrue_Given_TheBDDObjectsIsNullAndBDDObjectsDidNotChangedAndEditorApplicationIsCompilingIsFalseAndCompilingJustFinishedIsFalseAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = true;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenario = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        [Description("IsParametersRebuildNeeded method should return false given the BDDObjects is not null and BDDObjects did not changed and EditorApplicationIsCompiling is false and CompilingJustFinished is false and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnFalse_Given_TheBDDObjectsIsNullAndBDDObjectsDidNotChangedAndEditorApplicationIsCompilingIsFalseAndCompilingJustFinishedIsFalseAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = false;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenario = true;
            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        [Description("IsParametersRebuildNeeded method should return true given the BDDObjects is not null and BDDObjects are changed and EditorApplicationIsCompiling is false and CompilingJustFinished is false and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnTrue_Given_TheBDDObjectsIsNotNullAndBDDObjectsAreChangedAndEditorApplicationIsCompilingIsFalseAndCompilingJustFinishedIsFalseAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = true;
            bool isEditorApplicationCompiling = false;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenario = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsTrue(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }

        [Test]
        [Description("IsParametersRebuildNeeded method should return False given the BDDObjects is not null and BDDObjects are changed and EditorApplicationIsCompiling is true and CompilingJustFinished is false and it is a Dynamic scenario")]
        public void IsParametersRebuildNeeded_Should_ReturnFalse_Given_TheBDDObjectsIsNotNullAndBDDObjectsAreChangedAndEditorApplicationIsCompilingIsTrueAndCompilingJustFinishedIsFalseAndItIsADynamicScenario()
        {
            RunnerEditorBusinessLogicParametersRebuild runnerEditorBusinessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();
            bool isBDDObjectsNull = false;
            bool bddObjectsHaveChanged = true;
            bool isEditorApplicationCompiling = true;
            bool isEditorApplicationCompilingJustFinished = false;
            bool rebuild = false;
            bool isDynamicScenario = true;

            bool result = runnerEditorBusinessLogicParametersRebuild.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, isEditorApplicationCompiling, isEditorApplicationCompilingJustFinished, rebuild, isDynamicScenario);

            Assert.IsFalse(result, "The method IsParametersRebuildNeeded returns the wrong rebuild state");
        }
    }
}
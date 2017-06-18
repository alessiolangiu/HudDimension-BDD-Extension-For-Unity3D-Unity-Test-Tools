using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [CustomEditor(typeof(BDDExtensionRunner), true)]
    public class BDDExtensionRunnerEditor : Editor
    {
        private RunnerEditorBusinessLogicData runnerBusinessLogicData = new RunnerEditorBusinessLogicData();

        private IUnityInterfaceWrapper unityIntefaceWrapper = new UnityInterfaceWrapper();

        private RunnerEditorBusinessLogicParametersRebuild businessLogicParametersRebuild = new RunnerEditorBusinessLogicParametersRebuild();

        private RunnerEditorBusinessLogicDynamicRows businessLogicDynamicRows = new RunnerEditorBusinessLogicDynamicRows();

        private RunnerEditorBusinessLogicStaticRows businessLogicStaticRows = new RunnerEditorBusinessLogicStaticRows();

        private bool dirtyStatus = false;

        public override void OnInspectorGUI()
        {
            BDDExtensionRunner script = (BDDExtensionRunner)target;
            serializedObject.Update();
            Component[] components = script.gameObject.GetComponents<Component>();
            List<UnityTestBDDError> errors = new List<UnityTestBDDError>();
            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] bddComponents = new Component[0];

            try
            {
                bddComponents = bddComponentsFilter.Filter(components);
                if (bddComponents.Length == 0)
                {
                    UnityTestBDDError error = new UnityTestBDDError();
                    error.Message = "Please, add your BDD Components and enjoy BDD.";
                    error.MethodMethodInfo = null;
                    error.Component = null;
                    error.LockRunnerInpectorOnErrors = true;
                    error.ShowButton = false;
                    error.ShowRedEsclamationMark = false;
                    errors.Add(error);
                }
            }
            catch (DuplicateBDDComponentException ex)
            {
                UnityTestBDDError error = new UnityTestBDDError();
                error.Message = ex.Message;
                error.MethodMethodInfo = null;
                error.Component = null;
                error.LockRunnerInpectorOnErrors = true;
                error.ShowButton = false;
                errors.Add(error);
            }
            catch (StaticBDDException ex)
            {
                UnityTestBDDError error = new UnityTestBDDError();
                error.Message = ex.Message;
                error.MethodMethodInfo = null;
                error.Component = null;
                error.LockRunnerInpectorOnErrors = true;
                error.ShowButton = false;
                errors.Add(error);
            }

            if (!this.RunnerInspectorIsLockedOnErrors(errors) && bddComponents.Length > 0)
            {
                foreach (Component component in bddComponents)
                {
                    if (((BaseBDDComponent)component).Errors.Count > 0)
                    {
                        UnityTestBDDError error = new UnityTestBDDError();
                        error.Message = "There are some errors in the BDDComponents. Please, check and resolve them before continue.";
                        error.MethodMethodInfo = null;
                        error.Component = null;
                        error.LockRunnerInpectorOnErrors = true;
                        error.ShowButton = false;
                        errors.Add(error);
                        break;
                    }
                }
            }

            if (!this.RunnerInspectorIsLockedOnErrors(errors) && !this.IsStaticScenario(components))
            {
                ChosenMethodsChecker checkForErrors = new ChosenMethodsChecker();
                errors = checkForErrors.Check(script.Given, script.GivenParametersIndex, script.When, script.WhenParametersIndex, script.Then, script.ThenParametersIndex, bddComponents);
            }

            RunnerEditorBusinessLogicErrorsManagement runnerEditorBusinessLogicErrorsManagement = new RunnerEditorBusinessLogicErrorsManagement();
            runnerEditorBusinessLogicErrorsManagement.Errors(errors, this.unityIntefaceWrapper);

            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            bool isStaticScenario = methodsManagementUtilities.IsStaticBDDScenario(bddComponents);
            if (!this.RunnerInspectorIsLockedOnErrors(errors))
            {
                this.DrawOptions(this.runnerBusinessLogicData, isStaticScenario, script, this.unityIntefaceWrapper, bddComponents);

                if (!isStaticScenario)
                {
                    if (!this.BuildParametersIsLocked(errors))
                    {
                        bool isParametersRebuildNeeded = this.businessLogicParametersRebuild.IsParametersRebuildNeeded(this.unityIntefaceWrapper, this.runnerBusinessLogicData, bddComponents, bddComponentsFilter);
                        if (isParametersRebuildNeeded)
                        {
                            this.RebuildParameters(script, bddComponents, this.runnerBusinessLogicData);
                            this.runnerBusinessLogicData.BDDObjects = bddComponents;
                            this.runnerBusinessLogicData.SerializedObjects = this.businessLogicParametersRebuild.RebuildSerializedObjectsList(bddComponents, this.runnerBusinessLogicData.SerializedObjects);
                        }
                    }
                }

                if (Event.current.type == EventType.Layout || this.dirtyStatus == false)
                {
                    this.dirtyStatus = false;
                    if (this.runnerBusinessLogicData.SerializedObjects != null)
                    {
                        foreach (ISerializedObjectWrapper so in this.runnerBusinessLogicData.SerializedObjects.Values)
                        {
                            so.Update();
                        }
                    }

                    if (methodsManagementUtilities.IsStaticBDDScenario(bddComponents))
                    {
                        this.BuildStaticScenario(bddComponents);
                    }
                    else
                    {
                        this.BuildDynamicScenario(script, bddComponents, this.LockParametersRows(errors), out this.dirtyStatus);
                    }

                    serializedObject.ApplyModifiedProperties();
                    if (this.runnerBusinessLogicData.SerializedObjects != null)
                    {
                        foreach (ISerializedObjectWrapper so in this.runnerBusinessLogicData.SerializedObjects.Values)
                        {
                            so.ApplyModifiedProperties();
                        }
                    }
                }
                else
                {
                    this.unityIntefaceWrapper.EditorUtilitySetDirty(script);
                }
            }
        }

        private void DrawOptions(RunnerEditorBusinessLogicData businessLogicData, bool isStaticScenario, BDDExtensionRunner script, IUnityInterfaceWrapper unityInterface, Component[] bddComponents)
        {
            Rect rect = unityInterface.EditorGUILayoutGetControlRect();
            businessLogicData.OptionsFoldout = unityInterface.EditorGUIFoldout(rect, businessLogicData.OptionsFoldout, "Options");
            if (businessLogicData.OptionsFoldout)
            {
                if (!isStaticScenario)
                {
                    this.ForceRebuildParametersButton(script, bddComponents);
                }

                unityInterface.EditorGUILayoutSeparator();
                this.ChooseBetweenUpdateAndFixedUpdate(script, this.unityIntefaceWrapper);
                float width = unityInterface.EditorGUIUtilityCurrentViewWidth();
                int numberOfSeparatorChars = (int)width / 7;
                string text = string.Empty.PadLeft(numberOfSeparatorChars, '_');
                
                unityInterface.EditorGUILayoutLabelFieldTruncate(text, width);
            }
        }

        private void ChooseBetweenUpdateAndFixedUpdate(BDDExtensionRunner script, IUnityInterfaceWrapper unityInterface)
        {
            GUIContent label = unityInterface.GUIContent("Run under Fixed Update");
            script.UseFixedUpdate = GUILayout.Toggle(script.UseFixedUpdate, label, GUILayout.ExpandWidth(false));
        }

        private bool LockParametersRows(List<UnityTestBDDError> errors)
        {
            foreach (UnityTestBDDError error in errors)
            {
                if (error.LockParametersRows)
                {
                    return true;
                }
            }

            return false;
        }

        private void ForceRebuildParametersButton(BDDExtensionRunner script, Component[] components)
        {
            if (GUILayout.Button("Rebuild settings.", EditorStyles.miniButton, GUILayout.Width(100)))
            {
                GenericMenu menu = new GenericMenu();
                GUIContent optionNotRebuild = new GUIContent("I am not sure. I will try to fix the errors instead.");
                GUIContent optionRebuild = new GUIContent("Rebuild! Every parameter with errors could be resetted and the values could be lost.");
                bool on = false;
                menu.AddItem(
                    optionNotRebuild,
                    on,
                    () =>
                    {
                    });

                menu.AddItem(
                    optionRebuild,
                    on,
                    () =>
                    {
                        this.RebuildParameters(script, components, runnerBusinessLogicData);
                        runnerBusinessLogicData.BDDObjects = components;
                        runnerBusinessLogicData.SerializedObjects = businessLogicParametersRebuild.RebuildSerializedObjectsList(components, runnerBusinessLogicData.SerializedObjects);
                    });

                menu.ShowAsContext();
            }
        }

        private bool BuildParametersIsLocked(List<UnityTestBDDError> errors)
        {
            foreach (UnityTestBDDError error in errors)
            {
                if (error.LockBuildParameters)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsStaticScenario(Component[] components)
        {
            if (components == null)
            {
                return false;
            }

            foreach (Component component in components)
            {
                if (typeof(StaticBDDComponent).IsAssignableFrom(component.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        private bool RunnerInspectorIsLockedOnErrors(List<UnityTestBDDError> errors)
        {
            foreach (UnityTestBDDError error in errors)
            {
                if (error.LockRunnerInpectorOnErrors)
                {
                    return true;
                }
            }

            return false;
        }

        private void RebuildParameters(BDDExtensionRunner script, Component[] dynamicBDDComponents, RunnerEditorBusinessLogicData runnerBusinessLogicData)
        {
            // Generate the three list of MethodDescription for each step type: Given, When, Then
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();

            BaseMethodDescriptionBuilder methodBuilder = new BaseMethodDescriptionBuilder();
            IMethodsFilter givenMethodFilter = new MethodsFilterByMethodsFullNameList(script.Given);
            MethodsLoader givenMethodsLoader = new MethodsLoader(methodBuilder, givenMethodFilter);

            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            MethodParametersLoader methodsParametersLoader = new MethodParametersLoader();

            List<MethodDescription> givenMethodsDescriptionList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<GivenBaseAttribute>(dynamicBDDComponents, givenMethodsLoader, methodDescriptionBuilder, methodsParametersLoader, script.Given, script.GivenParametersIndex);

            List<FullMethodDescription> givenFullMethodsDescriptionList = methodsManagementUtilities.LoadFullMethodsDescriptions<GivenBaseAttribute>(givenMethodsDescriptionList, fullMethodDescriptionBuilder);

            IMethodsFilter whenMethodFilter = new MethodsFilterByMethodsFullNameList(script.When);
            MethodsLoader whenMethodsLoader = new MethodsLoader(methodBuilder, whenMethodFilter);
            List<MethodDescription> whenMethodsDescriptionList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(dynamicBDDComponents, whenMethodsLoader, methodDescriptionBuilder, methodsParametersLoader, script.When, script.WhenParametersIndex);

            List<FullMethodDescription> whenFullMethodsDescriptionList = methodsManagementUtilities.LoadFullMethodsDescriptions<WhenBaseAttribute>(whenMethodsDescriptionList, fullMethodDescriptionBuilder);

            IMethodsFilter thenMethodFilter = new MethodsFilterByMethodsFullNameList(script.Then);
            MethodsLoader thenMethodsLoader = new MethodsLoader(methodBuilder, thenMethodFilter);
            List<MethodDescription> thenMethodsDescriptionList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<ThenBaseAttribute>(dynamicBDDComponents, thenMethodsLoader, methodDescriptionBuilder, methodsParametersLoader, script.Then, script.ThenParametersIndex);

            List<FullMethodDescription> thenFullMethodsDescriptionList = methodsManagementUtilities.LoadFullMethodsDescriptions<ThenBaseAttribute>(thenMethodsDescriptionList, fullMethodDescriptionBuilder);

            // Reset the valuesArrayStorages for each component
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            arrayStorageUtilities.ResetAllArrayStorage(dynamicBDDComponents);

            // Rebuild the parameters indexes and locations for each list of MethodDescription
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            parametersLocationsBuilder.BuildParametersLocation(givenFullMethodsDescriptionList);
            parametersLocationsBuilder.BuildParametersLocation(whenFullMethodsDescriptionList);
            parametersLocationsBuilder.BuildParametersLocation(thenFullMethodsDescriptionList);

            // Rebuild the parameters Indexes arrays
            script.GivenParametersIndex = parametersLocationsBuilder.RebuildParametersIndexesArrays(givenFullMethodsDescriptionList, script.Given);
            script.WhenParametersIndex = parametersLocationsBuilder.RebuildParametersIndexesArrays(whenFullMethodsDescriptionList, script.When);
            script.ThenParametersIndex = parametersLocationsBuilder.RebuildParametersIndexesArrays(thenFullMethodsDescriptionList, script.Then);
        }

        private void BuildStaticScenario(Component[] bddComponents)
        {
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByExecutionOrder methodsFilterByExecutionOrder = new MethodsFilterByExecutionOrder();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByExecutionOrder);

            this.businessLogicStaticRows.DrawStaticRows<GivenBaseAttribute>(this.unityIntefaceWrapper, bddStepMethodsLoader, bddComponents, RunnerEditorBusinessLogicData.LabelWidthAbsolute, RunnerEditorBusinessLogicData.ButtonsWidthAbsolute);
            this.businessLogicStaticRows.DrawStaticRows<WhenBaseAttribute>(this.unityIntefaceWrapper, bddStepMethodsLoader, bddComponents, RunnerEditorBusinessLogicData.LabelWidthAbsolute, RunnerEditorBusinessLogicData.ButtonsWidthAbsolute);
            this.businessLogicStaticRows.DrawStaticRows<ThenBaseAttribute>(this.unityIntefaceWrapper, bddStepMethodsLoader, bddComponents, RunnerEditorBusinessLogicData.LabelWidthAbsolute, RunnerEditorBusinessLogicData.ButtonsWidthAbsolute);
        }

        private void BuildDynamicScenario(BDDExtensionRunner script, Component[] bddComponents, bool lockParametersRows, out bool dirtyStatus)
        {
            bool givenDirtyStatus = false;
            bool whenDirtyStatus = false;
            bool thenDirtyStatus = false;

            MethodParametersLoader parametersLoader = new MethodParametersLoader();
            RunnerEditorBusinessLogicMethodsUtilities methodsUtilities = new RunnerEditorBusinessLogicMethodsUtilities();
            RunnerEditorBusinessLogicDynamicRowsElements dynamicRowsElements = new RunnerEditorBusinessLogicDynamicRowsElements();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            IMethodsFilter methodFilter = new MethodsFilterByStepType();
            MethodsLoader methodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodFilter);

            ChosenMethods chosenMethods = new ChosenMethods();

            chosenMethods.ChosenMethodsNames = script.Given;
            chosenMethods.ChosenMethodsParametersIndex = script.GivenParametersIndex;

            this.runnerBusinessLogicData.Rebuild = this.businessLogicDynamicRows.DrawDynamicRows<GivenBaseAttribute>(this.unityIntefaceWrapper, methodsLoader, methodDescriptionBuilder, parametersLoader, bddComponents, chosenMethods, this.runnerBusinessLogicData.GivenFoldouts, this.runnerBusinessLogicData.SerializedObjects, script, methodsUtilities, dynamicRowsElements, lockParametersRows, this.runnerBusinessLogicData.Rebuild, out chosenMethods, out this.runnerBusinessLogicData.GivenFoldouts, out givenDirtyStatus);

            script.Given = chosenMethods.ChosenMethodsNames;
            script.GivenParametersIndex = chosenMethods.ChosenMethodsParametersIndex;

            chosenMethods.ChosenMethodsNames = script.When;
            chosenMethods.ChosenMethodsParametersIndex = script.WhenParametersIndex;

            this.runnerBusinessLogicData.Rebuild = this.businessLogicDynamicRows.DrawDynamicRows<WhenBaseAttribute>(this.unityIntefaceWrapper, methodsLoader, methodDescriptionBuilder, parametersLoader, bddComponents, chosenMethods, this.runnerBusinessLogicData.WhenFoldouts, this.runnerBusinessLogicData.SerializedObjects, script, methodsUtilities, dynamicRowsElements, lockParametersRows, this.runnerBusinessLogicData.Rebuild, out chosenMethods, out this.runnerBusinessLogicData.WhenFoldouts, out whenDirtyStatus);

            script.When = chosenMethods.ChosenMethodsNames;
            script.WhenParametersIndex = chosenMethods.ChosenMethodsParametersIndex;

            chosenMethods.ChosenMethodsNames = script.Then;
            chosenMethods.ChosenMethodsParametersIndex = script.ThenParametersIndex;
            this.runnerBusinessLogicData.Rebuild = this.businessLogicDynamicRows.DrawDynamicRows<ThenBaseAttribute>(this.unityIntefaceWrapper, methodsLoader, methodDescriptionBuilder, parametersLoader, bddComponents, chosenMethods, this.runnerBusinessLogicData.ThenFoldouts, this.runnerBusinessLogicData.SerializedObjects, script, methodsUtilities, dynamicRowsElements, lockParametersRows, this.runnerBusinessLogicData.Rebuild, out chosenMethods, out this.runnerBusinessLogicData.ThenFoldouts, out thenDirtyStatus);

            script.Then = chosenMethods.ChosenMethodsNames;
            script.ThenParametersIndex = chosenMethods.ChosenMethodsParametersIndex;

            dirtyStatus = givenDirtyStatus || whenDirtyStatus || thenDirtyStatus;
        }
    }
}
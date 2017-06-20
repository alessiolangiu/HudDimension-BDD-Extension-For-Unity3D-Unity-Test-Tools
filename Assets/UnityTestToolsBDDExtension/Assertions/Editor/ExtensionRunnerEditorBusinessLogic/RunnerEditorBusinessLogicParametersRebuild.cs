//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicParametersRebuild.cs" company="Hud Dimension">
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
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class RunnerEditorBusinessLogicParametersRebuild
    {
        public bool IsParametersRebuildNeeded(IUnityInterfaceWrapper unityInterfaceWrapper, RunnerEditorBusinessLogicData runnerBusinessLogicData, Component[] components, ComponentsFilter bddComponentsFilter)
        {
            bool isBDDObjectsNull = this.IsBDDObjectsNull(runnerBusinessLogicData);
            bool bddObjectsHaveChanged = this.BddObjectsHaveChanged(components, runnerBusinessLogicData, bddComponentsFilter);
            bool isEditorApplicationCompilingJustFinished = this.IsEditorApplicationCompilingJustFinished(unityInterfaceWrapper, runnerBusinessLogicData);
            bool isDynamicScenario = this.IsDynamicScenario(components);
            return this.IsParametersRebuildNeeded(isBDDObjectsNull, bddObjectsHaveChanged, runnerBusinessLogicData.IsCompiling, isEditorApplicationCompilingJustFinished, runnerBusinessLogicData.Rebuild, isDynamicScenario);
        }

        public bool IsParametersRebuildNeeded(bool isBDDObjectsNull, bool bddObjectsHaveChanged, bool isEditorApplicationCompiling, bool isEditorApplicationCompilingJustFinished, bool rebuild, bool isDynamicScenario)
        {
            if (isEditorApplicationCompiling || !isDynamicScenario)
            {
                // While compiling the state of the BDDComponents could be inconsistent
                return false;
            }
            else
            {
                return isBDDObjectsNull || bddObjectsHaveChanged || isEditorApplicationCompilingJustFinished || rebuild;
            }
        }

        public bool IsBDDObjectsNull(RunnerEditorBusinessLogicData runnerBusinessLogicData)
        {
            bool result = false;
            if (runnerBusinessLogicData.BDDObjects == null)
            {
                result = true;
            }

            return result;
        }

        public bool IsEditorApplicationCompilingJustFinished(IUnityInterfaceWrapper unityInterfaceWrapper, RunnerEditorBusinessLogicData runnerBusinessLogicData)
        {
            bool result = false;
            if (!unityInterfaceWrapper.EditorApplicationIsCompiling())
            {
                if (runnerBusinessLogicData.IsCompiling)
                {
                    result = true;
                    runnerBusinessLogicData.IsCompiling = false;
                }
            }
            else
            {
                runnerBusinessLogicData.IsCompiling = true;
                result = false;
            }

            return result;
        }

        public bool BddObjectsHaveChanged(Component[] components, RunnerEditorBusinessLogicData runnerBusinessLogicData, ComponentsFilter bddComponentsFilter)
        {
            bool result = false;
            object[] newBddObjects = bddComponentsFilter.Filter(components);
            object[] previuousBDDObjects = null;
            if (runnerBusinessLogicData.BDDObjects == null)
            {
                previuousBDDObjects = new object[0];
            }
            else
            {
                previuousBDDObjects = runnerBusinessLogicData.BDDObjects;
            }

            // Checking for some new BDD Object.
            foreach (object mainObj in newBddObjects)
            {
                bool found = false;
                foreach (object obj in previuousBDDObjects)
                {
                    if (obj.Equals(mainObj))
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    result = true;
                }
            }

            // Checking for some BDD Object removed
            foreach (object mainObj in previuousBDDObjects)
            {
                bool found = false;
                foreach (object obj in newBddObjects)
                {
                    if (obj.Equals(mainObj))
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    result = true;
                }
            }

            return result;
        }

        public Dictionary<Type, ISerializedObjectWrapper> RebuildSerializedObjectsList(Component[] components, Dictionary<Type, ISerializedObjectWrapper> serializedObjects)
        {
            Dictionary<Type, ISerializedObjectWrapper> result = new Dictionary<Type, ISerializedObjectWrapper>();
            foreach (Component component in components)
            {
                ISerializedObjectWrapper serializedObjectWrapper = null;
                if (serializedObjects == null || !serializedObjects.ContainsKey(component.GetType()))
                {
                    serializedObjectWrapper = new SerializedObjectWrapper(component);
                }
                else
                {
                    serializedObjects.TryGetValue(component.GetType(), out serializedObjectWrapper);
                }

                result.Add(component.GetType(), serializedObjectWrapper);
            }

            return result;
        }

        private bool IsDynamicScenario(Component[] components)
        {
            bool result = true;
            foreach (Component component in components)
            {
                if (typeof(StaticBDDComponent).IsAssignableFrom(component.GetType()))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="SerializedObjectWrapper.cs" company="Hud Dimension">
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
using UnityEditor;

namespace HudDimension.UnityTestBDD
{
    public class SerializedObjectWrapper : ISerializedObjectWrapper
    {
        private SerializedObject serializedObject;

        public SerializedObjectWrapper(UnityEngine.Object component)
        {
            this.serializedObject = new SerializedObject(component);
        }

        public void ApplyModifiedProperties()
        {
            this.serializedObject.ApplyModifiedProperties();
        }

        public ISerializedPropertyWrapper FindProperty(string parameterLocationString)
        {
            SerializedProperty property = this.serializedObject.FindProperty(parameterLocationString);
            ISerializedPropertyWrapper propertyWrapper = new SerializedPropertyWrapper(property);
            return propertyWrapper;
        }

        public SerializedObject GetSerializedObject()
        {
            return this.serializedObject;
        }

        public void Update()
        {
            this.serializedObject.Update();
        }
    }
}

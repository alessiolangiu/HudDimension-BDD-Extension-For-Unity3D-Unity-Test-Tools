//-----------------------------------------------------------------------
// <copyright file="DynamicBDDComponent.cs" company="Hud Dimension">
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
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class DynamicBDDComponent : BaseBDDComponent
    {
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected bool[] boolPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected byte[] bytePVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected sbyte[] sbytePVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected char[] charPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected decimal[] decimalPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected double[] doublePVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected float[] floatPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected int[] intPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected uint[] uintPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected long[] longPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected ulong[] ulongPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected short[] shortPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected ushort[] ushortPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected string[] stringPVS;

        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Vector2[] vector2PVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Vector3[] vector3PVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Vector4[] vector4PVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Rect[] rectPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Quaternion[] quaternionPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Matrix4x4[] matrix4x4PVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Color[] colorPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Color32[] color32PVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected LayerMask[] layerMaskPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected AnimationCurve[] animationCurvePVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Gradient[] gradientPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected RectOffset[] rectOffsetPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected GUIStyle[] guiStylePVS;

        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected GameObject[] gameObjectPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Transform[] transformPVS;
        [HideInInspector]
        [ParametersValuesStorage]
        [SerializeField]
        protected Component[] componentPVS;

        [AttributeUsage(System.AttributeTargets.Method)]
        public class Given : GivenBaseAttribute
        {
            public Given(string text) : base(text)
            {
            }
        }

        [AttributeUsage(System.AttributeTargets.Method)]
        public class When : WhenBaseAttribute
        {
            public When(string text) : base(text)
            {
            }
        }

        [AttributeUsage(System.AttributeTargets.Method)]
        public class Then : ThenBaseAttribute
        {
            public Then(string text) : base(text)
            {
            }
        }
    }
}

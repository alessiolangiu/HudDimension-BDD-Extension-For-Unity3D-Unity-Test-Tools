//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicData.cs" company="Hud Dimension">
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
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.UnityTestBDD
{
    public class RunnerEditorBusinessLogicData
    {
        public static readonly float LabelWidthAbsolute = 52;

        public static readonly float ButtonsWidthAbsolute = 60;

        public static readonly float TextWidthPercent = 0.40f;

        public bool IsCompiling;

        public object[] BDDObjects;

        public Dictionary<Type, ISerializedObjectWrapper> SerializedObjects;

        internal bool Rebuild;

        internal bool[] GivenFoldouts = new bool[50];
        internal bool[] WhenFoldouts = new bool[50];
        internal bool[] ThenFoldouts = new bool[50];
        internal bool OptionsFoldout = false;
    }
}
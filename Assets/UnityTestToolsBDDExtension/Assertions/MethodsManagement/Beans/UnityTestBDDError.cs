//-----------------------------------------------------------------------
// <copyright file="UnityTestBDDError.cs" company="Hud Dimesion">
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
using System.Reflection;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class UnityTestBDDError
    {
        public string Message { get; set; }

        public Component Component { get; set; }

        public MethodInfo MethodMethodInfo { get; set; }

        public Type StepType { get; set; }

        public int Index { get; set; }

        public bool ShowRedEsclamationMark { get; set; }

        public bool ShowButton { get; set; }

        public bool LockRunnerInpectorOnErrors { get; set; }

        public bool LockBuildParameters { get; set; }

        public bool LockParametersRows { get; set; }
    }
}

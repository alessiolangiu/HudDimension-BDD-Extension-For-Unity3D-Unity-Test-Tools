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

//-----------------------------------------------------------------------
// <copyright file="BaseMethodDescription.cs" company="Hud Dimesion">
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
    public class BaseMethodDescription
    {
        public Component ComponentObject { get; set; }

        public MethodInfo Method { get; set; }

        public string Text { get; set; }

        public Type StepType { get; set; }

        public uint ExecutionOrder { get; set; }

        public static string GetFullName(Type type, MethodInfo method)
        {
            return type.Name + "." + GetSignature(method);
        }

        public override string ToString()
        {
            return GetFullName();
        }

        public virtual string GetFullName()
        {
            return GetFullName(this.ComponentObject.GetType(), this.Method);
        }

        public override int GetHashCode()
        {
            int result =
                 (this.ComponentObject == null ? 0 : this.ComponentObject.GetHashCode())
                 +
                 (this.Method == null ? 0 : this.Method.GetHashCode())
                 +
                 (this.StepType == null ? 0 : this.StepType.GetHashCode())
                 +
                 (this.Text == null ? 0 : this.Text.GetHashCode())
                 +
                 this.ExecutionOrder.GetHashCode();

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BaseMethodDescription method = (BaseMethodDescription)obj;
            if (((this.ComponentObject == null && method.ComponentObject == null) || UnityEngine.Object.Equals(this.ComponentObject, method.ComponentObject))
                &&
                ((this.Method == null && method.Method == null) || this.Method.Equals(method.Method))
                &&
                ((this.StepType == null && method.StepType == null) || this.StepType.Equals(method.StepType))
                &&
                ((this.Text == null && method.Text == null) || this.Text.Equals(method.Text))
                 &&
                this.ExecutionOrder.Equals(method.ExecutionOrder))
            {
                return true;
            }

            return false;
        }

        public bool Equivalent(BaseMethodDescription method)
        {
            if (method == null)
            {
                return false;
            }

            if (((this.ComponentObject == null && method.ComponentObject == null) || UnityEngine.Object.Equals(this.ComponentObject, method.ComponentObject))
                &&
                ((this.Method == null && method.Method == null) || this.Method.Equals(method.Method))
                &&
                ((this.StepType == null && method.StepType == null) || this.StepType.Equals(method.StepType))
                &&
                this.ExecutionOrder.Equals(method.ExecutionOrder))
            {
                return true;
            }

            return false;
        }

        private static string GetSignature(MethodInfo method)
        {
            string result = string.Empty;
            string firstStep = method.ToString().Substring(method.ToString().IndexOf(' ') + 1);
            result = firstStep.Substring(0, firstStep.IndexOf('('));
            return result;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="FullMethodDescription.cs" company="Hud Dimesion">
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

namespace HudDimension.UnityTestBDD
{
    public class FullMethodDescription : MethodDescription, IComparable<FullMethodDescription>
    {
        private string id = string.Empty;

        public float Delay { get; set; }

        public float TimeOut { get; set; }

        public uint SuccessionOrder { get; set; }

        public FullMethodDescription MainMethod { get; set; }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
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
                 this.ExecutionOrder.GetHashCode()
                 +
                 (this.ParametersIndex == null ? 0 : this.ParametersIndex.GetHashCode())
                 +
                 (this.Parameters == null ? 0 : this.Parameters.GetHashCode())
                 +
                 this.Delay.GetHashCode()
                 +
                 this.TimeOut.GetHashCode()
                 +
                 this.SuccessionOrder.GetHashCode()
                 +
                 (this.MainMethod == null ? 0 : this.MainMethod.GetHashCode())
                 +
                 (this.Id == null ? 0 : this.Id.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            FullMethodDescription method = (FullMethodDescription)obj;
            if (((this.ComponentObject == null && method.ComponentObject == null) || object.Equals(this.ComponentObject, method.ComponentObject))
                &&
                ((this.Method == null && method.Method == null) || this.Method.Equals(method.Method))
                &&
                ((this.StepType == null && method.StepType == null) || this.StepType.Equals(method.StepType))
                &&
                ((this.Text == null && method.Text == null) || this.Text.Equals(method.Text))
                 &&
                this.ExecutionOrder.Equals(method.ExecutionOrder)
                &&
                ((this.ParametersIndex == null && method.ParametersIndex == null) || this.ParametersIndex.Equals(method.ParametersIndex))
                &&
                ((this.Parameters == null && method.Parameters == null) || this.Parameters.Equals(method.Parameters))
                &&
                this.Delay.Equals(method.Delay)
                &&
                this.TimeOut.Equals(method.TimeOut)
                &&
                this.SuccessionOrder.Equals(method.SuccessionOrder)
                &&
                ((this.MainMethod == null && method.MainMethod == null) || this.MainMethod.Equals(method.MainMethod))
                &&
                ((this.Id == null && method.Id == null) || this.Id.Equals(method.Id)))
            {
                return true;
            }

            return false;
        }

        public int CompareTo(FullMethodDescription other)
        {
            GerarchicOrder mainGerarchicOrder = this.GetGerarchicOrder();
            GerarchicOrder otherGerarchicOrder = other.GetGerarchicOrder();
            return mainGerarchicOrder.CompareTo(otherGerarchicOrder);
        }

        private GerarchicOrder GetGerarchicOrder()
        {
            GerarchicOrder result;
            GerarchicOrder gerarchicOrder = new GerarchicOrder(this.SuccessionOrder);
            if (this.MainMethod != null)
            {
                result = this.MainMethod.GetGerarchicOrder();
                result.AddAsLastElementGerarchicOrder(gerarchicOrder);
            }
            else
            {
                result = gerarchicOrder;
            }

            return result;
        }
    }
}

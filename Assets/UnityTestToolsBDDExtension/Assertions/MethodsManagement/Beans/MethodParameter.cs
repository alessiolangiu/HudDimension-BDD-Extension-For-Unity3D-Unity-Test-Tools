﻿using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodParameter
    {
        public ParameterInfo ParameterInfoObject { get; set; }

        public object Value { get; set; }

        public ParameterLocation ParameterLocation { get; set; }

        public override int GetHashCode()
        {
            int result =
                 (this.ParameterInfoObject == null ? 0 : this.ParameterInfoObject.GetHashCode())
                 +
                 (this.Value == null ? 0 : this.Value.GetHashCode())
                 +
                 (this.ParameterLocation == null ? 0 : this.ParameterLocation.GetHashCode());

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MethodParameter methodParameter = (MethodParameter)obj;
            if (((this.ParameterInfoObject == null && methodParameter.ParameterInfoObject == null) || object.Equals(this.ParameterInfoObject, methodParameter.ParameterInfoObject))
                &&
                ((this.Value == null && methodParameter.Value == null) || this.Value.Equals(methodParameter.Value))
                &&
                ((this.ParameterLocation == null && methodParameter.ParameterLocation == null) || this.ParameterLocation.Equals(methodParameter.ParameterLocation)))
            {
                return true;
            }

            return false;
        }
    }
}
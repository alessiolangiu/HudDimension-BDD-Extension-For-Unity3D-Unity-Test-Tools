//-----------------------------------------------------------------------
// <copyright file="ParameterLocation.cs" company="Hud Dimension">
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
using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class ParameterLocation
    {
        public ParameterLocation()
        {
            this.ParameterClassLocation = new ClassLocation();
            this.ParameterArrayLocation = new ArrayLocation();
        }

        public ClassLocation ParameterClassLocation { get; set; }

        public ArrayLocation ParameterArrayLocation { get; set; }

        public override int GetHashCode()
        {
            int result =
                 (this.ParameterClassLocation == null ? 0 : this.ParameterClassLocation.GetHashCode())
                 +
                 (this.ParameterArrayLocation == null ? 0 : this.ParameterArrayLocation.GetHashCode());

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ParameterLocation parameterLocation = (ParameterLocation)obj;
            if (((this.ParameterClassLocation == null && parameterLocation.ParameterClassLocation == null) || this.ParameterClassLocation.Equals(parameterLocation.ParameterClassLocation))
                &&
                ((this.ParameterArrayLocation == null && parameterLocation.ParameterArrayLocation == null) || this.ParameterArrayLocation.Equals(parameterLocation.ParameterArrayLocation)))
            {
                return true;
            }

            return false;
        }

        public class ClassLocation
        {
            public Type ComponentType { get; set; }

            public object ComponentObject { get; set; }

            public override int GetHashCode()
            {
                int result =
                     (this.ComponentType == null ? 0 : this.ComponentType.GetHashCode())
                     +
                     (this.ComponentObject == null ? 0 : this.ComponentObject.GetHashCode());

                return result;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                ClassLocation classLocation = (ClassLocation)obj;
                if (((this.ComponentType == null && classLocation.ComponentType == null) || object.Equals(this.ComponentType, classLocation.ComponentType))
                    &&
                    ((this.ComponentObject == null && classLocation.ComponentObject == null) || this.ComponentObject.Equals(classLocation.ComponentObject)))
                {
                    return true;
                }

                return false;
            }
        }

        public class ArrayLocation
        {
            public FieldInfo ArrayFieldInfo { get; set; }

            public string ArrayName { get; set; }

            public int ArrayIndex { get; set; }

            public override int GetHashCode()
            {
                int result =
                     this.ArrayFieldInfo == null ? 0 : this.ArrayFieldInfo.GetHashCode()
                     +
                     this.ArrayName == null ? 0 : this.ArrayName.GetHashCode()
                     +
                     this.ArrayIndex.GetHashCode();

                return result;
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                ArrayLocation arrayLocation = (ArrayLocation)obj;
                if (((this.ArrayFieldInfo == null && arrayLocation.ArrayFieldInfo == null) || this.ArrayFieldInfo.Equals(arrayLocation.ArrayFieldInfo))
                    &&
                    ((this.ArrayName == null && arrayLocation.ArrayName == null) || this.ArrayName.Equals(arrayLocation.ArrayName))
                    &&
                    this.ArrayIndex.Equals(arrayLocation.ArrayIndex))
                {
                    return true;
                }

                return false;
            }
        }
    }
}

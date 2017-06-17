//-----------------------------------------------------------------------
// <copyright file="ChosenMethods.cs" company="Hud Dimesion">
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
    public class ChosenMethods : ICloneable
    {
        private string[] chosenMethodsNames;

        private string[] chosenMethodsParametersIndex;

        public string[] ChosenMethodsNames
        {
            get
            {
                return this.chosenMethodsNames;
            }

            set
            {
                this.chosenMethodsNames = value;
            }
        }

        public string[] ChosenMethodsParametersIndex
        {
            get
            {
                return this.chosenMethodsParametersIndex;
            }

            set
            {
                this.chosenMethodsParametersIndex = value;
            }
        }

        public object Clone()
        {
            ChosenMethods newObject = new ChosenMethods();
            newObject.chosenMethodsNames = new string[this.chosenMethodsNames.Length];
            Array.Copy(this.chosenMethodsNames, newObject.chosenMethodsNames, this.chosenMethodsNames.Length);
            newObject.chosenMethodsParametersIndex = new string[this.chosenMethodsParametersIndex.Length];
            Array.Copy(this.chosenMethodsParametersIndex, newObject.chosenMethodsParametersIndex, this.chosenMethodsParametersIndex.Length);
            return newObject;
        }
    }
}
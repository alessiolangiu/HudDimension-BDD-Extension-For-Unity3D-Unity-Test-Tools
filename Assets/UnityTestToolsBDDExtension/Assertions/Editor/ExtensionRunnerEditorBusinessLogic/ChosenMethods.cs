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
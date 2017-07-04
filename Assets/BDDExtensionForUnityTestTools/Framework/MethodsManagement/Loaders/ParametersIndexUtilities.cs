//-----------------------------------------------------------------------
// <copyright file="ParametersIndexUtilities.cs" company="Hud Dimension">
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
using System.Linq;
using System.Text;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    public class ParametersIndexUtilities
    {
        private const string ARGUMENTSEPARATOR = ",";
        private const string ATTRIBUTESSEPARATOR = ".";

        public string BuildParameterIndex(Type parameterType, string componentName, string methodName, string parameterName, string parameterId, string parameterValueStorageName, int index)
        {
            string result = ";";
            result += parameterType.FullName;
            result += ARGUMENTSEPARATOR;
            result += componentName;
            result += ATTRIBUTESSEPARATOR;
            result += methodName;
            result += ATTRIBUTESSEPARATOR;
            result += parameterName;
            result += ATTRIBUTESSEPARATOR;
            result += parameterId;
            result += ARGUMENTSEPARATOR;
            result += parameterValueStorageName;
            result += ATTRIBUTESSEPARATOR;
            result += "Array.data[";
            result += index;
            result += "]";
            return result;
        }

        public string GetParameterType(string parameterIndex)
        {
            string result = null;
            string partialResult = parameterIndex;
            if (parameterIndex.StartsWith(";"))
            {
                partialResult = parameterIndex.Substring(1, parameterIndex.Length - 1);
            }

            result = partialResult.Split(',')[0];
            return result;
        }

        public string GetComponentName(string parameterIndex)
        {
            return parameterIndex.Split(',')[1].Split('.')[0];
        }

        public string GetMethodName(string parameterIndex)
        {
            return parameterIndex.Split(',')[1].Split('.')[1];
        }

        public string GetParameterName(string parameterIndex)
        {
            return parameterIndex.Split(',')[1].Split('.')[2];
        }

        public string GetParameterId(string parameterIndex)
        {
            return parameterIndex.Split(',')[1].Split('.')[3];
        }

        public string GetParameterValueStorageLocation(string parameterIndex)
        {
            return parameterIndex.Split(',')[2];
        }

        public int GetParameterValueStorageLocationIndex(string parameterIndex)
        {
            string parameterValueStorageLocation = this.GetParameterValueStorageLocation(parameterIndex);
            string indexString = parameterValueStorageLocation.Split(']')[0].Split('[')[1];
            return int.Parse(indexString);
        }

        public string GetParameterFullName(string parameterIndex)
        {
            return parameterIndex.Split(',')[1];
        }

        public string GetMethodFullName(string parameterIndex)
        {
            return this.GetParameterFullName(parameterIndex).Split('.')[0] + "." + this.GetParameterFullName(parameterIndex).Split('.')[1];
        }

        public string GetParameterValueStorageName(string parameterIndex)
        {
            return this.GetParameterValueStorageLocation(parameterIndex).Split('.')[0];
        }

        public string[] GetParametersIndexList(string parametersIndexes)
        {
            string[] result = null;
            List<string> resultList = new List<string>();
            if (parametersIndexes == null || parametersIndexes.Equals(string.Empty))
            {
                result = new string[0];
            }
            else
            {
                string[] stringSplitted = parametersIndexes.Split(';');
                foreach (string element in stringSplitted)
                {
                    if (!element.Equals(string.Empty))
                    {
                        resultList.Add(element);
                    }
                }

                result = resultList.ToArray();
            }

            return result;
        }

        public string GetParameterFullName(string componentName, string methodName, string parameterName, string parameterId)
        {
            return componentName + "." + methodName + "." + parameterName + "." + parameterId;
        }
    }
}

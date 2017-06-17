//-----------------------------------------------------------------------
// <copyright file="MethodParametersLoader.cs" company="Hud Dimesion">
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
using System.Collections.Generic;
using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodParametersLoader
    {
        public virtual MethodParameters LoadMethodParameters(object obj, MethodInfo method, string id, string parametersIndex)
        {
            List<MethodParameter> parametersList = new List<MethodParameter>();
            ParameterInfo[] parametersInfo = method.GetParameters();
            foreach (ParameterInfo parameterInfo in parametersInfo)
            {
                MethodParameter mp = new MethodParameter();
                mp.ParameterInfoObject = parameterInfo;
                mp.Value = LoadParameterValue(obj, method, parameterInfo, id, parametersIndex);
                mp.ParameterLocation = LoadParameterLocation(obj, method, parameterInfo, id, parametersIndex);
                parametersList.Add(mp);
            }

            MethodParameters result = new MethodParameters();
            result.Parameters = parametersList.ToArray();
            return result;
        }

        private static ParameterLocation LoadParameterLocation(object obj, MethodInfo method, ParameterInfo parameter, string id, string parametersIndex)
        {
            // parametersIndex Format: ;paramtype,className.methodName.paramName.fullId,arrayName.Array.data[index];
            ParameterLocation result = null;
            if (parametersIndex != null)
            {
                string parameterFullName = method.DeclaringType.Name + "." + method.Name + "." + parameter.Name + "." + id;
                string[] parameterIndexes = parametersIndex.Split(';');
                foreach (string pi in parameterIndexes)
                {
                    if (!pi.Equals(string.Empty))
                    {
                        string[] parameterDeclarations = pi.Split(',');
                        string parameterName = parameterDeclarations[1];
                        string parameterLocation = parameterDeclarations[2];
                        if (parameterName.Equals(parameterFullName))
                        {
                            string arrayName = parameterLocation.Split('.')[0];
                            string arrayIndex = parameterLocation.Split('[')[1].Split(']')[0];
                            int index = int.Parse(arrayIndex);
                            result = new ParameterLocation();
                            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
                            FieldInfo field = arrayStorageUtilities.GetArrayStorageFieldInfoByName(obj, arrayName);
                            result.ParameterArrayLocation.ArrayFieldInfo = field;
                            result.ParameterArrayLocation.ArrayIndex = index;
                            result.ParameterArrayLocation.ArrayName = arrayName;
                            result.ParameterClassLocation.ComponentType = obj.GetType();
                            result.ParameterClassLocation.ComponentObject = obj;
                        }
                    }
                }
            }

            return result;
        }

        private static object LoadParameterValue(object obj, MethodInfo method, ParameterInfo parameter, string id, string parametersIndex)
        {
            // parametersIndex Format: ;paramtype,className.methodName.paramName.fullId,arrayName.Array.data[index];
            object result = null;
            if (parametersIndex != null)
            {
                string parameterFullName = method.DeclaringType.Name + "." + method.Name + "." + parameter.Name + "." + id;
                string[] parameterIndexes = parametersIndex.Split(';');
                foreach (string parameterIndex in parameterIndexes)
                {
                    if (!parameterIndex.Equals(string.Empty))
                    {
                        string[] parameterDeclarations = parameterIndex.Split(',');
                        string parameterName = parameterDeclarations[1];
                        string parameterLocation = parameterDeclarations[2];
                        if (parameterName.Equals(parameterFullName))
                        {
                            string arrayName = parameterLocation.Split('.')[0];
                            string arrayIndex = parameterLocation.Split('[')[1].Split(']')[0];
                            int index = int.Parse(arrayIndex);
                            result = GetValue(obj, arrayName, index);
                        }
                    }
                }
            }

            return result;
        }

        private static object GetValue(object obj, string arrayName, int index)
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo field = arrayStorageUtilities.GetArrayStorageFieldInfoByName(obj, arrayName);
            if (field == null)
            {
                return null;
            }

            Array array = field.GetValue(obj) as Array;
            return array.GetValue(index);
        }
    }
}

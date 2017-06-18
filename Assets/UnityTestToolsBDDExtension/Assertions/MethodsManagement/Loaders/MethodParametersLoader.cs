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
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            ParameterLocation result = null;
            if (parametersIndex != null)
            {
                string expectedParameterFullName = parametersIndexUtilities.GetParameterFullName(method.DeclaringType.Name, method.Name, parameter.Name, id);
                string[] parameterIndexes = parametersIndexUtilities.GetParametersIndexList(parametersIndex);
                foreach (string parameterIndex in parameterIndexes)
                {
                    if (!parameterIndex.Equals(string.Empty))
                    {
                        string parameterFullName = parametersIndexUtilities.GetParameterFullName(parameterIndex);
                        if (parameterFullName.Equals(expectedParameterFullName))
                        {
                            string arrayName = parametersIndexUtilities.GetParameterValueStorageName(parameterIndex);

                            int index = parametersIndexUtilities.GetParameterValueStorageLocationIndex(parameterIndex);
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

        private static object LoadParameterValue(object obj, MethodInfo method, ParameterInfo parameter, string id, string parametersIndexes)
        {
            // parametersIndex Format: ;paramtype,className.methodName.paramName.fullId,arrayName.Array.data[index];
            object result = null;
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            if (parametersIndexes != null)
            {
                string expectedParameterFullName = parametersIndexUtilities.GetParameterFullName(method.DeclaringType.Name, method.Name, parameter.Name, id);
                string[] parametersIndexesList = parametersIndexUtilities.GetParametersIndexList(parametersIndexes);
                foreach (string parameterIndex in parametersIndexesList)
                {
                    if (!parameterIndex.Equals(string.Empty))
                    {
                        string parameterFullName = parametersIndexUtilities.GetParameterFullName(parameterIndex);
                        if (parameterFullName.Equals(expectedParameterFullName))
                        {
                            string arrayName = parametersIndexUtilities.GetParameterValueStorageName(parameterIndex);

                            int index = parametersIndexUtilities.GetParameterValueStorageLocationIndex(parameterIndex);
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

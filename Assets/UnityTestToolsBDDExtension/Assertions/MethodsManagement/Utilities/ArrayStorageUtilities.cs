using System;
using System.Reflection;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class ArrayStorageUtilities
    {
        public FieldInfo GetArrayStorageFieldInfoByType(object dynamicBDDComponent, Type elementType)
        {
            FieldInfo result = null;
            Type type = dynamicBDDComponent.GetType();
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo fieldInfo in fieldsInfo)
            {
                object[] valuesArrayStorageList = fieldInfo.GetCustomAttributes(typeof(ParametersValuesStorage), true);
                if (valuesArrayStorageList != null && valuesArrayStorageList.Length == 1)
                {
                    if (fieldInfo.FieldType.IsArray && fieldInfo.FieldType.GetElementType().Equals(elementType))
                    {
                        result = fieldInfo;
                    }
                }
            }

            return result;
        }

        public void ResetArrayStorage(FieldInfo fieldInfo, object dynamicBDDComponent)
        {
            Type elementType = fieldInfo.FieldType.GetElementType();
            Array array = Array.CreateInstance(elementType, 0);
            fieldInfo.SetValue(dynamicBDDComponent, array);
        }

        public void ResetAllArrayStorage(Component[] components)
        {
            foreach (object component in components)
            {
                Type type = component.GetType();
                FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (FieldInfo fieldInfo in fieldsInfo)
                {
                    object[] valuesArrayStorageList = fieldInfo.GetCustomAttributes(typeof(ParametersValuesStorage), true);
                    if (valuesArrayStorageList != null && valuesArrayStorageList.Length == 1)
                    {
                        this.ResetArrayStorage(fieldInfo, component);
                    }
                }
            }
        }

        public FieldInfo GetArrayStorageFieldInfoByName(object obj, string arrayName)
        {
            FieldInfo result = null;
            Type type = obj.GetType();
            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo fieldInfo in fieldsInfo)
            {
                object[] valuesArrayStorageList = fieldInfo.GetCustomAttributes(typeof(ParametersValuesStorage), true);
                if (valuesArrayStorageList != null && valuesArrayStorageList.Length == 1)
                {
                    if (fieldInfo.FieldType.IsArray && fieldInfo.Name.Equals(arrayName))
                    {
                        result = fieldInfo;
                    }
                }
            }

            return result;
        }
    }
}

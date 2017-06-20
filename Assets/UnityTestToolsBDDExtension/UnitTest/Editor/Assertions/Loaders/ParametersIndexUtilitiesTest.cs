//-----------------------------------------------------------------------
// <copyright file="ParametersIndexUtilitiesTest.cs" company="Hud Dimension">
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
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ParametersIndexUtilitiesTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("BuildParameterIndex method should return the expected ParameterIndex given all the informations for building it")]
        public void BuildParameterIndex_Should_ReturnTheExpectedParameterIndex_Given_AllTheInformationsForBuildingIt()
        {
            string expectedParametersIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            Type parameterType = typeof(string);
            string componentName = "ComponentName";
            string methodName = "MethodName";

            string parameterName = "parameterName";
            string parameterId = "parameterId";
            string parameterValueStorage = "parameterPVS";
            int index = 0;
            string result = parametersIndexUtilities.BuildParameterIndex(parameterType, componentName, methodName, parameterName, parameterId, parameterValueStorage, index);
            Assert.AreEqual(expectedParametersIndex, result, "The method BuildParameterIndex doesn't return the right index");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterType method should return SystemString given a parameterIndex for a string parameter")]
        public void GetParameterType_Should_ReturnSystemString_Given_AParameterIndexForAStringParameter()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParameterType = "System.String";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterType(parameterIndex);
            Assert.AreEqual(expectedParameterType, result, "The method GetParameterType doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetComponentName method should return ComponentName given a parameterIndex for a component called ComponentName")]
        public void GetComponentName_Should_ReturnComponentName_Given_AParameterIndexForAComponentCalledComponentName()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedComponentName = "ComponentName";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetComponentName(parameterIndex);
            Assert.AreEqual(expectedComponentName, result, "The method GetComponentName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetMethodName should return MethodName given a parameterIndex for a method called MethodName")]
        public void GetMethodName_Should_ReturnMethodName_Given_AParameterIndexForAMethodCalledMethodName()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedMethodName = "MethodName";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetMethodName(parameterIndex);
            Assert.AreEqual(expectedMethodName, result, "The method GetMethodName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterName method should return parameterName given a parameterIndex for a parameter called ParameterName")]
        public void GetParameterName_Should_ReturnParameterName_Given_AParameterIndexForAParameterCalledParameterName()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParamenterName = "parameterName";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterName(parameterIndex);
            Assert.AreEqual(expectedParamenterName, result, "The method GetParameterName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterId method should return parameterId given a parameterIndex for a parameter id with value parameterId")]
        public void GetParameterId_Should_ReturnParameterId_Given_AParameterIndexForAParameterIdWithValueParameterId()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParamenterId = "parameterId";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterId(parameterIndex);
            Assert.AreEqual(expectedParamenterId, result, "The method GetParameterId doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterValueStorageLocation method should return the expected ValueStorageLocation given a parameterIndex")]
        public void GetParameterValueStorageLocation_Should_ReturnTheExpectedValueStorageLocation_Given_AParameterIndex()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParamenterValueStorageLocation = "parameterPVS.Array.data[0]";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterValueStorageLocation(parameterIndex);
            Assert.AreEqual(expectedParamenterValueStorageLocation, result, "The method GetParameterValueStorageLocation doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterValueStorageLocationIndex method should return 0 given a parameterIndex whith the index of the ParametersValueStorage array set to 0")]
        public void GetParameterValueStorageLocationIndex_Should_ReturnZero_Given_AParameterIndexWithTheIndexOfTHeParametersValuesStorageArraySetToZero()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            int expectedParameterValueStorageLocationIndex = 0;
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            int result = parametersIndexUtilities.GetParameterValueStorageLocationIndex(parameterIndex);
            Assert.AreEqual(expectedParameterValueStorageLocationIndex, result, "The method GetParameterValueStorageLocationIndex doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterFullName method shuld return the expected parameter full name given a parameterIndex")]
        public void GetParameterFullName_Should_ReturnTheExpectedParameterFullName_Given_AParameterIndex()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParameterFullName = "ComponentName.MethodName.parameterName.parameterId";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterFullName(parameterIndex);
            Assert.AreEqual(expectedParameterFullName, result, "The method GetParameterFullName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterFullName method should return the expected parameter full name given all the informations for building it")]
        public void GetParameterFullName_Should_ReturnTheExpectedParameterFullName_Given_AllTheInformationsForBuildingIt()
        {
            string expectedParameterFullName = "ComponentName.MethodName.parameterName.parameterId";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string componentName = "ComponentName";
            string methodName = "MethodName";
            string parameterName = "parameterName";
            string parameterId = "parameterId";
            string result = parametersIndexUtilities.GetParameterFullName(componentName, methodName, parameterName, parameterId);
            Assert.AreEqual(expectedParameterFullName, result, "The method GetParameterFullName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetMethodFullName method should return the expected method full name given a parameterIndex")]
        public void GetMethodFullName_Should_ReturnTheExpectedMethodFullName_Given_AParameterIndex()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedMethodFullName = "ComponentName.MethodName";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetMethodFullName(parameterIndex);
            Assert.AreEqual(expectedMethodFullName, result, "The method GetMethodFullName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParameterValueStorageName method should return the expected ParameterValueStorage name given a parameterIndex")]
        public void GetParameterValueStorageName_Should_ReturnTheExpectedParameterValueStorageName_Given_AParameterIndex()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]";
            string expectedParameterValueStorageName = "parameterPVS";
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string result = parametersIndexUtilities.GetParameterValueStorageName(parameterIndex);
            Assert.AreEqual(expectedParameterValueStorageName, result, "The method GetParameterValueStorageName doesn't return the right parameterType");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("GetParametersIndexList method should return the expected list of parameterIndexes given a parametersIndexes")]
        public void GetParametersIndexList_Should_ReturnTheExpectedListOfParameterIndexes_Given_AParametersIndexes()
        {
            string parameterIndex = ";System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0];System.String,ComponentName.MethodName.parameterName.parameterId1,parameterPVS.Array.data[1];";
            string[] expectedGetParametersIndexList = new string[2] { "System.String,ComponentName.MethodName.parameterName.parameterId,parameterPVS.Array.data[0]", "System.String,ComponentName.MethodName.parameterName.parameterId1,parameterPVS.Array.data[1]" };
            ParametersIndexUtilities parametersIndexUtilities = new ParametersIndexUtilities();
            string[] result = parametersIndexUtilities.GetParametersIndexList(parameterIndex);
            Assert.AreEqual(expectedGetParametersIndexList[0], result[0], "The method GetParametersIndexList doesn't return the right parameterType");
            Assert.AreEqual(expectedGetParametersIndexList[1], result[1], "The method GetParametersIndexList doesn't return the right parameterType");
        }
    }
}

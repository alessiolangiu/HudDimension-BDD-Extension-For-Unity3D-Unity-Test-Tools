//-----------------------------------------------------------------------
// <copyright file="MethodParametersLoaderTest.cs" company="Hud Dimension">
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
using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodParametersLoaderTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("LoadMethodParameters method should return the expected MethodParameters object given a Dynamic component and a method with one string parameter and its parameterIndex")]
        public void LoadMethodParameters_Should_ReturnTheExpectedMethodParametersObject_Given_ADynamicComponentAndAMethodWithOneStringParameterAndItsParameterIndex()
        {
            MethodParametersLoaderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodParametersLoaderTestDynamicComponent>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            arrayStorage.SetValue(component, new string[1] { "Parameter Value" });

            MethodInfo method = component.GetType().GetMethod("GivenMethod");

            MethodParameter expectedParameter = new MethodParameter();
            expectedParameter.ParameterInfoObject = method.GetParameters()[0];

            ParameterLocation parameterLocation = new ParameterLocation();
            parameterLocation.ParameterClassLocation = new ParameterLocation.ClassLocation();
            parameterLocation.ParameterClassLocation.ComponentObject = component;
            parameterLocation.ParameterClassLocation.ComponentType = component.GetType();
            parameterLocation.ParameterArrayLocation = new ParameterLocation.ArrayLocation();
            parameterLocation.ParameterArrayLocation.ArrayFieldInfo = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            parameterLocation.ParameterArrayLocation.ArrayName = "stringPVS";
            parameterLocation.ParameterArrayLocation.ArrayIndex = 0;

            expectedParameter.ParameterLocation = parameterLocation;

            expectedParameter.Value = "Parameter Value";
            MethodParameters expectedMethodParameters = new MethodParameters();
            expectedMethodParameters.Parameters = new MethodParameter[1] { expectedParameter };

            string parametersIndex = ";System.String,MethodParametersLoaderTestDynamicComponent.GivenMethod.stringParam.,stringPVS.Array.data[0];";
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            MethodParameters methodParameters = methodParametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex);
            Assert.That(expectedMethodParameters.Equals(methodParameters), "The method MethodParametersLoader.LoadMethodParameters doesn't return the right object.");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("LoadMethodParameters method should return the expected MethodParameters object given a Dynamic component and a method with one string parameter and one int parameter with their parameterIndexes")]
        public void LoadMethodParameters_Should_ReturnTheExpectedMethodParametersObject_Given_ADynamicComponentAndAMethodWithOneStringParameterAndOneIntParameterWithTheirParameterIndexes()
        {
            MethodParametersLoaderTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodParametersLoaderTestDynamicComponent>();

            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();

            FieldInfo stringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            stringArrayStorage.SetValue(component, new string[1] { "Parameter Value" });

            FieldInfo intArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            intArrayStorage.SetValue(component, new int[1] { 102 });

            MethodInfo method = component.GetType().GetMethod("WhenMethod");
            ParameterInfo[] parametersInfo = method.GetParameters();

            MethodParameter expectedParameter1 = new MethodParameter();
            expectedParameter1.ParameterInfoObject = parametersInfo[0];

            ParameterLocation parameterLocation1 = new ParameterLocation();
            parameterLocation1.ParameterClassLocation = new ParameterLocation.ClassLocation();
            parameterLocation1.ParameterClassLocation.ComponentObject = component;
            parameterLocation1.ParameterClassLocation.ComponentType = component.GetType();
            parameterLocation1.ParameterArrayLocation = new ParameterLocation.ArrayLocation();
            parameterLocation1.ParameterArrayLocation.ArrayFieldInfo = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(string));
            parameterLocation1.ParameterArrayLocation.ArrayName = "stringPVS";
            parameterLocation1.ParameterArrayLocation.ArrayIndex = 0;

            expectedParameter1.ParameterLocation = parameterLocation1;

            expectedParameter1.Value = "Parameter Value";

            MethodParameter expectedParameter2 = new MethodParameter();
            expectedParameter2.ParameterInfoObject = parametersInfo[1];

            ParameterLocation parameterLocation2 = new ParameterLocation();
            parameterLocation2.ParameterClassLocation = new ParameterLocation.ClassLocation();
            parameterLocation2.ParameterClassLocation.ComponentObject = component;
            parameterLocation2.ParameterClassLocation.ComponentType = component.GetType();
            parameterLocation2.ParameterArrayLocation = new ParameterLocation.ArrayLocation();
            parameterLocation2.ParameterArrayLocation.ArrayFieldInfo = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, typeof(int));
            parameterLocation2.ParameterArrayLocation.ArrayName = "intPVS";
            parameterLocation2.ParameterArrayLocation.ArrayIndex = 0;

            expectedParameter2.ParameterLocation = parameterLocation2;

            expectedParameter2.Value = 102;

            MethodParameters expectedMethodParameters = new MethodParameters();
            expectedMethodParameters.Parameters = new MethodParameter[2] { expectedParameter1, expectedParameter2 };

            string parametersIndex = ";System.String,MethodParametersLoaderTestDynamicComponent.WhenMethod.whenStringParam.,stringPVS.Array.data[0];System.Int32,MethodParametersLoaderTestDynamicComponent.WhenMethod.whenIntParam.,intPVS.Array.data[0];";
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            MethodParameters methodParameters = methodParametersLoader.LoadMethodParameters(component, method, string.Empty, parametersIndex);
            Assert.That(expectedMethodParameters.Equals(methodParameters), "The method MethodParametersLoader.LoadMethodParameters doesn't return the right object.");
        }
    }
}

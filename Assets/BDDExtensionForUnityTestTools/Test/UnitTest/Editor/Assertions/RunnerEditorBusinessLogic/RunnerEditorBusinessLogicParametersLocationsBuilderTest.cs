//-----------------------------------------------------------------------
// <copyright file="RunnerEditorBusinessLogicParametersLocationsBuilderTest.cs" company="Hud Dimension">
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
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class RunnerEditorBusinessLogicParametersLocationsBuilderTest
    {
        [Test]
        [Description("BuildParametersLocation method should load the expected values for the parameters and build the expected parametersIndexes given a FullMethodDescription list on a single Dynamic component on a single method")]
        public void BuildParametersLocation_Should_LoadTheExpectedValuesForTheParametersAndBuildTheExpectedParametersIndexes_Given_AFullMethodDescriptionListOnASIngleDynamicComponentOnASingleMethod()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] methodsFullNamesList = new string[1] { "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[3]" };
            IMethodsFilter methodFilter = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            MethodsLoader methodsLoader = new MethodsLoader(metodBuilder, methodFilter);
            RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest>();
            Component[] components = new Component[1] { firstDynamicBDDComponent };

            string[] stringArray = new string[4] { string.Empty, string.Empty, string.Empty, "String Value for the parameter" };
            FieldInfo stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> methodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<GivenBaseAttribute>(components, methodsLoader, methodDescriptionBuilder, methodParametersLoader, methodsFullNamesList, parametersIndexes);

            stringArray = new string[0];
            stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(methodsDescriptionsList[0], 1);
            parametersLocationsBuilder.BuildParametersLocation(fullMethodsDescriptionsList);

            Array currentStringPVS = stringPVS.GetValue(firstDynamicBDDComponent) as Array;
            Assert.AreEqual(1, currentStringPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual("String Value for the parameter", currentStringPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0]", fullMethodsDescriptionsList[0].ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
        }

        [Test]
        [Description("BuildParametersLocation method should load the expected values for the parameters and build the expected parametersIndexes given a FullMethodDescription list on a single Dynamic component and on a single method with a CallBefore attribute")]
        public void BuildParametersLocation_Should_LoadTheExpectedValuesForTheParametersAndBuildTheExpectedParametersIndexes_Given_AFullMethodDescriptionListOnASIngleDynamicComponentOnASingleMethodWithACallBeforeAttibute()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] methodsFullNamesList = new string[1] { "RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters.SecondWhenMethod" };
            string[] parametersIndexes = new string[1] { ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[2];System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters.GivenMethod.stringParam.,stringPVS.Array.data[3]" };
            IMethodsFilter methodFilter = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            MethodsLoader methodsLoader = new MethodsLoader(metodBuilder, methodFilter);
            RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters>();
            Component[] components = new Component[1] { firstDynamicBDDComponent };
            string secondWhenMethodParam = "String Value for the parameter SecondWhenMethod";
            string givenMethodParam = "String Value for the parameter GivenMethod";
            string[] stringArray = new string[4] { string.Empty, string.Empty, secondWhenMethodParam, givenMethodParam };
            FieldInfo stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> methodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(components, methodsLoader, methodDescriptionBuilder, methodParametersLoader, methodsFullNamesList, parametersIndexes);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(methodsDescriptionsList[0], 1);

            stringArray = new string[0];
            stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            parametersLocationsBuilder.BuildParametersLocation(fullMethodsDescriptionsList);

            Array currentStringPVS = stringPVS.GetValue(firstDynamicBDDComponent) as Array;
            Assert.AreEqual(2, currentStringPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.That(givenMethodParam.Equals(currentStringPVS.GetValue(0)), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.That(secondWhenMethodParam.Equals(currentStringPVS.GetValue(1)), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters.GivenMethod.stringParam.,stringPVS.Array.data[0];System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTDynamicCallBeforeParameters.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[1]", fullMethodsDescriptionsList[1].ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
        }

        [Test]
        [Description("BuildParametersLocation method should load the expected values for the parameters and build the expected parametersIndexes given a FullMethodDescription list on a single Dynamic component and on three methods")]
        public void BuildParametersLocation_Should_LoadTheExpectedValuesForTheParametersAndBuildTheExpectedParametersIndexes_Given_AFullMethodDescriptionListOnASingleDynamicComponentAndOnThreeMethods()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] methodsFullNamesList = new string[3]
            {
                "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.SecondWhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod"
            };
            string[] parametersIndexes = new string[3]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[3]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[2]",
                ";String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0]",
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod.whenIntParam.,intPVS.Array.data[0]"
            };

            RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest>();
            Component[] components = new Component[1] { firstDynamicBDDComponent };

            string[] stringArray = new string[4] { "String Value for the SecondWhenMethod WhenStringParam parameter", string.Empty, string.Empty, "String Value for the WhenMethod WhenStringParam parameter" };
            FieldInfo stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            int[] intArray = new int[3] { 103, 0, 201 };
            FieldInfo intPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), intArray);

            IMethodsFilter methodFilter = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            MethodsLoader methodsLoader = new MethodsLoader(metodBuilder, methodFilter);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> methodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(components, methodsLoader, methodDescriptionBuilder, methodParametersLoader, methodsFullNamesList, parametersIndexes);

            stringArray = new string[0];
            stringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            intArray = new int[0];
            intPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), intArray);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(methodsDescriptionsList[0], 1);
            fullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(methodsDescriptionsList[1], 2));
            fullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(methodsDescriptionsList[2], 3));

            parametersLocationsBuilder.BuildParametersLocation(fullMethodsDescriptionsList);

            Array stringArrayPVS = stringPVS.GetValue(firstDynamicBDDComponent) as Array;
            Array intArrayPVS = intPVS.GetValue(firstDynamicBDDComponent) as Array;
            Assert.AreEqual(2, stringArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(2, intArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual("String Value for the WhenMethod WhenStringParam parameter", stringArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual("String Value for the SecondWhenMethod WhenStringParam parameter", stringArrayPVS.GetValue(1), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(201, intArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(103, intArrayPVS.GetValue(1), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            FullMethodDescription whenFullMethodMethodDescription = null;
            FullMethodDescription secondWhenFullMethodMethodDescription = null;
            FullMethodDescription thirdWhenFullMethodMethodDescription = null;
            foreach (FullMethodDescription fullMethodDescription in fullMethodsDescriptionsList)
            {
                if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod"))
                {
                    whenFullMethodMethodDescription = fullMethodDescription;
                }
                else if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.SecondWhenMethod"))
                {
                    secondWhenFullMethodMethodDescription = fullMethodDescription;
                }
                else if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod"))
                {
                    thirdWhenFullMethodMethodDescription = fullMethodDescription;
                }
            }

            Assert.AreEqual(
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0]",
                whenFullMethodMethodDescription.ParametersIndex,
                "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[1]", secondWhenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod.whenIntParam.,intPVS.Array.data[1]", thirdWhenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
        }

        [Test]
        [Description("BuildParametersLocation method should load the expected values for the parameters and build the expected parametersIndexes given a FullMethodDescription list on two Dynamic components and on three methods")]
        public void BuildParametersLocation_Should_LoadTheExpectedValuesForTheParametersAndBuildTheExpectedParametersIndexes_Given_AFullMethodDescriptionListOnTwoDynamicComponentsAndOnThreeMethods()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] methodsFullNamesList = new string[3]
            {
                "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod"
            };
            string[] parametersIndexes = new string[3]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[3]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[2]",
                ";String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0]",
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod.whenIntParam.,intPVS.Array.data[0]"
            };

            RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest>();
            RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest secondDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest>();
            Component[] components = new Component[2] { secondDynamicBDDComponent, firstDynamicBDDComponent };

            string[] stringArray = new string[4] { "Fake String Value for the SecondWhenMethod WhenStringParam parameter", string.Empty, string.Empty, "String Value for the WhenMethod WhenStringParam parameter" };
            FieldInfo firstStringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            int[] intArray = new int[3] { 103, 0, 201 };
            FieldInfo firstIntPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), intArray);

            stringArray = new string[4] { "String Value for the SecondWhenMethod WhenStringParam parameter of the secondDynamicBDDForTest", string.Empty, string.Empty, "Fake String Value for the WhenMethod WhenStringParam parameter" };
            FieldInfo secondStringPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), stringArray);

            intArray = null;
            FieldInfo secondIntPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), intArray);

            IMethodsFilter methodFilter = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            MethodsLoader methodsLoader = new MethodsLoader(metodBuilder, methodFilter);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> methodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(components, methodsLoader, methodDescriptionBuilder, methodParametersLoader, methodsFullNamesList, parametersIndexes);

            firstStringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), new string[0]);
            firstIntPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), new int[0]);
            secondStringPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), new string[0]);
            secondIntPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), new int[0]);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> fullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(methodsDescriptionsList[0], 1);
            fullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(methodsDescriptionsList[1], 2));
            fullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(methodsDescriptionsList[2], 3));

            parametersLocationsBuilder.BuildParametersLocation(fullMethodsDescriptionsList);

            Array firstStringArrayPVS = firstStringPVS.GetValue(firstDynamicBDDComponent) as Array;
            Array firstIntArrayPVS = firstIntPVS.GetValue(firstDynamicBDDComponent) as Array;
            Array secondStringArrayPVS = secondStringPVS.GetValue(secondDynamicBDDComponent) as Array;
            Array secondIntArrayPVS = secondIntPVS.GetValue(secondDynamicBDDComponent) as Array;

            Assert.AreEqual(1, firstStringArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(2, firstIntArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual(1, secondStringArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(0, secondIntArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual("String Value for the WhenMethod WhenStringParam parameter", firstStringArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(201, firstIntArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(103, firstIntArrayPVS.GetValue(1), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual("String Value for the SecondWhenMethod WhenStringParam parameter of the secondDynamicBDDForTest", secondStringArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            FullMethodDescription whenFullMethodMethodDescription = null;
            FullMethodDescription secondWhenFullMethodMethodDescription = null;
            FullMethodDescription thirdWhenFullMethodMethodDescription = null;
            foreach (FullMethodDescription fullMethodDescription in fullMethodsDescriptionsList)
            {
                if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod"))
                {
                    whenFullMethodMethodDescription = fullMethodDescription;
                }
                else if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod"))
                {
                    secondWhenFullMethodMethodDescription = fullMethodDescription;
                }
                else if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod"))
                {
                    thirdWhenFullMethodMethodDescription = fullMethodDescription;
                }
            }

            Assert.AreEqual(
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[0]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0]",
                whenFullMethodMethodDescription.ParametersIndex,
                "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0]", secondWhenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.ThirdWhenMethod.whenIntParam.,intPVS.Array.data[1]", thirdWhenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
        }

        [Test]
        [Description("BuildParametersLocation method should load the expected values for the parameters and build the expected parametersIndexes given a FullMethodDescription list on two Dynamic components and on three methods in adding")]
        public void BuildParametersLocation_Should_LoadTheExpectedValuesForTheParametersAndBuildTheExpectedParametersIndexes_Given_AFullMethodDescriptionListOnTwoDynamicComponentsAndOnThreeMethodsInAdding()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] givenMethodsFullNamesList = new string[1] { "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod" };
            string[] givenParametersIndexes = new string[1]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[2]"
            };

            string[] whenMethodsFullNamesList = new string[2]
            {
                "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod"
            };
            string[] whenParametersIndexes = new string[2]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[3]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[2]",
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[1]"
            };

            RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest>();
            RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest secondDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest>();
            Component[] components = new Component[2] { secondDynamicBDDComponent, firstDynamicBDDComponent };

            string[] stringArray = new string[4] { string.Empty, string.Empty, "GivenStringParamFirstClass", "WhenStringParamFirstClass" };
            FieldInfo firstStringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            int[] intArray = new int[3] { -1, -1, 103 };
            FieldInfo firstIntPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), intArray);

            stringArray = new string[4] { string.Empty, "SecondWhenMethodSecondClass", string.Empty, string.Empty };
            FieldInfo secondStringPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), stringArray);

            intArray = null;
            FieldInfo secondIntPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), intArray);

            IMethodsFilter methodFilterForGivenList = new MethodsFilterByMethodsFullNameList(givenMethodsFullNamesList);
            IMethodsFilter methodFilterForWhenList = new MethodsFilterByMethodsFullNameList(whenMethodsFullNamesList);
            MethodsLoader methodsLoaderForGivenMethods = new MethodsLoader(metodBuilder, methodFilterForGivenList);
            MethodsLoader methodsLoaderForWhenMethods = new MethodsLoader(metodBuilder, methodFilterForWhenList);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> givenMethodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<GivenBaseAttribute>(components, methodsLoaderForGivenMethods, methodDescriptionBuilder, methodParametersLoader, givenMethodsFullNamesList, givenParametersIndexes);
            List<MethodDescription> whenMethodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(components, methodsLoaderForWhenMethods, methodDescriptionBuilder, methodParametersLoader, whenMethodsFullNamesList, whenParametersIndexes);

            firstStringPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), new string[0]);
            firstIntPVS = this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), new int[0]);
            secondStringPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), new string[0]);
            secondIntPVS = this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), new int[0]);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> givenFullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(givenMethodsDescriptionsList[0], 1);

            parametersLocationsBuilder.BuildParametersLocation(givenFullMethodsDescriptionsList);

            List<FullMethodDescription> whenFullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(whenMethodsDescriptionsList[0], 1);
            whenFullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(whenMethodsDescriptionsList[1], 2));

            parametersLocationsBuilder.BuildParametersLocation(whenFullMethodsDescriptionsList);

            Array firstStringArrayPVS = firstStringPVS.GetValue(firstDynamicBDDComponent) as Array;
            Array firstIntArrayPVS = firstIntPVS.GetValue(firstDynamicBDDComponent) as Array;
            Array secondStringArrayPVS = secondStringPVS.GetValue(secondDynamicBDDComponent) as Array;
            Array secondIntArrayPVS = secondIntPVS.GetValue(secondDynamicBDDComponent) as Array;

            Assert.AreEqual(2, firstStringArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(1, firstIntArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual(1, secondStringArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(0, secondIntArrayPVS.Length, "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual("GivenStringParamFirstClass", firstStringArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");
            Assert.AreEqual(103, firstIntArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            Assert.AreEqual("SecondWhenMethodSecondClass", secondStringArrayPVS.GetValue(0), "The method BuildParametersLocation doesn't build the ParameterArrayStorage properly");

            FullMethodDescription givenFullMethodMethodDescription = givenFullMethodsDescriptionsList[0];
            FullMethodDescription whenFullMethodMethodDescription = null;
            FullMethodDescription secondWhenFullMethodMethodDescription = null;
            foreach (FullMethodDescription fullMethodDescription in whenFullMethodsDescriptionsList)
            {
                if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod"))
                {
                    whenFullMethodMethodDescription = fullMethodDescription;
                }
                else if (fullMethodDescription.GetFullName().Equals("RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod"))
                {
                    secondWhenFullMethodMethodDescription = fullMethodDescription;
                }
            }

            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0]", givenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[1]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0]",
                whenFullMethodMethodDescription.ParametersIndex,
                "The method BuildParametersLocation doesn't build the parametersIndex properly");
            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0]", secondWhenFullMethodMethodDescription.ParametersIndex, "The method BuildParametersLocation doesn't build the parametersIndex properly");
        }

        [Test]
        [Description("RebuildParametersIndexesArrays method should return the expected parametersIndexes arrays given the values in the FullMethodDescription objects are changed")]
        public void RebuildParametersIndexesArrays_Should_ReturnTheExpectedParametersIndexesArrays_Given_TheValuesInTheFullmethodDescriptionObjectAreChanged()
        {
            RunnerEditorBusinessLogicParametersLocationsBuilder parametersLocationsBuilder = new RunnerEditorBusinessLogicParametersLocationsBuilder();

            BaseMethodDescriptionBuilder metodBuilder = new BaseMethodDescriptionBuilder();
            string[] givenMethodsFullNamesList = new string[1] { "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod" };
            string[] givenParametersIndexes = new string[1]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[2]"
            };

            string[] whenMethodsFullNamesList = new string[2] { "RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod", "RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod" };
            string[] whenParametersIndexes = new string[2]
            {
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[3]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[2]",
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[1]"
            };

            RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest>();
            RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest secondDynamicBDDComponent = UnitTestUtility.CreateComponent<RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest>();
            Component[] components = new Component[2] { secondDynamicBDDComponent, firstDynamicBDDComponent };

            string[] stringArray = new string[4] { string.Empty, string.Empty, "GivenStringParamFirstClass", "WhenStringParamFirstClass" };
            this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), stringArray);

            int[] intArray = new int[3] { -1, -1, 103 };
            this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), intArray);

            stringArray = new string[4] { string.Empty, "SecondWhenMethodSecondClass", string.Empty, string.Empty };
            this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), stringArray);

            intArray = null;
            this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), intArray);

            IMethodsFilter methodFilterForGivenList = new MethodsFilterByMethodsFullNameList(givenMethodsFullNamesList);
            IMethodsFilter methodFilterForWhenList = new MethodsFilterByMethodsFullNameList(whenMethodsFullNamesList);
            MethodsLoader methodsLoaderForGivenMethods = new MethodsLoader(metodBuilder, methodFilterForGivenList);
            MethodsLoader methodsLoaderForWhenMethods = new MethodsLoader(metodBuilder, methodFilterForWhenList);
            MethodsManagementUtilities methodsManagementUtilities = new MethodsManagementUtilities();
            MethodDescriptionBuilder methodDescriptionBuilder = new MethodDescriptionBuilder();
            MethodParametersLoader methodParametersLoader = new MethodParametersLoader();
            List<MethodDescription> givenMethodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<GivenBaseAttribute>(components, methodsLoaderForGivenMethods, methodDescriptionBuilder, methodParametersLoader, givenMethodsFullNamesList, givenParametersIndexes);
            List<MethodDescription> whenMethodsDescriptionsList = methodsManagementUtilities.LoadMethodsDescriptionsFromChosenMethods<WhenBaseAttribute>(components, methodsLoaderForWhenMethods, methodDescriptionBuilder, methodParametersLoader, whenMethodsFullNamesList, whenParametersIndexes);

            this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(string), new string[0]);
            this.SetPVSAndReturnFieldInfo(firstDynamicBDDComponent, typeof(int), new int[0]);
            this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(string), new string[0]);
            this.SetPVSAndReturnFieldInfo(secondDynamicBDDComponent, typeof(int), new int[0]);

            FullMethodDescriptionBuilder fullMethodDescriptionBuilder = new FullMethodDescriptionBuilder();
            List<FullMethodDescription> givenFullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(givenMethodsDescriptionsList[0], 1);

            parametersLocationsBuilder.BuildParametersLocation(givenFullMethodsDescriptionsList);

            List<FullMethodDescription> whenFullMethodsDescriptionsList = fullMethodDescriptionBuilder.Build(whenMethodsDescriptionsList[0], 1);
            whenFullMethodsDescriptionsList.AddRange(fullMethodDescriptionBuilder.Build(whenMethodsDescriptionsList[1], 2));

            parametersLocationsBuilder.BuildParametersLocation(whenFullMethodsDescriptionsList);

            string[] newGivenIndexes = parametersLocationsBuilder.RebuildParametersIndexesArrays(givenFullMethodsDescriptionsList, givenMethodsFullNamesList);
            string[] newWhenIndexes = parametersLocationsBuilder.RebuildParametersIndexesArrays(whenFullMethodsDescriptionsList, whenMethodsFullNamesList);

            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.GivenMethod.stringParam.,stringPVS.Array.data[0]", newGivenIndexes[0], "The method RebuildParametersIndexesArrays does not rebuild the parametersIndexArray correctly");

            Assert.AreEqual(
                ";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenStringParam.,stringPVS.Array.data[1]" +
                ";System.Int32,RunnerEditorBusinessLogicParametersLocationsBuilderUTFirstDynamicBDDForTest.WhenMethod.whenIntParam.,intPVS.Array.data[0]",
                newWhenIndexes[0],
                "The method RebuildParametersIndexesArrays does not rebuild the parametersIndexArray correctly");

            Assert.AreEqual(";System.String,RunnerEditorBusinessLogicParametersLocationsBuilderUTSecondDynamicBDDForTest.SecondWhenMethod.whenStringParam.,stringPVS.Array.data[0]", newWhenIndexes[1], "The method RebuildParametersIndexesArrays does not rebuild the parametersIndexArray correctly");
        }

        private FieldInfo SetPVSAndReturnFieldInfo(object component, Type pvsType, object value)
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();

            FieldInfo pvs = arrayStorageUtilities.GetArrayStorageFieldInfoByType(component, pvsType);

            pvs.SetValue(component, value);
            return pvs;
        }
    }
}
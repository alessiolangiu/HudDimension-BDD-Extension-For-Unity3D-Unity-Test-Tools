//-----------------------------------------------------------------------
// <copyright file="ArrayStorageUtilitiesTest.cs" company="Hud Dimension">
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
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[module: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ArrayStorageUtilitiesTest
    {
        [Test]
        [Description("GetArrayStorageFieldInfoByType method should return the expected ParametersValuesStorage FieldInfo object given a Dynamic component passing string type")]
        public void GetArrayStorageFieldInfoByType_Should_ReturnTheExpectedParametersValuesStorageFieldInfoObject_Given_ADynamicComponentPassingStringType()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typeof(string));

            string fieldName = "stringPVS";
            FieldInfo expectedArrayStorage = dynamicBDDComponent.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Assert.That(expectedArrayStorage.Name.Equals(arrayStorage.Name), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.FieldType.Equals(arrayStorage.FieldType), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.DeclaringType.Equals(arrayStorage.DeclaringType), "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        [Description("GetArrayStorageFieldInfoByType method should return null given a Dynamic component passing a not present type")]
        public void GetArrayStorageFieldInfoByType_Should_ReturnNull_Given_ADynamicComponentPassingANotPresentType()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typeof(Button));
            Assert.IsNull(arrayStorage, "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        [Description("ResetArrayStorage method should reset the ParametersValuesStorage array given a Dynamic component and the FieldInfo object of the ParametersValuesStorage array")]
        public void ResetArrayStorage_Should_ResetTheParametersValuesStorageArray_Given_ADynamicComponentAndTheFieldInfoObjectOfTheParametersValuesStorageArray()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();
            FieldInfo stringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typeof(string));
            string[] stringArray = new string[1] { "FirstElement" };
            stringArrayStorage.SetValue(dynamicBDDComponent, stringArray);
            Array previousStringArray = stringArrayStorage.GetValue(dynamicBDDComponent) as Array;
            Assert.AreEqual(1, previousStringArray.Length, "The method ResetArrayStorage doesn't reset the array storage properly");

            arrayStorageUtilities.ResetArrayStorage(stringArrayStorage, dynamicBDDComponent);

            Array currentValue = stringArrayStorage.GetValue(dynamicBDDComponent) as Array;
            Assert.AreEqual(0, currentValue.Length, "The method ResetArrayStorage doesn't reset the array storage properly");
        }

        [Test]
        [Description("ResetAllArrayStorage method should reset all ParametersValuesStorage arrays inside the Dynamic components in the list")]
        public void ResetAllArrayStorage_Should_ResetAllParametersValuesStorageArraysInsideTheDynamicComponentsInTheList()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent firstDynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            FieldInfo firstStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(firstDynamicBDDComponent, typeof(string));
            string[] stringArray = new string[1] { "FirstElement" };
            firstStringArrayStorage.SetValue(firstDynamicBDDComponent, stringArray);
            Array previousStringArray = firstStringArrayStorage.GetValue(firstDynamicBDDComponent) as Array;
            Assert.AreEqual(1, previousStringArray.Length, "Test setup does not work properly");

            FieldInfo firstIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(firstDynamicBDDComponent, typeof(int));
            int[] intArray = new int[1] { 123 };
            firstIntArrayStorage.SetValue(firstDynamicBDDComponent, intArray);
            Array previousintArray = firstIntArrayStorage.GetValue(firstDynamicBDDComponent) as Array;
            Assert.AreEqual(1, previousintArray.Length, "Test setup does not work properly");

            ArrayStorageUtilitiesTestFirstDynamicComponent secondDynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            FieldInfo secondStringArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(secondDynamicBDDComponent, typeof(string));
            stringArray = new string[1] { "FirstElement" };
            secondStringArrayStorage.SetValue(secondDynamicBDDComponent, stringArray);
            previousStringArray = secondStringArrayStorage.GetValue(secondDynamicBDDComponent) as Array;
            Assert.AreEqual(1, previousStringArray.Length, "Test setup does not work properly");

            FieldInfo secondIntArrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(secondDynamicBDDComponent, typeof(int));
            intArray = new int[1] { 123 };
            secondIntArrayStorage.SetValue(secondDynamicBDDComponent, intArray);
            previousintArray = secondIntArrayStorage.GetValue(secondDynamicBDDComponent) as Array;
            Assert.AreEqual(1, previousintArray.Length, "Test setup does not work properly");
            Component[] components = new Component[2] { firstDynamicBDDComponent, secondDynamicBDDComponent };

            arrayStorageUtilities.ResetAllArrayStorage(components);

            Array currentFirstStringArrayStorageValue = firstStringArrayStorage.GetValue(firstDynamicBDDComponent) as Array;
            Array currentFirstIntArrayStorageValue = firstIntArrayStorage.GetValue(firstDynamicBDDComponent) as Array;
            Array currentSecondStringArrayStorageValue = secondStringArrayStorage.GetValue(secondDynamicBDDComponent) as Array;
            Array currentSecondIntArrayStorageValue = secondStringArrayStorage.GetValue(secondDynamicBDDComponent) as Array;

            Assert.AreEqual(0, currentFirstStringArrayStorageValue.Length, "The method ResetArrayStorage doesn't reset the array storage properly");
            Assert.AreEqual(0, currentFirstIntArrayStorageValue.Length, "The method ResetArrayStorage doesn't reset the array storage properly");
            Assert.AreEqual(0, currentSecondStringArrayStorageValue.Length, "The method ResetArrayStorage doesn't reset the array storage properly");
            Assert.AreEqual(0, currentSecondIntArrayStorageValue.Length, "The method ResetArrayStorage doesn't reset the array storage properly");
        }

        [Test]
        [Description("GetArrayStorageFieldInfoByType method should return the corresponding ParametersValuesStorage FieldInfo object for all the planned supported types")]
        public void GetArrayStorageFieldInfoByType_Should_ReturnTheCorrespondingParametersValuesStorageFieldInfoObjectForAllThePlannedSuppoertedTypes()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestSecondDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestSecondDynamicComponent>();
            Type[] typesToTest = new Type[43]
            {
                typeof(bool),
                typeof(byte),
                typeof(sbyte),
                typeof(char),
                typeof(decimal),
                typeof(double),
                typeof(float),
                typeof(int),
                typeof(uint),
                typeof(long),
                typeof(ulong),
                typeof(short),
                typeof(ushort),
                typeof(string),

                typeof(Boolean),
                typeof(Byte),
                typeof(SByte),
                typeof(Char),
                typeof(Decimal),
                typeof(Double),
                typeof(Int16),
                typeof(Int32),
                typeof(Int64),
                typeof(UInt16),
                typeof(UInt32),
                typeof(UInt64),
                typeof(String),

                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Rect),
                typeof(Quaternion),
                typeof(Matrix4x4),
                typeof(Color),
                typeof(Color32),
                typeof(LayerMask),
                typeof(AnimationCurve),
                typeof(Gradient),
                typeof(RectOffset),
                typeof(GUIStyle),

                typeof(GameObject),
                typeof(Transform),
                typeof(Component)
            };

            for (int index = 0; index < typesToTest.Length; index++)
            {
                Assert.IsNotNull(arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typesToTest[index]), "The GetArrayStorageFieldInfo can't locate the ParametersValuesStorage array of type " + typesToTest[index].Name);
                Type fieldType = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typesToTest[index]).FieldType.GetElementType();
                Assert.That(typesToTest[index].Equals(fieldType), "The GetArrayStorageFieldInfo returns the wrong ParametersValuesStorage array of type " + typesToTest[index].Name);
            }
        }

        [Test]
        [Description("GetArrayStorageFieldInfoByName method should return the expected FieldInfo object given a Dynamic component and the name of the ParametersValuesStorage array")]
        public void GetArrayStorageFieldInfoByName_Should_ReturnTheExpectedFieldInfoObject_Given_ADynamicComponentAndTheNameOfTheParametersValuesStorageArray()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            string fieldName = "stringPVS";
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByName(dynamicBDDComponent, fieldName);

            FieldInfo expectedArrayStorage = dynamicBDDComponent.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Assert.That(expectedArrayStorage.Name.Equals(arrayStorage.Name), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.FieldType.Equals(arrayStorage.FieldType), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.DeclaringType.Equals(arrayStorage.DeclaringType), "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        [Description("GetArrayStorageFieldInfoByName method should return null given a Dynamic component and a name of a ParametersValuesStorage array that is not present in the component")]
        public void GetArrayStorageFieldInfoByName_Should_ReturnNull_Given_ADynamicComponentAndANameOfAParametersValuesStorageArrayThatIsNotPresentInTheComponent()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesTestFirstDynamicComponent dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesTestFirstDynamicComponent>();

            string fieldName = "stringPVSForNotFound";
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByName(dynamicBDDComponent, fieldName);

            Assert.IsNull(arrayStorage, "The method GetArrayStorage doesn't return the right ArrayStorage");
        }
    }
}

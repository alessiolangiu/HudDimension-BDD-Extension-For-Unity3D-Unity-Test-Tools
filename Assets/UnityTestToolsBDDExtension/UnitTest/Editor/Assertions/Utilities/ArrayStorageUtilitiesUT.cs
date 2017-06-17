//-----------------------------------------------------------------------
// <copyright file="ArrayStorageUtilitiesUT.cs" company="Hud Dimesion">
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
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[module: SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ArrayStorageUtilitiesUT
    {
        [Test]
        public void ArrayStorageUtilitiesGetArrayStorageFieldInfoByType()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typeof(string));

            string fieldName = "stringPVS";
            FieldInfo expectedArrayStorage = dynamicBDDComponent.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Assert.That(expectedArrayStorage.Name.Equals(arrayStorage.Name), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.FieldType.Equals(arrayStorage.FieldType), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.DeclaringType.Equals(arrayStorage.DeclaringType), "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        public void ArrayStorageUtilitiesGetArrayStorageFieldInfoByTypeNotFound()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByType(dynamicBDDComponent, typeof(Button));
            Assert.IsNull(arrayStorage, "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        public void ArrayStorageUtilitiesResetArrayStorage()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();
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
        public void ArrayStorageUtilitiesResetAllArrayStorages()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest firstDynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

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

            ArrayStorageUtilitiesUTFirstDynamicBDDForTest secondDynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

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
        public void ArrayStorageUtilitiesTestTypes()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTDynamicComponentClean dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTDynamicComponentClean>();
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
            }
        }

        [Test]
        public void ArrayStorageUtilitiesGetArrayStorageFieldInfoByName()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

            string fieldName = "stringPVS";
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByName(dynamicBDDComponent, fieldName);

            FieldInfo expectedArrayStorage = dynamicBDDComponent.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Assert.That(expectedArrayStorage.Name.Equals(arrayStorage.Name), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.FieldType.Equals(arrayStorage.FieldType), "The method GetArrayStorage doesn't return the right ArrayStorage");
            Assert.That(expectedArrayStorage.DeclaringType.Equals(arrayStorage.DeclaringType), "The method GetArrayStorage doesn't return the right ArrayStorage");
        }

        [Test]
        public void ArrayStorageUtilitiesGetArrayStorageFieldInfoByNameNotFound()
        {
            ArrayStorageUtilities arrayStorageUtilities = new ArrayStorageUtilities();
            ArrayStorageUtilitiesUTFirstDynamicBDDForTest dynamicBDDComponent = UnitTestUtility.CreateComponent<ArrayStorageUtilitiesUTFirstDynamicBDDForTest>();

            string fieldName = "stringPVSForNotFound";
            FieldInfo arrayStorage = arrayStorageUtilities.GetArrayStorageFieldInfoByName(dynamicBDDComponent, fieldName);

            Assert.IsNull(arrayStorage, "The method GetArrayStorage doesn't return the right ArrayStorage");
        }
    }
}

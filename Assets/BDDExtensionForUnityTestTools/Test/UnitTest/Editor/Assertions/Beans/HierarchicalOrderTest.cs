//-----------------------------------------------------------------------
// <copyright file="HierarchicalOrderTest.cs" company="Hud Dimension">
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
using NUnit.Framework;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class HierarchicalOrderTest
    {
        [TearDown]
        public void Cleanup()
        {
            UnitTestUtility.DestroyTemporaryTestGameObjects();
        }

        [Test]
        [Description("CompareTo method should return 1 when the first Hierarchical Order is greater than the second one")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOIsGreaterThanTheSecondOne()
        {
            HierarchicalOrder greaterHierarchicalOrder = new HierarchicalOrder(2);

            HierarchicalOrder lowerHierarchicalOrder = new HierarchicalOrder(1);

            int result = greaterHierarchicalOrder.CompareTo(lowerHierarchicalOrder);

            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 0 When The two Hierarchical Orders have the same value")]
        public void CompareTo_Should_ReturnZero_When_TheTwoGOHaveTheSameValue()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(0, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the first Hierarchical Order is lower than the second one")]
        public void CompareTo_Should_ReturnOneMinus_When_TheFirstGOIsLowerThanTheSecondOne()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(1);
            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the top value of the first Hierarchical Order is greather than the top value of the second Hierarchical Order and the nested values are equals")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOGreaterThanTheSecondOne_And_TheNestedOnesHaveSameValues()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(1);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 0 when the top values and the nested values of the two Hierarchical Orders are equals")]
        public void CompareTo_Should_ReturnZero_When_GOrdersAreEqualInTheMainValuesAndInTheNestedValues()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(0, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the top value of the first Hierarchical Order is lower than the top value of the second Hierarchical Order and the nested values are equals")]
        public void CompareTo_Should_ReturnOneMinus_When_FirstGOHaveALowerMainValueThanTheOtherOneAndAnEqualNestedValue()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(1);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the top values of the two Hierarchical Orders are equals and the nested value of the first one is greater than the nested value of the second one")]
        public void CompareTo_Should_ReturnOne_When_TheMainValuesAreEqualsAndTheFirstNestedValueIsGreaterThanTheSecondOne()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(2);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the top values of the two Hierarchical Orders are equal and the nested value of the first one is lower than the nested value of the second one")]
        public void CompareTo_Should_ReturnOneMinus_When_TheMainValuesAreEqualsAndTheFirstNestedValueIsLowerThanTheSecondOne()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(2);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the main value of the first Hierarchical Order is greater and the nested values are lower than the second one")]
        public void CompareTo_Should_ReturnOne_When_TheMainValueOfTheFirstGOIsGreater_And_TheNestedValuesAreLowerThanTheSecondOne()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(2);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(1);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 0 when the main and the nested values of the first Hierarchical Order are all equal than the second one")]
        public void CompareTo_Should_ReturnZero_When_TheMainAndTheNestedValuesOfTheFirstGOAreAllEqualThanTheSecondOne()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(2);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(2);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(0, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the deeper nested value of the first Hierarchical Order is lower than the second one and the others are equal")]
        public void CompareTo_Should_ReturnOneMinus_When_TheDeeperNestedValueOfTheFirstGOIsLowerThanTheSecondOneAndTheOthersAreEqual()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(2);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(3);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the values are equal in the first level and the first nested value is greater than the second nested one")]
        public void CompareTo_Should_ReturnOne_When_TheValuesAreEqualInTheFirstLevelAndTheFirstNestedIsGreaterThanTheSecondNested()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(2);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(1);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(3);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the values are equal in the first level and the first nested value is lower than the second nested value")]
        public void CompareTo_Should_ReturnOneMinus_When_TheValuesAreEqualInTheFirstLevelAndTheFirstNestedIsLowerThanTheSecondNested()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(3);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(2);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(1);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the first Hierarchical Order have not a third nested Hierarchical Order and the second one have it with the other values equals")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOHaveNotAThirdNestedGOAndTheSecondHaveItWithTheOtherValuesEqual()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(2);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(2);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);
            HierarchicalOrder otherNestedNested = new HierarchicalOrder(3);
            otherNested.AddAsLastElementHierarchicalOrder(otherNestedNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the first Hierarchical Order have a third nested Hierarchical Order and the second one have not it with the other values equal")]
        public void CompareTo_Should_ReturnOneMinus_When_TheFirstGOHaveAThirdNestedGOAndTheSecondHaventItWithTheOtherValuesEqual()
        {
            HierarchicalOrder mainHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder mainNested = new HierarchicalOrder(1);
            mainHierarchicalOrder.AddAsLastElementHierarchicalOrder(mainNested);
            HierarchicalOrder mainNestedNested = new HierarchicalOrder(3);
            mainNested.AddAsLastElementHierarchicalOrder(mainNestedNested);

            HierarchicalOrder otherHierarchicalOrder = new HierarchicalOrder(2);
            HierarchicalOrder otherNested = new HierarchicalOrder(1);
            otherHierarchicalOrder.AddAsLastElementHierarchicalOrder(otherNested);

            int result = mainHierarchicalOrder.CompareTo(otherHierarchicalOrder);
            Assert.AreEqual(-1, result, "The comparison between the two HierarchicalOrder objects returns a wrong answer");
        }
    }
}

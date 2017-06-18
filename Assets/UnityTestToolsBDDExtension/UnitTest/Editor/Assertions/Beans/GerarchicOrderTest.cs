using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class GerarchicOrderTest
    {
        [Test]
        [Description("CompareTo method should return 1 when the first Gerarchic Order is greater than the second one")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOIsGreaterThanTheSecondOne()
        {
            // First GerarchicOrder: Greter than the second
            GerarchicOrder greaterGerarchicOrder = new GerarchicOrder(2);

            // Second GerarchicOrder: Lower than the first
            GerarchicOrder lowerGerarchicOrder = new GerarchicOrder(1);

            // Executing CompareTO
            int result = greaterGerarchicOrder.CompareTo(lowerGerarchicOrder);

            // CompareTo should return 1
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 0 When The two Gerarchic Orders have the same value")]
        public void CompareTo_Should_ReturnZero_When_TheTwoGOHaveTheSameValue()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(0, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the first Gerarchic Order is lower than the second one")]
        public void CompareTo_Should_ReturnOneMinus_When_TheFirstGOIsLowerThanTheSecondOne()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(1);
            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the top value of the first Gerarchic Order is greather than the top value of the second Gerarchic Order and the nested values are equals")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOGreaterThanTheSecondOne_And_TheNestedOnesHaveSameValues()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(1);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 0 when the top values and the nested values of the two Gerarchic Orders are equals")]
        public void CompareTo_Should_ReturnZero_When_GOrdersAreEqualInTheMainValuesAndInTheNestedValues()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(0, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return -1 when the top value of the first Gerarchic Order is lower than the top value of the second Gerarchic Order and the nested values are equals")]
        public void CompareTo_Should_ReturnOneMinus_When_FirstGOHaveALowerMainValueThanTheOtherOneAndAnEqualNestedValue()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(1);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return 1 when the top values of the two Gerarchic Orders are equals and the nested value of the first one is greater than the nested value of the second one")]
        public void CompareTo_Should_ReturnOne_When_TheMainValuesAreEqualsAndTheFirstNestedValueIsGreaterThanTheSecondOne()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(2);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("CompareTo method should return -1 when the top values of the two Gerarchic Orders are equal and the nested value of the first one is lower than the nested value of the second one")]
        public void CompareTo_Should_ReturnOneMinus_When_TheMainValuesAreEqualsAndTheFirstNestedValueIsLowerThanTheSecondOne()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(2);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOne_When_TheMainValueOfTheFirstGOIsGreater_And_TheNestedValuesAreLowerThanTheSecondOne()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(2);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(1);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnZero_When_TheMainAndTheNestedValuesOfTheFirstGOAreAllEqualThanTheSecondOne()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(2);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(2);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(0, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOneMinus_When_TheDeeperNestedValueOfTheFirstGOIsLowerThanTheSecondOneAndTheOthersAreEqualaaaaaaaaaaaa()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(2);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(3);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOne_When_TheValuesAreEqualInTheFirstLevelAndTheFirstNestedIsGreaterThanTheSecondNested()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(2);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(1);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(3);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOneMinus_When_TheValuesAreEqualInTheFirstLevelAndTheFirstNestedIsLowerThanTheSecondNested()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(3);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(2);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(1);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOne_When_TheFirstGOHaveNotAThirdNestedGOAndTheSecondHaveItWithTheOtherValuesEqual()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(2);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(2);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);
            GerarchicOrder otherNestedNested = new GerarchicOrder(3);
            otherNested.AddAsLastElementGerarchicOrder(otherNestedNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }

        [Test]
        [Description("CompareTo method should return  when ")]
        public void CompareTo_Should_ReturnOneMinus_When_TheFirstGOHaveAThirdNestedGOAndTheSecondHaventItWithTheOtherValuesEqual()
        {
            GerarchicOrder mainGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder mainNested = new GerarchicOrder(1);
            mainGerarchicOrder.AddAsLastElementGerarchicOrder(mainNested);
            GerarchicOrder mainNestedNested = new GerarchicOrder(3);
            mainNested.AddAsLastElementGerarchicOrder(mainNestedNested);

            GerarchicOrder otherGerarchicOrder = new GerarchicOrder(2);
            GerarchicOrder otherNested = new GerarchicOrder(1);
            otherGerarchicOrder.AddAsLastElementGerarchicOrder(otherNested);

            int result = mainGerarchicOrder.CompareTo(otherGerarchicOrder);
            Assert.AreEqual(-1, result, "The comparison between the two GerarchicOrder objects returns a wrong answer");
        }
    }
}

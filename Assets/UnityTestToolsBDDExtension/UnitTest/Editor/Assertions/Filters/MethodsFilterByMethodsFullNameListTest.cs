//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByMethodsFullNameListTest.cs" company="Hud Dimension">
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
    public class MethodsFilterByMethodsFullNameListTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should return true given a Dynamic component and the GivenMethod method and a list of methods that include the GivenMethod method")]
        public void Filter_Should_ReturnTrue_Given_ADynamicComponentAndTheGivenMethodMethodAndAListOfMethodsThatIncludeTheGivenMethodMethod()
        {
            MethodsFilterByMethodsFullNameListTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByMethodsFullNameListTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");
            string[] methodsFullNamesList = new string[2] { "MethodsFilterByMethodsFullNameListTestDynamicComponent.GivenMethod", "MethodsFilterByMethodsFullNameListTestDynamicComponent.ThirdGivenMethod" };
            MethodsFilterByMethodsFullNameList methodsFilterByMethodsFullNameList = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            bool result = methodsFilterByMethodsFullNameList.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(true, result, "The method MethodsFilterByMethodsFullNameListTestDynamicComponent.Filter does not return the right answer");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should return false given a Dynamic component and the SecondGivenMethod method and a list of methods that does not include the SecondGivenMethod method")]
        public void Filter_Should_ReturnFalse_Given_ADynamicComponentAndTheSecondGivenMethodMethodAndAListOfMethodsThatDoesNotIncludeTheSecondGivenMethodMethod()
        {
            MethodsFilterByMethodsFullNameListTestDynamicComponent component = UnitTestUtility.CreateComponent<MethodsFilterByMethodsFullNameListTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("SecondGivenMethod");
            string[] methodsFullNamesList = new string[2] { "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.GivenMethod", "MethodsFilterByMethodsFullNameListUTDynamicBDDForTest.ThirdGivenMethod" };
            MethodsFilterByMethodsFullNameList methodsFilterByMethodsFullNameList = new MethodsFilterByMethodsFullNameList(methodsFullNamesList);
            bool result = methodsFilterByMethodsFullNameList.Filter<GivenBaseAttribute>(methodInfo);
            Assert.AreEqual(false, result, "The method MethodsFilterByMethodsFullNameList.Filter does not return the right answer");
        }
    }
}

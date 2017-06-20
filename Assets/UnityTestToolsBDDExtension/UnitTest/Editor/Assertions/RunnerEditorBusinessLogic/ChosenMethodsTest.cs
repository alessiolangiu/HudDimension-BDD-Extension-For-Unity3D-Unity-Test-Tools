//-----------------------------------------------------------------------
// <copyright file="ChosenMethodsTest.cs" company="Hud Dimension">
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

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ChosenMethodsTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("Clone method should return the an equal object")]
        public void Clone_Should_ReturnAnEqualObject()
        {
            ChosenMethods original = new ChosenMethods();
            original.ChosenMethodsNames = new string[3] { "Name1", "Name3", "Name2" };
            original.ChosenMethodsParametersIndex = new string[3] { "indexParameter1", "indexParameter3", "indexParameter2" };
            ChosenMethods clone = (ChosenMethods)original.Clone();
            Assert.AreEqual(original.ChosenMethodsNames, clone.ChosenMethodsNames, "the clone method for the class ChosenMethods returns a different names list");
            Assert.AreEqual(original.ChosenMethodsParametersIndex, clone.ChosenMethodsParametersIndex, "the clone method for the class ChosenMethods returns a different indexes list");
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="ComponentsFilterUT.cs" company="Hud Dimesion">
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
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ComponentsFilterUT
    {
        [Test]
        public void FilterOneDynamicComponent()
        {
            Component[] classes = new Component[2];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();
            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(BDDComponentsFilterUTDynamicBDDForTest).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        public void FilterTwoDynamicClassInOrder()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();
            classes[2] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTSecondDynamicBDDComponentForTest>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(2, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(BDDComponentsFilterUTDynamicBDDForTest).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
            Assert.IsTrue(typeof(BDDComponentsFilterUTSecondDynamicBDDComponentForTest).Equals(filteredClasses[1].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        public void FilterTwiceTheSameDynamicClassAndReceiveAnException()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();
            classes[2] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            string expectedMessage = "There are two components with the same Class Name attached to the Intregration Test. You can only have one of them:\n BDDComponentsFilterUTDynamicBDDForTest";
            DuplicateBDDComponentException ex = Assert.Throws<DuplicateBDDComponentException>(() => { bddComponentsFilter.Filter(classes); }, "The method Filter doesn't return the expected exception DuplicateBDDComponentException ");
            Assert.That(ex.Message.Equals(expectedMessage), "The method Filter doesn't return the expected exception message");
        }

        [Test]
        public void FilterOneStaticClass()
        {
            Component[] classes = new Component[2];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTStaticBDDComponentForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(BDDComponentsFilterUTStaticBDDComponentForTest).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        public void FilterOneStaticClassWithADynamicClassToo()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTStaticBDDComponentForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();
            classes[2] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(BDDComponentsFilterUTStaticBDDComponentForTest).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        public void FilterTwoStaticClassWithADynamicClassTooAndReceiveAnException()
        {
            Component[] classes = new Component[4];
            classes[0] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTStaticBDDComponentForTest>();
            classes[1] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTNoBDDComponentForTest>();
            classes[2] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTDynamicBDDForTest>();
            classes[3] = UnitTestUtility.CreateComponent<BDDComponentsFilterUTSecondStaticBDDComponentForTest>();
            
            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            string expectedMessage = "There are more than one Bdd Static Components attached.\n\nBDDComponentsFilterUTStaticBDDComponentForTest,\nBDDComponentsFilterUTSecondStaticBDDComponentForTest\n\nYou can have only one static scenario.";
            StaticBDDException ex = Assert.Throws<StaticBDDException>(() => { bddComponentsFilter.Filter(classes); }, "The method Filter doesn't return the expected exception StaticBDDException ");
            Assert.That(ex.Message.Equals(expectedMessage), "The method Filter doesn't return the expected exception message");
        }
    }
}

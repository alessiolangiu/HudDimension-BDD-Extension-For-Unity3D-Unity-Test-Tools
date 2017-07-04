//-----------------------------------------------------------------------
// <copyright file="ComponentsFilterTest.cs" company="Hud Dimension">
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
using UnityEngine;

namespace HudDimension.BDDExtensionForUnityTestTools
{
    [TestFixture]
    public class ComponentsFilterTest
    {
        [Test]
        [Description("Filter method should return only the Dynamic component given two objects with the first as Dynamic component and the second as a normal MonoBehaviour class")]
        public void Filter_Should_ReturnOnlyTheDynamicComponent_Given_TwoObjectsWithTheFirstAsDynamicComponentsAndTheSecondAsANormalMonoBehaviourClass()
        {
            Component[] classes = new Component[2];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();
            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(ComponentsFilterTestFirstDynamicComponent).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        [Description("Filter method should return only the two Dynamic components given three objects with the first and the third as Dynamic components and the second as a normal MonoBehaviour class")]
        public void Filter_Should_ReturnOnlyTheTwoDynamicComponents_Given_ThreeObjectsWithTheFirstAndTheThirdAsDynamicComponentsAndTheSecondAsANormalMonoBehaviourClass()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();
            classes[2] = UnitTestUtility.CreateComponent<ComponentsFilterTestSecondDynamicComponent>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(2, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(ComponentsFilterTestFirstDynamicComponent).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
            Assert.IsTrue(typeof(ComponentsFilterTestSecondDynamicComponent).Equals(filteredClasses[1].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        [Description("Filter method should return only the Static component given two objects with the first as Static component and the second as a normal MonoBehaviour class")]
        public void Filter_Should_ReturnOnlyTheStaticComponent_Given_TwoObjectsWithTheFirstAsStaticComponentsAndTheSecondAsANormalMonoBehaviourClass()
        {
            Component[] classes = new Component[2];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstStaticComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(ComponentsFilterTestFirstStaticComponent).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }

        [Test]
        [Description("Filter method should return only the Static component given three objects with the first as Static component and the second as a normal MonoBehaviour class and the third as a Dynamic component")]
        public void Filter_Should_ReturnOnlyTheStaticComponent_Given_ThreeObjectsWithTheFirstAsStaticComponentsAndTheSecondAsANormalMonoBehaviourClassANdTheThirdAsADynamicComponent()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstStaticComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();
            classes[2] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            Component[] filteredClasses = bddComponentsFilter.Filter(classes);

            Assert.AreEqual(1, filteredClasses.Length, "The BddComponentsFilter doesn't return the right number of classes");
            Assert.IsTrue(typeof(ComponentsFilterTestFirstStaticComponent).Equals(filteredClasses[0].GetType()), "The BddComponentsFilter doesn't return the right class");
        }
    }
}

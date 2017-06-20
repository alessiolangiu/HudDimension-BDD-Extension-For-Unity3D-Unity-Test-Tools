using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class ComponentsFilterTest
    {
        [Test(Author = "AlessioLangiu")]
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

        [Test(Author = "AlessioLangiu")]
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

        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should throw and exception given three objects with the first and the third as the same Dynamic component and the second as a normal MonoBehaviour class")]
        public void Filter_Should_ThrowAnException_Given_ThreeObjectsWithTheFirstAndTheThirdAsTheSameDynamicComponentAndTheSecondAsANormalMonoBehaviourClass()
        {
            Component[] classes = new Component[3];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();
            classes[2] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            string expectedMessage = "There are two components with the same Class Name attached to the Intregration Test. You can only have one of them:\n ComponentsFilterTestFirstDynamicComponent";
            DuplicateBDDComponentException ex = Assert.Throws<DuplicateBDDComponentException>(() => { bddComponentsFilter.Filter(classes); }, "The method Filter doesn't return the expected exception DuplicateBDDComponentException ");
            Assert.That(ex.Message.Equals(expectedMessage), "The method Filter doesn't return the expected exception message");
        }

        [Test(Author = "AlessioLangiu")]
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

        [Test(Author = "AlessioLangiu")]
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

        [Test(Author = "AlessioLangiu")]
        [Description("Filter method should throw and exception given four objects with the first and the fourth as different Static components and the second as a normal MonoBehaviour class and the third as a Dynamic component")]
        public void Filter_Should_ThrowAnException_Given_FourObjectsWithTheFirstAndTheFourthAsDifferentStaticComponentsAndTheSecondAsANormalMonoBehaviourClassAndTheThirdAsADynamicComponent()
        {
            Component[] classes = new Component[4];
            classes[0] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstStaticComponent>();
            classes[1] = UnitTestUtility.CreateComponent<ComponentsFilterTestMonoBehaviourClass>();
            classes[2] = UnitTestUtility.CreateComponent<ComponentsFilterTestFirstDynamicComponent>();
            classes[3] = UnitTestUtility.CreateComponent<ComponentsFilterTestSecondStaticComponent>();

            ComponentsFilter bddComponentsFilter = new ComponentsFilter();
            string expectedMessage = "There are more than one Bdd Static Components attached.\n\nComponentsFilterTestFirstStaticComponent,\nComponentsFilterTestSecondStaticComponent\n\nYou can have only one static scenario.";
            StaticBDDException ex = Assert.Throws<StaticBDDException>(() => { bddComponentsFilter.Filter(classes); }, "The method Filter doesn't return the expected exception StaticBDDException ");
            Assert.That(ex.Message.Equals(expectedMessage), "The method Filter doesn't return the expected exception message");
        }
    }
}

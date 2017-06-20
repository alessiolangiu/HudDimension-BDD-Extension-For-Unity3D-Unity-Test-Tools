using System.Reflection;
using NUnit.Framework;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class BaseMethodDescriptionBuilderTest
    {
        [Test(Author = "AlessioLangiu")]
        [Description("Build method should return the expected BaseMethodDescription object given a Dynamic component and a simple Given method")]
        public void Build_Should_ReturnTheExpectedBaseMethodDescriptionObject_Given_ADynamicComponentAndASimpleGivenMethod()
        {
            BaseMethodDescriptionBuilderTestDynamicComponent component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderTestDynamicComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            BaseMethodDescription expectedBaseMethodDescription = new BaseMethodDescription();
            expectedBaseMethodDescription.ComponentObject = component;
            expectedBaseMethodDescription.Method = methodInfo;
            expectedBaseMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedBaseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedBaseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription builderResult = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);

            Assert.IsTrue(expectedBaseMethodDescription.Equals(builderResult), "The method BaseMethodDescriptionBuilder.Build does not return the expected object");
            Assert.AreEqual(expectedBaseMethodDescription.Text, builderResult.Text, "The method BaseMethodDescriptionBuilder.Build does not return the expected Text");
        }

        [Test(Author = "AlessioLangiu")]
        [Description("Build method should return the expected BaseMethodDescription object given a Static component on a Given method")]
        public void Build_Should_ReturnTheExpectedBaseMethodDescriptionObject_Given_AStaticComponentOnAGivenMethod()
        {
            BaseMethodDescriptionBuilderTestStaticComponent component = UnitTestUtility.CreateComponent<BaseMethodDescriptionBuilderTestStaticComponent>();
            MethodInfo methodInfo = component.GetType().GetMethod("GivenMethod");

            BaseMethodDescription expectedBaseMethodDescription = new BaseMethodDescription();
            expectedBaseMethodDescription.ComponentObject = component;
            expectedBaseMethodDescription.Method = methodInfo;
            expectedBaseMethodDescription.StepType = typeof(GivenBaseAttribute);
            expectedBaseMethodDescription.Text = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedBaseMethodDescription.ExecutionOrder = ((IGivenWhenThenDeclaration)methodInfo.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            BaseMethodDescription builderResult = baseMethodDescriptionBuilder.Build<GivenBaseAttribute>(component, methodInfo);

            Assert.IsTrue(expectedBaseMethodDescription.Equals(builderResult), "The method BaseMethodDescriptionBuilder.Build does not return the expected object");
            Assert.AreEqual(expectedBaseMethodDescription.Text, builderResult.Text, "The method BaseMethodDescriptionBuilder.Build does not return the expected Text");
            Assert.AreEqual(expectedBaseMethodDescription.ExecutionOrder, builderResult.ExecutionOrder, "The method BaseMethodDescriptionBuilder.Build does not return the expected ExecutionOrder");
        }
    }
}

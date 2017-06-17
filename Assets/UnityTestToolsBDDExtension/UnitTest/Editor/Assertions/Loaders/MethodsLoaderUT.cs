//-----------------------------------------------------------------------
// <copyright file="MethodsLoaderUT.cs" company="Hud Dimesion">
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
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    [TestFixture]
    public class MethodsLoaderUT
    {
        [Test]
        public void FilterAllDynamicGivenMethods()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTDynamicBDDComponentForTest>() };
            BaseMethodDescription expectedMethod = new BaseMethodDescription();
            expectedMethod.ComponentObject = components[0];
            expectedMethod.Method = components[0].GetType().GetMethod("GivenMethod");
            expectedMethod.StepType = typeof(GivenBaseAttribute);
            expectedMethod.Text = ((IGivenWhenThenDeclaration)expectedMethod.Method.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod.Method.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methods = bddStepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(components);
            Assert.AreEqual(1, methods.Count, "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected amount of elements");
            Assert.IsTrue(expectedMethod.Equals(methods[0]), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
        }

        [Test]
        public void FilterAllDynamicWhenMethodsWithoutAWhenMethod()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTDynamicBDDComponentForTest>() };
            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methods = bddStepMethodsLoader.LoadStepMethods<WhenBaseAttribute>(components);
            Assert.AreEqual(0, methods.Count, "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected amount of elements");
        }

        [Test]
        public void FilterAllDynamicThenMethodsWithTwoThenMethods()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTDynamicBDDComponentForTest>() };
            BaseMethodDescription expectedMethod1 = new BaseMethodDescription();
            expectedMethod1.ComponentObject = components[0];
            expectedMethod1.Method = components[0].GetType().GetMethod("ThenMethod");
            expectedMethod1.StepType = typeof(ThenBaseAttribute);
            expectedMethod1.Text = ((IGivenWhenThenDeclaration)expectedMethod1.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod1.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod1.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescription expectedMethod2 = new BaseMethodDescription();
            expectedMethod2.ComponentObject = components[0];
            expectedMethod2.Method = components[0].GetType().GetMethod("SecondThenMethod");
            expectedMethod2.StepType = typeof(ThenBaseAttribute);
            expectedMethod2.Text = ((IGivenWhenThenDeclaration)expectedMethod2.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod2.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod2.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methods = bddStepMethodsLoader.LoadStepMethods<ThenBaseAttribute>(components);
            Assert.AreEqual(2, methods.Count, "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected amount of elements");
            BaseMethodDescription returnedMethod1 = null;
            BaseMethodDescription returnedMethod2 = null;

            if (methods[0].Method.Name.Equals(expectedMethod1.Method.Name))
            {
                returnedMethod1 = methods[0];
                returnedMethod2 = methods[1];
            }
            else
            {
                returnedMethod1 = methods[1];
                returnedMethod2 = methods[2];
            }

            Assert.IsTrue(expectedMethod1.Equals(returnedMethod1), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
            Assert.IsTrue(expectedMethod2.Equals(returnedMethod2), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
        }

        [Test]
        public void FilterAllGivenMethodsFromStaticBDDComponent()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTStaticBDDComponentForTest>() };
            BaseMethodDescription expectedMethod = new BaseMethodDescription();
            expectedMethod.ComponentObject = components[0];
            expectedMethod.Method = components[0].GetType().GetMethod("GivenMethod");
            expectedMethod.StepType = typeof(GivenBaseAttribute);
            expectedMethod.Text = ((IGivenWhenThenDeclaration)expectedMethod.Method.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod.Method.GetCustomAttributes(typeof(GivenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methods = bddStepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(components);
            Assert.AreEqual(1, methods.Count, "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected amount of elements");
            Assert.IsTrue(expectedMethod.Equals(methods[0]), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
        }

        [Test]
        public void FilterAllThenMethodsFromStaticBDDComponent()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTStaticBDDComponentForTest>() };
            BaseMethodDescription expectedMethod1 = new BaseMethodDescription();
            expectedMethod1.ComponentObject = components[0];
            expectedMethod1.Method = components[0].GetType().GetMethod("SecondThenMethod");
            expectedMethod1.StepType = typeof(ThenBaseAttribute);
            expectedMethod1.Text = ((IGivenWhenThenDeclaration)expectedMethod1.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod1.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod1.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescription expectedMethod2 = new BaseMethodDescription();
            expectedMethod2.ComponentObject = components[0];
            expectedMethod2.Method = components[0].GetType().GetMethod("ThenMethod");
            expectedMethod2.StepType = typeof(ThenBaseAttribute);
            expectedMethod2.Text = ((IGivenWhenThenDeclaration)expectedMethod2.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod2.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod2.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescription expectedMethod3 = new BaseMethodDescription();
            expectedMethod3.ComponentObject = components[0];
            expectedMethod3.Method = components[0].GetType().GetMethod("ThirdThenMethod");
            expectedMethod3.StepType = typeof(ThenBaseAttribute);
            expectedMethod3.Text = ((IGivenWhenThenDeclaration)expectedMethod3.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetStepScenarioText();
            expectedMethod3.ExecutionOrder = ((IGivenWhenThenDeclaration)expectedMethod3.Method.GetCustomAttributes(typeof(ThenBaseAttribute), true)[0]).GetExecutionOrder();

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            List<BaseMethodDescription> methods = bddStepMethodsLoader.LoadStepMethods<ThenBaseAttribute>(components);
            Assert.AreEqual(3, methods.Count, "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected amount of elements");

            BaseMethodDescription resultMethod1 = methods[0];
            BaseMethodDescription resultMethod2 = methods[1];
            BaseMethodDescription resultMethod3 = methods[2];

            Assert.IsTrue(expectedMethod1.Equals(resultMethod1), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
            Assert.IsTrue(expectedMethod2.Equals(resultMethod2), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
            Assert.IsTrue(expectedMethod3.Equals(resultMethod3), "The BDDStepMethodsFilter.FilterAllStepMethods method doesn't return the expected Method Object");
        }

        [Test]
        public void FilterAllGivenMethodsFromStaticBDDComponentWithAJumpOfExecutionOrder()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTStaticBDDComponentWithOneGivenMissingForTest>() };

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            Assert.Throws<StaticBDDException>(() => { bddStepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(components); });
        }

        [Test]
        public void FilterAllGivenMethodsFromStaticBDDComponentWithADoubleExecutionOrder()
        {
            Component[] components = new Component[1] { UnitTestUtility.CreateComponent<BDDStepMethodsLoaderUTStaticBDDComponentWithTwoFirstGivenForTest>() };

            BaseMethodDescriptionBuilder baseMethodDescriptionBuilder = new BaseMethodDescriptionBuilder();
            MethodsFilterByStepType methodsFilterByStepType = new MethodsFilterByStepType();
            MethodsLoader bddStepMethodsLoader = new MethodsLoader(baseMethodDescriptionBuilder, methodsFilterByStepType);
            Assert.Throws<StaticBDDException>(() => { bddStepMethodsLoader.LoadStepMethods<GivenBaseAttribute>(components); });
        }
    }
}

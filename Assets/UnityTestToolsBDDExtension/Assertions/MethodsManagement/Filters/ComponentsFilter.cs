//-----------------------------------------------------------------------
// <copyright file="ComponentsFilter.cs" company="Hud Dimesion">
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
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class ComponentsFilter
    {
        public virtual Component[] Filter(Component[] components)
        {
            List<Component> bddComponentsList = Filter(typeof(StaticBDDComponent), components);

            if (bddComponentsList.Count() == 0)
            {
                bddComponentsList = Filter(typeof(DynamicBDDComponent), components);
                Dictionary<string, string> duplicationDictionary = new Dictionary<string, string>();
                foreach (Component component in bddComponentsList)
                {
                    if (duplicationDictionary.ContainsKey(component.GetType().Name))
                    {
                        string message = "There are two components with the same Class Name attached to the Intregration Test. You can only have one of them:\n " + component.GetType().Name;
                        throw new DuplicateBDDComponentException(message);
                    }
                    else
                    {
                        duplicationDictionary.Add(component.GetType().Name, component.GetType().Name);
                    }
                }
            }
            else if (bddComponentsList.Count() > 1)
            {
                string classList = GetClassList(bddComponentsList);
                string message = "There are more than one Bdd Static Components attached.\n\n" + classList + "\n\nYou can have only one static scenario.";
                throw new StaticBDDException(message);
            }

            return bddComponentsList.ToArray();
        }

        private static string GetClassList(List<Component> bddComponentsist)
        {
            string result = string.Empty;
            foreach (Component component in bddComponentsist)
            {
                if (!result.Equals(string.Empty))
                {
                    result += ",\n";
                }

                result += component.GetType().Name;
            }

            return result;
        }

        private static List<Component> Filter(Type bddComponentDeclaration, Component[] components)
        {
            List<Component> bddComponentsList = new List<Component>();
            foreach (Component component in components)
            {
                if (bddComponentDeclaration.IsAssignableFrom(component.GetType()))
                {
                    bddComponentsList.Add(component);
                }
            }

            return bddComponentsList;
        }
    }
}

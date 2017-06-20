//-----------------------------------------------------------------------
// <copyright file="MethodsFilterByMethodsFullNameList.cs" company="Hud Dimension">
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

namespace HudDimension.UnityTestBDD
{
    public class MethodsFilterByMethodsFullNameList : IMethodsFilter
    {
        private string[] methodsFullNamesList = null;

        public MethodsFilterByMethodsFullNameList(string[] methodsFullNamesList)
        {
            this.methodsFullNamesList = methodsFullNamesList;
        }

        public bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration
        {
            foreach (string methodFullName in this.methodsFullNamesList)
            {
                if (methodFullName.Equals(method.DeclaringType.Name + "." + method.Name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

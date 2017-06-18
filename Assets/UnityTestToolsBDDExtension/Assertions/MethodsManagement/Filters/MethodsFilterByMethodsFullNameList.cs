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

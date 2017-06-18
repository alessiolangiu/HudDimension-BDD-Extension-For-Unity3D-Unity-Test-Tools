using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodsFilterByStepType : IMethodsFilter
    {
        public bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration
        {
            if (method.GetCustomAttributes(typeof(T), true).Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}

using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public class MethodsFilterByExecutionOrder : IMethodsFilter
    {
        public bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration
        {
            if (!typeof(StaticBDDComponent).IsAssignableFrom(method.DeclaringType))
            {
                return false;
            }

            object[] attributes = method.GetCustomAttributes(typeof(T), true);
            if (attributes.Length > 0)
            {
                return true;
            }

            return false;
        }
    }
}

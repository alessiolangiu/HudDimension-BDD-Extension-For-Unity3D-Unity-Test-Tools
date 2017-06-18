using System.Reflection;

namespace HudDimension.UnityTestBDD
{
    public interface IMethodsFilter
    {
        bool Filter<T>(MethodInfo method) where T : IGivenWhenThenDeclaration;
    }
}

using System;

namespace HudDimension.UnityTestBDD
{
    public static class StepMethodUtilities
    {
        public static string GetStepMethodName<T>() where T : IGivenWhenThenDeclaration
        {
            IGivenWhenThenDeclaration declaration = Activator.CreateInstance(typeof(T), string.Empty) as IGivenWhenThenDeclaration;
            string result = declaration.GetStepName();
            return result;
        }
    }
}

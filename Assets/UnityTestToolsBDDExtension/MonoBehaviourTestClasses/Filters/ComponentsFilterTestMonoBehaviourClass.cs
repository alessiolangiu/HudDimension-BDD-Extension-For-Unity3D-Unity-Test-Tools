using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public class ComponentsFilterTestMonoBehaviourClass : MonoBehaviour
    {
        public IAssertionResult GivenMethod(string stringParam)
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult WhenMethod()
        {
            return new AssertionResultSuccessful();
        }

        public IAssertionResult ThenMethod()
        {
            return new AssertionResultSuccessful();
        }
    }
}

using UnityEngine;

namespace HudDimension.UnityTestBDD
{
    public static class UnitTestUtility
    {
        public static T CreateComponent<T>() where T : MonoBehaviour
        {
            GameObject gameObject = new GameObject();
            T component = gameObject.AddComponent<T>();
            return component;
        }
    }
}
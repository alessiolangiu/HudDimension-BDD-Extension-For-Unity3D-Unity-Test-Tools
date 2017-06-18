using UnityEditor;

namespace HudDimension.UnityTestBDD
{
    public class SerializedObjectWrapper : ISerializedObjectWrapper
    {
        private SerializedObject serializedObject;

        public SerializedObjectWrapper(UnityEngine.Object component)
        {
            this.serializedObject = new SerializedObject(component);
        }

        public void ApplyModifiedProperties()
        {
            this.serializedObject.ApplyModifiedProperties();
        }

        public ISerializedPropertyWrapper FindProperty(string parameterLocationString)
        {
            SerializedProperty property = this.serializedObject.FindProperty(parameterLocationString);
            ISerializedPropertyWrapper propertyWrapper = new SerializedPropertyWrapper(property);
            return propertyWrapper;
        }

        public void Update()
        {
            this.serializedObject.Update();
        }
    }
}

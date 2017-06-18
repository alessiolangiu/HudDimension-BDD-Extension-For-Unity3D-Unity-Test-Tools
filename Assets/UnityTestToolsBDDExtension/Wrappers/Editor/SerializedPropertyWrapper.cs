using UnityEditor;

namespace HudDimension.UnityTestBDD
{
    public class SerializedPropertyWrapper : ISerializedPropertyWrapper
    {
        public SerializedPropertyWrapper(SerializedProperty property)
        {
            this.Property = property;
        }

        private SerializedProperty Property { get; set; }

        public SerializedProperty GetProperty()
        {
            return this.Property;
        }
    }
}

namespace HudDimension.UnityTestBDD
{
    public class SerializedObjectWrapperBuilder
    {
        private GetInstanceOfISerializedObjectWrapper serializedObjectWrapperBuilderDelegate;

        public SerializedObjectWrapperBuilder(GetInstanceOfISerializedObjectWrapper serializedObjectWrapperBuilderDelegate)
        {
            this.serializedObjectWrapperBuilderDelegate = serializedObjectWrapperBuilderDelegate;
        }

        public delegate ISerializedObjectWrapper GetInstanceOfISerializedObjectWrapper(UnityEngine.Object component);

        public ISerializedObjectWrapper Build(UnityEngine.Object component)
        {
            return this.serializedObjectWrapperBuilderDelegate(component);
        }
    }
}

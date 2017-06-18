namespace HudDimension.UnityTestBDD
{
    public interface ISerializedObjectWrapper
    {
        ISerializedPropertyWrapper FindProperty(string parameterLocationString);

        void Update();

        void ApplyModifiedProperties();
    }
}
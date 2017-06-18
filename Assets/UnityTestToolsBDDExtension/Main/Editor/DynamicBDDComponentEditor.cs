using UnityEditor;

namespace HudDimension.UnityTestBDD
{
    [CustomEditor(typeof(DynamicBDDComponent), true)]
    public class DynamicBDDComponentEditor : BaseBDDComponentEditor
    {
        private string customMainTexturePath = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\HudDimensionDynamicComponentSprite.png";

        private void OnEnable()
        {
            this.TexturePath = this.customMainTexturePath;
        }
    }
}

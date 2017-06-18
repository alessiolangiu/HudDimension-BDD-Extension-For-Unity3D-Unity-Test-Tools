using UnityEditor;

namespace HudDimension.UnityTestBDD
{
    [CustomEditor(typeof(StaticBDDComponent), true)]
    public class StaticBDDComponentEditor : BaseBDDComponentEditor
    {
        private string customMainTexturePath = @"Assets\UnityTestToolsBDDExtension\Resources\Sprites\HudDimensionStaticComponentSprite.png";

        private void OnEnable()
        {
            this.TexturePath = this.customMainTexturePath;
        }
    }
}
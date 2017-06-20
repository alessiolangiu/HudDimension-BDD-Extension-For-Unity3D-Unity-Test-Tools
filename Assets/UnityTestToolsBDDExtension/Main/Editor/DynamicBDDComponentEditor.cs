//-----------------------------------------------------------------------
// <copyright file="DynamicBDDComponentEditor.cs" company="Hud Dimension">
//     Copyright (c) Hud Dimension. All rights reserved.
//     http://www.HudDimension.co.uk
// </copyright>
//
// <disclaimer>
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </disclaimer>
//
// <author>Alessio Langiu</author>
// <email>alessio.langiu@huddimension.co.uk</email>
//-----------------------------------------------------------------------
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

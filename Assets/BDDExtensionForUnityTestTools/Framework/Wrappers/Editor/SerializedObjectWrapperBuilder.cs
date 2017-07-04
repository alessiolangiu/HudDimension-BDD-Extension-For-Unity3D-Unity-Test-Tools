//-----------------------------------------------------------------------
// <copyright file="SerializedObjectWrapperBuilder.cs" company="Hud Dimension">
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
namespace HudDimension.BDDExtensionForUnityTestTools
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

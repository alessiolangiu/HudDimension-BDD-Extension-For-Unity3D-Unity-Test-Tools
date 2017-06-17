﻿//-----------------------------------------------------------------------
// <copyright file="SerializedObjectWrapperBuilder.cs" company="Hud Dimesion">
//     Copyright (c) Hud Dimension. All rights reserved.
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
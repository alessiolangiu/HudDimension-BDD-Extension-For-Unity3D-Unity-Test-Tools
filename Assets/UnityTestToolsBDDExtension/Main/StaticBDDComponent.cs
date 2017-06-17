//-----------------------------------------------------------------------
// <copyright file="StaticBDDComponent.cs" company="Hud Dimesion">
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
using System;

namespace HudDimension.UnityTestBDD
{
    public class StaticBDDComponent : BaseBDDComponent
    {
        [AttributeUsage(System.AttributeTargets.Method)]
        public class Given : GivenBaseAttribute
        {
            public Given(uint executionOrder, string text) : base(text)
            {
                this.ExecutionOrder = executionOrder;
            }

            public uint ExecutionOrder { get; set; }

            public override uint GetExecutionOrder()
            {
                return this.ExecutionOrder;
            }
        }

        [AttributeUsage(System.AttributeTargets.Method)]
        public class When : WhenBaseAttribute
        {
            public When(uint executionOrder, string text) : base(text)
            {
                this.ExecutionOrder = executionOrder;
            }

            public uint ExecutionOrder { get; set; }

            public override uint GetExecutionOrder()
            {
                return this.ExecutionOrder;
            }
        }

        [AttributeUsage(System.AttributeTargets.Method)]
        public class Then : ThenBaseAttribute
        {
            public Then(uint executionOrder, string text) : base(text)
            {
                this.ExecutionOrder = executionOrder;
            }

            public uint ExecutionOrder { get; set; }

            public override uint GetExecutionOrder()
            {
                return this.ExecutionOrder;
            }
        }
    }
}

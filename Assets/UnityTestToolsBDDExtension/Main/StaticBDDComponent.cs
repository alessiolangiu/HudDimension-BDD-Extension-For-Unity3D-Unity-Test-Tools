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

//-----------------------------------------------------------------------
// <copyright file="CallBefore.cs" company="Hud Dimension">
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
using System;

namespace HudDimension.UnityTestBDD
{
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
    public class CallBefore : Attribute
    {
        private string id = string.Empty;

        public CallBefore(uint executionOrder, string method)
        {
            this.ExecutionOrder = executionOrder;
            this.Method = method;
        }

        public uint ExecutionOrder { get; set; }

        public uint Delay { get; set; }

        public string Method { get; set; }

        private uint timeout = 3000;

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public uint Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                this.timeout = value;
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += "[CallBefore( " + this.ExecutionOrder + " \"" + this.Method + "\"";
            if (this.Delay != 0)
            {
                result += " Delay =" + this.Delay;
            }

            if (this.Timeout != 0)
            {
                result += " Timeout =" + this.Timeout;
            }

            if (!this.Id.Equals(string.Empty))
            {
                result += " Id =\"" + this.Id + "\"";
            }

            result += ")]";
            return result;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="GerarchicOrder.cs" company="Hud Dimesion">
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
    public class GerarchicOrder : IComparable<GerarchicOrder>
    {
        public GerarchicOrder(uint order)
        {
            this.Order = order;
        }

        private uint Order { get; set; }

        private GerarchicOrder NestedGerarchicOrder { get; set; }

        public void AddAsLastElementGerarchicOrder(GerarchicOrder lastElement)
        {
            if (this.NestedGerarchicOrder != null)
            {
                this.NestedGerarchicOrder.AddAsLastElementGerarchicOrder(lastElement);
            }
            else
            {
                this.NestedGerarchicOrder = lastElement;
            }
        }

        public int CompareTo(GerarchicOrder other)
        {
            if (this.Order < other.Order)
            {
                return -1;
            }

            if (this.Order > other.Order)
            {
                return +1;
            }

            if (this.NestedGerarchicOrder == null && other.NestedGerarchicOrder == null)
            {
                return 0;
            }

            if (this.NestedGerarchicOrder == null && other.NestedGerarchicOrder != null)
            {
                return 1;
            }

            if (this.NestedGerarchicOrder != null && other.NestedGerarchicOrder == null)
            {
                return -1;
            }

            return this.NestedGerarchicOrder.CompareTo(other.NestedGerarchicOrder);
        }
    }
}

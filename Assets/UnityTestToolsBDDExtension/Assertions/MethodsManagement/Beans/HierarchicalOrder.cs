//-----------------------------------------------------------------------
// <copyright file="HierarchicalOrder.cs" company="Hud Dimension">
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
    public class HierarchicalOrder : IComparable<HierarchicalOrder>
    {
        public HierarchicalOrder(uint order)
        {
            this.Order = order;
        }

        private uint Order { get; set; }

        private HierarchicalOrder NestedHierarchicalOrder { get; set; }

        public void AddAsLastElementHierarchicalOrder(HierarchicalOrder lastElement)
        {
            if (this.NestedHierarchicalOrder != null)
            {
                this.NestedHierarchicalOrder.AddAsLastElementHierarchicalOrder(lastElement);
            }
            else
            {
                this.NestedHierarchicalOrder = lastElement;
            }
        }

        public int CompareTo(HierarchicalOrder other)
        {
            if (this.Order < other.Order)
            {
                return -1;
            }

            if (this.Order > other.Order)
            {
                return +1;
            }

            if (this.NestedHierarchicalOrder == null && other.NestedHierarchicalOrder == null)
            {
                return 0;
            }

            if (this.NestedHierarchicalOrder == null && other.NestedHierarchicalOrder != null)
            {
                return 1;
            }

            if (this.NestedHierarchicalOrder != null && other.NestedHierarchicalOrder == null)
            {
                return -1;
            }

            return this.NestedHierarchicalOrder.CompareTo(other.NestedHierarchicalOrder);
        }
    }
}

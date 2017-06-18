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

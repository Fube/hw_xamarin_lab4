using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class TipModel
    {
        public decimal Bill;
        public decimal Tip;
        public int Guests;
        public decimal Total 
        {
            get
            {
                return Bill + TotalTip;
            }
        }

        public decimal TotalTip
        {
            get
            {
                return Tip * (1 + Guests / 100m);
            }
        }

        public void Clear()
        {
            Bill = Tip = default;
            Guests = default;
        }
    }
}

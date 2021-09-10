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
                return Bill + Tip;
            }
        }

        public decimal TotalTip
        {
            get
            {
                return Total * (1 + Guests / 100);
            }
        }

        public void Clear()
        {
            Bill = Tip = default;
            Guests = default;
        }
    }
}

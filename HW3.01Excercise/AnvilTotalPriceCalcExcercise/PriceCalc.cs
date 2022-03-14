using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnvilTotalPriceCalcExcercise
{
    public class PriceCalc
    {
        public static double CalcPricePerAnvil(int quantity, double regPrice)
        {
            // Calculates the volume discount for some quantity of anvils at some regular price
            // Expected discount:
            // - 1 - 9 anvils:      regular price.
            // - 10 - 19 anvils:    10% discount.
            // - 20 or more anvils: 20% discount.
            //
            //  If either quantity or regPrice is <= 0, discount price should return 0


            double discPrice = 0;

            if (quantity >= 20)
            {
                discPrice = regPrice * .8;
            }
            else if (quantity >= 10 && quantity < 20)
            {
                discPrice = regPrice * .9;
            }
            else if (quantity > 0 && quantity < 10)
            {
                discPrice = regPrice;
            }
            else
            {
                discPrice = 0;
            }
            return discPrice;
        }

        public static double CalcShippingCostPerAnvil(int zone)
        {
            //Return cost for requested shipping zone.
            //Zones are 1 - 3:
            //    Zone 1: $10 per anvil.
            //    Zone 2: $20 per anvil.
            //    Zone 3: $30 per anvil.
            //
            //IndexOutOfRange exception if zone is not represented in array.
            if (zone > 2 || zone < 0)
            {
                throw new IndexOutOfRangeException("Index Out of Range");
            }

            int[] zoneCost = new int[] { 10, 20, 30 };
            return zoneCost[zone];
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACP
{
    public class InventoryCostCalculator
    {
        /// <summary>
        /// Calculates the inventory cost based on various parameters
        /// </summary>
        /// <param name="costPrice">The original cost price</param>
        /// <param name="itemTaxPercent">Tax percentage for the item</param>
        /// <param name="discountPercent">Discount percentage (use 1 for 100%, 0.5 for 50%, etc.)</param>
        /// <param name="factor">Factor value (default is 1 if not applicable)</param>
        /// <param name="isFactorEnabled">Whether the factor calculation should be applied</param>
        /// <returns>Calculated inventory cost rounded to 2 decimal places</returns>
        public static decimal CalculateInventoryCost(decimal costPrice, decimal itemTaxPercent,
            decimal discountPercent, decimal factor, bool isFactorEnabled)
        {
            // Validate inputs
            if (costPrice < 0)
            {
                throw new ArgumentException("Cost price cannot be negative", "costPrice");
            }
            if (itemTaxPercent < 0)
            {
                throw new ArgumentException("Tax percentage cannot be negative", "itemTaxPercent");
            }
            if (factor <= 0)
            {
                throw new ArgumentException("Factor must be greater than zero", "factor");
            }

            // Calculate tax divisor
            decimal taxDivisor = (itemTaxPercent + 100m) / 100m;

            // Calculate inventory cost based on different scenarios
            decimal inventoryCost;

            if (!isFactorEnabled)
            {
                if (discountPercent == 0)
                {
                    // No factor, no discount
                    inventoryCost = costPrice / taxDivisor;
                }
                else
                {
                    // No factor, with discount
                    inventoryCost = (costPrice * discountPercent) / taxDivisor;
                }
            }
            else
            {
                if (discountPercent == 0)
                {
                    // With factor, no discount
                    inventoryCost = (costPrice / factor) / taxDivisor;
                }
                else
                {
                    // With factor and discount
                    inventoryCost = ((costPrice * discountPercent) / factor) / taxDivisor;
                }
            }

            return decimal.Round(inventoryCost, 2);
        }

        /// <summary>
        /// Overloaded method that provides default values for factor and isFactorEnabled
        /// </summary>
        public static decimal CalculateInventoryCost(decimal costPrice, decimal itemTaxPercent,
            decimal discountPercent)
        {
            return CalculateInventoryCost(costPrice, itemTaxPercent, discountPercent, 1m, false);
        }
    }
}

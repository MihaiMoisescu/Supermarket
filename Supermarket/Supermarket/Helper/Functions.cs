using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Helper
{
    internal class Functions
    {
        public static decimal? GetSellingPrice(decimal? purchasePrice)
        {
            string pricePercentageString = ConfigurationManager.AppSettings["PricePercentage"];

            int percentage= int.Parse(pricePercentageString);

            decimal? price = purchasePrice + purchasePrice * percentage / 100;

            return price;
        }
    }
}

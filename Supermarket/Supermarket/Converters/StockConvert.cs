using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Supermarket.Converters
{
    internal class StockConvert :IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
                    //< Binding ElementName = "comboboxProduct" Path = "SelectedItem.ProductID" />
                    //< Binding ElementName = "txtQuantity" Path = "Text" />
                    //< Binding ElementName = "Unit" Path = "Text" />
                    //< Binding ElementName = "dateSupply" Path = "SelectedDate" />
                    //< Binding ElementName = "dateExpiration" Path = "SelectedDate" />
            if (values == null || values.Length < 6)
                return null;

            string productID = values[0]?.ToString();
            string quantityString = values[1]?.ToString();
            string unit = values[2]?.ToString();
            string priceString = values[3]?.ToString();
            string dateSupply = values[4]?.ToString();
            string dateExpiration= values[5]?.ToString();


            int productIDInt;
            int quantityInt;
            decimal price;
            if (string.IsNullOrWhiteSpace(quantityString) || string.IsNullOrWhiteSpace(unit))
                return null;

            bool isProductIDParsed = int.TryParse(productID, out productIDInt);
            bool isQuantityParsed = int.TryParse(quantityString, out quantityInt);
            bool isPriceParsed = decimal.TryParse(priceString, out price);
            if (!isProductIDParsed&& !isQuantityParsed &&!isPriceParsed)
            {
                return null;
            }
            DateTime supplyDate;
            DateTime expirationDate;

            bool isExpirationParsed= DateTime.TryParse(dateExpiration, out expirationDate);
            bool isSupplyDateParsed=DateTime.TryParse(dateSupply, out supplyDate);
            if(!isSupplyDateParsed&& !isExpirationParsed) { return null; }
            return new Stock()
            {
                ProductID = productIDInt,
                Quantity = quantityInt,
                Unit = unit,
                PurchasePrice = price,
                DateOfSupply = supplyDate,
                ExpirationDate = expirationDate,
                SellingPrice = 0,

            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

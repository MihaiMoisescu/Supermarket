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
    internal class ProductConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 4)
                return null;

            string name = values[0]?.ToString();
            string barcode = values[1]?.ToString();
            string categoryIDString = values[2]?.ToString();
            string producerIDString = values[3]?.ToString();

            int categoryID;
            int producerID;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(barcode))
                return null;

            bool isCategoryIDParsed = int.TryParse(categoryIDString, out categoryID);
            bool isProducerIDParsed = int.TryParse(producerIDString, out producerID);
            if (!isCategoryIDParsed  && !isProducerIDParsed)
            {
                return null;
            }
            return new Product()
            {
                Name = name,
                Barcode = barcode,
                ProducerID = producerID,
                CategoryID = categoryID
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

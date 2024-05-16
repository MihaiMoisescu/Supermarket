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
            bool isActive = false;
            if (values[3].ToString() != null)
            {
                if (values[3].ToString() == "True")
                    isActive = true;
                else
                    isActive = false;
            }
            return new Product()
            {
                Name = values[0].ToString(),
                Barcode = values[1].ToString(),
                IsActive = isActive,
                CategoryID = int.Parse(values[3].ToString()),
                ProducerID= int.Parse(values[4].ToString())
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

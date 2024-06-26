﻿using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Supermarket.Converters
{
    class AccountConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isActive=false;
            if (values[3].ToString() != null) {
                if (values[3].ToString() == "True")
                    isActive = true;
                else
                    isActive = false;
                    }
            return new Account()
            {
                Username = values[0].ToString(),
                Password = values[1].ToString(),
                Role = values[2].ToString(),
                IsActive = isActive
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

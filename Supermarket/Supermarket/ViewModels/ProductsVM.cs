using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    internal class ProductsVM : BasePropertyChanged
    {
        private ProductsBLL _productsBLL;

        private string _errorMessage;

        public ProductsVM()
        {
            _productsBLL = new ProductsBLL();
            ProductsList = _productsBLL.GetAllProducts();

        }
        public ObservableCollection<Product> ProductsList
        {
            get => _productsBLL.ProductsList;
            set
            {
                _productsBLL.ProductsList = value;
                NotifyPropertyChanged(nameof(ProductsList));
            }
        }
    }
}

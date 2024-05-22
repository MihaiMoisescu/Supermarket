using Supermarket.Helper;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class CategoryPricesVM : BasePropertyChanged
    {
        private CategoryPricesBLL _categoryPricesBLL;
        private CategoryBLL _categoryBLL;
        private int _categoryID;
        private ICommand _sum;
        private string _totalPrice;
        public CategoryPricesVM()
        {
            
            CategoryIDBox = 0;
            _categoryBLL = new CategoryBLL();
            _categoryPricesBLL = new CategoryPricesBLL();
            CategoryList = _categoryBLL.GetAllCategories();

        }
        public ObservableCollection<Category> CategoryList
        {
            get => _categoryBLL.CategoryList;
            set
            {
                _categoryBLL.CategoryList = value;
                NotifyPropertyChanged(nameof(CategoryList));
            }
        }
        public int CategoryIDBox
        {
            get => _categoryID;
            set
            {
                _categoryID = value;
                NotifyPropertyChanged(nameof(CategoryIDBox));
            }
        }
        public string TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged(nameof(TotalPrice));
            }
        }
        public void SUM(object obj)
        {
            _categoryPricesBLL.GetCategoryPrices(CategoryIDBox);
            TotalPrice =_categoryPricesBLL.totalPrice;
        }
        public ICommand GetSum
        {
            get
            {
                if (_sum == null)
                    _sum = new RelayCommand(SUM);
                return _sum;
            }
        }
    }
}

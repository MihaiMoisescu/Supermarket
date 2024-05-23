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
    public class SearchProductVM :BasePropertyChanged
    {
        private SearchProductsBLL _searchProductsBLL;
        private ProducerBLL _producerBLL;
        private CategoryBLL _categoryBLL;
        private string _productName;
        private string _barcode;
        private string _expirationDate;
        private string _producerName;
        private string _categoryName;
        private ICommand _searchCommand;

        public SearchProductVM()
        {
            _searchProductsBLL = new SearchProductsBLL();
            _categoryBLL = new CategoryBLL();
            _producerBLL = new ProducerBLL();
           
            ProducersList = _producerBLL.GetAllProducers();
            CategoryList = _categoryBLL.GetAllCategories();
        }

        public ObservableCollection<SearchProduct_Result> SearchResults {
            get => _searchProductsBLL.SearchProducts;
            set
            {
                _searchProductsBLL.SearchProducts = value;
                NotifyPropertyChanged(nameof(SearchResults));
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                NotifyPropertyChanged(nameof(ProductName));
            }

        }
        public string Barcode
        {
            get
            {
                return _barcode;
            }
            set
            {
                _barcode = value;
                NotifyPropertyChanged(nameof(Barcode));
            }
        }
        public string ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                _expirationDate = value;
                NotifyPropertyChanged(nameof(ExpirationDate));
            }
        }
        public string ProducerName
        {
            get
            {
                return _producerName;
            }
            set
            {
                _producerName = value;
                NotifyPropertyChanged(nameof(ProducerName));
            }
        }
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                NotifyPropertyChanged(nameof(CategoryName));
            }
        }
        public ObservableCollection<Producer> ProducersList
        {
            get=>_producerBLL.ProducersList;
            set
            {
                _producerBLL.ProducersList = value;
                NotifyPropertyChanged(nameof(ProducersList));
            }
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

        public void Search(object obj)
        {
            SearchResults = _searchProductsBLL.GetSearchResults(ProductName, Barcode, ExpirationDate, ProducerName, CategoryName);
        }
        public ICommand SearchCommand
        {
            get
            {
                if(_searchCommand == null) { 
                    _searchCommand=new RelayCommand(Search);
                }
                return _searchCommand;
            }
        }
    }
}

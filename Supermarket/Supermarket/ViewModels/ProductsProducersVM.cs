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
    public class ProductsProducersVM :BasePropertyChanged
    {
        private ProducerBLL _producerBLL;
        private ProductsBLL _productBLL;
        private CategoryBLL _categoryBLL;
        private string _errorMessage;
        private int _producerID;
        private int _categoryID;
        private ICommand _getProductsCommand;
        public ProductsProducersVM()
        {
            ProducerIDBox = 0;
            CategoryIDBox = 0;
            _producerBLL = new ProducerBLL();
            _productBLL = new ProductsBLL();
            _categoryBLL = new CategoryBLL();
            Products = _productBLL.GetProductsFromProducer(_producerID,_categoryID);
            ProducersList = _producerBLL.GetAllProducers();
            CategoryList = _categoryBLL.GetAllCategories();
        }
        public ObservableCollection<GetProductsFromProducer_Result> Products
        {
            get => _productBLL.GetProductsFromProducer(_producerID, _categoryID);

            set
            {
                NotifyPropertyChanged(nameof(Products));
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
        public ObservableCollection<Producer>ProducersList 
        { 
            get =>_producerBLL.ProducersList;
            set 
            {
                _producerBLL.ProducersList = value;
                NotifyPropertyChanged(nameof(ProducersList));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }
        public int ProducerIDBox
        {
            get
            {
                return _producerID;
            }
            set
            {
                _producerID = value;
                NotifyPropertyChanged(nameof(ProducerIDBox));
            }
        }
        public int CategoryIDBox
        {
            get
            {
                return _categoryID;
            }
            set
            {
                _categoryID = value;
                NotifyPropertyChanged(nameof(CategoryIDBox));
            }
        }
        public void ProductsCommand(object obj)
        {
            Products=_productBLL.GetProductsFromProducer(ProducerIDBox, CategoryIDBox);

        }
        public ICommand GetProducts
        {
            get 
            {
                if (_getProductsCommand == null)
                    _getProductsCommand = new RelayCommand(ProductsCommand);
                return _getProductsCommand;
            }
        }
        
    }
}

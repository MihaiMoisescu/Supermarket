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
    internal class ProductsVM : BasePropertyChanged
    {
        private ProductsBLL _productsBLL;
        private CategoryBLL _categoryBLL;
        private ProducerBLL _producerBLL;

        private string _errorMessage;

        #region Members
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }
        public ProductsVM()
        {
            _productsBLL = new ProductsBLL();
            _categoryBLL = new CategoryBLL();
            _producerBLL = new ProducerBLL();
            ProductsList = _productsBLL.GetAllProducts();
            ProducersList = _producerBLL.GetAllProducers();
            CategoryList = _categoryBLL.GetAllCategories();

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
        public ObservableCollection<Producer> ProducersList
        {
            get => _producerBLL.ProducersList;
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
        #endregion

        #region Commands
        private ICommand deleteCommand;
        private ICommand addCommand;
        public void Delete(object obj)
        {
            _productsBLL.DeleteProduct(obj);
            ErrorMessage = _productsBLL.ErrorMessage;
            ProductsList = _productsBLL.GetAllProducts();

        }
        public ICommand DeleteProduct
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(Delete);
                return deleteCommand;
            }
        }
        public void Add(object obj)
        {
            _productsBLL.AddProduct(obj);
            ErrorMessage = _productsBLL.ErrorMessage;
            ProductsList=_productsBLL.GetAllProducts();
        }
        public ICommand AddProduct
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(Add);
                }
                return addCommand;
            }
        }
        #endregion
    }
}

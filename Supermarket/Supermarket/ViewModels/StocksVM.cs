using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Helper;
using System.Windows.Input;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    internal class StocksVM :BasePropertyChanged
    {
        private StockBLL _stockBLL;
        private ProductsBLL _productsBLL;
        private string _errorMessage;

        public StocksVM()
        {
            _stockBLL = new StockBLL();
            _productsBLL = new ProductsBLL();
            StocksList = _stockBLL.GetAllStocks();
            ProductList = _productsBLL.GetAllProducts();
        }

        public ObservableCollection<Stock> StocksList
        {
            get=> _stockBLL.StocksList;
            set
            {
                _stockBLL.StocksList = value;
                NotifyPropertyChanged(nameof(StocksList));
            }
        }
        public ObservableCollection<Product> ProductList
        {
            get => _productsBLL.ProductsList;
            set
            {
                _productsBLL.ProductsList = value;
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
        
        public void Add(object obj)
        {
            _stockBLL.AddStock(obj);
            ErrorMessage=_stockBLL.ErrorMessage;
            StocksList = _stockBLL.GetAllStocks();
        }
        public void Delete(object obj)
        {
            _stockBLL.DeleteStock(obj);
            ErrorMessage=_stockBLL.ErrorMessage;
            StocksList= _stockBLL.GetAllStocks();
        }
        public void Update(object obj)
        {
            UpdatePriceStockView updatePriceStockView = new UpdatePriceStockView();
            updatePriceStockView.ShowDialog();
        }
        private ICommand addCommand;
        private ICommand deleteCommand;
        private ICommand updateCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(Add);
                return addCommand;
            }
        }

        public ICommand DeleteStock
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(Delete);
                return deleteCommand;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if(updateCommand == null)
                    updateCommand = new RelayCommand(Update);
                return updateCommand;
            }
        }
        
    }
}

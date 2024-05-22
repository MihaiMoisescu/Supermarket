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
    public class UpdatePriceStockVM:BasePropertyChanged
    {
        private StockBLL _stockbll;
        private string _errorMessage;
        public UpdatePriceStockVM()
        {
            _stockbll = new StockBLL();
            StocksList = _stockbll.GetAllStocks();
        }
        public ObservableCollection<Stock> StocksList
        {
            get => _stockbll.StocksList;
            set
            {
                _stockbll.StocksList = value;
                NotifyPropertyChanged(nameof(StocksList));
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
        public void Update(object obj)
        {
            _stockbll.UpdateStock(obj);
            ErrorMessage=_stockbll.ErrorMessage;
            StocksList = _stockbll.GetAllStocks();

        }
        private ICommand updateCommand;

        public ICommand UpdateStock
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(Update);
                return updateCommand;
            }
        }

    }
}

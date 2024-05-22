using Supermarket.Helper;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    class AdministratorVM
    {
        private ICommand _userCommand;
        private ICommand _productCommand;
        private ICommand _stockCommand;
        private ICommand _producersCommand;
        private ICommand _moreOptionsCommand;

        #region Commands

        public void UsersInterface(object obj)
        {
            AccountsView accountsView = new AccountsView();
            accountsView.ShowDialog();
        }
        public void ProductsInterface(object obj)
        {
            ProductsView productsView = new ProductsView();
            productsView.ShowDialog();
        }
        public void ProducersInterface(object obj)
        {
            ProducersView producersView = new ProducersView();
            producersView.ShowDialog();
        }

        public void StocksInterface(object obj)
        {
            StocksView stocksView = new StocksView();
            stocksView.ShowDialog();
        }
        public void MoreOptionsInterface(object obj)
        {
            MoreOptionsView moreOptionsView = new MoreOptionsView();
            moreOptionsView.ShowDialog();
        }

        public ICommand ProducersCommand
        {
            get
            {
                if (_producersCommand == null)
                    _producersCommand = new RelayCommand(ProducersInterface);
                return _producersCommand;
            }
        }
        public ICommand UsersCommand
        {
            get
            {
                if(_userCommand == null)
                {
                    _userCommand = new RelayCommand(UsersInterface);
                }
                return _userCommand;
            }
        }
        public ICommand ProductsCommand
        {
            get
            {
                if(_productCommand == null)
                    _productCommand = new RelayCommand(ProductsInterface);
                return _productCommand;
            }
        }
        public ICommand StocksCommand
        {
            get
            {
                if(_stockCommand == null)
                    _stockCommand = new RelayCommand(StocksInterface);
                return _stockCommand;
            }
        }
        public ICommand MoreOptionsCommand
        {
            get
            {
                if(_moreOptionsCommand == null)
                    _moreOptionsCommand = new RelayCommand(MoreOptionsInterface);
                return _moreOptionsCommand;
            }
        }
        #endregion

    }
}

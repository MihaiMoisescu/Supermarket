using Supermarket.Helper;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CasherVM
    {
        private ICommand _searchCommand;
        private ICommand _makeReceiptCommand;

        public void SearchInterface(object obj)
        {
            FindProductCasherView findProductCasherView = new FindProductCasherView();
            findProductCasherView.ShowDialog();
        }
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(SearchInterface);
                return _searchCommand;
            }
        }
        public void MakeReceiptInterface(object obj)
        {
            MakeReceiptCasherView makeReceiptCasherView = new MakeReceiptCasherView();
            makeReceiptCasherView.ShowDialog();
        }
        public ICommand MakeReceiptCommand
        {
            get
            {
                if (_makeReceiptCommand == null)
                    _makeReceiptCommand = new RelayCommand(MakeReceiptInterface);
                return _makeReceiptCommand ;
            }
        }
    }
}

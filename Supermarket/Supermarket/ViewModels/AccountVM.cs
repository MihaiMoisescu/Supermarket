using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class AccountVM
    {
        private AccountBLL _accountBLL;

        public AccountVM()
        {
            _accountBLL = new AccountBLL(new SupermarketDBEntities());
            AccountList = _accountBLL.GetAllAccounts();
        }


        public ObservableCollection<Account> AccountList
        {
            get => _accountBLL.AccountsList;
            set => _accountBLL.AccountsList = value;
        }



        #region Commands
        private ICommand updateAccount;

        public ICommand UpdateAccount
        {
            get
            {
                if(updateAccount == null)
                {
                    updateAccount = new RelayCommand(_accountBLL.ModifyPerson);
                }    
                return updateAccount;
            }
        }

        #endregion
    }
}

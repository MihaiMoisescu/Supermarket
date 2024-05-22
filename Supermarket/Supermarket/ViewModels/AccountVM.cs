using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class AccountVM :BasePropertyChanged
    {
        private AccountBLL _accountBLL;
        public AccountVM()
        {
            _accountBLL = new AccountBLL();
            AccountList = _accountBLL.GetAllAccounts();
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ObservableCollection<Account> AccountList
        {
            get => _accountBLL.AccountsList;
            set
            {
                _accountBLL.AccountsList = value;
                NotifyPropertyChanged(nameof(AccountList));
            }
        }

        #region Commands
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ICommand addCommand;

        public void Update(object obj)
        {
            _accountBLL.UpdateAccount(obj);
            ErrorMessage=_accountBLL.ErrorMessage;
        }
        public ICommand UpdateAccount
        {
            get
            {
                if(updateCommand == null)
                {
                    updateCommand = new RelayCommand(Update);
                }    
                return updateCommand;
            }
        }
        public void Delete(object obj)
        {
            _accountBLL.DeleteAccount(obj);
            ErrorMessage=_accountBLL.ErrorMessage;
            AccountList = _accountBLL.GetAllAccounts();

        }
        public ICommand DeleteAccount
        {
            get
            {
                if(deleteCommand == null)
                    deleteCommand=new RelayCommand(Delete);
                return deleteCommand;
            }
        }
        public void Add(object obj)
        {
            _accountBLL.AddAccount(obj);
            ErrorMessage = _accountBLL.ErrorMessage;
        }
        public ICommand AddAccount
        {
            get
            {
                if(addCommand == null)
                {
                    addCommand = new RelayCommand(Add);
                }
                return addCommand;
            }
        }


        #endregion
    }
}

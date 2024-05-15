using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    class RegisterVM :BasePropertyChanged
    {
        AccountBLL _accountBLL;
        private string _username;
        private string _password;
        private string _role;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                NotifyPropertyChanged(nameof(Role));
            }
        }

        public RegisterVM()
        {
            _accountBLL = new AccountBLL(new SupermarketDBEntities());
        }

        private ICommand _createAccount;

        public void Register(object obj)
        {
            if(_accountBLL.CheckUsername(Username)!=null) 
            {
                MessageBox.Show("Username already exists.", "Register", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            {
                _accountBLL.AddMethod(Username, Password, Role);
                MessageBox.Show("Register successfully", "Register", MessageBoxButton.OK, MessageBoxImage.Information);


            }

        }
        public ICommand CreateAcconut
        {
            get
            {
                if (_createAccount == null)
                    _createAccount = new RelayCommand(Register);
                return _createAccount;
            }
        }
    }
}

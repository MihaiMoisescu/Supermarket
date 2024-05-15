using Microsoft.Win32;
using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    internal class LoginVM :BasePropertyChanged
    {
        private AccountBLL _accountBLL;
        private string _username;
        private string _password;

        public LoginVM()
        {
            _accountBLL = new AccountBLL(new SupermarketDBEntities());

        }
        public string Username
        {
            get
            {
                return _username;
            }
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

        #region Commands

        private ICommand createAccount;
        public ICommand CreateAccount
        {
            get
            {
                if (createAccount == null)
                    createAccount = new RelayCommand(ToRegister);
                return createAccount;
            }
        }
        public void ToRegister(object obj)
        {
            RegisterView register = new RegisterView();
            register.ShowDialog();
        }
        private ICommand connect;

        public void Connect(object obj)
        {
            var account = _accountBLL.VerifyUser(Username, Password);
            if (account != null)
            {
                if (account.IsActive == true)
                {
                    if (account.Role == "Administrator")
                    {
                        AdministratorView administrator = new AdministratorView();
                        administrator.ShowDialog();
                    }
                    else if (account.Role == "Casier")
                    {
                        CasherView casher = new CasherView();
                        casher.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Account is inactive.", "Autentification", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
                MessageBox.Show("Username or password inncorect.", "Autentification", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public ICommand Login
        {
            get
            {
                if (connect == null)
                    connect = new RelayCommand(Connect);
                return connect;
            }
        }
        #endregion
    }
}

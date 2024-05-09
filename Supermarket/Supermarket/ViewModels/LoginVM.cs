using Supermarket.DBContext;
using Supermarket.Helper;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class LoginVM :BasePropertyChanged
    {
        private AccountBLL AccountBLL;
        private string _username;
        private string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyPropertyChanged("Username");
            }
        }
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
            Register register= new Register();
            register.ShowDialog();
        }
        private ICommand connect;
        
        public void Connect(object obj)
        {
/*            int ok = 0;
            foreach(var account in accounts)
            {
                if (Username == account.Username)
                    ok = 1;
                
            }
            if(ok==1)
            {
                MessageBox.Show("merge");
            }
            else
            {
                MessageBox.Show("Nu merge");
            }*/
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

    }

}

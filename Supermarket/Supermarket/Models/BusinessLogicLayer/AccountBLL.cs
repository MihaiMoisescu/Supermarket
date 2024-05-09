using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class AccountBLL
    {
        private supermarketDBContext context=new supermarketDBContext();
        public ObservableCollection<Account> AccountsList { get; set; } 
        
        public AccountBLL() 
        {
            AccountsList = new ObservableCollection<Account>();
   
        }
        public ObservableCollection<Account> GetAllAccounts()
        {
    
            var accounts = new ObservableCollection<Account>();
            foreach(var acc in context.Account.ToList())
            {
                accounts.Add(acc);
            }
            return accounts;
        }
        public void AddMethod(object obj)
        {
        }
        public void UpdateMethod(object obj)
        {

        }
        public void DeleteMethod(object obj) { 
        }

    }
}

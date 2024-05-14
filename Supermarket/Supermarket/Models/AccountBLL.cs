using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    internal class AccountBLL
    {
        SupermarketDBEntities context;

        public ObservableCollection<Account> AccountsList { get; set; }

        public AccountBLL(SupermarketDBEntities contextDB)
        {
            context = contextDB;
            AccountsList = GetAllAccounts();
        }
        public ObservableCollection<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            ObservableCollection<Account> result = new ObservableCollection<Account>();

            foreach (Account account in accounts)
            {

                result.Add(account);
            }
            return result;
        }
        public Account VerifyUser(string username, string password)
        {
            return context.Accounts.FirstOrDefault(account => account.Username == username && account.Password == password);
        }
    }
}

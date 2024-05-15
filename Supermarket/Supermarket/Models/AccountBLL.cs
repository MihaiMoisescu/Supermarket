using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
            List<Account> accounts = context.Accounts.ToList();
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
        public Account CheckUsername(string username)
        {
            return context.Accounts.FirstOrDefault(context => context.Username == username);
        }
        public void AddMethod(string username,string password,string role)
        {

            if(username!=null&& password!=null && role!=null)
            {
                Account account=new Account();
                account.Username = username;
                account.Password = password;
                account.Role = role;
                account.IsActive = true;
                context.Accounts.Add(account);
                context.SaveChanges();
                account.AccountID=context.Accounts.Max(a => a.AccountID);
                AccountsList.Add(account);
            }
        }
    }
}

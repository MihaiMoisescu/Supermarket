using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    internal class AccountBLL
    {
        private SupermarketDBEntities context =new SupermarketDBEntities();
        public string ErrorMessage { get; set; }

        public ObservableCollection<Account> AccountsList { get; set; }

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
            }
        }
        public void UpdateAccount(object obj)
        {
            Account acc=obj as Account;
            if(acc==null)
            {
                ErrorMessage = "Trebuie sa selectati o persoana!";
            }
            else
            {
                if (acc.Role != "Administrator" && acc.Role != "Casier")
                {
                    ErrorMessage = "Categorie incorecta.";
                }
                else
                {
                    context.ModifyAccount(acc.AccountID, acc.Username, acc.Password, acc.Role, acc.IsActive);
                    context.SaveChanges();
                    ErrorMessage = "";
                }

            }
        }
        public void AddAccount(object obj)
        {
            Account acc=obj as Account;
            if (acc!=null)
            {
                if (string.IsNullOrEmpty(acc.Username))
                {
                    ErrorMessage = "Numele contului trebuie precizat!";
                }
                else
                if (context.Accounts.FirstOrDefault(account => account.Username == acc.Username) != null)
                {
                    ErrorMessage = "Exista deja o persoana cu acest utilizator!";
                }
                else 
                {
                    if (acc.Role != "Administrator" && acc.Role != "Casier")
                    {
                        ErrorMessage = "Categorie incorecta.";
                    }
                    else
                    {
                        acc.IsActive = true;
                        context.AddAccount(acc.Username, acc.Password, acc.Role, acc.IsActive, new ObjectParameter("accID", acc.AccountID));
                        context.SaveChanges();
                        acc.AccountID = context.Accounts.Max(a => a.AccountID);
                        AccountsList.Add(acc);
                        ErrorMessage = "";
                    }
                }
                
            }
        }
        public void DeleteAccount(object obj)
        {
     
            Account acc=obj as Account;
            if (acc == null)
            {
                ErrorMessage = "Trebuie sa selectati o persoana!";
            }
            else
            {
                acc.IsActive = false;
                context.DeleteAccount(acc.AccountID, acc.IsActive);
                AccountsList.FirstOrDefault(context => context.AccountID == acc.AccountID).IsActive = false;
                context.SaveChanges();
                ErrorMessage = "";
            }
        }
    }
}

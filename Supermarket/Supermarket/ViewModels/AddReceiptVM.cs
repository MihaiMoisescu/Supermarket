using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class AddReceiptVM:BasePropertyChanged
    {
        private decimal? _totalPrice;
        private Product _selectedProduct;
        private int _accountID;
        private int _quantity;
        private ObservableCollection<Account>_casherAccounts;
        private ObservableCollection<Product> _products;
        private ObservableCollection<ReceiptItem> _receiptItems;
        private ICommand _addProductOnReceipt;
        private ICommand _makeReceipt;

        public AddReceiptVM()
        {
            PopulateCollections();
            ReceiptItems = new ObservableCollection<ReceiptItem>();
            TotalPrice = 0;
        }

        public void PopulateCollections()
        {
            using (var context =new SupermarketDBEntities())
            {
                Products=new ObservableCollection<Product>(context.Products.Where(product=>product.IsActive==true).ToList());
                CasherAccounts=new ObservableCollection<Account>(context.Accounts.Where(account =>account.IsActive==true&&account.Role=="Casier").ToList());
            }
        }

        public decimal? TotalPrice {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                NotifyPropertyChanged(nameof(TotalPrice));
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }
        public Product SelectedProduct 
        { 
            get 
            { 
                return _selectedProduct;
            }
            set 
            {
                _selectedProduct = value;
                NotifyPropertyChanged(nameof(SelectedProduct));
            }
        }
        public int AccountID
        {
            get { return _accountID; }
            set
            {
                _accountID = value;
                NotifyPropertyChanged(nameof(AccountID));
            }
        }
        public ObservableCollection<Account> CasherAccounts
        {
            get
            {
                return _casherAccounts;
            }
            set
            {
                _casherAccounts = value;
                NotifyPropertyChanged(nameof(CasherAccounts));
            }
        }
        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {   
                _products = value;
                NotifyPropertyChanged(nameof(Products));
            }
        }
        public ObservableCollection<ReceiptItem>ReceiptItems {
            get 
            {
                return _receiptItems;
            }
            set
            { 
                _receiptItems = value;
                NotifyPropertyChanged(nameof(ReceiptItems));
            }
        }

        public void AddProduct(object obj)
        {
            if(SelectedProduct!=null&& Quantity>0) 
            {
                using(var context =new SupermarketDBEntities())
                {
                    var stock=context.Stocks.FirstOrDefault(st=>st.ProductID==SelectedProduct.ProductID&&st.IsActive==true);
                    if (stock!=null && stock.Quantity>=Quantity)
                    {
                        var ReceiptItem = new ReceiptItem
                        {
                            Product=SelectedProduct,
                            ProductID = SelectedProduct.ProductID,
                            Quantity = Quantity,
                            Subtotal = Quantity * stock.SellingPrice
                        };
                        ReceiptItems.Add(ReceiptItem);
                        TotalPrice += Quantity * stock.SellingPrice;
                    }
                    context.SaveChanges();
                }
            }
        }
        public void AddReceipt(object obj)
        {
            if(AccountID>0&&ReceiptItems!=null)
            {
                using(var context= new SupermarketDBEntities())
                {
                    var Receipt = new Receipt
                    {
                        AccountID = AccountID,
                        Amount = TotalPrice,
                        Date = DateTime.Now

                    };
                    context.Receipts.Add(Receipt);
                    foreach (var item in ReceiptItems)
                    {
                        var ReceiptItem = new ReceiptItem
                        {
                            ProductID = item.ProductID,
                            Quantity = item.Quantity,
                            Subtotal = item.Subtotal,
                            ReceiptID = Receipt.ReceiptID
                        };
                        context.ReceiptItems.Add(ReceiptItem);

                        var stock = context.Stocks.FirstOrDefault(st => st.ProductID == ReceiptItem.ProductID);
                        stock.Quantity -= ReceiptItem.Quantity;
                        if (stock.Quantity == 0)
                            stock.IsActive = false;
                    }
                context.SaveChanges() ;
                }
            }
            else
            {
                MessageBox.Show("Introduceti casierul","Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ReceiptItems.Clear();
            TotalPrice = 0;
        }
        public ICommand AddProductOnReceipt
        {
            get
            {
                if(_addProductOnReceipt==null)
                    _addProductOnReceipt=new RelayCommand(AddProduct);
                return _addProductOnReceipt;
            }
        }
        public ICommand MakeReceipt
        {
            get
            {
                if (_makeReceipt == null)
                    _makeReceipt = new RelayCommand(AddReceipt);
                return _makeReceipt;

            }
        }
        
    }
}

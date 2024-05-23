using Supermarket.Helper;
using Supermarket.Models;
using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class ViewReceiptCasherVM : BasePropertyChanged
    {
        private ReceiptItemsBLL _receiptItemsBLL;
        private string _cahserName;
        private int _receiptID;
        private decimal? _totalPrice;
        private DateTime? _receiptDate;
        private ObservableCollection<Receipt> _receipts;
        private ObservableCollection<ReceiptItem> _receiptItems;
        private ICommand _getCommand;

        public ViewReceiptCasherVM()
        {
            TotalPrice = 0;
            _receiptItemsBLL = new ReceiptItemsBLL();
            ReceiptItems = _receiptItemsBLL.GetReceiptItems(ReceiptID);
            InitialiseReceipts();
        }
        public void InitialiseReceipts()
        {
            using (var context = new SupermarketDBEntities())
            {
                Receipts = new ObservableCollection<Receipt>(context.Receipts.ToList());
            }
        }
        public decimal? TotalPrice
        {
            get
            { return _totalPrice; } 
            set
            {
               _totalPrice = value;
                NotifyPropertyChanged(nameof(TotalPrice));
            }
        }
        public DateTime? ReceiptDate
        {
            get
            {
                return _receiptDate;
            }
            set
            {
                _receiptDate = value;
                NotifyPropertyChanged(nameof(ReceiptDate));
            }
        }
        public string CahserName
        {
            get { return _cahserName; }
            set { _cahserName = value; NotifyPropertyChanged(nameof(CahserName)); }
        }
        public int ReceiptID
        {
            get
            {
                return _receiptID;
            }
            set
            {
                _receiptID = value;
                NotifyPropertyChanged(nameof(ReceiptID));
            }
        }
        public ObservableCollection<ReceiptItem> ReceiptItems
        {
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
        public ObservableCollection<Receipt> Receipts
        {
            get
            {
                return _receipts;
            }
            set
            {
                _receipts = value;
                NotifyPropertyChanged(nameof(ReceiptItems));
            }
        }
        public void GetReceipts(object obj)
        {
            using (var context = new SupermarketDBEntities()) 
            {
                ReceiptItems = _receiptItemsBLL.GetReceiptItems(ReceiptID);
                var receipt =context.Receipts.FirstOrDefault(o=>o.ReceiptID == ReceiptID);
                if (receipt != null)
                {
                    TotalPrice = context.Receipts.FirstOrDefault(rec => rec.ReceiptID == ReceiptID).Amount;
                    ReceiptDate=receipt.Date;
                    CahserName=receipt.Account.Username;
                }
            }
        }
        public ICommand GetCommand
        {
            get
            {
                if (_getCommand == null)
                    _getCommand = new RelayCommand(GetReceipts);
                return _getCommand;
            }
        }
    }
}

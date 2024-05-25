using Supermarket.Helper;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class HighestReceiptVM :BasePropertyChanged
    {
        private ReceiptItemsBLL _receiptItemsBLL;
        private string _cahserName;
        private decimal? _totalPrice;
        private DateTime? _receiptDate;
        private Receipt _receipt;
        private ObservableCollection<ReceiptItem> _receiptItems;
        private ICommand _getCommand;

        public HighestReceiptVM()
        {
            TotalPrice = 0;
            ReceiptDate = DateTime.Now;
            _receiptItemsBLL = new ReceiptItemsBLL();
            _receiptItems = new ObservableCollection<ReceiptItem>();
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
        public Receipt Receipt
        {
            get
            {
                return _receipt;
            }
            set
            {
                _receipt = value;
                NotifyPropertyChanged(nameof(Receipt));
            }
        }
        public void GetReceipts(object obj)
        {
            using (var context = new SupermarketDBEntities())
            {
                if(ReceiptItems!=null)
                {
                    ReceiptItems.Clear();
                    TotalPrice = 0;

                }
                var receipt=context.Receipts.Where(o=>o.Date==_receiptDate).OrderByDescending(o=>o.Amount).FirstOrDefault();
                if (receipt!=null)
                {
                    ReceiptItems=_receiptItemsBLL.GetReceiptItems(receipt.ReceiptID);
                    CahserName=receipt.Account.Username;
                    TotalPrice=receipt.Amount;
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ReceiptItemsBLL
    {
        private SupermarketDBEntities context;
        
        public ReceiptItemsBLL()
        {
            context = new SupermarketDBEntities();
        }
        public ObservableCollection<ReceiptItem> GetReceiptItems(int receiptID)
        {
            var results=context.ReceiptItems.Where(receipt=>receipt.ReceiptID==receiptID).ToList();
            var receipts=new ObservableCollection<ReceiptItem>();
            foreach(var receipt in results)
            {
                receipts.Add(receipt);
            }
            return receipts;
        }

    }
}

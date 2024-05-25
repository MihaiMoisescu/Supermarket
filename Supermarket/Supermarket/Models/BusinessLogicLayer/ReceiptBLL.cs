using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ReceiptBLL
    {
        private SupermarketDBEntities context;

        public ReceiptBLL()
        {
            context = new SupermarketDBEntities();
        }

        public Receipt HighestPriceReceipt(DateTime? date)
        {
            return context.Receipts.Where(o => o.Date == date).OrderByDescending(o=>o.Amount).FirstOrDefault();
        }
    }
}

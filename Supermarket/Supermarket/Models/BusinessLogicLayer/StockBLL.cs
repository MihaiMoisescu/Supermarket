using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class StockBLL
    {
        private supermarketDBContext context = new supermarketDBContext();
        public ObservableCollection<AccountBLL> StockList { get; set; }

        public StockBLL()
        {
            StockList = new ObservableCollection<AccountBLL>();

        }
        public void AddMethod(object obj)
        {

        }
        public void UpdateMethod(object obj)
        {

        }
        public void DeleteMethod(object obj)
        {
        }
    }
}

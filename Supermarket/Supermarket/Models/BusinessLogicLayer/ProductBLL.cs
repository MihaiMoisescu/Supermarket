using Supermarket.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class ProductBLL
    {
        private supermarketDBContext context = new supermarketDBContext();
        public ObservableCollection<AccountBLL> ProductList { get; set; }

        public ProductBLL()
        {
            ProductList = new ObservableCollection<AccountBLL>();

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

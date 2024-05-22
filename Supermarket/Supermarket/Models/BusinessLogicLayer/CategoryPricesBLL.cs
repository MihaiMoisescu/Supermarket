using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class CategoryPricesBLL
    {
        private SupermarketDBEntities context;
        public string totalPrice {  get; set; }
        public CategoryPricesBLL()
        {
            context = new SupermarketDBEntities();
        }
        public void GetCategoryPrices(int categoryID)
        {
            if (!string.IsNullOrEmpty(totalPrice))
                totalPrice = "";
            var results= context.GetCategoryPrices(categoryID).ToList();
            foreach(var item in results)
            {
                totalPrice += item.TotalPrice.ToString();
            }
            if(!string.IsNullOrEmpty(totalPrice))
                totalPrice += "$";
        }
    }
}

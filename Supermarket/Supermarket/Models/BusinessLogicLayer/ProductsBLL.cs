using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    internal class ProductsBLL
    {
        private SupermarketDBEntities context=new SupermarketDBEntities();

        public ObservableCollection<Product> ProductsList { get; set;}


        public ObservableCollection<Product> GetAllProducts()
        {
            var products = context.Products.ToList();

            var results = new ObservableCollection<Product>();
            foreach (var product in products)
            {
                results.Add(product);
            }
            return results;
        }
    }
}

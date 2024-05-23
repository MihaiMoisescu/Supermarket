using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    internal class SearchProductsBLL
    {
        private SupermarketDBEntities context;
        public ObservableCollection<SearchProduct_Result> SearchProducts {  get; set; }
        public SearchProductsBLL()
        {
            context = new SupermarketDBEntities();
            SearchProducts = new ObservableCollection<SearchProduct_Result>();
        }
        public ObservableCollection<SearchProduct_Result> GetSearchResults(string productName, string barcode,string expirationDate, string producerName, string categoryName)
        {
            if (string.IsNullOrEmpty(productName))
                productName = null;
            if (string.IsNullOrEmpty(barcode))
                barcode = null;

            if (string.IsNullOrEmpty(producerName))
                producerName = null; 
            if (string.IsNullOrEmpty(categoryName))
                categoryName = null;
            DateTime? _expirationDate = DateTime.TryParse(expirationDate,out DateTime validDate)?validDate:(DateTime?)null;
            if(SearchProducts.Count!=0)
            {
                SearchProducts.Clear();
            }
            var products=context.SearchProduct(productName,barcode,_expirationDate,producerName,categoryName);
             var searchProducts = new ObservableCollection<SearchProduct_Result>();
            foreach (var product in products)
            {
                searchProducts.Add(product);
            };
            return searchProducts;
        }
    }
}

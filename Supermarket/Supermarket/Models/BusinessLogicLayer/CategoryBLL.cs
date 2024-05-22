using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class CategoryBLL
    {
        private SupermarketDBEntities context;
        public CategoryBLL() { 
            context = new SupermarketDBEntities();
        }

        public ObservableCollection<Category> CategoryList { get; set; }

        public ObservableCollection<Category> GetAllCategories()
        {
            var categories = context.Categories.ToList();

            var results = new ObservableCollection<Category>();
            foreach (var category in categories)
            {
                results.Add(category);
            }
            return results;
        }

    }
}

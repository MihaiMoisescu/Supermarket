using Microsoft.Xaml.Behaviors;
using Supermarket.Models;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Supermarket.Helper
{
    public class UpdateStocksComboboxes : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssociatedObject.SelectedItem != null)
            {
                var selectedProduct = AssociatedObject.SelectedItem as Stock;
                var matchingProduct = (from product in ((StocksVM)AssociatedObject.DataContext).ProductList
                                        where product.Name == selectedProduct.Product.Name
                                        select product).FirstOrDefault();
                var comboBoxProducer = AssociatedObject.FindName("comboboxProduct") as ComboBox;
                if (comboBoxProducer != null)
                {
                    comboBoxProducer.SelectedItem = matchingProduct;
                }
            }
        }
    }
}

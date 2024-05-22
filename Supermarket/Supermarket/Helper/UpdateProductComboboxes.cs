using Microsoft.Xaml.Behaviors;
using Supermarket.Models;
using Supermarket.ViewModels;
using System.Linq;
using System.Windows.Controls;

namespace Supermarket.Helper
{
    public class UpdateProductComboboxes : Behavior<DataGrid>
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
                var selectedProduct = AssociatedObject.SelectedItem as Product;
                var matchingProducer = (from producer in ((ProductsVM)AssociatedObject.DataContext).ProducersList
                                        where producer.Name == selectedProduct.Producer.Name
                                        select producer).FirstOrDefault();
                var matchingCategory = (from category in ((ProductsVM)AssociatedObject.DataContext).CategoryList
                                        where category.Name == selectedProduct.Category.Name
                                        select category).FirstOrDefault();

                var comboBoxProducer = AssociatedObject.FindName("comboboxProducers") as ComboBox;
                if (comboBoxProducer != null)
                {
                    comboBoxProducer.SelectedItem=matchingProducer;
                }

                var comboBoxCategory = AssociatedObject.FindName("comboboxCategory") as ComboBox;
                if (comboBoxCategory != null)
                {
                    comboBoxCategory.SelectedItem = matchingCategory;
                }
            }
        }
    }
}

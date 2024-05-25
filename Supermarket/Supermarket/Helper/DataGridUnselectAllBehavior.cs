using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Supermarket.Helper
{
    public class DataGridUnselectAllBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseDown += OnPreviewMouseDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseDown -= OnPreviewMouseDown;
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null)
                return;

            var hit = dataGrid.InputHitTest(e.GetPosition(dataGrid)) as DependencyObject;
            while (hit != null && hit != dataGrid)
            {
                if (hit is DataGridRow)
                    return;
                hit = VisualTreeHelper.GetParent(hit);
            }
            dataGrid.UnselectAll();
        }
    }
}

using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Supermarket.Helper
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += PasswordBox_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var dataContext = AssociatedObject.DataContext;
            var passwordProperty = dataContext?.GetType().GetProperty("Password");

            if (passwordProperty != null && passwordProperty.PropertyType == typeof(string))
            {
                passwordProperty.SetValue(dataContext, AssociatedObject.Password);
            }
        }
    }
}

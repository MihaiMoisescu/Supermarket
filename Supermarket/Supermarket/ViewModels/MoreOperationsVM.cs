using Supermarket.Helper;
using Supermarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class MoreOperationsVM
    {
        private ICommand _productsOfAProducer;
        private ICommand _sumPrices;
        private ICommand _userEarnings;

        public void ProductsOfAProducer(object obj)
        {
            ProductsOfAProducerView productsOfAProducerView = new ProductsOfAProducerView();
            productsOfAProducerView.ShowDialog();
        }
        public void sumPrices(object obj)
        {
            SumPricesView sumPricesView = new SumPricesView();
            sumPricesView.ShowDialog();
        }
        public void userEarnings(object obj)
        {
            UserEarningsView user=new UserEarningsView();
            user.ShowDialog();
        }

        public ICommand ProductsOfProducer
        {
            get
            {
                if(_productsOfAProducer == null)
                {
                    _productsOfAProducer = new RelayCommand(ProductsOfAProducer);
                }
                return _productsOfAProducer;
            }
        }
        public ICommand SumPrices
        {
            get
            {
                if(_sumPrices == null)
                {
                    _sumPrices = new RelayCommand(sumPrices);
                   
                }
                return _sumPrices;
            }
        }
        public ICommand UserEarnings
        {
            get
            {
                if(_userEarnings == null)
                {
                    _userEarnings=new RelayCommand(userEarnings);
                }
                return _userEarnings;
            }
        }
    }
}

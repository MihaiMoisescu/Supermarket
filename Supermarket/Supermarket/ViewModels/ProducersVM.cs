using Supermarket.Helper;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    internal class ProducersVM :BasePropertyChanged
    {
        private ProducerBLL _producerBLL;
        private string errorMessage;

        public ProducersVM()
        {
            _producerBLL = new ProducerBLL();
            ProducersList = _producerBLL.GetAllProducers();
        }

        public ObservableCollection<Producer> ProducersList
        {
            get => _producerBLL.ProducersList;
            set
            {
                _producerBLL.ProducersList = value;
                NotifyPropertyChanged(nameof(ProducersList));
            }
        }
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        #region Commands
        private ICommand updateCommand;
        private ICommand deleteCommand;
        private ICommand addCommand;

        public void Update(object obj)
        {
            _producerBLL.UpdateProducer(obj);
            ErrorMessage =_producerBLL.ErrorMessage;
        }
        public ICommand UpdateProducer
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(Update);
                }
                return updateCommand;
            }
        }
        public void Delete(object obj)
        {
            _producerBLL.DeleteProducer(obj);
            ErrorMessage = _producerBLL.ErrorMessage;

        }
        public ICommand DeleteProducer
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(Delete);
                return deleteCommand;
            }
        }
        public void Add(object obj)
        {
            _producerBLL.AddProducer(obj);
            ErrorMessage = _producerBLL.ErrorMessage;
        }
        public ICommand AddProducer
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(Add);
                }
                return addCommand;
            }
        }


        #endregion
    }
}

using Supermarket.Models.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace Supermarket.ViewModels
{
    internal class ReceiptItemsVM
    {
        private ReceiptItemsBLL _receiptItemsBLL;

        public ReceiptItemsVM()
        {
            _receiptItemsBLL = new ReceiptItemsBLL();
        }
        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(_receiptItemsBLL.AddMethod);
                }
                return addCommand;
            }
        }
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(_receiptItemsBLL.UpdateMethod);
                return updateCommand;
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(_receiptItemsBLL.DeleteMethod);
                return deleteCommand;
            }
        }
        #endregion

    }
}

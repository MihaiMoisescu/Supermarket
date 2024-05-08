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
    internal class CategoryVM
    {
        private CategoryBLL _categoryBLL;

        public CategoryVM()
        {
            _categoryBLL = new CategoryBLL();
        }
        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(_categoryBLL.AddMethod);
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
                    updateCommand = new RelayCommand(_categoryBLL.UpdateMethod);
                return updateCommand;
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new RelayCommand(_categoryBLL.DeleteMethod);
                return deleteCommand;
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.UI.Common;
using AHDB.Data;

namespace AHDB.UI.ViewModels
{
    public class CreateNewCustomerViewModel : ViewModelBase
    {
        public CreateNewCustomerViewModel()
        {
            this.SaveNewCustomer = new CommandBase<object>(SaveNewCustomerMethod, CanSaveNewCustomer);
        }

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        private CustomerViewModel customer = new CustomerViewModel();
        public CustomerViewModel Customer
        {
            get { return customer; }
            set 
            { 
                customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        #region Commands
        public CommandBase<object> SaveNewCustomer { get; private set; }
        void SaveNewCustomerMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetCustomerManager().CreateNewCustomer(customer.Description, customer.CompanyName);
            RefreshAction();
            CloseAction();
        }
        bool CanSaveNewCustomer(object arg)
        {
            return true;
        }
        #endregion
    }
}
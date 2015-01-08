using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data;
using AHDB.UI.Views;

namespace AHDB.UI.ViewModels
{
    public sealed class CreateNewRepairViewModel : ViewModelBase
    {
        public Action CloseAction { get; set; }
        public Action Refresh { get; set; }

        private ObservableCollection<CustomerViewModel> customers;
        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        private CustomerViewModel selectedCustomer = new CustomerViewModel() { CustomerId = -1 };
        public CustomerViewModel SelectedCustomer
        {
            get { return selectedCustomer; }
            set 
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        private RepairViewModel repair = new RepairViewModel();
        public RepairViewModel Repair
        {
            get { return repair; }
            set 
            {
                repair = value;
                RaisePropertyChanged("NewRepair");
            }
        }

        #region Commands
        public CommandBase<object> SaveNewRepair { get; private set; }
        void SaveNewRepairMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetRepairManager().CreateNewRepair(repair.Description, null, null, null, selectedCustomer.CustomerId);
            Refresh();
            CloseAction();
        }
        bool CanSaveNewRepair(object arg)
        {
            if (string.IsNullOrEmpty(repair.Description))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion Commands

        #region Methods
        public void GetCustomerList()
        {
            ObservableCollection<CustomerViewModel> customers = new ObservableCollection<CustomerViewModel>();
            FactoryManager myManager = new FactoryManager();
            foreach (var item in myManager.GetCustomerManager().GetAllCustomers())
            {
                customers.Add(
                    new CustomerViewModel() 
                    { 
                        CustomerId = item.ID, 
                        CompanyName = item.CompanyName 
                    });
            }
            this.Customers = customers;
        }
        #endregion Methods

        public CreateNewRepairViewModel()
        {
            GetCustomerList();
            this.SaveNewRepair = new CommandBase<object>(SaveNewRepairMethod, CanSaveNewRepair);
        }
    }
}

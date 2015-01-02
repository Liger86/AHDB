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
        

        private RepairViewModel newRepair = new RepairViewModel();
        public RepairViewModel NewRepair
        {
            get { return newRepair; }
            set 
            {
                newRepair = value;
                RaisePropertyChanged("NewRepair");
            }
        }
        

        #region Commands
        public CommandBase<object> SaveNewRepair { get; private set; }
        void SaveNewRepairMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetRepairManager().CreateNewRepair(newRepair.Description, selectedCustomer.CustomerId);
            
        }
        bool CanSaveNewRepair(object arg)
        {
            if (string.IsNullOrEmpty(newRepair.Description))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public CommandBase<object> CreateNewRepair { get; private set; }
        void CreateNewRepairMethod(object arg)
        {
            CreateNewRepairView myView = new CreateNewRepairView();
            myView.ShowDialog();
        }
        bool CanCreateNewRepair(object arg)
        {
            return true;
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
                        CustomerId = item.Id, 
                        CompanyName = item.CompanyName 
                    });
            }
            this.Customers = customers;
        }
        #endregion Methods

        #region Singleton
        private CreateNewRepairViewModel()
        {
            GetCustomerList();
            this.SaveNewRepair = new CommandBase<object>(SaveNewRepairMethod, CanSaveNewRepair);
            this.CreateNewRepair = new CommandBase<object>(CreateNewRepairMethod, CanCreateNewRepair);
        }

        private static readonly Lazy<CreateNewRepairViewModel> lazy =
            new Lazy<CreateNewRepairViewModel>(() => new CreateNewRepairViewModel());
        public static CreateNewRepairViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}

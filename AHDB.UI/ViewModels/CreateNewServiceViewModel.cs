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
    public sealed class CreateNewServiceViewModel : ViewModelBase
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
        

        private ServiceViewModel newService = new ServiceViewModel();
        public ServiceViewModel NewService
        {
            get { return newService; }
            set 
            {
                newService = value;
                RaisePropertyChanged("NewService");
            }
        }
        

        #region Commands
        public CommandBase<object> SaveNewService { get; private set; }
        void SaveNewServiceMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetServiceManager().CreateNewService(newService.Description, selectedCustomer.CustomerId);
            
        }
        bool CanSaveNewService(object arg)
        {
            if (string.IsNullOrEmpty(newService.Description))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public CommandBase<object> CreateNewService { get; private set; }
        void CreateNewServiceMethod(object arg)
        {
            CreateNewServiceView myView = new CreateNewServiceView();
            myView.ShowDialog();
        }
        bool CanCreateNewService(object arg)
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
        private CreateNewServiceViewModel()
        {
            GetCustomerList();
            this.SaveNewService = new CommandBase<object>(SaveNewServiceMethod, CanSaveNewService);
            this.CreateNewService = new CommandBase<object>(CreateNewServiceMethod, CanCreateNewService);
        }

        private static readonly Lazy<CreateNewServiceViewModel> lazy =
            new Lazy<CreateNewServiceViewModel>(() => new CreateNewServiceViewModel());
        public static CreateNewServiceViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}

using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data;
using System.Windows;
using AHDB.UI.Views;

namespace AHDB.UI.ViewModels
{
    public sealed class ServiceListViewModel : ViewModelBase
    {
        private ObservableCollection<ServiceViewModel> services;
        public ObservableCollection<ServiceViewModel> Services
        {
            get { return services; }
            set
            {
                services = value;
                RaisePropertyChanged("Services");
            }
        }

        private ServiceViewModel selectedService;
        public ServiceViewModel SelectedService
        {
            get { return selectedService; }
            set
            {
                selectedService = value;
                RaisePropertyChanged("SelectedService");
            }
        }

        #region Commands
        // See constructor.
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
        public void Refresh()
        {
            ObservableCollection<ServiceViewModel> services = new ObservableCollection<ServiceViewModel>();
            FactoryManager myManager = new FactoryManager();
            foreach (var item in myManager.GetServiceManager().GetAllServices())
            {
                services.Add(
                    new ServiceViewModel()
                    {
                        ServiceId = item.Id,
                        Description = item.Description,
                        Customer = new CustomerViewModel()
                        {
                            CustomerId = item.Customer.Id,
                            CompanyName = item.Customer.CompanyName
                        }
                    });
            }
            this.Services = services;
        }
        #endregion Methods

        #region Singleton
        private ServiceListViewModel()
        {
            Refresh();
            this.CreateNewService = new CommandBase<object>(CreateNewServiceMethod, CanCreateNewService);
        }

        private static readonly Lazy<ServiceListViewModel> lazy =
            new Lazy<ServiceListViewModel>(() => new ServiceListViewModel());

        public static ServiceListViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}
using AHDB.UI.Common;

namespace AHDB.UI.ViewModels
{
    public class ServiceViewModel : ViewModelBase
    {
        private int serviceId;
        public int ServiceId
        {
            get { return serviceId; }
            set 
            { 
                serviceId = value;
                RaisePropertyChanged("ServiceId");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set 
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        private CustomerViewModel customer;
        public CustomerViewModel Customer
        {
            get { return customer; }
            set 
            { 
                customer = value;
                RaisePropertyChanged("Customer");
            }
        }
    }
}
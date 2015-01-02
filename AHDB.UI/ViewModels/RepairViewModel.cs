using AHDB.UI.Common;

namespace AHDB.UI.ViewModels
{
    public class RepairViewModel : ViewModelBase
    {
        private int repairId;
        public int RepairId
        {
            get { return repairId; }
            set 
            { 
                repairId = value;
                RaisePropertyChanged("RepairId");
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
using AHDB.UI.Common;
using System.Collections.ObjectModel;


namespace AHDB.UI.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set 
            {
                customerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set 
            {
                companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        private ObservableCollection<RepairViewModel> repairs;
        public ObservableCollection<RepairViewModel> Repairs
        {
            get { return repairs; }
            set
            {
                repairs = value;
                RaisePropertyChanged("Repairs");
            }
        }
    }
}
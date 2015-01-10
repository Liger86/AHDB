using AHDB.UI.Common;
using System.Collections.ObjectModel;
using System;


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

        private DateTime dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set 
            {
                dateCreated = value;
                RaisePropertyChanged("DateCreated");
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
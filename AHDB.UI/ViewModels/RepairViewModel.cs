using AHDB.UI.Common;
using System;
using System.Collections.ObjectModel;

namespace AHDB.UI.ViewModels
{
    public class RepairViewModel : ViewModelBase
    {
        private int repairID;
        public int RepairID
        {
            get { return repairID; }
            set 
            { 
                repairID = value;
                RaisePropertyChanged("RepairID");
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

        private string purchaseOrder;
        public string PurchaseOrder
        {
            get { return purchaseOrder; }
            set 
            { 
                purchaseOrder = value;
                RaisePropertyChanged("PurchaseOrder");
            }
        }

        private string quoteNumber;
        public string QuoteNumber
        {
            get { return quoteNumber; }
            set 
            { 
                quoteNumber = value;
                RaisePropertyChanged("QuoteNumber");
            }
        }
        

        private Nullable<bool> completed;
        public Nullable<bool> Completed
        {
            get { return completed; }
            set 
            { 
                completed = value;
                RaisePropertyChanged("Completed");
            }
        }

        private Nullable<DateTime> dateCreated;
        public Nullable<DateTime> DateCreated
        {
            get { return dateCreated; }
            set 
            { 
                dateCreated = value;
                RaisePropertyChanged("DateCreated");
            }
        }

        private Nullable<DateTime> dateCompleted;
        public Nullable<DateTime> DateCompleted
        {
            get { return dateCompleted; }
            set 
            { 
                dateCompleted = value;
                RaisePropertyChanged("DateCompleted");
            }
        }

        private Nullable<DateTime> dueDate;
        public Nullable<DateTime> DueDate
        {
            get { return dueDate; }
            set 
            { 
                dueDate = value;
                RaisePropertyChanged("DueDate");
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

        private ObservableCollection<VendorViewModel> vendors;
        public ObservableCollection<VendorViewModel> Vendors
        {
            get { return vendors; }
            set 
            {
                vendors = value;
                RaisePropertyChanged("Vendor");
            }
        }
    }
}
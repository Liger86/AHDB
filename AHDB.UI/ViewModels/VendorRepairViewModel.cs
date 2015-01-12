using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class VendorRepairViewModel : ViewModelBase
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

        private int vendorID;
        public int VendorID
        {
            get { return vendorID; }
            set 
            { 
                vendorID = value;
                RaisePropertyChanged("VendorID");
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

        private System.DateTime dateCreatedAsUtcTime;
        public System.DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set 
            { 
                dateCreatedAsUtcTime = value;
                RaisePropertyChanged("DateCreatedAsUtcTime");
            }
        }

        private RepairViewModel repair;
        public RepairViewModel Repair
        {
            get { return repair; }
            set 
            { 
                repair = value;
                RaisePropertyChanged("Repair");
            }
        }

        private VendorViewModel vendor;
        public VendorViewModel Vendor
        {
            get { return vendor; }
            set 
            { 
                vendor = value;
                RaisePropertyChanged("Vendor");
            }
        }
    }
}

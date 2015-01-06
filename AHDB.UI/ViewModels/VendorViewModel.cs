using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.UI.Common;

namespace AHDB.UI.ViewModels
{
    public class VendorViewModel : ViewModelBase
    {
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
    }
}
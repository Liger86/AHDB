using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.UI.Common;
using AHDB.Data;

namespace AHDB.UI.ViewModels
{
    public class CreateNewVendorViewModel : ViewModelBase
    {
        public CreateNewVendorViewModel()
        {
            this.SaveNewVendor = new CommandBase<object>(SaveNewVendorMethod, CanSaveNewVendor);
        }

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        private VendorViewModel vendor = new VendorViewModel();
        public VendorViewModel Vendor
        {
            get { return vendor; }
            set 
            { 
                vendor = value;
                RaisePropertyChanged("Vendor");
            }
        }

        #region Commands
        public CommandBase<object> SaveNewVendor { get; set; }
        void SaveNewVendorMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetVendorManager().CreateNewVendor(vendor.Description, vendor.CompanyName);
            RefreshAction();
            CloseAction();
        }
        bool CanSaveNewVendor(object arg)
        {
            return true;
        }
        #endregion
    }
}

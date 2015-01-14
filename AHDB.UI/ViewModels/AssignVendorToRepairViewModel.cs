using AHDB.Data;
using AHDB.DataTransfer;
using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class AssignVendorToRepairViewModel : ViewModelBase
    {
        public AssignVendorToRepairViewModel(RepairViewModel repair)
        {
            this.AssignRepairToVendor = new CommandBase<object>(AssignNewRepairToVendorMethod, CanAssignNewRepairToVendor);
            this.repair = repair;
            RefreshVendorList();
        }

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

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

        private ObservableCollection<VendorViewModel> vendors;
        public ObservableCollection<VendorViewModel> Vendors
        {
            get { return vendors; }
            set 
            { 
                vendors = value;
                RaisePropertyChanged("Vendors");
            }
        }

        private VendorViewModel selectedVendor;
        public VendorViewModel SelectedVendor
        {
            get { return selectedVendor; }
            set 
            { 
                selectedVendor = value;
                RaisePropertyChanged("SelectedVendor");
            }
        }

        #region Methods
        void RefreshVendorList()
        {
            FactoryManager myManager = new FactoryManager();
            var result = myManager.GetVendorManager().GetVendorList();
            List<VendorViewModel> vendorResult = new List<VendorViewModel>();
            foreach (VendorDTO vendor in result)
            {
                vendorResult.Add(new VendorViewModel() { VendorID = vendor.ID, CompanyName = vendor.CompanyName });
            }
            vendors = new ObservableCollection<VendorViewModel>(vendorResult);
        }
        #endregion

        #region Commands
        public CommandBase<object> AssignRepairToVendor { get; set; }
        void AssignNewRepairToVendorMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetVendorRepairManager().AssignVendorToRepair(repair.RepairID, selectedVendor.VendorID);
            RefreshAction();
            CloseAction();
        }
        bool CanAssignNewRepairToVendor(object arg)
        {
            if (selectedVendor == null || selectedVendor.VendorID == 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
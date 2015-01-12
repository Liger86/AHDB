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
using AHDB.DataTransfer;

namespace AHDB.UI.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
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

        private RepairViewModel selectedRepair;
        public RepairViewModel SelectedRepair
        {
            get { return selectedRepair; }
            set
            {
                selectedRepair = value;
                RaisePropertyChanged("SelectedRepair");
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

        #region Commands
        // See constructor.
        public CommandBase<object> CreateNewRepair { get; private set; }
        void CreateNewRepairMethod(object arg)
        {
            CreateNewRepairView myView = new CreateNewRepairView();
            myView.ShowDialog();
        }
        bool CanCreateNewRepair(object arg)
        {
            return true;
        }

        public CommandBase<object> CreateNewCustomer { get; private set; }
        void CreateNewCustomerMethod(object arg)
        {
            CreateNewCustomerView myView = new CreateNewCustomerView();
            myView.ShowDialog();
        }
        bool CanCreateNewCustomer(object arg)
        {
            return true;
        }

        public CommandBase<object> CreateNewVendor { get; private set; }
        void CreateNewVendorMethod(object arg)
        {
            CreateNewVendorView myView = new CreateNewVendorView();
            myView.ShowDialog();
        }
        bool CanCreateNewVendor(object arg)
        {
            return true;
        }
        #endregion Commands

        #region Methods
        public void RefreshRepairs()
        {
            ObservableCollection<RepairViewModel> repairs = new ObservableCollection<RepairViewModel>();
            FactoryManager myManager = new FactoryManager();

            var result = myManager.GetRepairManager().GetAllNotCompletedRepairsAndTheirVendors();

            foreach (RepairDTO repair in result)
            {
                repairs.Add(
                    new RepairViewModel()
                    {
                        RepairID = repair.ID,
                        Description = repair.Description,
                        PurchaseOrder = repair.PurchaseOrder,
                        QuoteNumber = repair.QuoteNumber,
                        Completed = repair.Completed,
                        DateCreated = repair.DateCreatedAsUtcTime,
                        DateCompleted = repair.DateCompleted,
                        DueDate = repair.DueDate,
                        Customer = new CustomerViewModel 
                        {
                            CustomerId = repair.Customer.ID,
                            CompanyName = repair.Customer.CompanyName
                        },
                        VendorRepairs = new ObservableCollection<VendorRepairViewModel>((from vendorRepair in repair.VendorRepairs
                                        select new VendorRepairViewModel
                                        {
                                            VendorID = vendorRepair.VendorID,
                                            RepairID = vendorRepair.RepairID,
                                            Completed = vendorRepair.Completed,
                                            DateCreatedAsUtcTime = vendorRepair.DateCreatedAsUtcTime,
                                            Vendor = new VendorViewModel()
                                            {
                                                VendorID = vendorRepair.Vendor.ID,
                                                CompanyName = vendorRepair.Vendor.CompanyName,
                                            }
                                        }).ToList())
                    });
            }

            this.Repairs = repairs;
        }
        #endregion Methods

        #region Singleton
        private MainWindowViewModel()
        {
            RefreshRepairs();
            this.CreateNewRepair = new CommandBase<object>(CreateNewRepairMethod, CanCreateNewRepair);
            this.CreateNewCustomer = new CommandBase<object>(CreateNewCustomerMethod, CanCreateNewCustomer);
            this.CreateNewVendor = new CommandBase<object>(CreateNewVendorMethod, CanCreateNewVendor);
        }

        private static readonly Lazy<MainWindowViewModel> lazy =
            new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());

        public static MainWindowViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}
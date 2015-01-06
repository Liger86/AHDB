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

namespace AHDB.UI.ViewModels
{
    public sealed class RepairListViewModel : ViewModelBase
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

        #endregion Commands

        #region Methods
        public void Refresh()
        {
            ObservableCollection<RepairViewModel> repairs = new ObservableCollection<RepairViewModel>();
            FactoryManager myManager = new FactoryManager();
            List<Data.Repair> dataReapair = myManager.GetRepairManager().GetAllNotCompletedRepairsAndTheirVendor();
            foreach (var item in dataReapair)
            {
                repairs.Add(
                    new RepairViewModel()
                    {
                        RepairID = item.ID,
                        Description = item.Description,
                        PurchaseOrder = item.PurchaseOrder,
                        Completed = item.Completed,
                        DateCreated = item.DateCreatedAsUtcTime,
                        DateCompleted = item.DateCompleted,
                        DueDate = item.DueDate,
                        Customer = new CustomerViewModel()
                        {
                            CustomerId = item.Customer.ID,
                            Description = item.Customer.Description,
                            CompanyName = item.Customer.CompanyName,
                            DateCreated = item.Customer.DateCreatedAsUtcTime
                        },
                    });
            }
            this.Repairs = repairs;
        }
        #endregion Methods

        #region Singleton
        private RepairListViewModel()
        {
            Refresh();
            this.CreateNewRepair = new CommandBase<object>(CreateNewRepairMethod, CanCreateNewRepair);
        }

        private static readonly Lazy<RepairListViewModel> lazy =
            new Lazy<RepairListViewModel>(() => new RepairListViewModel());

        public static RepairListViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}
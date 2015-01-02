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
            foreach (var item in myManager.GetRepairManager().GetAllRepairs())
            {
                repairs.Add(
                    new RepairViewModel()
                    {
                        RepairId = item.Id,
                        Description = item.Description,
                        Customer = new CustomerViewModel()
                        {
                            CustomerId = item.Customer.Id,
                            CompanyName = item.Customer.CompanyName
                        }
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
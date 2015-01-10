﻿using AHDB.UI.Common;
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
                        }
                    });
            }

            this.Repairs = repairs;
        }
        #endregion Methods

        #region Singleton
        private MainWindowViewModel()
        {
            Refresh();
            this.CreateNewRepair = new CommandBase<object>(CreateNewRepairMethod, CanCreateNewRepair);
        }

        private static readonly Lazy<MainWindowViewModel> lazy =
            new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());

        public static MainWindowViewModel Instance { get { return lazy.Value; } }
        #endregion
    }
}
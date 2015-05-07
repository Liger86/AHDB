using AHDB.UI.Common;
using AHDB.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class MenuUserControlViewModel : ViewModelBase
    {
        public MenuUserControlViewModel()
        {
            this.CreateNewRepair = new CommandBase<object>(CreateNewRepairMethod, CanCreateNewRepair);
            this.CreateNewCustomer = new CommandBase<object>(CreateNewCustomerMethod, CanCreateNewCustomer);
            this.CreateNewVendor = new CommandBase<object>(CreateNewVendorMethod, CanCreateNewVendor);
        }

        public CommandBase<object> CreateNewRepair { get; private set; }
        void CreateNewRepairMethod(object arg)
        {
            CreateNewRepairView myView = new CreateNewRepairView();
            myView.ShowDialog();
        }
        bool CanCreateNewRepair(object arg)
        {
            return false;
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
    }
}
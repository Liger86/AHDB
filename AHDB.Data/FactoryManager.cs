using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;

namespace AHDB.Data
{
    public class FactoryManager
    {
        private IDataManager dataManager;

        public FactoryManager()
        {
            dataManager = new EntityFrameworkManager();
        }

        public IRepairManager GetRepairManager()
        {
            return dataManager.GetRepairManager();
        }

        public ICustomerManager GetCustomerManager()
        {
            return dataManager.GetCustomerManager();
        }

        public IVendorManager GetVendorManager()
        {
            return dataManager.GetVendorManager();
        }

        public IVendorRepairManager GetVendorRepairManager()
        {
            return dataManager.GetVendorRepairManager();
        }

        public INoteManager GetNoteManager()
        {
            return dataManager.GetNoteManager();
        }
    }
}

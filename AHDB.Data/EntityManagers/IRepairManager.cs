using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Data.EntityManagers
{
    public interface IRepairManager
    {
        void CreateNewRepair(string description, int customerId);
        List<Repair> GetAllNotCompletedRepairsAndTheirVendors();
    }
}
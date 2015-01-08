using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.DataTransfer;

namespace AHDB.Data.EntityManagers
{
    public interface IRepairManager
    {
        void CreateNewRepair(string description,
                string purchaseOrder, string quoteNumber, Nullable<DateTime> dueDate, int customerID);
        List<RepairDTO> GetAllNotCompletedRepairsAndTheirVendors();
    }
}
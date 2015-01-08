using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.DataTransfer
{
    public class VendorRepairDTO
    {
        public int RepairID { get; set; }
        public int VendorID { get; set; }
        public Nullable<bool> Completed { get; set; }
        public System.DateTime DateCreatedAsUtcTime { get; set; }

        public RepairDTO Repair { get; set; }
        public VendorDTO Vendor { get; set; }
    }
}
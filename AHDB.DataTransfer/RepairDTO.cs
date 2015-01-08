using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.DataTransfer
{
    public class RepairDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string PurchaseOrder { get; set; }
        public string QuoteNumber { get; set; }
        public Nullable<bool> Completed { get; set; }
        public System.DateTime DateCreatedAsUtcTime { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public int CustomerID { get; set; }

        public CustomerDTO Customer { get; set; }
        public ICollection<NoteDTO> Notes { get; set; }
        public ICollection<VendorRepairDTO> VendorRepairs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.DataTransfer
{
    public class ContactDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }
        public System.DateTime DateCreatedAsUtcTime { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> VendorID { get; set; }

        public CustomerDTO Customer { get; set; }
        public VendorDTO Vendor { get; set; }
    }
}

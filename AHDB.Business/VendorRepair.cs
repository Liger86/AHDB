using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Business
{
    public class VendorRepair
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int vendorId;
        public int VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        private bool completed;
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        private DateTime dateCreatedAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set { dateCreatedAsUtcTime = value; }
        }

        private Repair repair;
        public Repair Repair
        {
            get { return repair; }
            set { repair = value; }
        }

        private Vendor vendor;
        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AHDB.DataTransfer
{
    public class VendorDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public System.DateTime DateCreatedAsUtcTime { get; set; }

        public ICollection<ContactDTO> Contacts { get; set; }
        public ICollection<VendorRepairDTO> VendorRepairs { get; set; }
    }
}

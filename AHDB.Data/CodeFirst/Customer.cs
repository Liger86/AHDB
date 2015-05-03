namespace AHDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Contacts = new HashSet<Contact>();
            Repairs = new HashSet<Repair>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreatedAsUtcTime { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }
    }
}

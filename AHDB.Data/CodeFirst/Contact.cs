namespace AHDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string CellPhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreatedAsUtcTime { get; set; }

        public int? CustomerID { get; set; }

        public int? VendorID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}

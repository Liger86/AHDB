namespace AHDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        public Repair()
        {
            Notes = new HashSet<Note>();
            VendorRepairs = new HashSet<VendorRepair>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string PurchaseOrder { get; set; }

        [StringLength(50)]
        public string QuoteNumber { get; set; }

        public bool? Completed { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreatedAsUtcTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCompleted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DueDate { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<VendorRepair> VendorRepairs { get; set; }
    }
}

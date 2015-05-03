namespace AHDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorRepair")]
    public partial class VendorRepair
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RepairID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VendorID { get; set; }

        public bool? Completed { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreatedAsUtcTime { get; set; }

        public virtual Repair Repair { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}

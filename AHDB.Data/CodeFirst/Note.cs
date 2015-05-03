namespace AHDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        public int ID { get; set; }

        public string NoteText { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreatedAsUtcTime { get; set; }

        public int RepairID { get; set; }

        public virtual Repair Repair { get; set; }
    }
}

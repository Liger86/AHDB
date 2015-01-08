using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.DataTransfer
{
    public class NoteDTO
    {
        public int ID { get; set; }
        public string NoteText { get; set; }
        public System.DateTime DateCreatedAsUtcTime { get; set; }
        public int RepairID { get; set; }

        public RepairDTO Repair { get; set; }
    }
}

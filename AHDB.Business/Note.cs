using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Business
{
    public class Note
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string noteText;
        public string NoteText
        {
            get { return noteText; }
            set { noteText = value; }
        }

        private DateTime dateCreatedAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set { dateCreatedAsUtcTime = value; }
        }

        private int repairId;
        public int RepairId
        {
            get { return repairId; }
            set { repairId = value; }
        }

        private Repair repair;
        public Repair Repair
        {
            get { return repair; }
            set { repair = value; }
        }
    }
}
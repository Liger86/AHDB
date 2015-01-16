using AHDB.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Data.EntityManagers
{
    public interface INoteManager
    {
        List<NoteDTO> GetNotesByRepair(int RepairID);
        void CreateNewNote(string noteText, int repairID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.DataTransfer
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Data.EntityManagers
{
    public interface IServiceManager
    {
        List<Service> GetAllServices();
    }
}

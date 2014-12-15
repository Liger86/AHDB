using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;

namespace AHDB.Data
{
    interface IDataManager
    {
        IServiceManager GetServiceManager();
    }
}

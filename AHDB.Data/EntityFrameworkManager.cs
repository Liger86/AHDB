using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;

namespace AHDB.Data
{
    class EntityFrameworkManager : IDataManager
    {
        public EntityManagers.IServiceManager GetServiceManager()
        {
            return new ServiceManager();
        }

        class ServiceManager : IServiceManager
        {
            public List<Service> GetAllServices()
            {
                List<Service> services = new List<Service>();
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    foreach (var item in myEntities.Services.ToList())
                    {
                        services.Add(
                            new Service() 
                            {
                                Id = item.Id,
                                Description = item.Description, 
                                Customer = item.Customer 
                            });
                    }
                }
                return services;
            }
        }
    }
}
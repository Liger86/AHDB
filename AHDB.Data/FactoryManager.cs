﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;

namespace AHDB.Data
{
    public class FactoryManager
    {
        private IDataManager dataManager;

        public FactoryManager()
        {
            dataManager = new EntityFrameworkManager();
        }

        public IServiceManager GetServiceManager()
        {
            return dataManager.GetServiceManager();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AHDBServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost myHost = new ServiceHost(typeof(AHDBService.AHDBService)))
            {
                myHost.Open();
                Console.WriteLine("Host started @ " + DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
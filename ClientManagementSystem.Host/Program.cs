﻿using ClientManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagementSystem.Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ClientManagementService)))
            {
                host.Open();
                Console.WriteLine("Service is running...");
                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}

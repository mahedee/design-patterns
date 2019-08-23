using System;
using System.Collections.Generic;

namespace DotNetOptimized
{
    /// The 'Singleton' class
    /// Definition: Ensure a class has only one instance and provide a global point of access to it.
    /// Used sealed class so that it cannot be inherited
    public sealed class LoadBalancer
    {

        // Static members are 'eagerly initialized', that is, 
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization
        // Used readonly
        private static readonly LoadBalancer _instance = new LoadBalancer();

        // Type-safe generic list of servers
        private List<Server> _servers = new List<Server>();

        private Random _random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Note: constructor is 'private'
        private LoadBalancer()
        {
            // Load list of available servers
            _servers = new List<Server>
            {
             new Server{ Name = "ServerI", IP = "120.14.220.18" },
             new Server{ Name = "ServerII", IP = "120.14.220.19" },
             new Server{ Name = "ServerIII", IP = "120.14.220.20" },
             new Server{ Name = "ServerIV", IP = "120.14.220.21" },
             new Server{ Name = "ServerV", IP = "120.14.220.22" },
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return _instance;
        }

        // Simple, but effective load balancer
        public Server NextServer
        {
            get

            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }

    /// <summary>
    /// Represents a server machine
    /// </summary>
    public class Server
    {
        // Gets or sets server name
        public string Name { get; set; }

        // Gets or sets server IP address
        public string IP { get; set; }
    }


    // Program startup class for Real-World 
    // Singleton Design Pattern.
    public class Program
    {
        // Entry point into console application.
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Confirm these are the same instance

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Next, load balance 15 requests for a server

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }

            // Wait for user input
            Console.ReadKey();
        }
    }
}

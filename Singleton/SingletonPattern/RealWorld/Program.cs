using System;
using System.Collections.Generic;

namespace RealWorld
{
    /// <summary>
    /// The 'Singleton' class
    /// Definition: Ensure a class has only one instance and provide a global point of access to it.
    /// </summary>
    public class LoadBalancer
    {
        private static LoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor is 'protected'
        // So this class cannot be instantiated
        protected LoadBalancer()
        {
            // List of available servers
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        // Support multithreaded applications through
        // 'Double checked locking' pattern which (once
        // the instance exists) avoids locking each
        // time the method is invoked
        public static LoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock(syncLock)
                {
                    if(_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }

                }
            }

            return _instance;
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }


    // Program startup class for Real-World 
    // Singleton Design Pattern.
    public class Program
    {
        // Entry point into console application.
        static void Main(string[] args)
        {
            // Constructor is protected -- cannot use new
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }


            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user input
            Console.ReadKey();
        }
    }
}

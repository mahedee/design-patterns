using System;

namespace Structural
{

    /// <summary>
    /// The 'Singleton' class
    /// Definition: Ensure a class has only one instance and provide a global point of access to it.
    /// </summary>
    public class Singleton
    {
        private static Singleton _instance;

        // Constructor is 'protected'
        protected Singleton()
        {

        }

        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }


    // Program startup class for Structural
    // Singleton Design Pattern.
    public class Program
    {
        // Entry point into console application.
        static void Main(string[] args)
        {
            // Constructor is protected -- cannot use new
            Singleton singleton1 = Singleton.Instance();
            Singleton singleton2 = Singleton.Instance();

            // Test for same instance
            if (singleton1 == singleton2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            // Wait for user input
            Console.ReadKey();
        }
    }
}

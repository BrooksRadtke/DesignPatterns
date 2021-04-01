using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SingletonPattern
{
    // Example of a 'thread-safe' Singleton
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "{0}\n{1}\n{2}\n",
                "If you see the same value, then singleton was reused (woo!)",
                "If you see different values, then 2 singletons were created (boo!!)",
                "RESULT: "
                );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        public static void TestSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
            Console.ReadLine();
        }
    }

    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        // Lock object that syncronizes threads during first access 
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            // Conditional that prevents threads from interupting lock once ready
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }

            return _instance;
        }

        public string Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface ITarget
    {
        string GetRequest();
    }

    // Contains useful behavior, but incompatible with existing client code
    // Needs to be adapted before client can use it
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific Request.";
        }
    }

    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapater, client can call it's method!");

            Console.WriteLine(target.GetRequest());
            Console.ReadLine();
        }
    }
}

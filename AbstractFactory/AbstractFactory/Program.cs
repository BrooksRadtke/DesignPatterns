using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }

    // Declares a set of methods that return different abstract products.
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    // Concrete Factories produce a family of products that belong to a single variant.
    // Guarentees that results are compatible.
    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of Product A1.";
        }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "The result of Product A2.";
        }
    }

    // Base interface of another product
    public interface IAbstractProductB
    {
        string UsefulFunctionB();
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    class ConcreteProductB1 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the Product B1.";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            return $"The result of B1 collaborating with ({result})";
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string UsefulFunctionB()
        {
            return "The result of the product B2.";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            return $"The result of the B2 collaborating with ({result})";
        }
    }

    class Client
    {
        public void Main()
        {
            // Client code can work with any concrete factory class
            Console.WriteLine("Client: Testing client code with the first factory type: ");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory: ");
            ClientMethod(new ConcreteFactory2());
            Console.ReadLine();
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.UsefulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }
}

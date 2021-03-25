using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Creator
    {
        // Primary responsibilty is not creating products,
        // rather, contains some core business logic that 
        // relies on Product objects
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            // Call the Factory method to create a Product object
            var product = FactoryMethod();
            // Now use product
            var result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }
}

// The Product interface declares the operations that all concrete products must implement
public interface IProduct
{
    string Operation();
}
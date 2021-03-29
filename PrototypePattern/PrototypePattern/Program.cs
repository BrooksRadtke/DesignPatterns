using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "John Jacob Jingle-Heimer Schmitt";
            p1.idInfo = new IdInfo(123);

            // Perform a shallow copy of p1 and assign it to p2
            Person p2 = p1.ShallowCopy();
            // make a deep copy of p1 and assign it to p3
            Person p3 = p1.DeepCopy();

            //Display values of p1, p2, p3
            Console.WriteLine("Original values of p1, p2, p3 : ");
            Console.WriteLine("p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values: ");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values: ");
            DisplayValues(p3);

            // Change te value of p1 properties and display the values of p1, p2, p3
            p1.age = 28;
            p1.BirthDate = Convert.ToDateTime("1001-01-01");
            p1.Name = "Jeb";
            p1.idInfo.IdNumber = 102;

            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1: ");
            Console.WriteLine("p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values: ");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values: ");
            DisplayValues(p3);
            Console.ReadLine();
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine(" Name: {0:s}, Age: {1:d}, Birthdate: {2:MM/dd/yy}",
                p.Name, p.age, p.BirthDate);
            Console.WriteLine(" ID: {0:d}", p.idInfo.IdNumber);
        }
    }

    public class Person
    {
        public int age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo idInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.idInfo = new IdInfo(idInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
}

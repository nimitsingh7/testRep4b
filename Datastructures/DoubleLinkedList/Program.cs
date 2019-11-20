using System;
using DoubleLinkedList.models;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Nimit", "Singh", Geschlecht.männlich, new DateTime(2000,04,20));

            DoubleLinkedList<Person> dll = new DoubleLinkedList<Person>();

            dll.Add(p);
            Console.WriteLine(dll);
            Console.ReadKey();

        }
    }
}
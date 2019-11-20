using System;
using SingleLinkedList.models;

namespace SingleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klasse Person testen
            
            Person p = new Person("ELias", "Rist", new DateTime(2000, 4, 24));
            Person p2 = new Person("Christian", "Hölbling", new DateTime(2000, 4, 24));
            Person p3 = new Person("Tobias", "Flöckinger", new DateTime(2000, 4, 24));
            Person p4 = new Person("Thomas", "Mairer", new DateTime(2000, 4, 24));

            SingleLinkedList<Person> sll = new SingleLinkedList<Person>();

            if (sll.Remove(null))
            {
                Console.WriteLine("Person wurde etnfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Parameter = null");
            }

            if (sll.Remove(p))
            {
                Console.WriteLine("Person wurde etnfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Liste ist leer");
            }

            sll.Add(p);
            sll.Add(p2);
            sll.Add(p3);
            sll.Add(p4);

            sll.Find(p3);
            Console.WriteLine("Hier ist das gewünschte Element: {0}", p3);

            // 1. Fall
            if (sll.Remove(p3))
            {
                Console.WriteLine("Person wurde etnfernt - Eintrag dazwischen wurde entfernt");
            }
            else
            {
                Console.WriteLine("Person wurde nicht entfernt - Eintrag dazwischen");
            }

            Console.WriteLine(sll);

            bool isStartitem;
            SingleLinkedListitem<Person> personBefore = sll.FinditembeforeItemToFind(p3, out isStartitem);
            if (isStartitem)
            {
                Console.WriteLine("Es exisitiert kein Eintrag vor dem gesuchten Eintrag.");
                Console.WriteLine("Die gesuchte Person ist im Starteintrag enthalten!");
            }
            else if (personBefore != null)
            {
                Console.WriteLine("Item vor gesuchter Person existiert.");
                Console.WriteLine("Person vor der gesuchten Person lautet: ");
                Console.WriteLine(personBefore);
            }
            else
            {
                Console.WriteLine("Gesuchte Person ist in der Liste nicht enthalten!");
            }

            // Console.WriteLine(p);
            /*
            if (p == p2)
            {
                Console.WriteLine("p und p2 sind gleich: ==");
            }
            else
            {
                Console.WriteLine("p und p2 sind nicht gleich: ==");
            }

            if (p.Equals(p2))
            {
                Console.WriteLine("p und p2 sind gleich: Equals()");
            }
            else
            {
                Console.WriteLine("p und p2 sind nicht gleich: Equals()");
            }

            if (p == p3)
            {
                Console.WriteLine("p und p3 sind gleich: ==");
            }
            else
            {
                Console.WriteLine("p und p3 sind nicht gleich: ==");
            }

            if (p.Equals(p3))
            {
                Console.WriteLine("p und p3 sind gleich: Equals()");
            }
            else
            {
                Console.WriteLine("p und p3 sind nicht gleich: Equals()");
            }
            Console.ReadKey();
            */

            /*
            // Klasse SingleLinkedListitem testen
            // generische Klasse verwenden
            SingleLinkedListitem<Person> item = new SingleLinkedListitem<Person>(p, null);
            // Console.WriteLine(item);

            // Klasse SLL testen
            // Methode Add() testen
            SingleLinkedList<Person> singlell = new SingleLinkedList<Person>();
            if(singlell.Add(p))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }
            if (singlell.Add(new Person ("Tobias", "Flöckinger", new DateTime(2000, 8, 12))))
            {
                Console.WriteLine("Person wurde hinzugefügt!");
            }
            else
            {
                Console.WriteLine("Person konnte nicht hinzugefügt werden.");
            }
            Console.WriteLine("Komplette SLL ausgeben: ");
            Console.WriteLine(singlell);
            */
            Console.ReadKey();
        }
    }
}
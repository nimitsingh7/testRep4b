using System;
using System.Collections.Generic;
using System.Text;

namespace SingleLinkedList.models
{
    class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        // usw., weitere Felder

        // ctors
        public Person() : this(" ", " ", DateTime.MinValue){}
        public Person(string firstname, string lastname, DateTime birthdate)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Birthdate = birthdate;
        }

        // ToString()
        public override string ToString()
        {
            return this.Firstname + " " + this.Lastname + " " + this.Birthdate.ToLongDateString();
        }

        public override bool Equals(object obj)
        {
            // as versucht obj in den Datentyp Person umzuwandeln, falls das funktioniert
            // folgt eine Istanz von Person wird an die Equals() - Methode übergeben
            // falls es nicht funktioniert => null wird übergeben => es wird keine Exception geworfen
            return Equals(obj as Person);

        }
        public bool Equals(Person obj)
        {
            // Parameter prüfen
            if (obj == null)
            {
                return false;
            }
            if (obj.Firstname == this.Firstname &&
                obj.Lastname == this.Lastname &&
                obj.Birthdate == this.Birthdate)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            // Startwert ist eine Primzahl
            var hashCode = -1786895991;

            // die 2te Zahl ist ebenfalls eine Primzahl
            // es müssen die gleichen Felder (Firstname, Lastname, Birthdate)
            //      wie in Equals() verwendet werden
            hashCode = hashCode * -1521134295 + 
                EqualityComparer<string>.Default.GetHashCode(Firstname);

            hashCode = hashCode * -1521134295 +
                EqualityComparer<string>.Default.GetHashCode(Lastname);

            hashCode = hashCode * -1521134295 +
                EqualityComparer<DateTime>.Default.GetHashCode(Birthdate);

            return hashCode;
        }

    }
}
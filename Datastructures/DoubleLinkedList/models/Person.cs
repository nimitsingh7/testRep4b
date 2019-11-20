using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList.models
{
    enum Geschlecht
    {
        männlich, weiblich, androgynerMensch, bigender, FrauzuMann, intersexuell, notSpecified
    }
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Geschlecht Geschlecht { get; set; }
        public DateTime Geburtstag { get; set; }

        // ctors
        public Person() : this("", "", Geschlecht.notSpecified, DateTime.MinValue) { }
        public Person(string vorname, string nachname, Geschlecht geschlecht, DateTime geburtstag)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geschlecht = geschlecht;
            this.Geburtstag = geburtstag;
        }

        public override string ToString()
        {
            return this.Vorname + "" + this.Nachname + "" + this.Geschlecht + this.Geburtstag.ToLongDateString();
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
            if (obj.Vorname == this.Vorname &&
                obj.Vorname == this.Nachname &&
                obj.Geschlecht == this.Geschlecht &&
                obj.Geburtstag == this.Geburtstag)
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
                EqualityComparer<string>.Default.GetHashCode(Vorname);

            hashCode = hashCode * -1521134295 +
                EqualityComparer<string>.Default.GetHashCode(Nachname);

            hashCode = hashCode * -1521134295 +
                EqualityComparer<Geschlecht>.Default.GetHashCode(Geschlecht);

            hashCode = hashCode * -1521134295 +
                EqualityComparer<DateTime>.Default.GetHashCode(Geburtstag);

            return hashCode;
        }

    }
}
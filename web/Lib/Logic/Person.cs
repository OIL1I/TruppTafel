using System.Text.Json.Serialization;

namespace web.Lib.Logic
{
    [Serializable]
    public class Person : IComparable<Person>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "M.Mustermann";

        [JsonConverter(typeof(JsonNumberEnumConverter<Ausbildungsgrad>))]
        public Ausbildungsgrad Ausbildung { get; set; } = Ausbildungsgrad.Zugfuehrer;

        public Person() { }

        public Person(string name, Ausbildungsgrad ausbildung)
        {
            Name = name;
            Ausbildung = ausbildung;
        }

        public static bool operator <(Person person1, Person person2)
        {
            switch (Global.AktuelleOrdnung)
            {
                case SortierOrdnung.Alphabet:
                    string nachname1 = person1.Name.Split('.')[1];
                    string nachname2 = person2.Name.Split('.')[1];
                    return nachname1.CompareTo(nachname2) < 0;
                case SortierOrdnung.Ausbildung:
                    return person1.Ausbildung < person2.Ausbildung;
                default:
                    return false;
            }
        }
        
        public static bool operator >(Person person1, Person person2)
        {
            switch (Global.AktuelleOrdnung)
            {
                case SortierOrdnung.Alphabet:
                    string nachname1 = person1.Name.Split('.')[1];
                    string nachname2 = person2.Name.Split('.')[1];
                    return nachname1.CompareTo(nachname2) > 0;
                case SortierOrdnung.Ausbildung:
                    return person1.Ausbildung > person2.Ausbildung;
                default:
                    return false;
            }
        }

        public int CompareTo(Person? obj)
        {
            if (obj is not null)
            {
                if (this < obj) return -1;
                else return 1;
            }

            return 0;
        }
    }
}
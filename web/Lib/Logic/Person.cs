using System.Text.Json.Serialization;

namespace web.Lib.Logic
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; } = "M.Mustermann";

        [JsonConverter(typeof(JsonNumberEnumConverter<Ausbildungsgrad>))]
        public Ausbildungsgrad Ausbildung { get; set; } = Ausbildungsgrad.Zugfuehrer;

        public Person() { }

        // optionaler Komfort-Konstruktor (wird NICHT für die Deserialisierung verwendet)
        public Person(string name, Ausbildungsgrad ausbildung)
        {
            Name = name;
            Ausbildung = ausbildung;
        }
    }
}
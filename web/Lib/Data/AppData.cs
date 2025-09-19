using web.Lib.Logic;

namespace web.Lib.Data;

public class AppData
{
    public List<Fahrzeug> Fahrzeuge { get; set; }
    public List<Person> Personen { get; set; }
    
    public AppData()
    {
        Fahrzeuge = new List<Fahrzeug>();
        Personen = new List<Person>();
    }
}
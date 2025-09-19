namespace web.Lib.Logic
{
    public class Fahrzeug
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FahrzeugName { get; set; }
        public Besatzung FahrzeugBesatzung { get; set; }

        public Fahrzeug(string pName, Besatzung pBesatzung)
        {
            FahrzeugName = pName;
            FahrzeugBesatzung = pBesatzung;
        }
    }
}
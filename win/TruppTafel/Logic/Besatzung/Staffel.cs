using TruppTafel.Logic.Interfaces;

namespace TruppTafel.Logic.Besatzung;

public class Staffel : IBesatzung
{
    public string BesatzungName => "Staffel";
    public List<string> BesatzungsPlätze => ["GF", "MA", "AF", "AM", "WF", "WM"];
}
using TruppTafel.Logic.Interfaces;

namespace TruppTafel.Logic.Besatzung;

public class Gruppe : IBesatzung
{
    public string BesatzungName => "Gruppe";
    public List<string> BesatzungsPlätze => ["GF","MA", "ME", "AF", "AM", "WF", "WM", "SF", "SM"];
}
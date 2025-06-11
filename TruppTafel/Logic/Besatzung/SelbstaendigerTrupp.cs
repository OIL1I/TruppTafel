using TruppTafel.Logic.Interfaces;

namespace TruppTafel.Logic.Besatzung;

public class SelbstaendigerTrupp : IBesatzung
{
    public string BesatzungName => "Selbständiger Trupp";
    public List<string> BesatzungsPlätze => ["MA", "TF", "TM"];
}
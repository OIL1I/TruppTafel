using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class GF : Interfaces.IAusbildungsgrad
{
    public string Name => "Gruppenführer";
    public Color Farbe => Color.FromRgb(0, 0, 255);
}
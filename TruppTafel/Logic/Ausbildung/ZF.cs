using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class ZF : Interfaces.IAusbildungsgrad
{
    public string Name => "Zugführer";
    public Color Farbe => Color.FromRgb(255, 0, 0);
}
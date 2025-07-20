using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class AGT : Interfaces.IAusbildungsgrad
{
    public string Name => "Angriffstrupp";
    public Color Farbe => Color.FromRgb(255, 255, 0);
}
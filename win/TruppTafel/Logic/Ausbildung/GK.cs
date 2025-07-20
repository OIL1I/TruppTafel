using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class GK : Interfaces.IAusbildungsgrad
{
    public string Name => "Truppmann 1+2";
    public Color Farbe => Color.FromRgb(0, 160, 0);
}
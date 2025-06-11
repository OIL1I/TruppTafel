using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class TM : Interfaces.IAusbildungsgrad
{
    public string Name => "Truppmann";
    public Color Farbe => Color.FromRgb(115, 115, 115);
}
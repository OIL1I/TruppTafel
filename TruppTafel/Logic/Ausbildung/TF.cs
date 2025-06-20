using System.Windows.Media;

namespace TruppTafel.Logic.Ausbildung;

public class TF : Interfaces.IAusbildungsgrad
{
    public string Name => "Truppführer";
    public Color Farbe => Color.FromRgb(255, 255, 255);
}
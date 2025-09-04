using System.ComponentModel;

namespace web.Lib.Logic
{
    public enum BesatzungsArt
    {
        SelbstaendigerTrupp,
        Staffel,
        Gruppe
    }

    [TypeConverter(typeof(BesatzungsConverter))]
    public class Besatzung{
      
      public static Besatzung GruppenBesatzung = new Besatzung(BesatzungsArt.Gruppe);
      public static Besatzung StaffelBesatzung = new Besatzung(BesatzungsArt.Staffel);
      public static Besatzung STruppBesatzung = new Besatzung(BesatzungsArt.SelbstaendigerTrupp);
      
      public string BesatzungsName { get; set;}
      public string[] BesatzungListe { get; set;}

      public Besatzung()
      {
        BesatzungsName = "Unbekannt";
        BesatzungListe = [];
      }
      
      public Besatzung(BesatzungsArt besatzungsArt){
        switch (besatzungsArt){
          case BesatzungsArt.SelbstaendigerTrupp:
            BesatzungsName = "Selbständiger Trupp";
            BesatzungListe = ["MA", "TF", "TM"];
            break;
          case BesatzungsArt.Staffel:
            BesatzungsName = "Staffel";
            BesatzungListe = ["GF", "MA", "AF", "AM", "WF", "WM"];
            break;
          case BesatzungsArt.Gruppe:
            BesatzungsName = "Gruppe";
            BesatzungListe = ["GF", "MA", "ME", "AF", "AM", "WF", "WM", "SF", "SM"];
            break;
        }
      }

      public override string ToString()
      {
        return BesatzungsName;
      }
    }
}

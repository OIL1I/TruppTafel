using web.Lib.Data;
using web.Lib.Logic;

namespace web;
public static class Global
{
    public static AppData AppData { get; private set; } = new();
    public static SortierOrdnung AktuelleOrdnung { get; set; } = SortierOrdnung.Alphabet;
}
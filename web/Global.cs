using web.Lib.Data;

namespace web;
public static class Global
{
    public static AppData AppData { get; private set; } = new();
}
using System.ComponentModel;
using System.Globalization;

namespace web.Lib.Logic;

public class BesatzungsConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        return destinationType == typeof(string);
    }

    public override Besatzung? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if(value is not string) return null;
        switch ((string)value)
        {
            case "Gruppe":
                return Besatzung.GruppenBesatzung;
            case "Staffel":
                return Besatzung.StaffelBesatzung;
            case "Selbständiger Trupp":
                return Besatzung.STruppBesatzung;
            default:
                return null;
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType != typeof(string)) return null;
        return value?.ToString();
    }
}
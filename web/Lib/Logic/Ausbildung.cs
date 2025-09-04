using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace web.Lib.Logic
{
    [Serializable]
    // [JsonConverter(typeof(JsonNumberEnumConverter<Ausbildungsgrad>))]
    public enum Ausbildungsgrad
    {
        [EnumMember(Value = "0")]
        TM1_2 = 0,
        [EnumMember(Value = "1")]
        Truppmann = 1,
        [EnumMember(Value = "2")]
        AGT = 2,
        [EnumMember(Value = "3")]
        Truppfuehrer = 3,
        [EnumMember(Value = "4")]
        Gruppenfuehrer = 4,
        [EnumMember(Value = "5")]
        Zugfuehrer = 5
    }
}

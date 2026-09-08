using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminFontFamilySerializer))]
public enum AdminFontFamily
{
    [EnumMember(Value = "MODERN_SANS")]
    ModernSans,

    [EnumMember(Value = "BOOK_SANS")]
    BookSans,

    [EnumMember(Value = "ORGANIC_SANS")]
    OrganicSans,

    [EnumMember(Value = "GEOMETRIC_SANS")]
    GeometricSans,

    [EnumMember(Value = "HEAVY_SANS")]
    HeavySans,

    [EnumMember(Value = "ROUNDED_SANS")]
    RoundedSans,

    [EnumMember(Value = "MODERN_SERIF")]
    ModernSerif,

    [EnumMember(Value = "BOOK_SERIF")]
    BookSerif,

    [EnumMember(Value = "MONOSPACE")]
    Monospace,
}

internal class AdminFontFamilySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminFontFamily>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminFontFamily
    > _stringToEnum = new()
    {
        { "MODERN_SANS", AdminFontFamily.ModernSans },
        { "BOOK_SANS", AdminFontFamily.BookSans },
        { "ORGANIC_SANS", AdminFontFamily.OrganicSans },
        { "GEOMETRIC_SANS", AdminFontFamily.GeometricSans },
        { "HEAVY_SANS", AdminFontFamily.HeavySans },
        { "ROUNDED_SANS", AdminFontFamily.RoundedSans },
        { "MODERN_SERIF", AdminFontFamily.ModernSerif },
        { "BOOK_SERIF", AdminFontFamily.BookSerif },
        { "MONOSPACE", AdminFontFamily.Monospace },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminFontFamily,
        string
    > _enumToString = new()
    {
        { AdminFontFamily.ModernSans, "MODERN_SANS" },
        { AdminFontFamily.BookSans, "BOOK_SANS" },
        { AdminFontFamily.OrganicSans, "ORGANIC_SANS" },
        { AdminFontFamily.GeometricSans, "GEOMETRIC_SANS" },
        { AdminFontFamily.HeavySans, "HEAVY_SANS" },
        { AdminFontFamily.RoundedSans, "ROUNDED_SANS" },
        { AdminFontFamily.ModernSerif, "MODERN_SERIF" },
        { AdminFontFamily.BookSerif, "BOOK_SERIF" },
        { AdminFontFamily.Monospace, "MONOSPACE" },
    };

    public override AdminFontFamily Read(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception("The JSON value could not be read as a string.");
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void Write(
        global::System.Text.Json.Utf8JsonWriter writer,
        AdminFontFamily value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminFontFamily ReadAsPropertyName(
        ref global::System.Text.Json.Utf8JsonReader reader,
        global::System.Type typeToConvert,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        var stringValue =
            reader.GetString()
            ?? throw new global::System.Exception(
                "The JSON property name could not be read as a string."
            );
        return _stringToEnum.TryGetValue(stringValue, out var enumValue) ? enumValue : default;
    }

    public override void WriteAsPropertyName(
        global::System.Text.Json.Utf8JsonWriter writer,
        AdminFontFamily value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

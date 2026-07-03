using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsBoostRoundingSerializer))]
public enum AdminPointsBoostRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}

internal class AdminPointsBoostRoundingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsBoostRounding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsBoostRounding
    > _stringToEnum = new()
    {
        { "down", AdminPointsBoostRounding.Down },
        { "up", AdminPointsBoostRounding.Up },
        { "nearest", AdminPointsBoostRounding.Nearest },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsBoostRounding,
        string
    > _enumToString = new()
    {
        { AdminPointsBoostRounding.Down, "down" },
        { AdminPointsBoostRounding.Up, "up" },
        { AdminPointsBoostRounding.Nearest, "nearest" },
    };

    public override AdminPointsBoostRounding Read(
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
        AdminPointsBoostRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsBoostRounding ReadAsPropertyName(
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
        AdminPointsBoostRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

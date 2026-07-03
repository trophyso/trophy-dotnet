using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsBoostRoundingSerializer))]
public enum PointsBoostRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}

internal class PointsBoostRoundingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsBoostRounding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsBoostRounding
    > _stringToEnum = new()
    {
        { "down", PointsBoostRounding.Down },
        { "up", PointsBoostRounding.Up },
        { "nearest", PointsBoostRounding.Nearest },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsBoostRounding,
        string
    > _enumToString = new()
    {
        { PointsBoostRounding.Down, "down" },
        { PointsBoostRounding.Up, "up" },
        { PointsBoostRounding.Nearest, "nearest" },
    };

    public override PointsBoostRounding Read(
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
        PointsBoostRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsBoostRounding ReadAsPropertyName(
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
        PointsBoostRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

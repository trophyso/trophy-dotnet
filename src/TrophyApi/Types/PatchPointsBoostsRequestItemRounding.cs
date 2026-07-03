using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PatchPointsBoostsRequestItemRoundingSerializer))]
public enum PatchPointsBoostsRequestItemRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}

internal class PatchPointsBoostsRequestItemRoundingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PatchPointsBoostsRequestItemRounding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PatchPointsBoostsRequestItemRounding
    > _stringToEnum = new()
    {
        { "down", PatchPointsBoostsRequestItemRounding.Down },
        { "up", PatchPointsBoostsRequestItemRounding.Up },
        { "nearest", PatchPointsBoostsRequestItemRounding.Nearest },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PatchPointsBoostsRequestItemRounding,
        string
    > _enumToString = new()
    {
        { PatchPointsBoostsRequestItemRounding.Down, "down" },
        { PatchPointsBoostsRequestItemRounding.Up, "up" },
        { PatchPointsBoostsRequestItemRounding.Nearest, "nearest" },
    };

    public override PatchPointsBoostsRequestItemRounding Read(
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
        PatchPointsBoostsRequestItemRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PatchPointsBoostsRequestItemRounding ReadAsPropertyName(
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
        PatchPointsBoostsRequestItemRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

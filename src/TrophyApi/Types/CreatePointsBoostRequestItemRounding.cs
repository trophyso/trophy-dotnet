using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreatePointsBoostRequestItemRoundingSerializer))]
public enum CreatePointsBoostRequestItemRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}

internal class CreatePointsBoostRequestItemRoundingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreatePointsBoostRequestItemRounding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreatePointsBoostRequestItemRounding
    > _stringToEnum = new()
    {
        { "down", CreatePointsBoostRequestItemRounding.Down },
        { "up", CreatePointsBoostRequestItemRounding.Up },
        { "nearest", CreatePointsBoostRequestItemRounding.Nearest },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreatePointsBoostRequestItemRounding,
        string
    > _enumToString = new()
    {
        { CreatePointsBoostRequestItemRounding.Down, "down" },
        { CreatePointsBoostRequestItemRounding.Up, "up" },
        { CreatePointsBoostRequestItemRounding.Nearest, "nearest" },
    };

    public override CreatePointsBoostRequestItemRounding Read(
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
        CreatePointsBoostRequestItemRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreatePointsBoostRequestItemRounding ReadAsPropertyName(
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
        CreatePointsBoostRequestItemRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

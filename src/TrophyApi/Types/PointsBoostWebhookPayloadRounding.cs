using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsBoostWebhookPayloadRoundingSerializer))]
public enum PointsBoostWebhookPayloadRounding
{
    [EnumMember(Value = "down")]
    Down,

    [EnumMember(Value = "up")]
    Up,

    [EnumMember(Value = "nearest")]
    Nearest,
}

internal class PointsBoostWebhookPayloadRoundingSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsBoostWebhookPayloadRounding>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsBoostWebhookPayloadRounding
    > _stringToEnum = new()
    {
        { "down", PointsBoostWebhookPayloadRounding.Down },
        { "up", PointsBoostWebhookPayloadRounding.Up },
        { "nearest", PointsBoostWebhookPayloadRounding.Nearest },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsBoostWebhookPayloadRounding,
        string
    > _enumToString = new()
    {
        { PointsBoostWebhookPayloadRounding.Down, "down" },
        { PointsBoostWebhookPayloadRounding.Up, "up" },
        { PointsBoostWebhookPayloadRounding.Nearest, "nearest" },
    };

    public override PointsBoostWebhookPayloadRounding Read(
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
        PointsBoostWebhookPayloadRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsBoostWebhookPayloadRounding ReadAsPropertyName(
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
        PointsBoostWebhookPayloadRounding value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

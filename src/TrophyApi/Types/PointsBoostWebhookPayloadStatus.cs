using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsBoostWebhookPayloadStatusSerializer))]
public enum PointsBoostWebhookPayloadStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class PointsBoostWebhookPayloadStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsBoostWebhookPayloadStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsBoostWebhookPayloadStatus
    > _stringToEnum = new()
    {
        { "active", PointsBoostWebhookPayloadStatus.Active },
        { "finished", PointsBoostWebhookPayloadStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsBoostWebhookPayloadStatus,
        string
    > _enumToString = new()
    {
        { PointsBoostWebhookPayloadStatus.Active, "active" },
        { PointsBoostWebhookPayloadStatus.Finished, "finished" },
    };

    public override PointsBoostWebhookPayloadStatus Read(
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
        PointsBoostWebhookPayloadStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsBoostWebhookPayloadStatus ReadAsPropertyName(
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
        PointsBoostWebhookPayloadStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

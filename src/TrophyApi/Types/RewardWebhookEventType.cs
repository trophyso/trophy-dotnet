using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(RewardWebhookEventTypeSerializer))]
public enum RewardWebhookEventType
{
    [EnumMember(Value = "reward.awarded")]
    RewardAwarded,

    [EnumMember(Value = "reward.redeemed")]
    RewardRedeemed,
}

internal class RewardWebhookEventTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<RewardWebhookEventType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        RewardWebhookEventType
    > _stringToEnum = new()
    {
        { "reward.awarded", RewardWebhookEventType.RewardAwarded },
        { "reward.redeemed", RewardWebhookEventType.RewardRedeemed },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        RewardWebhookEventType,
        string
    > _enumToString = new()
    {
        { RewardWebhookEventType.RewardAwarded, "reward.awarded" },
        { RewardWebhookEventType.RewardRedeemed, "reward.redeemed" },
    };

    public override RewardWebhookEventType Read(
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
        RewardWebhookEventType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override RewardWebhookEventType ReadAsPropertyName(
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
        RewardWebhookEventType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

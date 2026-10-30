using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateRewardTriggerRequestItemTypeSerializer))]
public enum CreateRewardTriggerRequestItemType
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "achievement")]
    Achievement,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "leaderboard")]
    Leaderboard,
}

internal class CreateRewardTriggerRequestItemTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateRewardTriggerRequestItemType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateRewardTriggerRequestItemType
    > _stringToEnum = new()
    {
        { "metric", CreateRewardTriggerRequestItemType.Metric },
        { "achievement", CreateRewardTriggerRequestItemType.Achievement },
        { "streak", CreateRewardTriggerRequestItemType.Streak },
        { "leaderboard", CreateRewardTriggerRequestItemType.Leaderboard },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateRewardTriggerRequestItemType,
        string
    > _enumToString = new()
    {
        { CreateRewardTriggerRequestItemType.Metric, "metric" },
        { CreateRewardTriggerRequestItemType.Achievement, "achievement" },
        { CreateRewardTriggerRequestItemType.Streak, "streak" },
        { CreateRewardTriggerRequestItemType.Leaderboard, "leaderboard" },
    };

    public override CreateRewardTriggerRequestItemType Read(
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
        CreateRewardTriggerRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateRewardTriggerRequestItemType ReadAsPropertyName(
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
        CreateRewardTriggerRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

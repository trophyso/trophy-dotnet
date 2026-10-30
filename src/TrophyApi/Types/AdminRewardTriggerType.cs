using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminRewardTriggerTypeSerializer))]
public enum AdminRewardTriggerType
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

internal class AdminRewardTriggerTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminRewardTriggerType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminRewardTriggerType
    > _stringToEnum = new()
    {
        { "metric", AdminRewardTriggerType.Metric },
        { "achievement", AdminRewardTriggerType.Achievement },
        { "streak", AdminRewardTriggerType.Streak },
        { "leaderboard", AdminRewardTriggerType.Leaderboard },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminRewardTriggerType,
        string
    > _enumToString = new()
    {
        { AdminRewardTriggerType.Metric, "metric" },
        { AdminRewardTriggerType.Achievement, "achievement" },
        { AdminRewardTriggerType.Streak, "streak" },
        { AdminRewardTriggerType.Leaderboard, "leaderboard" },
    };

    public override AdminRewardTriggerType Read(
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
        AdminRewardTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminRewardTriggerType ReadAsPropertyName(
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
        AdminRewardTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

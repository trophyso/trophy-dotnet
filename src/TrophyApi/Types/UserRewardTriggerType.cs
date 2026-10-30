using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UserRewardTriggerTypeSerializer))]
public enum UserRewardTriggerType
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

internal class UserRewardTriggerTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UserRewardTriggerType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UserRewardTriggerType
    > _stringToEnum = new()
    {
        { "metric", UserRewardTriggerType.Metric },
        { "achievement", UserRewardTriggerType.Achievement },
        { "streak", UserRewardTriggerType.Streak },
        { "leaderboard", UserRewardTriggerType.Leaderboard },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UserRewardTriggerType,
        string
    > _enumToString = new()
    {
        { UserRewardTriggerType.Metric, "metric" },
        { UserRewardTriggerType.Achievement, "achievement" },
        { UserRewardTriggerType.Streak, "streak" },
        { UserRewardTriggerType.Leaderboard, "leaderboard" },
    };

    public override UserRewardTriggerType Read(
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
        UserRewardTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UserRewardTriggerType ReadAsPropertyName(
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
        UserRewardTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

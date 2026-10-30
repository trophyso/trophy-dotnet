using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateRewardTriggersRequestItemTypeSerializer))]
public enum UpdateRewardTriggersRequestItemType
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

internal class UpdateRewardTriggersRequestItemTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateRewardTriggersRequestItemType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateRewardTriggersRequestItemType
    > _stringToEnum = new()
    {
        { "metric", UpdateRewardTriggersRequestItemType.Metric },
        { "achievement", UpdateRewardTriggersRequestItemType.Achievement },
        { "streak", UpdateRewardTriggersRequestItemType.Streak },
        { "leaderboard", UpdateRewardTriggersRequestItemType.Leaderboard },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateRewardTriggersRequestItemType,
        string
    > _enumToString = new()
    {
        { UpdateRewardTriggersRequestItemType.Metric, "metric" },
        { UpdateRewardTriggersRequestItemType.Achievement, "achievement" },
        { UpdateRewardTriggersRequestItemType.Streak, "streak" },
        { UpdateRewardTriggersRequestItemType.Leaderboard, "leaderboard" },
    };

    public override UpdateRewardTriggersRequestItemType Read(
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
        UpdateRewardTriggersRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateRewardTriggersRequestItemType ReadAsPropertyName(
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
        UpdateRewardTriggersRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AchievementResponseTriggerSerializer))]
public enum AchievementResponseTrigger
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "api")]
    Api,

    [EnumMember(Value = "achievement")]
    Achievement,
}

internal class AchievementResponseTriggerSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AchievementResponseTrigger>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AchievementResponseTrigger
    > _stringToEnum = new()
    {
        { "metric", AchievementResponseTrigger.Metric },
        { "streak", AchievementResponseTrigger.Streak },
        { "api", AchievementResponseTrigger.Api },
        { "achievement", AchievementResponseTrigger.Achievement },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AchievementResponseTrigger,
        string
    > _enumToString = new()
    {
        { AchievementResponseTrigger.Metric, "metric" },
        { AchievementResponseTrigger.Streak, "streak" },
        { AchievementResponseTrigger.Api, "api" },
        { AchievementResponseTrigger.Achievement, "achievement" },
    };

    public override AchievementResponseTrigger Read(
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
        AchievementResponseTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AchievementResponseTrigger ReadAsPropertyName(
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
        AchievementResponseTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

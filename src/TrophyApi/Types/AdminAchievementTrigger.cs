using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminAchievementTriggerSerializer))]
public enum AdminAchievementTrigger
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "api")]
    Api,

    [EnumMember(Value = "achievement")]
    Achievement,

    [EnumMember(Value = "anniversary")]
    Anniversary,
}

internal class AdminAchievementTriggerSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminAchievementTrigger>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminAchievementTrigger
    > _stringToEnum = new()
    {
        { "metric", AdminAchievementTrigger.Metric },
        { "streak", AdminAchievementTrigger.Streak },
        { "api", AdminAchievementTrigger.Api },
        { "achievement", AdminAchievementTrigger.Achievement },
        { "anniversary", AdminAchievementTrigger.Anniversary },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminAchievementTrigger,
        string
    > _enumToString = new()
    {
        { AdminAchievementTrigger.Metric, "metric" },
        { AdminAchievementTrigger.Streak, "streak" },
        { AdminAchievementTrigger.Api, "api" },
        { AdminAchievementTrigger.Achievement, "achievement" },
        { AdminAchievementTrigger.Anniversary, "anniversary" },
    };

    public override AdminAchievementTrigger Read(
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
        AdminAchievementTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminAchievementTrigger ReadAsPropertyName(
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
        AdminAchievementTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

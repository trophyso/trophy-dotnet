using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateAchievementRequestItemTriggerSerializer))]
public enum UpdateAchievementRequestItemTrigger
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

internal class UpdateAchievementRequestItemTriggerSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateAchievementRequestItemTrigger>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateAchievementRequestItemTrigger
    > _stringToEnum = new()
    {
        { "metric", UpdateAchievementRequestItemTrigger.Metric },
        { "streak", UpdateAchievementRequestItemTrigger.Streak },
        { "api", UpdateAchievementRequestItemTrigger.Api },
        { "achievement", UpdateAchievementRequestItemTrigger.Achievement },
        { "anniversary", UpdateAchievementRequestItemTrigger.Anniversary },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateAchievementRequestItemTrigger,
        string
    > _enumToString = new()
    {
        { UpdateAchievementRequestItemTrigger.Metric, "metric" },
        { UpdateAchievementRequestItemTrigger.Streak, "streak" },
        { UpdateAchievementRequestItemTrigger.Api, "api" },
        { UpdateAchievementRequestItemTrigger.Achievement, "achievement" },
        { UpdateAchievementRequestItemTrigger.Anniversary, "anniversary" },
    };

    public override UpdateAchievementRequestItemTrigger Read(
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
        UpdateAchievementRequestItemTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateAchievementRequestItemTrigger ReadAsPropertyName(
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
        UpdateAchievementRequestItemTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

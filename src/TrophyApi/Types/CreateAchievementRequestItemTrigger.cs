using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateAchievementRequestItemTriggerSerializer))]
public enum CreateAchievementRequestItemTrigger
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

internal class CreateAchievementRequestItemTriggerSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateAchievementRequestItemTrigger>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateAchievementRequestItemTrigger
    > _stringToEnum = new()
    {
        { "metric", CreateAchievementRequestItemTrigger.Metric },
        { "streak", CreateAchievementRequestItemTrigger.Streak },
        { "api", CreateAchievementRequestItemTrigger.Api },
        { "achievement", CreateAchievementRequestItemTrigger.Achievement },
        { "anniversary", CreateAchievementRequestItemTrigger.Anniversary },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateAchievementRequestItemTrigger,
        string
    > _enumToString = new()
    {
        { CreateAchievementRequestItemTrigger.Metric, "metric" },
        { CreateAchievementRequestItemTrigger.Streak, "streak" },
        { CreateAchievementRequestItemTrigger.Api, "api" },
        { CreateAchievementRequestItemTrigger.Achievement, "achievement" },
        { CreateAchievementRequestItemTrigger.Anniversary, "anniversary" },
    };

    public override CreateAchievementRequestItemTrigger Read(
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
        CreateAchievementRequestItemTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateAchievementRequestItemTrigger ReadAsPropertyName(
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
        CreateAchievementRequestItemTrigger value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

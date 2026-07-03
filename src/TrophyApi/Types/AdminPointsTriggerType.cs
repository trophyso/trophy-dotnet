using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsTriggerTypeSerializer))]
public enum AdminPointsTriggerType
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "achievement")]
    Achievement,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "time")]
    Time,

    [EnumMember(Value = "user_creation")]
    UserCreation,
}

internal class AdminPointsTriggerTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsTriggerType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsTriggerType
    > _stringToEnum = new()
    {
        { "metric", AdminPointsTriggerType.Metric },
        { "achievement", AdminPointsTriggerType.Achievement },
        { "streak", AdminPointsTriggerType.Streak },
        { "time", AdminPointsTriggerType.Time },
        { "user_creation", AdminPointsTriggerType.UserCreation },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsTriggerType,
        string
    > _enumToString = new()
    {
        { AdminPointsTriggerType.Metric, "metric" },
        { AdminPointsTriggerType.Achievement, "achievement" },
        { AdminPointsTriggerType.Streak, "streak" },
        { AdminPointsTriggerType.Time, "time" },
        { AdminPointsTriggerType.UserCreation, "user_creation" },
    };

    public override AdminPointsTriggerType Read(
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
        AdminPointsTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsTriggerType ReadAsPropertyName(
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
        AdminPointsTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

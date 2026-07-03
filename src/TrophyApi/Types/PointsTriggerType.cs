using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsTriggerTypeSerializer))]
public enum PointsTriggerType
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

internal class PointsTriggerTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsTriggerType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsTriggerType
    > _stringToEnum = new()
    {
        { "metric", PointsTriggerType.Metric },
        { "achievement", PointsTriggerType.Achievement },
        { "streak", PointsTriggerType.Streak },
        { "time", PointsTriggerType.Time },
        { "user_creation", PointsTriggerType.UserCreation },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsTriggerType,
        string
    > _enumToString = new()
    {
        { PointsTriggerType.Metric, "metric" },
        { PointsTriggerType.Achievement, "achievement" },
        { PointsTriggerType.Streak, "streak" },
        { PointsTriggerType.Time, "time" },
        { PointsTriggerType.UserCreation, "user_creation" },
    };

    public override PointsTriggerType Read(
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
        PointsTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsTriggerType ReadAsPropertyName(
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
        PointsTriggerType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

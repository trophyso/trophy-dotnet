using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PatchPointsTriggersRequestItemTypeSerializer))]
public enum PatchPointsTriggersRequestItemType
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

internal class PatchPointsTriggersRequestItemTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PatchPointsTriggersRequestItemType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PatchPointsTriggersRequestItemType
    > _stringToEnum = new()
    {
        { "metric", PatchPointsTriggersRequestItemType.Metric },
        { "achievement", PatchPointsTriggersRequestItemType.Achievement },
        { "streak", PatchPointsTriggersRequestItemType.Streak },
        { "time", PatchPointsTriggersRequestItemType.Time },
        { "user_creation", PatchPointsTriggersRequestItemType.UserCreation },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PatchPointsTriggersRequestItemType,
        string
    > _enumToString = new()
    {
        { PatchPointsTriggersRequestItemType.Metric, "metric" },
        { PatchPointsTriggersRequestItemType.Achievement, "achievement" },
        { PatchPointsTriggersRequestItemType.Streak, "streak" },
        { PatchPointsTriggersRequestItemType.Time, "time" },
        { PatchPointsTriggersRequestItemType.UserCreation, "user_creation" },
    };

    public override PatchPointsTriggersRequestItemType Read(
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
        PatchPointsTriggersRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PatchPointsTriggersRequestItemType ReadAsPropertyName(
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
        PatchPointsTriggersRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

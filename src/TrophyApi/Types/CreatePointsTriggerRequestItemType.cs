using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreatePointsTriggerRequestItemTypeSerializer))]
public enum CreatePointsTriggerRequestItemType
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

internal class CreatePointsTriggerRequestItemTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreatePointsTriggerRequestItemType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreatePointsTriggerRequestItemType
    > _stringToEnum = new()
    {
        { "metric", CreatePointsTriggerRequestItemType.Metric },
        { "achievement", CreatePointsTriggerRequestItemType.Achievement },
        { "streak", CreatePointsTriggerRequestItemType.Streak },
        { "time", CreatePointsTriggerRequestItemType.Time },
        { "user_creation", CreatePointsTriggerRequestItemType.UserCreation },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreatePointsTriggerRequestItemType,
        string
    > _enumToString = new()
    {
        { CreatePointsTriggerRequestItemType.Metric, "metric" },
        { CreatePointsTriggerRequestItemType.Achievement, "achievement" },
        { CreatePointsTriggerRequestItemType.Streak, "streak" },
        { CreatePointsTriggerRequestItemType.Time, "time" },
        { CreatePointsTriggerRequestItemType.UserCreation, "user_creation" },
    };

    public override CreatePointsTriggerRequestItemType Read(
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
        CreatePointsTriggerRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreatePointsTriggerRequestItemType ReadAsPropertyName(
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
        CreatePointsTriggerRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

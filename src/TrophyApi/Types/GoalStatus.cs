using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(GoalStatusSerializer))]
public enum GoalStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "completed")]
    Completed,

    [EnumMember(Value = "missed")]
    Missed,

    [EnumMember(Value = "ended")]
    Ended,
}

internal class GoalStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GoalStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GoalStatus
    > _stringToEnum = new()
    {
        { "active", GoalStatus.Active },
        { "completed", GoalStatus.Completed },
        { "missed", GoalStatus.Missed },
        { "ended", GoalStatus.Ended },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GoalStatus,
        string
    > _enumToString = new()
    {
        { GoalStatus.Active, "active" },
        { GoalStatus.Completed, "completed" },
        { GoalStatus.Missed, "missed" },
        { GoalStatus.Ended, "ended" },
    };

    public override GoalStatus Read(
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
        GoalStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GoalStatus ReadAsPropertyName(
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
        GoalStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

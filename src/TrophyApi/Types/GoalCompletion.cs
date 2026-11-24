using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(GoalCompletionSerializer))]
public enum GoalCompletion
{
    [EnumMember(Value = "manual")]
    Manual,

    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "metric")]
    Metric,
}

internal class GoalCompletionSerializer
    : global::System.Text.Json.Serialization.JsonConverter<GoalCompletion>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        GoalCompletion
    > _stringToEnum = new()
    {
        { "manual", GoalCompletion.Manual },
        { "none", GoalCompletion.None },
        { "metric", GoalCompletion.Metric },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        GoalCompletion,
        string
    > _enumToString = new()
    {
        { GoalCompletion.Manual, "manual" },
        { GoalCompletion.None, "none" },
        { GoalCompletion.Metric, "metric" },
    };

    public override GoalCompletion Read(
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
        GoalCompletion value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override GoalCompletion ReadAsPropertyName(
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
        GoalCompletion value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(StreakEvaluationModePreferenceSerializer))]
public enum StreakEvaluationModePreference
{
    [EnumMember(Value = "OR")]
    Or,

    [EnumMember(Value = "AND")]
    And,
}

internal class StreakEvaluationModePreferenceSerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreakEvaluationModePreference>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreakEvaluationModePreference
    > _stringToEnum = new()
    {
        { "OR", StreakEvaluationModePreference.Or },
        { "AND", StreakEvaluationModePreference.And },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreakEvaluationModePreference,
        string
    > _enumToString = new()
    {
        { StreakEvaluationModePreference.Or, "OR" },
        { StreakEvaluationModePreference.And, "AND" },
    };

    public override StreakEvaluationModePreference Read(
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
        StreakEvaluationModePreference value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreakEvaluationModePreference ReadAsPropertyName(
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
        StreakEvaluationModePreference value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(StreakFrequencySerializer))]
public enum StreakFrequency
{
    [EnumMember(Value = "daily")]
    Daily,

    [EnumMember(Value = "weekly")]
    Weekly,

    [EnumMember(Value = "monthly")]
    Monthly,
}

internal class StreakFrequencySerializer
    : global::System.Text.Json.Serialization.JsonConverter<StreakFrequency>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        StreakFrequency
    > _stringToEnum = new()
    {
        { "daily", StreakFrequency.Daily },
        { "weekly", StreakFrequency.Weekly },
        { "monthly", StreakFrequency.Monthly },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        StreakFrequency,
        string
    > _enumToString = new()
    {
        { StreakFrequency.Daily, "daily" },
        { StreakFrequency.Weekly, "weekly" },
        { StreakFrequency.Monthly, "monthly" },
    };

    public override StreakFrequency Read(
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
        StreakFrequency value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override StreakFrequency ReadAsPropertyName(
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
        StreakFrequency value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

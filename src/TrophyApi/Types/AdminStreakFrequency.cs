using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminStreakFrequencySerializer))]
public enum AdminStreakFrequency
{
    [EnumMember(Value = "daily")]
    Daily,

    [EnumMember(Value = "weekly")]
    Weekly,

    [EnumMember(Value = "monthly")]
    Monthly,
}

internal class AdminStreakFrequencySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminStreakFrequency>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminStreakFrequency
    > _stringToEnum = new()
    {
        { "daily", AdminStreakFrequency.Daily },
        { "weekly", AdminStreakFrequency.Weekly },
        { "monthly", AdminStreakFrequency.Monthly },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminStreakFrequency,
        string
    > _enumToString = new()
    {
        { AdminStreakFrequency.Daily, "daily" },
        { AdminStreakFrequency.Weekly, "weekly" },
        { AdminStreakFrequency.Monthly, "monthly" },
    };

    public override AdminStreakFrequency Read(
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
        AdminStreakFrequency value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminStreakFrequency ReadAsPropertyName(
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
        AdminStreakFrequency value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

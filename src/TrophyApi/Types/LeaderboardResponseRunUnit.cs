using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(LeaderboardResponseRunUnitSerializer))]
public enum LeaderboardResponseRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}

internal class LeaderboardResponseRunUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<LeaderboardResponseRunUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        LeaderboardResponseRunUnit
    > _stringToEnum = new()
    {
        { "day", LeaderboardResponseRunUnit.Day },
        { "month", LeaderboardResponseRunUnit.Month },
        { "year", LeaderboardResponseRunUnit.Year },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        LeaderboardResponseRunUnit,
        string
    > _enumToString = new()
    {
        { LeaderboardResponseRunUnit.Day, "day" },
        { LeaderboardResponseRunUnit.Month, "month" },
        { LeaderboardResponseRunUnit.Year, "year" },
    };

    public override LeaderboardResponseRunUnit Read(
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
        LeaderboardResponseRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override LeaderboardResponseRunUnit ReadAsPropertyName(
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
        LeaderboardResponseRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

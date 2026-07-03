using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminLeaderboardRunUnitSerializer))]
public enum AdminLeaderboardRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}

internal class AdminLeaderboardRunUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminLeaderboardRunUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminLeaderboardRunUnit
    > _stringToEnum = new()
    {
        { "day", AdminLeaderboardRunUnit.Day },
        { "month", AdminLeaderboardRunUnit.Month },
        { "year", AdminLeaderboardRunUnit.Year },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminLeaderboardRunUnit,
        string
    > _enumToString = new()
    {
        { AdminLeaderboardRunUnit.Day, "day" },
        { AdminLeaderboardRunUnit.Month, "month" },
        { AdminLeaderboardRunUnit.Year, "year" },
    };

    public override AdminLeaderboardRunUnit Read(
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
        AdminLeaderboardRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminLeaderboardRunUnit ReadAsPropertyName(
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
        AdminLeaderboardRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

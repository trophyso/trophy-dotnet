using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateLeaderboardRequestItemRunUnitSerializer))]
public enum UpdateLeaderboardRequestItemRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}

internal class UpdateLeaderboardRequestItemRunUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateLeaderboardRequestItemRunUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateLeaderboardRequestItemRunUnit
    > _stringToEnum = new()
    {
        { "day", UpdateLeaderboardRequestItemRunUnit.Day },
        { "month", UpdateLeaderboardRequestItemRunUnit.Month },
        { "year", UpdateLeaderboardRequestItemRunUnit.Year },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateLeaderboardRequestItemRunUnit,
        string
    > _enumToString = new()
    {
        { UpdateLeaderboardRequestItemRunUnit.Day, "day" },
        { UpdateLeaderboardRequestItemRunUnit.Month, "month" },
        { UpdateLeaderboardRequestItemRunUnit.Year, "year" },
    };

    public override UpdateLeaderboardRequestItemRunUnit Read(
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
        UpdateLeaderboardRequestItemRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateLeaderboardRequestItemRunUnit ReadAsPropertyName(
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
        UpdateLeaderboardRequestItemRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

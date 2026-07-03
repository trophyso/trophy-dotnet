using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateLeaderboardRequestItemRunUnitSerializer))]
public enum CreateLeaderboardRequestItemRunUnit
{
    [EnumMember(Value = "day")]
    Day,

    [EnumMember(Value = "month")]
    Month,

    [EnumMember(Value = "year")]
    Year,
}

internal class CreateLeaderboardRequestItemRunUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateLeaderboardRequestItemRunUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateLeaderboardRequestItemRunUnit
    > _stringToEnum = new()
    {
        { "day", CreateLeaderboardRequestItemRunUnit.Day },
        { "month", CreateLeaderboardRequestItemRunUnit.Month },
        { "year", CreateLeaderboardRequestItemRunUnit.Year },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateLeaderboardRequestItemRunUnit,
        string
    > _enumToString = new()
    {
        { CreateLeaderboardRequestItemRunUnit.Day, "day" },
        { CreateLeaderboardRequestItemRunUnit.Month, "month" },
        { CreateLeaderboardRequestItemRunUnit.Year, "year" },
    };

    public override CreateLeaderboardRequestItemRunUnit Read(
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
        CreateLeaderboardRequestItemRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateLeaderboardRequestItemRunUnit ReadAsPropertyName(
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
        CreateLeaderboardRequestItemRunUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

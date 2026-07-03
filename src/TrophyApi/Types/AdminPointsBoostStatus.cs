using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsBoostStatusSerializer))]
public enum AdminPointsBoostStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class AdminPointsBoostStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsBoostStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsBoostStatus
    > _stringToEnum = new()
    {
        { "active", AdminPointsBoostStatus.Active },
        { "scheduled", AdminPointsBoostStatus.Scheduled },
        { "finished", AdminPointsBoostStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsBoostStatus,
        string
    > _enumToString = new()
    {
        { AdminPointsBoostStatus.Active, "active" },
        { AdminPointsBoostStatus.Scheduled, "scheduled" },
        { AdminPointsBoostStatus.Finished, "finished" },
    };

    public override AdminPointsBoostStatus Read(
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
        AdminPointsBoostStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsBoostStatus ReadAsPropertyName(
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
        AdminPointsBoostStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

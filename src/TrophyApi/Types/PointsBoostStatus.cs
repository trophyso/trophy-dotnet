using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsBoostStatusSerializer))]
public enum PointsBoostStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class PointsBoostStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsBoostStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsBoostStatus
    > _stringToEnum = new()
    {
        { "active", PointsBoostStatus.Active },
        { "scheduled", PointsBoostStatus.Scheduled },
        { "finished", PointsBoostStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsBoostStatus,
        string
    > _enumToString = new()
    {
        { PointsBoostStatus.Active, "active" },
        { PointsBoostStatus.Scheduled, "scheduled" },
        { PointsBoostStatus.Finished, "finished" },
    };

    public override PointsBoostStatus Read(
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
        PointsBoostStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsBoostStatus ReadAsPropertyName(
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
        PointsBoostStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

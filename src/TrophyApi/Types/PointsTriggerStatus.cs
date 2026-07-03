using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsTriggerStatusSerializer))]
public enum PointsTriggerStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "archived")]
    Archived,
}

internal class PointsTriggerStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsTriggerStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsTriggerStatus
    > _stringToEnum = new()
    {
        { "active", PointsTriggerStatus.Active },
        { "inactive", PointsTriggerStatus.Inactive },
        { "archived", PointsTriggerStatus.Archived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsTriggerStatus,
        string
    > _enumToString = new()
    {
        { PointsTriggerStatus.Active, "active" },
        { PointsTriggerStatus.Inactive, "inactive" },
        { PointsTriggerStatus.Archived, "archived" },
    };

    public override PointsTriggerStatus Read(
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
        PointsTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsTriggerStatus ReadAsPropertyName(
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
        PointsTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

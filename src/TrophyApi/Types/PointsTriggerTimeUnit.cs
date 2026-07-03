using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PointsTriggerTimeUnitSerializer))]
public enum PointsTriggerTimeUnit
{
    [EnumMember(Value = "hour")]
    Hour,

    [EnumMember(Value = "day")]
    Day,
}

internal class PointsTriggerTimeUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PointsTriggerTimeUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PointsTriggerTimeUnit
    > _stringToEnum = new()
    {
        { "hour", PointsTriggerTimeUnit.Hour },
        { "day", PointsTriggerTimeUnit.Day },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PointsTriggerTimeUnit,
        string
    > _enumToString = new()
    {
        { PointsTriggerTimeUnit.Hour, "hour" },
        { PointsTriggerTimeUnit.Day, "day" },
    };

    public override PointsTriggerTimeUnit Read(
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
        PointsTriggerTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PointsTriggerTimeUnit ReadAsPropertyName(
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
        PointsTriggerTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

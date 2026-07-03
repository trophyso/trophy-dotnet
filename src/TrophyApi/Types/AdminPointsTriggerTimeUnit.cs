using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsTriggerTimeUnitSerializer))]
public enum AdminPointsTriggerTimeUnit
{
    [EnumMember(Value = "hours")]
    Hours,

    [EnumMember(Value = "days")]
    Days,
}

internal class AdminPointsTriggerTimeUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsTriggerTimeUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsTriggerTimeUnit
    > _stringToEnum = new()
    {
        { "hours", AdminPointsTriggerTimeUnit.Hours },
        { "days", AdminPointsTriggerTimeUnit.Days },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsTriggerTimeUnit,
        string
    > _enumToString = new()
    {
        { AdminPointsTriggerTimeUnit.Hours, "hours" },
        { AdminPointsTriggerTimeUnit.Days, "days" },
    };

    public override AdminPointsTriggerTimeUnit Read(
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
        AdminPointsTriggerTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsTriggerTimeUnit ReadAsPropertyName(
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
        AdminPointsTriggerTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

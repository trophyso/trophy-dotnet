using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminAttributeTypeSerializer))]
public enum AdminAttributeType
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "event")]
    Event,
}

internal class AdminAttributeTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminAttributeType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminAttributeType
    > _stringToEnum = new()
    {
        { "user", AdminAttributeType.User },
        { "event", AdminAttributeType.Event },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminAttributeType,
        string
    > _enumToString = new()
    {
        { AdminAttributeType.User, "user" },
        { AdminAttributeType.Event, "event" },
    };

    public override AdminAttributeType Read(
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
        AdminAttributeType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminAttributeType ReadAsPropertyName(
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
        AdminAttributeType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

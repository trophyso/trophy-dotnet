using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(NotificationChannelSerializer))]
public enum NotificationChannel
{
    [EnumMember(Value = "email")]
    Email,

    [EnumMember(Value = "push")]
    Push,
}

internal class NotificationChannelSerializer
    : global::System.Text.Json.Serialization.JsonConverter<NotificationChannel>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        NotificationChannel
    > _stringToEnum = new()
    {
        { "email", NotificationChannel.Email },
        { "push", NotificationChannel.Push },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        NotificationChannel,
        string
    > _enumToString = new()
    {
        { NotificationChannel.Email, "email" },
        { NotificationChannel.Push, "push" },
    };

    public override NotificationChannel Read(
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
        NotificationChannel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override NotificationChannel ReadAsPropertyName(
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
        NotificationChannel value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

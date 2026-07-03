using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsTriggerStatusSerializer))]
public enum AdminPointsTriggerStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class AdminPointsTriggerStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsTriggerStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsTriggerStatus
    > _stringToEnum = new()
    {
        { "active", AdminPointsTriggerStatus.Active },
        { "inactive", AdminPointsTriggerStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsTriggerStatus,
        string
    > _enumToString = new()
    {
        { AdminPointsTriggerStatus.Active, "active" },
        { AdminPointsTriggerStatus.Inactive, "inactive" },
    };

    public override AdminPointsTriggerStatus Read(
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
        AdminPointsTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsTriggerStatus ReadAsPropertyName(
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
        AdminPointsTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

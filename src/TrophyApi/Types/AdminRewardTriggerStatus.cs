using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminRewardTriggerStatusSerializer))]
public enum AdminRewardTriggerStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class AdminRewardTriggerStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminRewardTriggerStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminRewardTriggerStatus
    > _stringToEnum = new()
    {
        { "active", AdminRewardTriggerStatus.Active },
        { "inactive", AdminRewardTriggerStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminRewardTriggerStatus,
        string
    > _enumToString = new()
    {
        { AdminRewardTriggerStatus.Active, "active" },
        { AdminRewardTriggerStatus.Inactive, "inactive" },
    };

    public override AdminRewardTriggerStatus Read(
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
        AdminRewardTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminRewardTriggerStatus ReadAsPropertyName(
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
        AdminRewardTriggerStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

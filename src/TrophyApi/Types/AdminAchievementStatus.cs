using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminAchievementStatusSerializer))]
public enum AdminAchievementStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "locked")]
    Locked,
}

internal class AdminAchievementStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminAchievementStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminAchievementStatus
    > _stringToEnum = new()
    {
        { "active", AdminAchievementStatus.Active },
        { "inactive", AdminAchievementStatus.Inactive },
        { "locked", AdminAchievementStatus.Locked },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminAchievementStatus,
        string
    > _enumToString = new()
    {
        { AdminAchievementStatus.Active, "active" },
        { AdminAchievementStatus.Inactive, "inactive" },
        { AdminAchievementStatus.Locked, "locked" },
    };

    public override AdminAchievementStatus Read(
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
        AdminAchievementStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminAchievementStatus ReadAsPropertyName(
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
        AdminAchievementStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

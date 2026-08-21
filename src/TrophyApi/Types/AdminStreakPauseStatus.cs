using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminStreakPauseStatusSerializer))]
public enum AdminStreakPauseStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "archived")]
    Archived,
}

internal class AdminStreakPauseStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminStreakPauseStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminStreakPauseStatus
    > _stringToEnum = new()
    {
        { "active", AdminStreakPauseStatus.Active },
        { "archived", AdminStreakPauseStatus.Archived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminStreakPauseStatus,
        string
    > _enumToString = new()
    {
        { AdminStreakPauseStatus.Active, "active" },
        { AdminStreakPauseStatus.Archived, "archived" },
    };

    public override AdminStreakPauseStatus Read(
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
        AdminStreakPauseStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminStreakPauseStatus ReadAsPropertyName(
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
        AdminStreakPauseStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

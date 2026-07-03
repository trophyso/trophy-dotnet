using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminLeaderboardStatusSerializer))]
public enum AdminLeaderboardStatus
{
    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class AdminLeaderboardStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminLeaderboardStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminLeaderboardStatus
    > _stringToEnum = new()
    {
        { "inactive", AdminLeaderboardStatus.Inactive },
        { "active", AdminLeaderboardStatus.Active },
        { "scheduled", AdminLeaderboardStatus.Scheduled },
        { "finished", AdminLeaderboardStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminLeaderboardStatus,
        string
    > _enumToString = new()
    {
        { AdminLeaderboardStatus.Inactive, "inactive" },
        { AdminLeaderboardStatus.Active, "active" },
        { AdminLeaderboardStatus.Scheduled, "scheduled" },
        { AdminLeaderboardStatus.Finished, "finished" },
    };

    public override AdminLeaderboardStatus Read(
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
        AdminLeaderboardStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminLeaderboardStatus ReadAsPropertyName(
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
        AdminLeaderboardStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

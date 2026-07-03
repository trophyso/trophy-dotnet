using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateLeaderboardRequestItemStatusSerializer))]
public enum UpdateLeaderboardRequestItemStatus
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

internal class UpdateLeaderboardRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateLeaderboardRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateLeaderboardRequestItemStatus
    > _stringToEnum = new()
    {
        { "inactive", UpdateLeaderboardRequestItemStatus.Inactive },
        { "active", UpdateLeaderboardRequestItemStatus.Active },
        { "scheduled", UpdateLeaderboardRequestItemStatus.Scheduled },
        { "finished", UpdateLeaderboardRequestItemStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateLeaderboardRequestItemStatus,
        string
    > _enumToString = new()
    {
        { UpdateLeaderboardRequestItemStatus.Inactive, "inactive" },
        { UpdateLeaderboardRequestItemStatus.Active, "active" },
        { UpdateLeaderboardRequestItemStatus.Scheduled, "scheduled" },
        { UpdateLeaderboardRequestItemStatus.Finished, "finished" },
    };

    public override UpdateLeaderboardRequestItemStatus Read(
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
        UpdateLeaderboardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateLeaderboardRequestItemStatus ReadAsPropertyName(
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
        UpdateLeaderboardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

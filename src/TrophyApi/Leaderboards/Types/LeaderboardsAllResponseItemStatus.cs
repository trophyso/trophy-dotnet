using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(LeaderboardsAllResponseItemStatusSerializer))]
public enum LeaderboardsAllResponseItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class LeaderboardsAllResponseItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<LeaderboardsAllResponseItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        LeaderboardsAllResponseItemStatus
    > _stringToEnum = new()
    {
        { "active", LeaderboardsAllResponseItemStatus.Active },
        { "scheduled", LeaderboardsAllResponseItemStatus.Scheduled },
        { "finished", LeaderboardsAllResponseItemStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        LeaderboardsAllResponseItemStatus,
        string
    > _enumToString = new()
    {
        { LeaderboardsAllResponseItemStatus.Active, "active" },
        { LeaderboardsAllResponseItemStatus.Scheduled, "scheduled" },
        { LeaderboardsAllResponseItemStatus.Finished, "finished" },
    };

    public override LeaderboardsAllResponseItemStatus Read(
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
        LeaderboardsAllResponseItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override LeaderboardsAllResponseItemStatus ReadAsPropertyName(
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
        LeaderboardsAllResponseItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

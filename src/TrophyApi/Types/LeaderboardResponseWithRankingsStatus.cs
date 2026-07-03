using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(LeaderboardResponseWithRankingsStatusSerializer))]
public enum LeaderboardResponseWithRankingsStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "scheduled")]
    Scheduled,

    [EnumMember(Value = "finished")]
    Finished,
}

internal class LeaderboardResponseWithRankingsStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<LeaderboardResponseWithRankingsStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        LeaderboardResponseWithRankingsStatus
    > _stringToEnum = new()
    {
        { "active", LeaderboardResponseWithRankingsStatus.Active },
        { "scheduled", LeaderboardResponseWithRankingsStatus.Scheduled },
        { "finished", LeaderboardResponseWithRankingsStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        LeaderboardResponseWithRankingsStatus,
        string
    > _enumToString = new()
    {
        { LeaderboardResponseWithRankingsStatus.Active, "active" },
        { LeaderboardResponseWithRankingsStatus.Scheduled, "scheduled" },
        { LeaderboardResponseWithRankingsStatus.Finished, "finished" },
    };

    public override LeaderboardResponseWithRankingsStatus Read(
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
        LeaderboardResponseWithRankingsStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override LeaderboardResponseWithRankingsStatus ReadAsPropertyName(
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
        LeaderboardResponseWithRankingsStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

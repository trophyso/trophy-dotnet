using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(LeaderboardResponseRankBySerializer))]
public enum LeaderboardResponseRankBy
{
    [EnumMember(Value = "points")]
    Points,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "metric")]
    Metric,
}

internal class LeaderboardResponseRankBySerializer
    : global::System.Text.Json.Serialization.JsonConverter<LeaderboardResponseRankBy>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        LeaderboardResponseRankBy
    > _stringToEnum = new()
    {
        { "points", LeaderboardResponseRankBy.Points },
        { "streak", LeaderboardResponseRankBy.Streak },
        { "metric", LeaderboardResponseRankBy.Metric },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        LeaderboardResponseRankBy,
        string
    > _enumToString = new()
    {
        { LeaderboardResponseRankBy.Points, "points" },
        { LeaderboardResponseRankBy.Streak, "streak" },
        { LeaderboardResponseRankBy.Metric, "metric" },
    };

    public override LeaderboardResponseRankBy Read(
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
        LeaderboardResponseRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override LeaderboardResponseRankBy ReadAsPropertyName(
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
        LeaderboardResponseRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

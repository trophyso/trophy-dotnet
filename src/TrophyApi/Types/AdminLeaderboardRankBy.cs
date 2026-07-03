using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminLeaderboardRankBySerializer))]
public enum AdminLeaderboardRankBy
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "points")]
    Points,
}

internal class AdminLeaderboardRankBySerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminLeaderboardRankBy>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminLeaderboardRankBy
    > _stringToEnum = new()
    {
        { "metric", AdminLeaderboardRankBy.Metric },
        { "streak", AdminLeaderboardRankBy.Streak },
        { "points", AdminLeaderboardRankBy.Points },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminLeaderboardRankBy,
        string
    > _enumToString = new()
    {
        { AdminLeaderboardRankBy.Metric, "metric" },
        { AdminLeaderboardRankBy.Streak, "streak" },
        { AdminLeaderboardRankBy.Points, "points" },
    };

    public override AdminLeaderboardRankBy Read(
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
        AdminLeaderboardRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminLeaderboardRankBy ReadAsPropertyName(
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
        AdminLeaderboardRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

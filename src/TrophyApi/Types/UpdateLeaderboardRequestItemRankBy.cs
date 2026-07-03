using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateLeaderboardRequestItemRankBySerializer))]
public enum UpdateLeaderboardRequestItemRankBy
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "points")]
    Points,
}

internal class UpdateLeaderboardRequestItemRankBySerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateLeaderboardRequestItemRankBy>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateLeaderboardRequestItemRankBy
    > _stringToEnum = new()
    {
        { "metric", UpdateLeaderboardRequestItemRankBy.Metric },
        { "streak", UpdateLeaderboardRequestItemRankBy.Streak },
        { "points", UpdateLeaderboardRequestItemRankBy.Points },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateLeaderboardRequestItemRankBy,
        string
    > _enumToString = new()
    {
        { UpdateLeaderboardRequestItemRankBy.Metric, "metric" },
        { UpdateLeaderboardRequestItemRankBy.Streak, "streak" },
        { UpdateLeaderboardRequestItemRankBy.Points, "points" },
    };

    public override UpdateLeaderboardRequestItemRankBy Read(
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
        UpdateLeaderboardRequestItemRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateLeaderboardRequestItemRankBy ReadAsPropertyName(
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
        UpdateLeaderboardRequestItemRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

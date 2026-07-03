using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateLeaderboardRequestItemRankBySerializer))]
public enum CreateLeaderboardRequestItemRankBy
{
    [EnumMember(Value = "metric")]
    Metric,

    [EnumMember(Value = "streak")]
    Streak,

    [EnumMember(Value = "points")]
    Points,
}

internal class CreateLeaderboardRequestItemRankBySerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateLeaderboardRequestItemRankBy>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateLeaderboardRequestItemRankBy
    > _stringToEnum = new()
    {
        { "metric", CreateLeaderboardRequestItemRankBy.Metric },
        { "streak", CreateLeaderboardRequestItemRankBy.Streak },
        { "points", CreateLeaderboardRequestItemRankBy.Points },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateLeaderboardRequestItemRankBy,
        string
    > _enumToString = new()
    {
        { CreateLeaderboardRequestItemRankBy.Metric, "metric" },
        { CreateLeaderboardRequestItemRankBy.Streak, "streak" },
        { CreateLeaderboardRequestItemRankBy.Points, "points" },
    };

    public override CreateLeaderboardRequestItemRankBy Read(
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
        CreateLeaderboardRequestItemRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateLeaderboardRequestItemRankBy ReadAsPropertyName(
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
        CreateLeaderboardRequestItemRankBy value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateLeaderboardRequestItemStatusSerializer))]
public enum CreateLeaderboardRequestItemStatus
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

internal class CreateLeaderboardRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateLeaderboardRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateLeaderboardRequestItemStatus
    > _stringToEnum = new()
    {
        { "inactive", CreateLeaderboardRequestItemStatus.Inactive },
        { "active", CreateLeaderboardRequestItemStatus.Active },
        { "scheduled", CreateLeaderboardRequestItemStatus.Scheduled },
        { "finished", CreateLeaderboardRequestItemStatus.Finished },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateLeaderboardRequestItemStatus,
        string
    > _enumToString = new()
    {
        { CreateLeaderboardRequestItemStatus.Inactive, "inactive" },
        { CreateLeaderboardRequestItemStatus.Active, "active" },
        { CreateLeaderboardRequestItemStatus.Scheduled, "scheduled" },
        { CreateLeaderboardRequestItemStatus.Finished, "finished" },
    };

    public override CreateLeaderboardRequestItemStatus Read(
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
        CreateLeaderboardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateLeaderboardRequestItemStatus ReadAsPropertyName(
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
        CreateLeaderboardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

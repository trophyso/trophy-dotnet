using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateAchievementRequestItemStatusSerializer))]
public enum UpdateAchievementRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,

    [EnumMember(Value = "locked")]
    Locked,
}

internal class UpdateAchievementRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateAchievementRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateAchievementRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", UpdateAchievementRequestItemStatus.Active },
        { "inactive", UpdateAchievementRequestItemStatus.Inactive },
        { "locked", UpdateAchievementRequestItemStatus.Locked },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateAchievementRequestItemStatus,
        string
    > _enumToString = new()
    {
        { UpdateAchievementRequestItemStatus.Active, "active" },
        { UpdateAchievementRequestItemStatus.Inactive, "inactive" },
        { UpdateAchievementRequestItemStatus.Locked, "locked" },
    };

    public override UpdateAchievementRequestItemStatus Read(
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
        UpdateAchievementRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateAchievementRequestItemStatus ReadAsPropertyName(
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
        UpdateAchievementRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

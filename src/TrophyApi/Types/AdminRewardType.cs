using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminRewardTypeSerializer))]
public enum AdminRewardType
{
    [EnumMember(Value = "points")]
    Points,

    [EnumMember(Value = "custom")]
    Custom,
}

internal class AdminRewardTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminRewardType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminRewardType
    > _stringToEnum = new()
    {
        { "points", AdminRewardType.Points },
        { "custom", AdminRewardType.Custom },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminRewardType,
        string
    > _enumToString = new()
    {
        { AdminRewardType.Points, "points" },
        { AdminRewardType.Custom, "custom" },
    };

    public override AdminRewardType Read(
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
        AdminRewardType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminRewardType ReadAsPropertyName(
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
        AdminRewardType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

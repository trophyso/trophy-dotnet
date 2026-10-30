using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateRewardRequestItemStatusSerializer))]
public enum UpdateRewardRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class UpdateRewardRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateRewardRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateRewardRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", UpdateRewardRequestItemStatus.Active },
        { "inactive", UpdateRewardRequestItemStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateRewardRequestItemStatus,
        string
    > _enumToString = new()
    {
        { UpdateRewardRequestItemStatus.Active, "active" },
        { UpdateRewardRequestItemStatus.Inactive, "inactive" },
    };

    public override UpdateRewardRequestItemStatus Read(
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
        UpdateRewardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateRewardRequestItemStatus ReadAsPropertyName(
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
        UpdateRewardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateRewardRequestItemStatusSerializer))]
public enum CreateRewardRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class CreateRewardRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateRewardRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateRewardRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", CreateRewardRequestItemStatus.Active },
        { "inactive", CreateRewardRequestItemStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateRewardRequestItemStatus,
        string
    > _enumToString = new()
    {
        { CreateRewardRequestItemStatus.Active, "active" },
        { CreateRewardRequestItemStatus.Inactive, "inactive" },
    };

    public override CreateRewardRequestItemStatus Read(
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
        CreateRewardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateRewardRequestItemStatus ReadAsPropertyName(
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
        CreateRewardRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

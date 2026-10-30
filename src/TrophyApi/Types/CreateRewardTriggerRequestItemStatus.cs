using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateRewardTriggerRequestItemStatusSerializer))]
public enum CreateRewardTriggerRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class CreateRewardTriggerRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateRewardTriggerRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateRewardTriggerRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", CreateRewardTriggerRequestItemStatus.Active },
        { "inactive", CreateRewardTriggerRequestItemStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateRewardTriggerRequestItemStatus,
        string
    > _enumToString = new()
    {
        { CreateRewardTriggerRequestItemStatus.Active, "active" },
        { CreateRewardTriggerRequestItemStatus.Inactive, "inactive" },
    };

    public override CreateRewardTriggerRequestItemStatus Read(
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
        CreateRewardTriggerRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateRewardTriggerRequestItemStatus ReadAsPropertyName(
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
        CreateRewardTriggerRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

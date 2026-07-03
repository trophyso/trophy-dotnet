using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreatePointsTriggerRequestItemStatusSerializer))]
public enum CreatePointsTriggerRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class CreatePointsTriggerRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreatePointsTriggerRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreatePointsTriggerRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", CreatePointsTriggerRequestItemStatus.Active },
        { "inactive", CreatePointsTriggerRequestItemStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreatePointsTriggerRequestItemStatus,
        string
    > _enumToString = new()
    {
        { CreatePointsTriggerRequestItemStatus.Active, "active" },
        { CreatePointsTriggerRequestItemStatus.Inactive, "inactive" },
    };

    public override CreatePointsTriggerRequestItemStatus Read(
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
        CreatePointsTriggerRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreatePointsTriggerRequestItemStatus ReadAsPropertyName(
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
        CreatePointsTriggerRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PatchPointsTriggersRequestItemStatusSerializer))]
public enum PatchPointsTriggersRequestItemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "inactive")]
    Inactive,
}

internal class PatchPointsTriggersRequestItemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PatchPointsTriggersRequestItemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PatchPointsTriggersRequestItemStatus
    > _stringToEnum = new()
    {
        { "active", PatchPointsTriggersRequestItemStatus.Active },
        { "inactive", PatchPointsTriggersRequestItemStatus.Inactive },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PatchPointsTriggersRequestItemStatus,
        string
    > _enumToString = new()
    {
        { PatchPointsTriggersRequestItemStatus.Active, "active" },
        { PatchPointsTriggersRequestItemStatus.Inactive, "inactive" },
    };

    public override PatchPointsTriggersRequestItemStatus Read(
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
        PatchPointsTriggersRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PatchPointsTriggersRequestItemStatus ReadAsPropertyName(
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
        PatchPointsTriggersRequestItemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

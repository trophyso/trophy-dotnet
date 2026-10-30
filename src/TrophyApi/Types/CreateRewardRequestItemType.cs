using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateRewardRequestItemTypeSerializer))]
public enum CreateRewardRequestItemType
{
    [EnumMember(Value = "points")]
    Points,

    [EnumMember(Value = "custom")]
    Custom,
}

internal class CreateRewardRequestItemTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateRewardRequestItemType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateRewardRequestItemType
    > _stringToEnum = new()
    {
        { "points", CreateRewardRequestItemType.Points },
        { "custom", CreateRewardRequestItemType.Custom },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateRewardRequestItemType,
        string
    > _enumToString = new()
    {
        { CreateRewardRequestItemType.Points, "points" },
        { CreateRewardRequestItemType.Custom, "custom" },
    };

    public override CreateRewardRequestItemType Read(
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
        CreateRewardRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateRewardRequestItemType ReadAsPropertyName(
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
        CreateRewardRequestItemType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

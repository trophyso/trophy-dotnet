using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(RewardSummaryTypeSerializer))]
public enum RewardSummaryType
{
    [EnumMember(Value = "points")]
    Points,

    [EnumMember(Value = "custom")]
    Custom,
}

internal class RewardSummaryTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<RewardSummaryType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        RewardSummaryType
    > _stringToEnum = new()
    {
        { "points", RewardSummaryType.Points },
        { "custom", RewardSummaryType.Custom },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        RewardSummaryType,
        string
    > _enumToString = new()
    {
        { RewardSummaryType.Points, "points" },
        { RewardSummaryType.Custom, "custom" },
    };

    public override RewardSummaryType Read(
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
        RewardSummaryType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override RewardSummaryType ReadAsPropertyName(
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
        RewardSummaryType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

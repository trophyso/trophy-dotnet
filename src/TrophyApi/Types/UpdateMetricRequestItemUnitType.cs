using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UpdateMetricRequestItemUnitTypeSerializer))]
public enum UpdateMetricRequestItemUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}

internal class UpdateMetricRequestItemUnitTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UpdateMetricRequestItemUnitType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UpdateMetricRequestItemUnitType
    > _stringToEnum = new()
    {
        { "number", UpdateMetricRequestItemUnitType.Number },
        { "currency", UpdateMetricRequestItemUnitType.Currency },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UpdateMetricRequestItemUnitType,
        string
    > _enumToString = new()
    {
        { UpdateMetricRequestItemUnitType.Number, "number" },
        { UpdateMetricRequestItemUnitType.Currency, "currency" },
    };

    public override UpdateMetricRequestItemUnitType Read(
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
        UpdateMetricRequestItemUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UpdateMetricRequestItemUnitType ReadAsPropertyName(
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
        UpdateMetricRequestItemUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

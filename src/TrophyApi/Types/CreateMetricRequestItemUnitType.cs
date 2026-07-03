using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreateMetricRequestItemUnitTypeSerializer))]
public enum CreateMetricRequestItemUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}

internal class CreateMetricRequestItemUnitTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreateMetricRequestItemUnitType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreateMetricRequestItemUnitType
    > _stringToEnum = new()
    {
        { "number", CreateMetricRequestItemUnitType.Number },
        { "currency", CreateMetricRequestItemUnitType.Currency },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreateMetricRequestItemUnitType,
        string
    > _enumToString = new()
    {
        { CreateMetricRequestItemUnitType.Number, "number" },
        { CreateMetricRequestItemUnitType.Currency, "currency" },
    };

    public override CreateMetricRequestItemUnitType Read(
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
        CreateMetricRequestItemUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreateMetricRequestItemUnitType ReadAsPropertyName(
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
        CreateMetricRequestItemUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreatedMetricUnitTypeSerializer))]
public enum CreatedMetricUnitType
{
    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "currency")]
    Currency,
}

internal class CreatedMetricUnitTypeSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreatedMetricUnitType>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreatedMetricUnitType
    > _stringToEnum = new()
    {
        { "number", CreatedMetricUnitType.Number },
        { "currency", CreatedMetricUnitType.Currency },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreatedMetricUnitType,
        string
    > _enumToString = new()
    {
        { CreatedMetricUnitType.Number, "number" },
        { CreatedMetricUnitType.Currency, "currency" },
    };

    public override CreatedMetricUnitType Read(
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
        CreatedMetricUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreatedMetricUnitType ReadAsPropertyName(
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
        CreatedMetricUnitType value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

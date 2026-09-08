using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminAggregationPeriodSerializer))]
public enum AdminAggregationPeriod
{
    [EnumMember(Value = "weekly")]
    Weekly,

    [EnumMember(Value = "monthly")]
    Monthly,
}

internal class AdminAggregationPeriodSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminAggregationPeriod>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminAggregationPeriod
    > _stringToEnum = new()
    {
        { "weekly", AdminAggregationPeriod.Weekly },
        { "monthly", AdminAggregationPeriod.Monthly },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminAggregationPeriod,
        string
    > _enumToString = new()
    {
        { AdminAggregationPeriod.Weekly, "weekly" },
        { AdminAggregationPeriod.Monthly, "monthly" },
    };

    public override AdminAggregationPeriod Read(
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
        AdminAggregationPeriod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminAggregationPeriod ReadAsPropertyName(
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
        AdminAggregationPeriod value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

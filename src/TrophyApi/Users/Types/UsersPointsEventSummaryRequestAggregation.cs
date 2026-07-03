using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(UsersPointsEventSummaryRequestAggregationSerializer))]
public enum UsersPointsEventSummaryRequestAggregation
{
    [EnumMember(Value = "daily")]
    Daily,

    [EnumMember(Value = "weekly")]
    Weekly,

    [EnumMember(Value = "monthly")]
    Monthly,
}

internal class UsersPointsEventSummaryRequestAggregationSerializer
    : global::System.Text.Json.Serialization.JsonConverter<UsersPointsEventSummaryRequestAggregation>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        UsersPointsEventSummaryRequestAggregation
    > _stringToEnum = new()
    {
        { "daily", UsersPointsEventSummaryRequestAggregation.Daily },
        { "weekly", UsersPointsEventSummaryRequestAggregation.Weekly },
        { "monthly", UsersPointsEventSummaryRequestAggregation.Monthly },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        UsersPointsEventSummaryRequestAggregation,
        string
    > _enumToString = new()
    {
        { UsersPointsEventSummaryRequestAggregation.Daily, "daily" },
        { UsersPointsEventSummaryRequestAggregation.Weekly, "weekly" },
        { UsersPointsEventSummaryRequestAggregation.Monthly, "monthly" },
    };

    public override UsersPointsEventSummaryRequestAggregation Read(
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
        UsersPointsEventSummaryRequestAggregation value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override UsersPointsEventSummaryRequestAggregation ReadAsPropertyName(
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
        UsersPointsEventSummaryRequestAggregation value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

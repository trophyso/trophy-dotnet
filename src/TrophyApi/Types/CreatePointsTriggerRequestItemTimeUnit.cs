using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(CreatePointsTriggerRequestItemTimeUnitSerializer))]
public enum CreatePointsTriggerRequestItemTimeUnit
{
    [EnumMember(Value = "hours")]
    Hours,

    [EnumMember(Value = "days")]
    Days,
}

internal class CreatePointsTriggerRequestItemTimeUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<CreatePointsTriggerRequestItemTimeUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        CreatePointsTriggerRequestItemTimeUnit
    > _stringToEnum = new()
    {
        { "hours", CreatePointsTriggerRequestItemTimeUnit.Hours },
        { "days", CreatePointsTriggerRequestItemTimeUnit.Days },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        CreatePointsTriggerRequestItemTimeUnit,
        string
    > _enumToString = new()
    {
        { CreatePointsTriggerRequestItemTimeUnit.Hours, "hours" },
        { CreatePointsTriggerRequestItemTimeUnit.Days, "days" },
    };

    public override CreatePointsTriggerRequestItemTimeUnit Read(
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
        CreatePointsTriggerRequestItemTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override CreatePointsTriggerRequestItemTimeUnit ReadAsPropertyName(
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
        CreatePointsTriggerRequestItemTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

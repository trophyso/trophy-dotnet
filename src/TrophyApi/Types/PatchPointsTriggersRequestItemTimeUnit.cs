using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(PatchPointsTriggersRequestItemTimeUnitSerializer))]
public enum PatchPointsTriggersRequestItemTimeUnit
{
    [EnumMember(Value = "hours")]
    Hours,

    [EnumMember(Value = "days")]
    Days,
}

internal class PatchPointsTriggersRequestItemTimeUnitSerializer
    : global::System.Text.Json.Serialization.JsonConverter<PatchPointsTriggersRequestItemTimeUnit>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        PatchPointsTriggersRequestItemTimeUnit
    > _stringToEnum = new()
    {
        { "hours", PatchPointsTriggersRequestItemTimeUnit.Hours },
        { "days", PatchPointsTriggersRequestItemTimeUnit.Days },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        PatchPointsTriggersRequestItemTimeUnit,
        string
    > _enumToString = new()
    {
        { PatchPointsTriggersRequestItemTimeUnit.Hours, "hours" },
        { PatchPointsTriggersRequestItemTimeUnit.Days, "days" },
    };

    public override PatchPointsTriggersRequestItemTimeUnit Read(
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
        PatchPointsTriggersRequestItemTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override PatchPointsTriggersRequestItemTimeUnit ReadAsPropertyName(
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
        PatchPointsTriggersRequestItemTimeUnit value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}

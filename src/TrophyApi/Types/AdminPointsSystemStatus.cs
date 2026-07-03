using global::System.Runtime.Serialization;
using global::System.Text.Json.Serialization;

namespace TrophyApi;

[JsonConverter(typeof(AdminPointsSystemStatusSerializer))]
public enum AdminPointsSystemStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "archived")]
    Archived,
}

internal class AdminPointsSystemStatusSerializer
    : global::System.Text.Json.Serialization.JsonConverter<AdminPointsSystemStatus>
{
    private static readonly global::System.Collections.Generic.Dictionary<
        string,
        AdminPointsSystemStatus
    > _stringToEnum = new()
    {
        { "active", AdminPointsSystemStatus.Active },
        { "archived", AdminPointsSystemStatus.Archived },
    };

    private static readonly global::System.Collections.Generic.Dictionary<
        AdminPointsSystemStatus,
        string
    > _enumToString = new()
    {
        { AdminPointsSystemStatus.Active, "active" },
        { AdminPointsSystemStatus.Archived, "archived" },
    };

    public override AdminPointsSystemStatus Read(
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
        AdminPointsSystemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WriteStringValue(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : null
        );
    }

    public override AdminPointsSystemStatus ReadAsPropertyName(
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
        AdminPointsSystemStatus value,
        global::System.Text.Json.JsonSerializerOptions options
    )
    {
        writer.WritePropertyName(
            _enumToString.TryGetValue(value, out var stringValue) ? stringValue : value.ToString()
        );
    }
}
